using OpenCvSharp;
using System;
using System.Collections.Generic;

namespace oyo
{
    public class OYODetector
    {
        public delegate bool isDetectedDelegate(RotatedRect detectedRect);

        //
        // Threshold
        //  엣지 검출에 사용될 임계값입니다.
        //
        private Range _threshold;
        public Range Threshold
        {
            get
            {
                return this._threshold;
            }
            set
            {
                this._threshold = value;
            }
        }

        //
        // DetectedVertices
        //  업데이트된 이후 검출된 정점들입니다.
        //
        private Point[][] DetectedVertices
        {
            get
            {
                if(this._detectedRects == null)
                    return null;

                var ret = new Point[this._detectedRects.Count][];
                for (var i1 = 0; i1 < this._detectedRects.Count; i1++)
                {
                    var points2f = this._detectedRects[i1].Points();
                    ret[i1] = new Point[points2f.Length];

                    for (var i2 = 0; i2 < points2f.Length; i2++)
                        ret[i1][i2] = points2f[i2];
                }

                return ret;
            }
        }

        //
        // DetectedRects
        //  업데이트된 이후에 검출된 영역들입니다.
        //
        private List<RotatedRect> _detectedRects = new List<RotatedRect>();
        public RotatedRect[] DetectedRects
        {
            get
            {
                return this._detectedRects.ToArray();
            }
        }

        public OYODetector()
        {
            this.Threshold = new Range(50, 100);
        }

        public OYODetector(Range threshold)
        {
            this.Threshold = threshold;
        }

        //
        // Update
        //  프레임과 마스크를 업데이트하여 검출상태를 갱신합니다.
        //  
        // Parameters
        //  source              영역 검출을 위한 행렬입니다.
        //                      이 변수의 엣지를 검출한 뒤에 영역을 구하기 때문에 잡음이 없는 마스크 형식이 가장 이상적입니다.
        //
        public void Update(Mat source, isDetectedDelegate callback)
        {
            if (source.Type() != MatType.CV_8UC1)
				source.ConvertTo(source, MatType.CV_8UC1);

            this._detectedRects.Clear();

            var edged           = source.Canny(this.Threshold.Start, this.Threshold.End).Dilate(null).Erode(null);
            var cnts            = null as Point[][];
            var hierarchy       = null as HierarchyIndex[];

            edged.FindContours(out cnts, out hierarchy, RetrievalModes.External, ContourApproximationModes.ApproxSimple);
            foreach (var c in cnts)
            {
                if (Cv2.ContourArea(c) < 100)
                    continue;

                var detectedRect = Cv2.MinAreaRect(c);
                if(callback(detectedRect) == false)
                    continue;

                this._detectedRects.Add(detectedRect);
            }
        }

        //
        // DrawDetectedRects
        //  검출된 영역을 이미지에 표시합니다.
        //
        // Parameters
        //  frame               표시할 이미지
        //
        // Return
        //  표시된 이미지를 리턴합니다.
        //
        public Mat DrawDetectedRects(Mat frame)
        {
            var vertices = this.DetectedVertices;
            if(vertices == null)
                return null;

            var ret = frame.Clone();
            Cv2.DrawContours(ret, vertices, -1, Scalar.Lime, 2);

            return ret;
        }
    }
}