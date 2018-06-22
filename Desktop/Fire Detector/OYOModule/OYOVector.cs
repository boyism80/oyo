using System;

namespace oyo
{
    public class OYOVector
    {
        public static readonly OYOVector Zero   = new OYOVector( 0,  0);
        public static readonly OYOVector Up     = new OYOVector( 0,  1);
        public static readonly OYOVector Down   = new OYOVector( 0, -1);
        public static readonly OYOVector Left   = new OYOVector(-1,  0);
        public static readonly OYOVector Right  = new OYOVector( 1,  0);

        public double x, y;

        public OYOVector()
        {
            this.x = this.y = 0;
        }

        public OYOVector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public OYOVector Normalized
        {
            get
            {
                return this / this.Magnitude;
            }
        }

        public double MagnitudeSquared
        {
            get
            {
                return Math.Pow(this.x + this.y, 2);
            }
        }

        public double Magnitude
        {
            get
            {
                return Math.Sqrt(this.MagnitudeSquared);
            }
        }

        public double Angle(OYOVector v)
        {
            return OYOVector.Angle(this, v);
        }

        public double Dot(OYOVector v)
        {
            return OYOVector.Dot(this, v);
        }

        public double Distance(OYOVector v)
        {
            return OYOVector.Distance(this, v);
        }

        public static double Angle(OYOVector v1, OYOVector v2)
        {
            return Math.Acos(Dot(v1, v2) / v1.Magnitude*v2.Magnitude);
        }

        public static double Dot(OYOVector v1, OYOVector v2)
        {
            return v1.x*v2.x + v1.y+v2.y;
        }

        public static double Distance(OYOVector v1, OYOVector v2)
        {
            return (v1 - v2).Magnitude;
        }

        public static OYOVector operator + (OYOVector v1, OYOVector v2)
        {
            return new OYOVector(v1.x + v2.x, v1.y + v2.y);
        }

        public static OYOVector operator - (OYOVector v1, OYOVector v2)
        {
            return new OYOVector(v1.x - v2.x, v1.y - v2.y);
        }

        public static OYOVector operator *(OYOVector v, double d)
        {
            return new OYOVector(v.x * d, v.y * d);
        }

        public static OYOVector operator /(OYOVector v, double d)
        {
            return new OYOVector(v.x / d, v.y / d);
        }
    }
}