using System;

namespace Fire_Detector.Source
{
    public class Config
    {
        public class BlendingConfig
        {
            public bool Enabled { get; set; }
        }

        public class DetectingConfig
        {
            public bool Enabled { get; set;}
        }

        public class VisualizeConfig
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

            public VisualizeConfig()
            {
            }
        }

        public BlendingConfig Blending { get; private set; }
        public DetectingConfig Detecting { get; private set; }
        public VisualizeConfig Visualize { get; private set; }
        public Config()
        {
            this.Blending = new BlendingConfig();
            this.Detecting = new DetectingConfig();
            this.Visualize = new VisualizeConfig();
        }
    }
}
