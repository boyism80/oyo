﻿using System.IO;

namespace BebopCommandSet
{
    public class Command
    {
        private byte [] _buffer;
        private BinaryWriter _writer;

        public int size
        {
            get
            {
                return this._buffer.Length;
            }
        }

        public byte[] cmd
        {
            get
            {
                return this._buffer;
            }
        }

        public Command(int size)
        {
            this._buffer = new byte[size];
            this._writer = new BinaryWriter(new MemoryStream(this._buffer));
        }

        public Command(byte[] buffer, int offset, int size) : this(size)
        {
            this._writer.Write(buffer, offset, size);
        }

        public void append(byte data)
        {
            this._writer.Write(data);
        }

        public void append(short data)
        {
            this._writer.Write(data);
        }

        public void append(int data)
        {
            this._writer.Write(data);
        }
    }

    public class Pcmd
    {
        public int flag;
        public int roll;
        public int pitch;
        public int yaw;
        public int gaz;

        public Pcmd Reversed
        {
            get
            {
                return new Pcmd(-this.pitch, -this.yaw, -this.roll, -this.gaz, this.flag);
            }
        }

        public Pcmd()
        { }

        public Pcmd(int pitch, int yaw, int roll, int gaz, int flag)
        {
            this.pitch = pitch;
            this.yaw = yaw;
            this.roll = roll;
            this.gaz = gaz;
            this.flag = flag;
        }

        public Pcmd(Pcmd right)
        {
            this.flag = right.flag;
            this.pitch = right.pitch;
            this.roll = right.roll;
            this.yaw = right.yaw;
            this.gaz = right.gaz;
        }

        public override bool Equals(object obj)
        {
            var right = obj as Pcmd;
            if(right == null)
                return base.Equals(obj);

            return (this.pitch == right.pitch   &&
                    this.yaw == right.yaw       &&
                    this.roll == right.roll     &&
                    this.gaz == right.gaz       &&
                    this.flag == right.flag);
        }

        public override string ToString()
        {
            return string.Format("pitch : {0}, yaw : {1}, roll : {2}, gaz : {3}, flag : {4}", this.pitch, this.yaw, this.roll, this.gaz, this.flag);
        }

        public void Reset()
        {
            this.pitch = 0;
            this.yaw = 0;
            this.roll = 0;
            this.gaz = 0;
            this.flag = 0;
        }
    }

    public class CommandSet
    {
        // eARCOMMANDS_ID_PROJECT
        public const int ARCOMMANDS_ID_PROJECT_COMMON = 0;
        public const int ARCOMMANDS_ID_PROJECT_ARDRONE3 = 1;

        // eARCOMMANDS_ID_ARDRONE3_CLASS
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_PILOTING = 0;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_ANIMATIONS = 5;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_CAMERA = 1;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_MEDIARECORD = 7;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_MEDIARECORDSTATE = 8;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_MEDIARECORDEVENT = 3;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_PILOTINGSTATE = 4;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_NETWORK = 13;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_NETWORKSTATE = 14;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_PILOTINGSETTINGS = 2;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_PILOTINGSETTINGSSTATE = 6;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_SPEEDSETTINGS = 11;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_SPEEDSETTINGSSTATE = 12;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_NETWORKSETTINGS = 9;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_NETWORKSETTINGSSTATE = 10;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_SETTINGS = 15;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_SETTINGSSTATE = 16;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_DIRECTORMODE = 17;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_DIRECTORMODESTATE = 18;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_PICTURESETTINGS = 19;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_PICTURESETTINGSSTATE = 20;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_MEDIASTREAMING = 21;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_MEDIASTREAMINGSTATE = 22;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_GPSSETTINGS = 23;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_GPSSETTINGSSTATE = 24;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_CAMERASTATE = 25;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_ANTIFLICKERING = 29;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_ANTIFLICKERINGSTATE = 30;

