using BebopCommandSet;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace ParrotBebop2
{
    public class C2DSocket
    {
        private Socket              _socket;
        private IPEndPoint          _endpoint;
        private int[]               _sequence = new int[256];

        public C2DSocket()
        {
            this._socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            this._endpoint = new IPEndPoint(IPAddress.Parse(CommandSet.IP), CommandSet.C2D_PORT);
        }

        private int updateSequence(int id)
        {
            this._sequence[id] = (this._sequence[id] + 1) % 256;
            return this._sequence[id];
        }

        private byte[] encodeCommand(Command cmd, bool ackRequest)
        {
            var id = ackRequest ? CommandSet.BD_NET_CD_ACK_ID : CommandSet.BD_NET_CD_NONACK_ID;

            return this.encodeCommand(CommandSet.ARNETWORKAL_FRAME_TYPE_DATA, id, cmd);
        }

        private byte[] encodeCommand(int type, int id, Command cmd)
        {
            var buffer = new byte[cmd.size + 7];

            using (var writer = new BinaryWriter(new MemoryStream(buffer)))
            {
                writer.Write((byte)type);
                writer.Write((byte)id);
                writer.Write((byte)this.updateSequence(id));
                writer.Write(buffer.Length);
                writer.Write(cmd.cmd, 0, cmd.size);
            }

            return buffer;
        }

        public bool Send(Command cmd, bool ackRequest = false)
        {
            try
            {
                var encodedCommand = this.encodeCommand(cmd, ackRequest);
                this._socket.SendTo(encodedCommand, this._endpoint);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool Send(int type, int id, Command cmd)
        {
            try
            {
                var encodedCommand = this.encodeCommand(type, id, cmd);
                this._socket.SendTo(encodedCommand, this._endpoint);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}