using BebopCommandSet;
using Leap;
using OpenCvSharp;
using SimpleJSON;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ParrotBebop2
{

    public class Bebop2
    {
        public enum Bebop2State
        {
            Landed                              = CommandSet.ARCOMMANDS_ARDRONE3_PILOTINGSTATE_FLYINGSTATECHANGED_STATE_LANDED,
            TakingOff                           = CommandSet.ARCOMMANDS_ARDRONE3_PILOTINGSTATE_FLYINGSTATECHANGED_STATE_TAKINGOFF,
            Hovering                            = CommandSet.ARCOMMANDS_ARDRONE3_PILOTINGSTATE_FLYINGSTATECHANGED_STATE_HOVERING,
            Flying                              = CommandSet.ARCOMMANDS_ARDRONE3_PILOTINGSTATE_FLYINGSTATECHANGED_STATE_FLYING,
            Landing                             = CommandSet.ARCOMMANDS_ARDRONE3_PILOTINGSTATE_FLYINGSTATECHANGED_STATE_LANDING,
            Emergency                           = CommandSet.ARCOMMANDS_ARDRONE3_PILOTINGSTATE_FLYINGSTATECHANGED_STATE_EMERGENCY,
            Max                                 = CommandSet.ARCOMMANDS_ARDRONE3_PILOTINGSTATE_FLYINGSTATECHANGED_STATE_MAX,
        }

        public delegate void                    ConnectionEvent(Bebop2 bebop);
        public delegate void                    DisconnectionEvent(Bebop2 bebop);
        public delegate void                    StreamingEvent(Bebop2 bebop, Mat frame);
        public delegate Pcmd                    RequestPcmdEvent(Bebop2 bebop);
        public delegate void                    BatteryChangedEvent(Bebop2 bebop2, int battery);
        public delegate void                    SpeedChangedEvent(Bebop2 bebop2, Vector speed);
        public delegate void                    RotationChangedEvent(Bebop2 bebop2, float pitch, float yaw, float roll);
        public delegate void                    PositionChangedEvent(Bebop2 bebop2, double lat, double lon, double alt);
        public delegate void                    PilotStateChanged(Bebop2 bebop2, Bebop2State currentState);
        public delegate void                    AltitudeChanged(Bebop2 bebop2, double altitude);
        public delegate void                    ErrorEvent(Bebop2 bebop, string message);
        public delegate void                    WifiChanged(Bebop2 bebop2, short rssi);

        private int[]                           seq = new int[256];
        public Pcmd                             pcmd;

        private UdpClient                       clientArStream;
        private IPEndPoint                      endpoint;

        private static object                   _thisLock = new object();

        private D2CSocket                       _d2c;
        private C2DSocket                       _c2d;
        private Thread                          _commandThread, _streamingThread;

        public event ConnectionEvent            OnConnected;
        public event DisconnectionEvent         OnDisconnected;
        public event StreamingEvent             OnStreaming;
        public event RequestPcmdEvent           OnRequestPcmd;
        public event BatteryChangedEvent        OnBatteryChanged;
        public event SpeedChangedEvent          OnSpeedChanged;
        public event RotationChangedEvent       OnRotationChanged;
        public event PositionChangedEvent       OnPositionChanged;
        public event PilotStateChanged          OnPilotStateChanged;
        public event AltitudeChanged            OnAltitudeChanged;
        public event ErrorEvent                 OnError;
        public event WifiChanged                OnWifiChanged;

        public short RSSI { get; private set; }

        private uint _state;

        public oyo.GPS GPS { get; private set; }

        public Bebop2State State
        {
            get
            {
                return (Bebop2State)this._state;
            }
        }

        public Vector Speed { get; private set; }

        public float Pitch { get; private set; }
        public float Yaw { get; private set; }
        public float Roll { get; private set; }

        public double Altitude { get; private set; }

        public byte Pan { get; private set; }
        public byte Tilt { get; private set; }
        
        public bool Connected { get; private set; }
        public byte Battery { get; private set; }


        public Bebop2()
        {
            this._d2c                           = new D2CSocket();
            this._d2c.OnReceiveFrame           += this.OnReceiveFrame;

            this._c2d                           = new C2DSocket();
        }

        public void Connect()
        {
            var connectionThread = new Thread(this.RequestConnection);
            connectionThread.Start();
        }


        private void RequestConnection()
        {
            try
            {
                //make handshake with TCP_client, and the port is set to be 4444
                var client                                      = new TcpClient(CommandSet.IP, CommandSet.DISCOVERY_PORT);
                var stream                                      = new NetworkStream(client.Client);

                //initialize reader and writer
                var streamWriter                                = new StreamWriter(stream);
                var streamReader                                = new StreamReader(stream);

                //when the drone receive the message bellow, it will return the confirmation
                var handshake                                   = new JSONClass();
                handshake["controller_type"]                    = "computer";
                handshake["controller_name"]                    = "oyo";
                handshake["d2c_port"]                           = new JSONData(43210); // "43210"
                handshake["arstream2_client_stream_port"]       = new JSONData(55004);
                handshake["arstream2_client_control_port"]      = new JSONData(55005);
                streamWriter.WriteLine(handshake.ToString());
                streamWriter.Flush();

                var message = streamReader.ReadLine();
                if (message == null)
                    throw new Exception(message);


                //initialize
                this.GenerateAllStates();
                this.GenerateAllSettings();

                //enable video streaming
                this.EnableVideoStream();

                if (this._d2c.Connect() == false)
                    return;

                this.Connected                                  = true;
                this._commandThread                             = new Thread(this.commandThreadRoutine);
                this._commandThread.Start();

                this._streamingThread                           = new Thread(this.streamingThreadRoutine);
                this._streamingThread.Start();

                if (this.OnConnected != null)
                    this.OnConnected.Invoke(this);
            }
            catch (Exception e)
            {
                if(this.OnError != null)
                    this.OnError.Invoke(this, e.Message);
            }
        }

        public void Disconnect()
        {
            if(this.Connected == false)
                return;

            this.Connected = false;
            this._d2c.Disconnect();
            this._commandThread.Join();
            this._streamingThread.Join();

            if(this.OnDisconnected != null)
                this.OnDisconnected.Invoke(this);
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
                var pcmd = this.OnRequestPcmd(this);
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

                    frame = frame.Resize(new OpenCvSharp.Size(frame.Width / 2, frame.Height / 2));
                    this.OnStreaming.Invoke(this, frame);
                }
                catch(Exception)
                {

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
            clientArStream = new UdpClient(55004);
            endpoint = new IPEndPoint(IPAddress.Any, 0);
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
                                this.RSSI = reader.ReadInt16();

                                if(this.OnWifiChanged != null)
                                    this.OnWifiChanged(this, this.RSSI);
                            }
                            else
                            { }
                        }
                        else if(commandProject == CommandSet.ARCOMMANDS_ID_PROJECT_ARDRONE3)
                        {
                            if(commandClass == CommandSet.ARCOMMANDS_ID_ARDRONE3_CLASS_PILOTINGSTATE && commandId == CommandSet.ARCOMMANDS_ID_ARDRONE3_PILOTINGSTATE_CMD_POSITIONCHANGED)
                            {
                                this.GPS = new oyo.GPS(reader.ReadDouble(), reader.ReadDouble(), reader.ReadDouble());

                                if(this.OnPositionChanged != null)
                                    this.OnPositionChanged.Invoke(this, this.GPS.lat, this.GPS.lon, this.GPS.alt);
                            }
                            else if(commandClass == CommandSet.ARCOMMANDS_ID_ARDRONE3_CLASS_PILOTINGSTATE && commandId == CommandSet.ARCOMMANDS_ID_ARDRONE3_PILOTINGSTATE_CMD_SPEEDCHANGED)
                            {
                                this.Speed = new Vector(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());

                                if(this.OnSpeedChanged != null)
                                    this.OnSpeedChanged.Invoke(this, this.Speed);
                            }
                            else if(commandClass == CommandSet.ARCOMMANDS_ID_ARDRONE3_CLASS_PILOTINGSTATE && commandId == CommandSet.ARCOMMANDS_ID_ARDRONE3_PILOTINGSTATE_CMD_ATTITUDECHANGED)
                            {
                                this.Roll = reader.ReadSingle();
                                this.Pitch = reader.ReadSingle();
                                this.Yaw = reader.ReadSingle();

                                if(this.OnRotationChanged != null)
                                    this.OnRotationChanged.Invoke(this, this.Pitch, this.Yaw, this.Roll);
                            }
                            else if(commandClass == CommandSet.ARCOMMANDS_ID_ARDRONE3_CLASS_PILOTINGSTATE && commandId == CommandSet.ARCOMMANDS_ID_ARDRONE3_PILOTINGSTATE_CMD_ALTITUDECHANGED)
                            {
                                this.Altitude = reader.ReadDouble();

                                if(this.OnAltitudeChanged != null)
                                    this.OnAltitudeChanged.Invoke(this, this.Altitude);
                            }
                            else if(commandClass == CommandSet.ARCOMMANDS_ID_ARDRONE3_CLASS_CAMERASTATE && commandId == 0)
                            {
                                this.Pan = reader.ReadByte();
                                this.Tilt = reader.ReadByte();
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

                            if(this.OnBatteryChanged != null)
                                this.OnBatteryChanged.Invoke(this, this.Battery);
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

                                if(this.OnPilotStateChanged != null)
                                    this.OnPilotStateChanged.Invoke(this, (Bebop2State)this._state);
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
                }
            }
            catch (Exception)
            { }
        }
    }
}