        // eARCOMMANDS_ID_ARDRONE3_PILOTINGSTATE_CMD
        public const int ARCOMMANDS_ID_ARDRONE3_PILOTINGSTATE_CMD_FLATTRIMCHANGED = 0;
        public const int ARCOMMANDS_ID_ARDRONE3_PILOTINGSTATE_CMD_FLYINGSTATECHANGED = 1;
        public const int ARCOMMANDS_ID_ARDRONE3_PILOTINGSTATE_CMD_ALERTSTATECHANGED = 2;
        public const int ARCOMMANDS_ID_ARDRONE3_PILOTINGSTATE_CMD_NAVIGATEHOMESTATECHANGED = 3;
        public const int ARCOMMANDS_ID_ARDRONE3_PILOTINGSTATE_CMD_POSITIONCHANGED = 4;
        public const int ARCOMMANDS_ID_ARDRONE3_PILOTINGSTATE_CMD_SPEEDCHANGED = 5;
        public const int ARCOMMANDS_ID_ARDRONE3_PILOTINGSTATE_CMD_ATTITUDECHANGED = 6;
        public const int ARCOMMANDS_ID_ARDRONE3_PILOTINGSTATE_CMD_AUTOTAKEOFFMODECHANGED = 7;
        public const int ARCOMMANDS_ID_ARDRONE3_PILOTINGSTATE_CMD_ALTITUDECHANGED = 8;
        public const int ARCOMMANDS_ID_ARDRONE3_PILOTINGSTATE_CMD_MAX = 9;

        // eARCOMMANDS_ID_ARDRONE3_ANIMATIONS_CMD;
        public const int ARCOMMANDS_ID_ARDRONE3_ANIMATIONS_CMD_FLIP = 0;
        public const int ARCOMMANDS_ID_ARDRONE3_ANIMATIONS_CMD_MAX = 1;

        // eARCOMMANDS_ARDRONE3_PILOTINGSTATE_FLYINGSTATECHANGED_STATE;
        public const int ARCOMMANDS_ARDRONE3_PILOTINGSTATE_FLYINGSTATECHANGED_STATE_LANDED = 0;
        public const int ARCOMMANDS_ARDRONE3_PILOTINGSTATE_FLYINGSTATECHANGED_STATE_TAKINGOFF = 1;
        public const int ARCOMMANDS_ARDRONE3_PILOTINGSTATE_FLYINGSTATECHANGED_STATE_HOVERING = 2;
        public const int ARCOMMANDS_ARDRONE3_PILOTINGSTATE_FLYINGSTATECHANGED_STATE_FLYING = 3;
        public const int ARCOMMANDS_ARDRONE3_PILOTINGSTATE_FLYINGSTATECHANGED_STATE_LANDING = 4;
        public const int ARCOMMANDS_ARDRONE3_PILOTINGSTATE_FLYINGSTATECHANGED_STATE_EMERGENCY = 5;
        public const int ARCOMMANDS_ARDRONE3_PILOTINGSTATE_FLYINGSTATECHANGED_STATE_MAX = 6;

        // eARCOMMANDS_ARDRONE3_ANIMATIONS_FLIP_DIRECTION;
        public const int ARCOMMANDS_ARDRONE3_ANIMATIONS_FLIP_DIRECTION_FRONT = 0;
        public const int ARCOMMANDS_ARDRONE3_ANIMATIONS_FLIP_DIRECTION_BACK = 1;
        public const int ARCOMMANDS_ARDRONE3_ANIMATIONS_FLIP_DIRECTION_RIGHT = 2;
        public const int ARCOMMANDS_ARDRONE3_ANIMATIONS_FLIP_DIRECTION_LEFT = 3;
        public const int ARCOMMANDS_ARDRONE3_ANIMATIONS_FLIP_DIRECTION_MAX = 4;

