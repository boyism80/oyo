﻿using OpenCvSharp;
using System;

namespace oyo
{
    public class OYOVisualizer
    {
        public static float MAX_SCALED_SIZE    = 15.0f;

        /// <summary>
        /// 커스텀 팔레트인 IRON BLACK을 위한 데이터입니다.
        /// 가장 보기 좋은 최적의 팔레트 컬러맵입니다.
        /// </summary>
        private static Mat                      IRON_BLACK_PALETTE   = new Mat(256, 1, MatType.CV_8UC3, new byte[] { 255, 255, 255, 253, 253, 253, 251, 251, 251, 249, 249, 249, 247, 247, 247, 245, 245, 245, 243, 243, 243, 241, 241, 241, 239, 239, 239, 237, 237, 237, 235, 235, 235, 233, 233, 233, 231, 231, 231, 229, 229, 229, 227, 227, 227, 225, 225, 225, 223, 223, 223, 221, 221, 221, 219, 219, 219, 217, 217, 217, 215, 215, 215, 213, 213, 213, 211, 211, 211, 209, 209, 209, 207, 207, 207, 205, 205, 205, 203, 203, 203, 201, 201, 201, 199, 199, 199, 197, 197, 197, 195, 195, 195, 193, 193, 193, 191, 191, 191, 189, 189, 189, 187, 187, 187, 185, 185, 185, 183, 183, 183, 181, 181, 181, 179, 179, 179, 177, 177, 177, 175, 175, 175, 173, 173, 173, 171, 171, 171, 169, 169, 169, 167, 167, 167, 165, 165, 165, 163, 163, 163, 161, 161, 161, 159, 159, 159, 157, 157, 157, 155, 155, 155, 153, 153, 153, 151, 151, 151, 149, 149, 149, 147, 147, 147, 145, 145, 145, 143, 143, 143, 141, 141, 141, 139, 139, 139, 137, 137, 137, 135, 135, 135, 133, 133, 133, 131, 131, 131, 129, 129, 129, 126, 126, 126, 124, 124, 124, 122, 122, 122, 120, 120, 120, 118, 118, 118, 116, 116, 116, 114, 114, 114, 112, 112, 112, 110, 110, 110, 108, 108, 108, 106, 106, 106, 104, 104, 104, 102, 102, 102, 100, 100, 100, 98, 98, 98, 96, 96, 96, 94, 94, 94, 92, 92, 92, 90, 90, 90, 88, 88, 88, 86, 86, 86, 84, 84, 84, 82, 82, 82, 80, 80, 80, 78, 78, 78, 76, 76, 76, 74, 74, 74, 72, 72, 72, 70, 70, 70, 68, 68, 68, 66, 66, 66, 64, 64, 64, 62, 62, 62, 60, 60, 60, 58, 58, 58, 56, 56, 56, 54, 54, 54, 52, 52, 52, 50, 50, 50, 48, 48, 48, 46, 46, 46, 44, 44, 44, 42, 42, 42, 40, 40, 40, 38, 38, 38, 36, 36, 36, 34, 34, 34, 32, 32, 32, 30, 30, 30, 28, 28, 28, 26, 26, 26, 24, 24, 24, 22, 22, 22, 20, 20, 20, 18, 18, 18, 16, 16, 16, 14, 14, 14, 12, 12, 12, 10, 10, 10, 8, 8, 8, 6, 6, 6, 4, 4, 4, 2, 2, 2, 0, 0, 0, 9, 0, 0, 16, 0, 2, 24, 0, 4, 31, 0, 6, 38, 0, 8, 45, 0, 10, 53, 0, 12, 60, 0, 14, 67, 0, 17, 74, 0, 19, 82, 0, 21, 89, 0, 23, 96, 0, 25, 103, 0, 27, 111, 0, 29, 118, 0, 31, 120, 0, 36, 121, 0, 41, 122, 0, 46, 123, 0, 51, 124, 0, 56, 125, 0, 61, 126, 0, 66, 127, 0, 71, 128, 1, 76, 129, 1, 81, 130, 1, 86, 131, 1, 91, 132, 1, 96, 133, 1, 101, 134, 1, 106, 135, 1, 111, 136, 1, 116, 136, 1, 121, 137, 2, 125, 137, 2, 130, 137, 3, 135, 138, 3, 139, 138, 3, 144, 138, 4, 149, 139, 4, 153, 139, 5, 158, 139, 5, 163, 140, 5, 167, 140, 6, 172, 140, 6, 177, 141, 7, 181, 141, 7, 186, 137, 10, 189, 132, 13, 191, 127, 16, 194, 121, 19, 196, 116, 22, 198, 111, 25, 200, 106, 28, 203, 101, 31, 205, 95, 34, 207, 90, 37, 209, 85, 40, 212, 80, 43, 214, 75, 46, 216, 69, 49, 218, 64, 52, 221, 59, 55, 223, 49, 57, 224, 47, 60, 225, 44, 64, 226, 42, 67, 227, 39, 71, 228, 37, 74, 229, 34, 78, 230, 32, 81, 231, 29, 85, 231, 27, 88, 232, 24, 92, 233, 22, 95, 234, 19, 99, 235, 17, 102, 236, 14, 106, 237, 12, 109, 238, 12, 112, 239, 12, 116, 240, 12, 119, 240, 12, 123, 241, 12, 127, 241, 12, 130, 242, 12, 134, 242, 12, 138, 243, 13, 141, 243, 13, 145, 244, 13, 149, 244, 13, 152, 245, 13, 156, 245, 13, 160, 246, 13, 163, 246, 13, 167, 247, 13, 171, 247, 14, 175, 248, 15, 178, 248, 16, 182, 249, 18, 185, 249, 19, 189, 250, 20, 192, 250, 21, 196, 251, 22, 199, 251, 23, 203, 252, 24, 206, 252, 25, 210, 253, 27, 213, 253, 28, 217, 254, 29, 220, 254, 30, 224, 255, 39, 227, 255, 53, 229, 255, 67, 231, 255, 81, 233, 255, 95, 234, 255, 109, 236, 255, 123, 238, 255, 137, 240, 255, 151, 242, 255, 165, 244, 255, 179, 246, 255, 193, 248, 255, 207, 249, 255, 221, 251, 255, 235, 253, 255, 24, 255, 255 });
        private static Mat                      FLIR_DEFAULT_PALETTE = new Mat(256, 1, MatType.CV_8UC3, new byte[] { 0, 0, 0, 7, 0, 0, 24, 0, 0, 38, 0, 0, 46, 0, 0, 52, 0, 0, 59, 0, 0, 66, 0, 0, 73, 0, 0, 80, 0, 0, 85, 0, 1, 89, 0, 2, 93, 0, 3, 97, 0, 4, 101, 0, 5, 104, 0, 6, 108, 0, 8, 112, 0, 10, 116, 0, 11, 118, 0, 13, 119, 0, 15, 121, 0, 17, 123, 0, 20, 126, 0, 24, 128, 0, 27, 130, 0, 30, 133, 0, 33, 135, 0, 36, 136, 0, 40, 138, 0, 43, 139, 0, 47, 141, 0, 50, 142, 0, 53, 144, 0, 56, 145, 0, 59, 146, 0, 62, 148, 0, 64, 149, 0, 66, 150, 0, 69, 150, 0, 72, 150, 0, 75, 151, 0, 78, 151, 0, 81, 152, 0, 83, 152, 0, 87, 153, 0, 90, 154, 0, 93, 155, 0, 96, 155, 0, 99, 155, 0, 102, 155, 0, 105, 156, 0, 108, 156, 0, 111, 157, 0, 113, 157, 0, 115, 157, 0, 119, 157, 0, 122, 157, 0, 125, 157, 0, 128, 157, 0, 130, 157, 0, 133, 157, 0, 136, 157, 0, 138, 157, 0, 141, 156, 0, 144, 156, 0, 147, 155, 0, 150, 155, 0, 153, 155, 0, 155, 155, 0, 157, 155, 0, 160, 155, 0, 162, 155, 0, 164, 154, 0, 167, 154, 0, 169, 153, 0, 171, 153, 0, 172, 152, 1, 174, 152, 1, 176, 151, 1, 177, 151, 1, 179, 150, 2, 181, 149, 2, 183, 149, 3, 184, 149, 4, 185, 148, 5, 187, 147, 5, 188, 146, 5, 190, 146, 6, 191, 145, 7, 192, 144, 8, 193, 143, 9, 194, 142, 11, 195, 141, 12, 196, 140, 13, 197, 138, 14, 199, 136, 16, 200, 134, 18, 201, 133, 19, 202, 131, 20, 203, 129, 22, 205, 127, 23, 206, 124, 25, 207, 121, 26, 208, 119, 27, 209, 116, 29, 210, 114, 31, 211, 112, 33, 212, 108, 34, 213, 104, 36, 214, 101, 38, 215, 98, 40, 216, 95, 42, 217, 92, 45, 218, 87, 47, 219, 82, 48, 220, 77, 49, 221, 71, 51, 222, 65, 53, 223, 60, 55, 224, 54, 56, 224, 49, 58, 225, 43, 60, 226, 37, 62, 227, 32, 63, 228, 28, 65, 228, 26, 67, 229, 24, 69, 230, 21, 71, 230, 19, 73, 231, 17, 75, 232, 15, 76, 232, 13, 77, 233, 12, 78, 234, 11, 80, 235, 10, 82, 235, 9, 84, 235, 8, 86, 236, 8, 88, 236, 7, 90, 237, 6, 91, 237, 5, 92, 238, 5, 94, 238, 4, 95, 239, 4, 97, 239, 3, 99, 240, 3, 101, 240, 3, 102, 241, 3, 103, 241, 2, 105, 241, 2, 106, 241, 1, 108, 241, 1, 109, 242, 1, 111, 242, 1, 113, 243, 1, 114, 243, 0, 116, 244, 0, 117, 244, 0, 119, 244, 0, 121, 244, 0, 124, 245, 0, 126, 245, 0, 128, 246, 0, 130, 246, 0, 131, 247, 0, 133, 247, 0, 135, 248, 0, 136, 248, 0, 137, 248, 0, 139, 248, 0, 140, 248, 0, 142, 249, 0, 143, 249, 0, 144, 249, 0, 146, 249, 0, 148, 250, 0, 150, 250, 0, 152, 251, 0, 155, 251, 0, 157, 252, 0, 159, 252, 0, 161, 253, 0, 163, 253, 0, 166, 253, 0, 168, 253, 0, 170, 253, 0, 172, 253, 0, 174, 253, 0, 175, 254, 0, 177, 254, 0, 178, 254, 0, 180, 254, 0, 183, 254, 0, 185, 254, 0, 186, 254, 0, 188, 254, 0, 189, 254, 0, 191, 254, 0, 193, 254, 0, 195, 254, 0, 197, 254, 0, 199, 254, 0, 200, 254, 1, 202, 254, 1, 203, 254, 2, 204, 254, 3, 206, 254, 4, 207, 254, 6, 209, 254, 8, 211, 254, 10, 213, 254, 11, 215, 254, 12, 216, 254, 14, 218, 255, 16, 219, 255, 19, 220, 255, 23, 221, 255, 27, 222, 255, 31, 224, 255, 35, 225, 255, 38, 227, 255, 42, 228, 255, 48, 229, 255, 53, 230, 255, 60, 231, 255, 65, 233, 255, 71, 234, 255, 77, 235, 255, 83, 237, 255, 89, 238, 255, 96, 239, 255, 102, 239, 255, 109, 240, 255, 115, 241, 255, 124, 241, 255, 132, 242, 255, 139, 243, 255, 146, 244, 255, 153, 244, 255, 160, 245, 255, 168, 245, 255, 175, 246, 255, 181, 247, 255, 187, 248, 255, 193, 248, 255, 198, 249, 255, 204, 249, 255, 210, 250, 255, 216, 251, 255, 222, 252, 255, 227, 253, 255, 232, 253, 255, 237, 254, 255, 243, 254, 255, 247, 255, 255, 249, 255, 255 });

