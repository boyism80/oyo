using System.Drawing;

namespace oyo
{
    public class OYODrag
    {
        public bool IsDragging { get; private set; }
        public Point BeginPoint { get; private set; }
        public Point EndPoint { get; private set; }

        public OYODrag()
        { }

        public bool Begin(int x, int y)
        {
            if(this.IsDragging)
                return false;

            this.BeginPoint = new Point(x, y);
            this.IsDragging = true;
            return true;
        }

        public bool End(int x, int y, out Point moved)
        {
            if (this.IsDragging == false)
            {
                moved = new Point();
                return false;
            }

            this.EndPoint = new Point(x, y);
            moved = new Point(this.EndPoint.X- this.BeginPoint.X, this.EndPoint.Y - this.BeginPoint.Y);
            this.IsDragging = false;
            
            return true;
        }

        public bool Move(int x, int y, out Point moved)
        {
            if (this.IsDragging == false)
            {
                moved = Point.Empty;
                return false;
            }

            moved = new Point(x - this.BeginPoint.X, y - this.BeginPoint.Y);
            return true;
        }
    }
}