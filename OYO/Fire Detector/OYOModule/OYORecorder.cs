using OpenCvSharp;
using System;
using System.Collections.Generic;

namespace oyo
{
    public class OYORecorder
    {
        public static FourCC                    DEFAULT_FOUR_CC = FourCC.H264;
        public static string                    DEFAULT_EXTENSION = "avi";

        public enum RecordingStateType
        {
            None        = 0x00000000,
            Infrared    = 0x00000001,
            Visual      = 0x00000002,
            Blending    = 0x00000004,
            Display     = 0x00000008,
        }

        private Dictionary<RecordingStateType, VideoWriter> _videoRecordTable = new Dictionary<RecordingStateType, VideoWriter>();

        public bool AnyVideoRecording
        {
            get
            {
                foreach (var type in this._videoRecordTable.Keys)
                {
                    if(this.IsRecording(type))
                        return true;
                }

                return false;
            }
        }

        public bool AllVideoRecording
        {
            get
            {
                foreach (var type in this._videoRecordTable.Keys)
                {
                    if(this.IsRecording(type) == false)
                        return false;
                }

                return true;
            }
        }

        public OYORecorder()
        {
            this._videoRecordTable.Add(RecordingStateType.Infrared, new VideoWriter());
            this._videoRecordTable.Add(RecordingStateType.Visual, new VideoWriter());
            this._videoRecordTable.Add(RecordingStateType.Display, new VideoWriter());
        }

        public bool IsRecording(RecordingStateType type)
        {
            try
            {
                return this._videoRecordTable[type].IsOpened();
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool IsCollisionPath(string path)
        {
            foreach (var writer in this._videoRecordTable.Values)
            {
                if(writer.IsOpened() && writer.FileName.Equals(path))
                    return true;
            }

            return false;
        }

        public bool Record(RecordingStateType type, string path, Size size, int fps)
        {
            try
            {
                if (this.IsRecording(type))
                    return false;

                if (this.IsCollisionPath(path))
                    return false;

                lock (this._videoRecordTable[type])
                {
                    this._videoRecordTable[type].Open(path, FourCC.XVID, fps, size);
                }
                return this._videoRecordTable[type].IsOpened();
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Stop(RecordingStateType type)
        {
            try
            {
                if (this.IsRecording(type) == false)
                    return false;

                lock (this._videoRecordTable[type])
                {
                    this._videoRecordTable[type].Release();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Release()
        {
            foreach(var writer in this._videoRecordTable.Values)
                writer.Release();
        }

        public void Write(RecordingStateType type, Mat frame)
        {
            try
            {
                if(this.IsRecording(type) == false)
                    return;

                lock (this._videoRecordTable[type])
                {
                    this._videoRecordTable[type].Write(frame.Resize(this._videoRecordTable[type].FrameSize));
                }
            }
            catch (Exception)
            { }
        }

        public Size GetRecordSize(RecordingStateType type)
        {
            try
            {
                if(this.IsRecording(type) == false)
                    throw new Exception();

                return this._videoRecordTable[type].FrameSize;
            }
            catch (Exception)
            {
                return Size.Zero;
            }
        }
    }
}