        // eARCOMMANDS_ID_COMMON_CLASS
        public const int ARCOMMANDS_ID_COMMON_CLASS_NETWORK = 0;
        public const int ARCOMMANDS_ID_COMMON_CLASS_NETWORKEVENT = 1;
        public const int ARCOMMANDS_ID_COMMON_CLASS_SETTINGS = 2;
        public const int ARCOMMANDS_ID_COMMON_CLASS_SETTINGSSTATE = 3;
        public const int ARCOMMANDS_ID_COMMON_CLASS_COMMON = 4;
        public const int ARCOMMANDS_ID_COMMON_CLASS_COMMONSTATE = 5;
        public const int ARCOMMANDS_ID_COMMON_CLASS_OVERHEAT = 6;
        public const int ARCOMMANDS_ID_COMMON_CLASS_OVERHEATSTATE = 7;
        public const int ARCOMMANDS_ID_COMMON_CLASS_CONTROLLERSTATE = 8;
        public const int ARCOMMANDS_ID_COMMON_CLASS_WIFISETTINGS = 9;
        public const int ARCOMMANDS_ID_COMMON_CLASS_WIFISETTINGSSTATE = 10;
        public const int ARCOMMANDS_ID_COMMON_CLASS_MAVLINK = 11;
        public const int ARCOMMANDS_ID_COMMON_CLASS_MAVLINKSTATE = 12;
        public const int ARCOMMANDS_ID_COMMON_CLASS_CALIBRATION = 13;
        public const int ARCOMMANDS_ID_COMMON_CLASS_CALIBRATIONSTATE = 14;
        public const int ARCOMMANDS_ID_COMMON_CLASS_CAMERASETTINGSSTATE = 15;
        public const int ARCOMMANDS_ID_COMMON_CLASS_GPS = 16;
        public const int ARCOMMANDS_ID_COMMON_CLASS_FLIGHTPLANSTATE = 17;
        public const int ARCOMMANDS_ID_COMMON_CLASS_FLIGHTPLANEVENT = 19;
        public const int ARCOMMANDS_ID_COMMON_CLASS_ARLIBSVERSIONSSTATE = 18;

        // eARCOMMANDS_ID_ARDRONE3_PILOTING_CMD
        public const int ARCOMMANDS_ID_ARDRONE3_PILOTING_CMD_FLATTRIM = 0;
        public const int ARCOMMANDS_ID_ARDRONE3_PILOTING_CMD_TAKEOFF = 1;
        public const int ARCOMMANDS_ID_ARDRONE3_PILOTING_CMD_PCMD = 2;
        public const int ARCOMMANDS_ID_ARDRONE3_PILOTING_CMD_LANDING = 3;
        public const int ARCOMMANDS_ID_ARDRONE3_PILOTING_CMD_EMERGENCY = 4;
        public const int ARCOMMANDS_ID_ARDRONE3_PILOTING_CMD_NAVIGATEHOME = 5;
        public const int ARCOMMANDS_ID_ARDRONE3_PILOTING_CMD_AUTOTAKEOFFMODE = 6;
        public const int ARCOMMANDS_ID_ARDRONE3_PILOTING_CMD_MAX = 7;

        // eARCOMMANDS_ID_ARDRONE3_CLASS_SETTINGSSTATE_CMD
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_SETTINGSSTATE_CMD_PRODUCTMOTORVERSIONLISTCHANGED = 0;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_SETTINGSSTATE_CMD_PRODUCTGPSVERSIONCHANGED = 1;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_SETTINGSSTATE_CMD_MOTORERRORSTATECHANGED = 2;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_SETTINGSSTATE_CMD_MOTORSOFTWAREVERSIONCHANGED = 3;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_SETTINGSSTATE_CMD_MOTORFLIGHTSSTATUSCHANGED = 4;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_SETTINGSSTATE_CMD_MOTORERRORLASTERRORCHANGED = 5;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_SETTINGSSTATE_CMD_P7ID = 6;
        public const int ARCOMMANDS_ID_ARDRONE3_CLASS_SETTINGSSTATE_CMD_MAX = 7;