        public Rect VisualCropRect { get; set; }
        public Rect InfraredCropRect { get; set; }


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

        public OYOVisualizer()
        {
            this.StreamingType          = StreamingType.Infrared;
            this.Palette                = "Grayscale";

            this.VisualCropRect = new Rect(new Point(0, 0), new Size(640, 480));
            this.InfraredCropRect = new Rect(new Point(0, 0), new Size(640, 480));
        }

        public Mat mappingPalette(Mat frame)
        {
            lock (this.Palette)
            {
                var ret = new Mat();
                switch (this.Palette)
                {
                    case "Grayscale":
                        ret = frame;
                        break;

                    case "Default":
                        ret = frame.LUT(FLIR_DEFAULT_PALETTE);
                        break;

                    case "IronBlack":
                        ret = frame.LUT(IRON_BLACK_PALETTE);
                        break;

                    default:
                        var ctype = (ColormapTypes)Enum.Parse(typeof(ColormapTypes), this.Palette);
                        Cv2.ApplyColorMap(frame, ret, ctype);
                        break;
                }

                return ret;
            }
        }

        public void markTemperature(Mat frame, OpenCvSharp.Point location, double temperature, Scalar color)
        {
            var fontScaled                   = frame.Width / 400.0f;
            var baseLine                     = 0;
            var text                         = string.Format("{0} 'C", temperature.ToString("N2"));
            var font                         = HersheyFonts.HersheyPlain;
            var textSize                     = Cv2.GetTextSize(text, font, fontScaled, 1, out baseLine);
            var padding                      = new OpenCvSharp.Size(3, 3);
            textSize.Width                  += (padding.Width * 2);
            textSize.Height                 += (padding.Height * 2);

            Cv2.Rectangle(frame, new Rect(location, textSize), color, -1, LineTypes.Link4);
            Cv2.PutText(frame, text, new OpenCvSharp.Point(location.X + padding.Width, location.Y + (textSize.Height - padding.Height)), font, fontScaled, Scalar.White);
        }

        public Mat Crop(Mat source, StreamingType type)
        {
            source = source.Resize(new OpenCvSharp.Size(640, 480));
            if(type == StreamingType.Visual)
                return source.Clone(this.VisualCropRect).Resize(new Size(640, 480));
            else
                return source.Clone(this.InfraredCropRect).Resize(new Size(640, 480));
        }
    }
}