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

        public delegate void                    StartEvent(RecordingStateType type);
        public delegate void                    StopEvent(RecordingStateType type);
        public delegate void                    RecordedEvent(RecordingStateType type, Mat frame, int count);
        public delegate void                    IncreasedTimeEvent(RecordingStateType type, int count, int seconds);
        


        private Dictionary<RecordingStateType, VideoWriter> _videoRecordTable = new Dictionary<RecordingStateType, VideoWriter>();
        private Dictionary<RecordingStateType, int> _recordedFrameCountTable = new Dictionary<RecordingStateType, int>();


        public event StartEvent                 OnStart;
        public event StopEvent                  OnStop;
        public event RecordedEvent              OnRecorded;
        public event IncreasedTimeEvent         OnIncreasedTime;

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
            this._videoRecordTable.Add(RecordingStateType.Blending, new VideoWriter());
            this._videoRecordTable.Add(RecordingStateType.Display, new VideoWriter());

            this._recordedFrameCountTable.Add(RecordingStateType.Infrared, 0);
            this._recordedFrameCountTable.Add(RecordingStateType.Visual, 0);
            this._recordedFrameCountTable.Add(RecordingStateType.Blending, 0);
            this._recordedFrameCountTable.Add(RecordingStateType.Display, 0);
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

                var success = this._videoRecordTable[type].IsOpened();
                if(success && this.OnStart != null)
                    this.OnStart.Invoke(type);

                return success;
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
                    this._recordedFrameCountTable[type] = 0;
                    if(this.OnStop != null)
                        this.OnStop.Invoke(type);
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
            foreach(var type in this._videoRecordTable.Keys)
                this.Stop(type);
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
                    this._recordedFrameCountTable[type]++;

                    if (this.OnRecorded != null)
                        this.OnRecorded.Invoke(type, frame, this._recordedFrameCountTable[type]);

                    var seconds = this._recordedFrameCountTable[type] / (int)this._videoRecordTable[type].Fps;
                    var mod = this._recordedFrameCountTable[type] % (int)this._videoRecordTable[type].Fps;
                    if(this.OnIncreasedTime != null && mod == 0)
                        this.OnIncreasedTime.Invoke(type, this._recordedFrameCountTable[type], seconds);
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