        // eARCOMMANDS_ID_ARDRONE3_SETTINGSSTATE_MOTORERRORSTATECHANGED_MOTORERROR
        public const int ARCOMMANDS_ID_ARDRONE3_SETTINGSSTATE_MOTORERRORSTATECHANGED_MOTORERROR_NOERROR = 0;
        public const int ARCOMMANDS_ID_ARDRONE3_SETTINGSSTATE_MOTORERRORSTATECHANGED_MOTORERROR_ERROREEPROM = 1;
        public const int ARCOMMANDS_ID_ARDRONE3_SETTINGSSTATE_MOTORERRORSTATECHANGED_MOTORERROR_ERRORMOTORSTALLED = 2;
        public const int ARCOMMANDS_ID_ARDRONE3_SETTINGSSTATE_MOTORERRORSTATECHANGED_MOTORERROR_ERRORPROPELLERSECURITY = 3;
        public const int ARCOMMANDS_ID_ARDRONE3_SETTINGSSTATE_MOTORERRORSTATECHANGED_MOTORERROR_ERRORCOMMLOST = 4;
        public const int ARCOMMANDS_ID_ARDRONE3_SETTINGSSTATE_MOTORERRORSTATECHANGED_MOTORERROR_ERRORRCEMERGECYSTOP = 5;
        public const int ARCOMMANDS_ID_ARDRONE3_SETTINGSSTATE_MOTORERRORSTATECHANGED_MOTORERROR_ERRORREALTIME = 6;
        public const int ARCOMMANDS_ID_ARDRONE3_SETTINGSSTATE_MOTORERRORSTATECHANGED_MOTORERROR_ERRORMOTORSETTING = 7;
        public const int ARCOMMANDS_ID_ARDRONE3_SETTINGSSTATE_MOTORERRORSTATECHANGED_MOTORERROR_ERRORTEMPERATURE = 8;
        public const int ARCOMMANDS_ID_ARDRONE3_SETTINGSSTATE_MOTORERRORSTATECHANGED_MOTORERROR_ERRORBATTERYVOLTAGE = 9;
        public const int ARCOMMANDS_ID_ARDRONE3_SETTINGSSTATE_MOTORERRORSTATECHANGED_MOTORERROR_ERRORLIPOCELLS = 10;
        public const int ARCOMMANDS_ID_ARDRONE3_SETTINGSSTATE_MOTORERRORSTATECHANGED_MOTORERROR_ERRORMOSFET = 11;
        public const int ARCOMMANDS_ID_ARDRONE3_SETTINGSSTATE_MOTORERRORSTATECHANGED_MOTORERROR_ERRORBOOTLOADER = 12;
        public const int ARCOMMANDS_ID_ARDRONE3_SETTINGSSTATE_MOTORERRORSTATECHANGED_MOTORERROR_ERRORASSERT = 13;
        public const int ARCOMMANDS_ID_ARDRONE3_SETTINGSSTATE_MOTORERRORSTATECHANGED_MOTORERROR_MAX = 14;


        // eARCOMMANDS_ID_COMMON_COMMON_CMD
        public const int ARCOMMANDS_ID_COMMON_COMMON_CMD_ALLSTATES = 0;
        public const int ARCOMMANDS_ID_COMMON_COMMON_CMD_CURRENTDATE = 1;
        public const int ARCOMMANDS_ID_COMMON_COMMON_CMD_CURRENTTIME = 2;
        public const int ARCOMMANDS_ID_COMMON_COMMON_CMD_REBOOT = 3;
        public const int ARCOMMANDS_ID_COMMON_COMMON_CMD_MAX = 4;

        // eARCOMMANDS_ID_COMMON_COMMONSTATE_CMD;
        public const int ARCOMMANDS_ID_COMMON_COMMONSTATE_CMD_ALLSTATESCHANGED = 0;
        public const int ARCOMMANDS_ID_COMMON_COMMONSTATE_CMD_BATTERYSTATECHANGED = 1;
        public const int ARCOMMANDS_ID_COMMON_COMMONSTATE_CMD_MASSSTORAGESTATELISTCHANGED = 2;
        public const int ARCOMMANDS_ID_COMMON_COMMONSTATE_CMD_MASSSTORAGEINFOSTATELISTCHANGED = 3;
        public const int ARCOMMANDS_ID_COMMON_COMMONSTATE_CMD_CURRENTDATECHANGED = 4;
        public const int ARCOMMANDS_ID_COMMON_COMMONSTATE_CMD_CURRENTTIMECHANGED = 5;
        public const int ARCOMMANDS_ID_COMMON_COMMONSTATE_CMD_MASSSTORAGEINFOREMAININGLISTCHANGED = 6;
        public const int ARCOMMANDS_ID_COMMON_COMMONSTATE_CMD_WIFISIGNALCHANGED = 6;
        public const int ARCOMMANDS_ID_COMMON_COMMONSTATE_CMD_SENSORSSTATESLISTCHANGED = 7;
        public const int ARCOMMANDS_ID_COMMON_COMMONSTATE_CMD_MAX = 8;

