using BebopCommandSet;
using OpenCvSharp;
using SimpleJSON;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ParrotBebop2
{

    public class Bebop : D2CSocket.OnReceiveListener
    {
        public enum BebopState
        {
            Landed = CommandSet.ARCOMMANDS_ARDRONE3_PILOTINGSTATE_FLYINGSTATECHANGED_STATE_LANDED,
            TakingOff = CommandSet.ARCOMMANDS_ARDRONE3_PILOTINGSTATE_FLYINGSTATECHANGED_STATE_TAKINGOFF,
            Hovering = CommandSet.ARCOMMANDS_ARDRONE3_PILOTINGSTATE_FLYINGSTATECHANGED_STATE_HOVERING,
            Flying = CommandSet.ARCOMMANDS_ARDRONE3_PILOTINGSTATE_FLYINGSTATECHANGED_STATE_FLYING,
            Landing = CommandSet.ARCOMMANDS_ARDRONE3_PILOTINGSTATE_FLYINGSTATECHANGED_STATE_LANDING,
            Emergency = CommandSet.ARCOMMANDS_ARDRONE3_PILOTINGSTATE_FLYINGSTATECHANGED_STATE_EMERGENCY,
            Max = CommandSet.ARCOMMANDS_ARDRONE3_PILOTINGSTATE_FLYINGSTATECHANGED_STATE_MAX,
        }

        public interface IBebopListener
        {
            void                OnStreaming(Mat frame);
            PCMD                OnRequestPCMD();
            void                OnStateChanged(Bebop bebop);
            void                OnUpdateGMap(Mat gmap);
        }

        public struct Position
        {
            public double lon, lat, alt;
        }

        private int[] seq = new int[256];
        public PCMD pcmd;

        private Mutex pcmdMtx = new Mutex();

        private UdpClient arstreamClient;
        private IPEndPoint remoteIpEndPoint;

        //private UdpClient c2d_client;

        private static object _thisLock = new object();

        private D2CSocket _d2c;
        private C2DSocket _c2d;
        private Thread _commandThread, _streamingThread, _gmapThread;
        private Mutex _gmapMutex;
        private IBebopListener _listener;

        private short _rssi;
        private uint _state;
        public BebopState State
        {
            get
            {
                return (BebopState)this._state;
            }
            private set
            {
                this._state = (uint)value;
            }
        }
        public double _lat, _lon, _alt;
        public float _speed_x, _speed_y, _speed_z;
        public float _pitch, _yaw, _roll;
        public double _altitude;
        public byte _tilt;
        public byte _pan;

        public bool Connected { get; private set; }
        public byte Battery { get; private set; }
        public Mat GMap { get; private set; }


        public Bebop(IBebopListener listener)
        {
            this._d2c = new D2CSocket(this);
            this._c2d = new C2DSocket();

            this._listener = listener;
        }


        public bool Connect()
        {
            //make handshake with TCP_client, and the port is set to be 4444
            var clientTCP = new TcpClient(CommandSet.IP, CommandSet.DISCOVERY_PORT);
            var stream = new NetworkStream(clientTCP.Client);

            //initialize reader and writer
            var streamWriter = new StreamWriter(stream);
            var streamReader = new StreamReader(stream);

            //when the drone receive the message bellow, it will return the confirmation
            //string handshake_json = "{\"controller_type\":\"computer\", \"controller_name\":\"katarina\", \"d2c_port\":\"43210\", \"arstream2_client_stream_port\":\"55004\", \"arstream2_client_control_port\":\"55005\"}";
            var handshake = new JSONClass();
            handshake["controller_type"] = "computer";
            handshake["controller_name"] = "oyo";
            handshake["d2c_port"] = new JSONData(43210); // "43210"
            handshake["arstream2_client_stream_port"] = new JSONData(55004);
            handshake["arstream2_client_control_port"] = new JSONData(55005);
            streamWriter.WriteLine(handshake.ToString());
            streamWriter.Flush();

            var message = streamReader.ReadLine();
            if (message == null)
                return false;


            //initialize
            this.GenerateAllStates();
            this.GenerateAllSettings();

            //enable video streaming
            this.EnableVideoStream();

            if(this._d2c.Connect() == false)
                return false;

            this._gmapMutex                 = new Mutex();

            this.Connected                  = true;
            this._commandThread             = new Thread(this.commandThreadRoutine);
            this._commandThread.Start();

            this._streamingThread           = new Thread(this.streamingThreadRoutine);
            this._streamingThread.Start();

            this._gmapThread                = new Thread(this.gmapThreadRoutine);
            this._gmapThread.Start();
            return true;
        }

        public void Disconnect()
        {
            if(this.Connected == false)
                return;

            this.Connected = false;
            this._d2c.Disconnect();
            this._commandThread.Join();
            this._streamingThread.Join();
            this._gmapThread.Join();

            this._gmapMutex.Close();
        }

        public void takeoff()
        {
            var cmd = new Command(4);

            cmd.append((byte)CommandSet.ARCOMMANDS_ID_PROJECT_ARDRONE3);
            cmd.append((byte)CommandSet.ARCOMMANDS_ID_ARDRONE3_CLASS_PILOTING);
            cmd.append((byte)CommandSet.ARCOMMANDS_ID_ARDRONE3_PILOTING_CMD_TAKEOFF);
            cmd.append((byte)0);

            this._c2d.Send(CommandSet.ARNETWORKAL_FRAME_TYPE_DATA_WITH_ACK, CommandSet.BD_NET_CD_ACK_ID, cmd);
        }

        public void landing()
        {
            var cmd = new Command(4);

            cmd.append((byte)CommandSet.ARCOMMANDS_ID_PROJECT_ARDRONE3);
            cmd.append((byte)CommandSet.ARCOMMANDS_ID_ARDRONE3_CLASS_PILOTING);
            cmd.append((byte)CommandSet.ARCOMMANDS_ID_ARDRONE3_PILOTING_CMD_LANDING);
            cmd.append((byte)0);

            this._c2d.Send(CommandSet.ARNETWORKAL_FRAME_TYPE_DATA_WITH_ACK, CommandSet.BD_NET_CD_ACK_ID, cmd);
        }

        public void GeneratePCMD()
        {
            lock (_thisLock)
            {
                var pcmd = this._listener.OnRequestPCMD();
                var cmd = new Command(13);

                cmd.append((byte)CommandSet.ARCOMMANDS_ID_PROJECT_ARDRONE3);
                cmd.append((byte)CommandSet.ARCOMMANDS_ID_ARDRONE3_CLASS_PILOTING);
                cmd.append((byte)CommandSet.ARCOMMANDS_ID_ARDRONE3_PILOTING_CMD_PCMD);
                cmd.append((byte)0);

                cmd.append((byte)pcmd.flag);  // flag
                cmd.append((byte)(pcmd.roll >= 0 ? pcmd.roll : 256 + pcmd.roll));  // roll: fly left or right [-100 ~ 100]
                cmd.append((byte)(pcmd.pitch >= 0 ? pcmd.pitch : 256 + pcmd.pitch));  // pitch: backward or forward [-100 ~ 100]
                cmd.append((byte)(pcmd.yaw >= 0 ? pcmd.yaw : 256 + pcmd.yaw));  // yaw: rotate left or right [-100 ~ 100]
                cmd.append((byte)(pcmd.gaz >= 0 ? pcmd.gaz : 256 + pcmd.gaz));  // gaze: down or up [-100 ~ 100]


                cmd.append((byte)0);
                cmd.append((byte)0);
                cmd.append((byte)0);
                cmd.append((byte)0);


                this._c2d.Send(cmd);
                //sendCommandAdpator(ref cmd);
            }
        }

        public void commandThreadRoutine()
        {
            while(this.Connected)
            {
                lock(this)
                {
                    this.GeneratePCMD();
                }
                Thread.Sleep(100);  //sleep 50ms each time.
            }
        }

        private void streamingThreadRoutine()
        {
            var exists = File.Exists("bebop.sdp");
            if (exists == false)
                return;

            var capture = new VideoCapture("bebop.sdp");
            var frame = new Mat();
            while (capture.IsOpened() && this.Connected)
            {
                try
                {
                    if (capture.Read(frame) == false)
                        break;

                    frame = frame.Resize(new Size(frame.Width / 2, frame.Height / 2));
                    if (this._listener != null)
                        this._listener.OnStreaming(frame);
                }
                catch(Exception)
                {

                }
            }
        }

        private void gmapThreadRoutine()
        {
            while(this.Connected)
            {
                try
                {
this._gmapMutex.WaitOne();
                    var uri = new Uri(string.Format("http://maps.googleapis.com/maps/api/staticmap?center={0},{1}&markers=color:blue%7Clabel:OYO%7C{2},{3}&size=600x600&sensor=true&format=png&maptype=roadmap&zoom=18&language=ko&key=AIzaSyDO1LpjNHsEWBWLFdBPc6acJgyujd8ur2s", this._lat, this._lon, this._lat, this._lon));
this._gmapMutex.ReleaseMutex();
                    var httpRequest = (HttpWebRequest)HttpWebRequest.Create(uri);
                    var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                    var imageStream = httpResponse.GetResponseStream();

                    var mstream = new MemoryStream();
                    imageStream.CopyTo(mstream);
                    this.GMap = Cv2.ImDecode(mstream.ToArray(), ImreadModes.AnyColor);
                    this._listener.OnUpdateGMap(this.GMap);
                }
                catch(Exception e)
                {
                }
                finally
                {
                    Thread.Sleep(1000);
                }
            }
        }

        public void GenerateAllStates()
        {
            var cmd = new Command(4);

            cmd.cmd[0] = CommandSet.ARCOMMANDS_ID_PROJECT_COMMON;
            cmd.cmd[1] = CommandSet.ARCOMMANDS_ID_COMMON_CLASS_COMMON;
            cmd.cmd[2] = (CommandSet.ARCOMMANDS_ID_COMMON_COMMON_CMD_ALLSTATES & 0xff);
            cmd.cmd[3] = (CommandSet.ARCOMMANDS_ID_COMMON_COMMON_CMD_ALLSTATES & 0xff00 >> 8);

            this._c2d.Send(CommandSet.ARNETWORKAL_FRAME_TYPE_DATA_WITH_ACK, CommandSet.BD_NET_CD_ACK_ID, cmd);
        }

        public void GenerateAllSettings()
        {
            var cmd = new Command(4);

            cmd.cmd[0] = CommandSet.ARCOMMANDS_ID_PROJECT_COMMON;
            cmd.cmd[1] = CommandSet.ARCOMMANDS_ID_COMMON_CLASS_SETTINGS;
            cmd.cmd[2] = (0 & 0xff); // ARCOMMANDS_ID_COMMON_CLASS_SETTINGS_CMD_ALLSETTINGS = 0
            cmd.cmd[3] = (0 & 0xff00 >> 8);

            this._c2d.Send(CommandSet.ARNETWORKAL_FRAME_TYPE_DATA_WITH_ACK, CommandSet.BD_NET_CD_ACK_ID, cmd);
        }

        public void EnableVideoStream()
        {
            var cmd = new Command(5);

            cmd.cmd[0] = CommandSet.ARCOMMANDS_ID_PROJECT_ARDRONE3;
            cmd.cmd[1] = CommandSet.ARCOMMANDS_ID_ARDRONE3_CLASS_MEDIASTREAMING;
            cmd.cmd[2] = (0 & 0xff); // ARCOMMANDS_ID_COMMON_CLASS_SETTINGS_CMD_VIDEOENABLE = 0
            cmd.cmd[3] = (0 & 0xff00 >> 8);
            cmd.cmd[4] = 1; //arg: Enable

            //sendCommandAdpator(ref cmd, CommandSet.ARNETWORKAL_FRAME_TYPE_DATA_WITH_ACK, CommandSet.BD_NET_CD_ACK_ID);
            this._c2d.Send(CommandSet.ARNETWORKAL_FRAME_TYPE_DATA_WITH_ACK, CommandSet.BD_NET_CD_ACK_ID, cmd);
        }

        public void initARStream()
        {
            arstreamClient = new UdpClient(55004);
            remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
        }

        public static bool CompareCommandSet(byte _project, byte _cls, ushort _id, byte project, byte cls, ushort id)
        {
            if(_project != project)
                return false;

            if(_cls != cls)
                return false;

            if(_id != id)
                return false;

            return true;
        }

        public void OnReceiveFrame(int frameType, int frameId, int frameSeq, Command cmd)
        {
            try
            {
                using (var reader = new BinaryReader(new MemoryStream(cmd.cmd)))
                {
                    if (frameType != CommandSet.ARNETWORKAL_FRAME_TYPE_DATA && frameType != CommandSet.ARNETWORKAL_FRAME_TYPE_DATA_WITH_ACK)
                        return;

                    if (frameType == CommandSet.ARNETWORKAL_FRAME_TYPE_ACK)
                    {
                        if (cmd.size != 8)
                            return;

                        if (frameId != 0x8B)
                            return;

                        return;
                    }


                    if (frameType == CommandSet.ARNETWORKAL_FRAME_TYPE_DATA_LOW_LATENCY)
                    {
                        if (cmd.size < 12)
                            return;

                        if (frameId != 0x7D)
                            return;

                        var frameNumber = reader.ReadUInt16();
                        var frameFlags = reader.ReadByte();
                        var fragmentNumber = reader.ReadByte();
                        var fragmentPerFrame = reader.ReadByte();
                        return;
                    }

                    if(frameId == 0x7F)
                    {
                        var commandProject = reader.ReadByte();
                        var commandClass = reader.ReadByte();
                        var commandId = reader.ReadUInt16();

                        if(commandProject == CommandSet.ARCOMMANDS_ID_PROJECT_COMMON)
                        {
                            if(commandClass == CommandSet.ARCOMMANDS_ID_COMMON_CLASS_COMMONSTATE && commandId == 7/*CommandSet.ARCOMMANDS_ID_COMMON_COMMONSTATE_CMD_WIFISIGNALCHANGED*/)
                            {
                                this._rssi = reader.ReadInt16();
                            }
                            else
                            { }
                        }
                        else if(commandProject == CommandSet.ARCOMMANDS_ID_PROJECT_ARDRONE3)
                        {
                            if(commandClass == CommandSet.ARCOMMANDS_ID_ARDRONE3_CLASS_PILOTINGSTATE && commandId == CommandSet.ARCOMMANDS_ID_ARDRONE3_PILOTINGSTATE_CMD_POSITIONCHANGED)
                            {
this._gmapMutex.WaitOne();
                                this._lat = reader.ReadDouble();
                                this._lon = reader.ReadDouble();
                                this._alt = reader.ReadDouble();
this._gmapMutex.ReleaseMutex();
                            }
                            else if(commandClass == CommandSet.ARCOMMANDS_ID_ARDRONE3_CLASS_PILOTINGSTATE && commandId == CommandSet.ARCOMMANDS_ID_ARDRONE3_PILOTINGSTATE_CMD_SPEEDCHANGED)
                            {
                                this._speed_x = reader.ReadSingle();
                                this._speed_y = reader.ReadSingle();
                                this._speed_z = reader.ReadSingle();
                            }
                            else if(commandClass == CommandSet.ARCOMMANDS_ID_ARDRONE3_CLASS_PILOTINGSTATE && commandId == CommandSet.ARCOMMANDS_ID_ARDRONE3_PILOTINGSTATE_CMD_ATTITUDECHANGED)
                            {
                                this._roll = reader.ReadSingle();
                                this._pitch = reader.ReadSingle();
                                this._yaw = reader.ReadSingle();
                            }
                            else if(commandClass == CommandSet.ARCOMMANDS_ID_ARDRONE3_CLASS_PILOTINGSTATE && commandId == CommandSet.ARCOMMANDS_ID_ARDRONE3_PILOTINGSTATE_CMD_ALTITUDECHANGED)
                            {
                                this._altitude = reader.ReadDouble();
                            }
                            else if(commandClass == CommandSet.ARCOMMANDS_ID_ARDRONE3_CLASS_CAMERASTATE && commandId == 0)
                            {
                                this._pan = reader.ReadByte();
                                this._tilt = reader.ReadByte();
                            }
                            else
                            {
                                //
                                // Unknown command
                                //
                            }
                        }
                        else
                        {
                            //
                            // Unknown project
                            //
                        }
                    }
                    else if(frameId == 0x7E)
                    {
                        var commandProject = reader.ReadByte();
                        var commandClass = reader.ReadByte();
                        var commandId = reader.ReadUInt16();

                        if (commandProject == CommandSet.ARCOMMANDS_ID_PROJECT_COMMON && commandClass == CommandSet.ARCOMMANDS_ID_COMMON_CLASS_COMMONSTATE && commandId == CommandSet.ARCOMMANDS_ID_COMMON_COMMONSTATE_CMD_BATTERYSTATECHANGED)
                        {
                            this.Battery = reader.ReadByte();
                        }
                        else if(commandProject == CommandSet.ARCOMMANDS_ID_PROJECT_ARDRONE3 && commandClass == CommandSet.ARCOMMANDS_ID_ARDRONE3_CLASS_PILOTINGSTATE)
                        {
                            if(commandId == CommandSet.ARCOMMANDS_ID_ARDRONE3_PILOTINGSTATE_CMD_FLATTRIMCHANGED)
                            {
                                //
                                // Flat trim changed
                                //
                            }
                            else if(commandId == CommandSet.ARCOMMANDS_ID_ARDRONE3_PILOTINGSTATE_CMD_FLYINGSTATECHANGED)
                            {
                                this._state = reader.ReadUInt32();
                            }
                            else if(commandId == CommandSet.ARCOMMANDS_ID_ARDRONE3_PILOTINGSTATE_CMD_ALERTSTATECHANGED)
                            {
                                var alert = reader.ReadUInt32();
                                // ["none/No alert", "user/User emergency alert", "cut_out/Cut out alert", "critical_battery", "low_battery", "too_much_angle"]
                            }
                            else if(commandId == CommandSet.ARCOMMANDS_ID_ARDRONE3_PILOTINGSTATE_CMD_NAVIGATEHOMESTATECHANGED)
                            {
                                var state = reader.ReadUInt32();
                                var readson = reader.ReadUInt32();
                                // states = ["available", "inProgress", "unavailable", "pending", "low_battery", "too_much_angle"]
                                // reasons = ["userRequest", "connectionLost", "lowBattery", "finished", "stopped", "disabled", "enabled"]
                            }
                            else
                            {
                                //
                                // Unknown piloting state
                                //
                            }
                        }
                        else if(commandProject == CommandSet.ARCOMMANDS_ID_PROJECT_ARDRONE3 && commandClass == CommandSet.ARCOMMANDS_ID_ARDRONE3_CLASS_PILOTINGSETTINGSSTATE)
                        {
                            //
                            // 설정된 비행 상태값을 얻어오는 부분인 것 같다.
                            //
                        }
                        else if(commandProject == CommandSet.ARCOMMANDS_ID_PROJECT_ARDRONE3 && commandClass == CommandSet.ARCOMMANDS_ID_ARDRONE3_CLASS_PILOTINGSETTINGSSTATE)
                        { }
                        else
                        {
                            //
                            // 다 필요없는 부분인듯..
                            //
                        }
                    }
                    else if(frameId == 0x00)
                    {
                        //
                        // 이것도 필요없어보임..
                        //
                    }
                    else
                    {
                        // 이것도..
                    }

                    this._listener.OnStateChanged(this);
                }
            }
            catch (Exception)
            { }
        }
    }
}