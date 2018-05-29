using BebopCommandSet;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ParrotBebop2
{
    public class D2CSocket
    {
        public static readonly int          BUFFER_SIZE = 80960;

        public delegate void                ReceiveFrameEvent(int type, int id, int seq, Command cmd);

        private Socket                      _socket;
        private Thread                      _commandThread;

        public event ReceiveFrameEvent      OnReceiveFrame;

        public bool Connected { get; private set; }

        public D2CSocket()
        {
        }

        ~D2CSocket()
        {
            this.Disconnect();
        }

        private void commandThreadRoutine()
        {
            var buffer = new byte[BUFFER_SIZE];
            while(this.Connected)
            {
                try
                {
                    var readsize = this._socket.Receive(buffer, 0, BUFFER_SIZE, SocketFlags.None);
                    using (var reader = new BinaryReader(new MemoryStream(buffer, 0, readsize)))
                    {
                        var frameType = reader.ReadByte();
                        var frameId = reader.ReadByte();
                        var frameSeq = reader.ReadByte();
                        var frameSize = reader.ReadInt32();

                        var cmd = new Command(reader.ReadBytes(frameSize), 0, frameSize - 7);
                        this.OnReceiveFrame.Invoke(frameType, frameId, frameSeq, cmd);
                    }
                }
                catch(SocketException e)
                {
                    if(e.ErrorCode == 10004)
                        break;
                }
                catch(Exception)
                {
                    break;
                }
            }
        }

        public bool Connect()
        {
            try
            {
                var endpoint = new IPEndPoint(IPAddress.Any, CommandSet.D2C_PORT);
                this._socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                this._socket.Bind(endpoint);

                this.Connected = true;
                this._commandThread = new Thread(this.commandThreadRoutine);
                this._commandThread.Start();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public void Disconnect()
        {
            try
            {
                this.Connected = false;
                this._socket.Close();
            }
            catch(Exception)
            { }
        }
    }
}