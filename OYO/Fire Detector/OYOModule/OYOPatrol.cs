using BebopCommandSet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace oyo
{
    public class PatrolElement
    {
        public int ElapsedTime { get; private set; }
        public Pcmd Command { get; private set; }

        public PatrolElement(int elapsedTime, Pcmd command)
        {
            this.ElapsedTime = elapsedTime;
            this.Command = new Pcmd(command);
        }

        public byte[] ToBytes()
        {
            var buffer = new byte[sizeof(float) + sizeof(int) * 5];
            using (var writer = new BinaryWriter(new MemoryStream(buffer)))
            {
                writer.Write(this.ElapsedTime);
                writer.Write(this.Command.pitch);
                writer.Write(this.Command.yaw);
                writer.Write(this.Command.roll);
                writer.Write(this.Command.gaz);
                writer.Write(this.Command.flag);
            }

            return buffer;
        }

        public override string ToString()
        {
            return string.Format("elapsed time : {0}\ncommand : {1}", this.ElapsedTime, this.Command);
        }
    }


    public class OYOPatrolWriter
    {
        private FileStream _fstream;
        private Stopwatch _stopwatch = new Stopwatch();
        private Pcmd _last_Pcmd = null;

        public Queue<PatrolElement> PatrolElementQueue { get; private set; }

        public bool Recording
        {
            get
            {
                return this._fstream != null;
            }
        }


        public bool StartRecord(string filename)
        {
            if(this.Recording == true)
                return false;

            this.PatrolElementQueue = new Queue<PatrolElement>();
            this._fstream = File.Open(filename, FileMode.Create);
            return true;
        }

        public void StopRecord()
        {
            if(this.Recording == false)
                return;

            this.Write(new Pcmd());

            using (var writer = new BinaryWriter(this._fstream))
            {
                writer.Write(this.PatrolElementQueue.Count);
                foreach (var element in this.PatrolElementQueue)
                {
                    writer.Write(element.ToBytes());
                }
            }

            this.PatrolElementQueue.Clear();
            this._last_Pcmd = null;
            this._stopwatch.Reset();

            this._fstream.Close();
            this._fstream = null;
        }

        public bool Write(Pcmd Pcmd)
        {
            if(this.Recording == false)
                return false;

            if(this._last_Pcmd != null && this._last_Pcmd.Equals(Pcmd))
                return false;

            if(this._last_Pcmd != null)
            {
                this._stopwatch.Stop();
                var element = new PatrolElement((int)this._stopwatch.ElapsedMilliseconds, this._last_Pcmd);

                this.PatrolElementQueue.Enqueue(element);
            }

            this._last_Pcmd = new Pcmd(Pcmd);
            this._stopwatch.Reset();
            this._stopwatch.Start();
            return true;
        }
    }

    public class OYOPatrolReader
    {
        //private Queue<PatrolElement> _patrol_element_queue = new Queue<PatrolElement>();
        private PatrolElement[] _patrol_elements;

        public delegate void ChangedEvent(Pcmd Pcmd);
        public delegate void ExitEvent();

        public event ChangedEvent OnChanged;
        public event ExitEvent OnExit;

        public bool Patroling { get; private set; }

        public OYOPatrolReader()
        { }

        public bool StartPatrol(string filename)
        {
            try
            {
                if (this.Patroling)
                    throw new Exception("cannot load patrol file while patroling");

                var fstream = File.Open(filename, FileMode.Open);
                using (var reader = new BinaryReader(fstream))
                {
                    var count = reader.ReadInt32();
                    this._patrol_elements = new PatrolElement[count];
                    for(var i = 0; i < count; i++)
                    {
                        var elapsed_time = reader.ReadInt32();
                        var Pcmd = new Pcmd(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
                        this._patrol_elements[i] = new PatrolElement(elapsed_time, Pcmd);
                    }
                }
                this.Patroling = true;

                var thread = new Thread(this.InterruptThreadRoutine);
                thread.Start();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public void StopPatrol()
        {
            if(this.Patroling == false)
                return;

            this.Patroling = false;
            this._patrol_elements = null;
        }

        private void InterruptThreadRoutine()
        {
            var reversed = this._patrol_elements.Clone() as PatrolElement[];
            Array.Reverse(reversed);
            while (this.Patroling)
            {
                foreach (var element in this._patrol_elements)
                {
                    if (this.Patroling == false)
                        break;

                    if (this.OnChanged != null)
                        this.OnChanged.Invoke(element.Command);

                    Console.WriteLine(element);
                    Thread.Sleep(element.ElapsedTime);
                }

                foreach (var element in reversed)
                {
                    if (this.Patroling == false)
                        break;

                    if (this.OnChanged != null)
                        this.OnChanged.Invoke(element.Command.Reversed);

                    Console.WriteLine(element);
                    Thread.Sleep(element.ElapsedTime);
                }
            }

            if(this.OnExit != null)
                this.OnExit.Invoke();
        }
    }
}
