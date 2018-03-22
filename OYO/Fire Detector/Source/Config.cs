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
            json["crop"]["visual"]    = new JSONClass();
            json["crop"]["visual"]["x"] = new JSONData(base.VisualCroppedRect.X);
            json["crop"]["visual"]["y"] = new JSONData(base.VisualCroppedRect.Y);
            json["crop"]["visual"]["width"] = new JSONData(base.VisualCroppedRect.Width);
            json["crop"]["visual"]["height"] = new JSONData(base.VisualCroppedRect.Height);

            //json["crop"]["infrared"]    = new JSONClass();
            //json["crop"]["infrared"]["x"] = new JSONData(base.InfraredCroppedRect.X);
            //json["crop"]["infrared"]["y"] = new JSONData(base.InfraredCroppedRect.Y);
            //json["crop"]["infrared"]["width"] = new JSONData(base.InfraredCroppedRect.Width);
            //json["crop"]["infrared"]["height"] = new JSONData(base.InfraredCroppedRect.Height);

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

                base.VisualCroppedRect  = new OpenCvSharp.Rect(new OpenCvSharp.Point(json["crop"]["visual"]["x"].AsInt, json["crop"]["visual"]["y"].AsInt), new OpenCvSharp.Size(json["crop"]["visual"]["width"].AsInt, json["crop"]["visual"]["height"].AsInt));
                //base.InfraredCroppedRect = new OpenCvSharp.Rect(new OpenCvSharp.Point(json["crop"]["infrared"]["x"].AsInt, json["crop"]["infrared"]["y"].AsInt), new OpenCvSharp.Size(json["crop"]["infrared"]["width"].AsInt, json["crop"]["infrared"]["height"].AsInt));
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
        public Visualizing Visualizer { get; private set; }


        public Config()
        {
            this.Visualizer = new Visualizing();
        }

        public JSONClass ToJson()
        {
            var json                        = new JSONClass();
            json["visualize"]               = this.Visualizer.ToJson();

            return json;
        }

        public bool FromJson(JSONNode json)
        {
            try
            {
                this.Visualizer.FromJson(json["visualize"]);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