        // eARMEDIA_ENCAPSULER_CODEC
        public const int CODEC_UNKNNOWN = 0;
        public const int CODEC_VLIB = 1;
        public const int CODEC_P264 = 2;
        public const int CODEC_MPEG4_VISUAL = 3;
        public const int CODEC_MPEG4_AVC = 4;
        public const int CODEC_MOTION_JPEG = 5;

        // eARMEDIA_ENCAPSULER_FRAME_TYPE;
        public const int ARMEDIA_ENCAPSULER_FRAME_TYPE_UNKNNOWN = 0;
        public const int ARMEDIA_ENCAPSULER_FRAME_TYPE_I_FRAME = 1;
        public const int ARMEDIA_ENCAPSULER_FRAME_TYPE_P_FRAME = 2;
        public const int ARMEDIA_ENCAPSULER_FRAME_TYPE_JPEG = 3;
        public const int ARMEDIA_ENCAPSULER_FRAME_TYPE_MAX = 4;

        // libARNetworkAL/Includes/libARNetworkAL/ARNETWORKAL_Manager.h
        public const int ARNETWORKAL_MANAGER_DEFAULT_ID_MAX = 256;

        // eARNETWORK_MANAGER_INTERNAL_BUFFER_ID
        public const int ARNETWORK_MANAGER_INTERNAL_BUFFER_ID_PING = 0;
        public const int ARNETWORK_MANAGER_INTERNAL_BUFFER_ID_PONG = 1;
        public const int ARNETWORK_MANAGER_INTERNAL_BUFFER_ID_MAX = 3;

        // eARNETWORKAL_FRAME_TYPE
        public const int ARNETWORKAL_FRAME_TYPE_UNINITIALIZED = 0;
        public const int ARNETWORKAL_FRAME_TYPE_ACK = 1;
        public const int ARNETWORKAL_FRAME_TYPE_DATA = 2;
        public const int ARNETWORKAL_FRAME_TYPE_DATA_LOW_LATENCY = 3;
        public const int ARNETWORKAL_FRAME_TYPE_DATA_WITH_ACK = 4;
        public const int ARNETWORKAL_FRAME_TYPE_MAX = 5;

        // ARNETWORKAL_Frame_t identifiers
        public const int BD_NET_CD_NONACK_ID = 10;
        public const int BD_NET_CD_ACK_ID = 11;
        public const int BD_NET_CD_EMERGENCY_ID = 12;
        public const int BD_NET_CD_VIDEO_ACK_ID = 13;
        public const int BD_NET_DC_VIDEO_DATA_ID = 125;
        public const int BD_NET_DC_EVENT_ID = 126;
        public const int BD_NET_DC_NAVDATA_ID = 127;

        public const int BD_NET_DC_VIDEO_FRAG_SIZE = 1000;
        public const int BD_NET_DC_VIDEO_MAX_NUMBER_OF_FRAG = 128;

        public const int ARCOMMANDS_ID_ARDRONE3_CAMERA_CMD_ORIENTATION = 0;

        public const int BD_RAW_FRAME_BUFFER_SIZE = 50;
        public const int BD_RAW_FRAME_POOL_SIZE = 50;

        //Network Port & Network IP
        public const int DISCOVERY_PORT = 44444;
        public const int D2C_PORT = 43210;
        public const int C2D_PORT = 54321;
        public const int client_stream_port = 55004;
		public const int client_control_port = 55005;
		public const string IP = "192.168.42.1";
    }

  
}