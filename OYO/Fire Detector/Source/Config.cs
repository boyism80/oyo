using oyo;
using SimpleJSON;
using System;

namespace Fire_Detector.Source
{
    public class Blending : OYOBlender
    {
        public bool Enabled { get; set; }

        public int Threshold { get; set; }

        public Blending(OpenCvSharp.Size size, float alpha = 0.5f, bool smooth = true) : base(size, alpha, smooth)
        { }

        public JSONClass ToJson()
        {
            var json                    = new JSONClass();
            json["enabled"]             = new JSONData(this.Enabled);

            json["crop"]                = new JSONClass();
            json["crop"]["x"]           = new JSONData(base.CroppedRect.X);
            json["crop"]["y"]           = new JSONData(base.CroppedRect.Y);
            json["crop"]["width"]       = new JSONData(base.CroppedRect.Width);
            json["crop"]["height"]      = new JSONData(base.CroppedRect.Height);

            json["size"]                = new JSONClass();
            json["size"]["width"]       = new JSONData(base.Size.Width);
            json["size"]["height"]      = new JSONData(base.Size.Height);

            json["transparency"]        = new JSONData(base.Transparency);
            json["smooth"]              = new JSONData(base.Smooth);
            json["threshold"]           = new JSONData(this.Threshold);
            
            return json;
        }

        public bool FromJson(JSONNode json)
        {
            try
            {
                this.Enabled            = json["enabled"].AsBool;

                base.CroppedRect        = new OpenCvSharp.Rect(new OpenCvSharp.Point(json["crop"]["x"].AsInt, json["crop"]["y"].AsInt), new OpenCvSharp.Size(json["crop"]["width"].AsInt, json["crop"]["height"].AsInt));
                base.Size               = new OpenCvSharp.Size(json["size"]["width"].AsInt, json["size"]["height"].AsInt);
                base.Transparency       = json["transparency"].AsFloat;
                base.Smooth             = json["smooth"].AsBool;
                this.Threshold          = json["threshold"].AsInt;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public class Detecting : OYODetector
    {
        public bool Enabled { get; set;}

        public int Threshold { get; set; }

        public JSONClass ToJson()
        {
            var json                    = new JSONClass();
            json["enabled"]             = new JSONData(this.Enabled);
            json["threshold"]           = new JSONData(this.Threshold);

            return json;
        }

        public bool FromJson(JSONNode json)
        {
            try
            {
                this.Enabled            = json["enabled"].AsBool;
                this.Threshold          = json["threshold"].AsInt;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public class Visualizing
    {
        public static float MAX_SCALED_SIZE    = 15.0f;

        public string Palette { get; set; }

        private float _scaled = 1.0f;
        public float Scaled
        {
            get
            {
                return this._scaled;
            }

            set
            {
                this._scaled = Math.Max(1.0f, Math.Min(MAX_SCALED_SIZE, value));
            }
        }

        public StreamingType StreamingType { get; set; }

        public Visualizing()
        {
            this.StreamingType          = StreamingType.Infrared;
            this.Palette                = "Grayscale";
        }

        public JSONClass ToJson()
        {
            var json                    = new JSONClass();
            json["palette"]             = new JSONData(this.Palette);
            json["scaled"]              = new JSONData(this.Scaled);
            json["streaming_type"]      = new JSONData((int)this.StreamingType);

            return json;
        }

        public bool FromJson(JSONNode json)
        {
            try
            {
                this.Palette            = json["palette"].Value;
                this.Scaled             = json["scaled"].AsFloat;
                this.StreamingType      = (StreamingType)json["streaming_type"].AsInt;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public class Config
    {
        public Blending Blender { get; private set; }
        public Detecting Detector { get; private set; }
        public Visualizing Visualizer { get; private set; }


        public Config()
        {
            this.Blender = new Blending(new OpenCvSharp.Size(720, 480));
            this.Detector = new Detecting();
            this.Visualizer = new Visualizing();
        }

        public JSONClass ToJson()
        {
            var json                        = new JSONClass();
            json["visualize"]               = this.Visualizer.ToJson();
            json["detecting"]               = this.Detector.ToJson();
            json["blending"]                = this.Blender.ToJson();

            return json;
        }

        public bool FromJson(JSONNode json)
        {
            try
            {
                this.Visualizer.FromJson(json["visualize"]);
                this.Detector.FromJson(json["detecting"]);
                this.Blender.FromJson(json["blending"]);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
