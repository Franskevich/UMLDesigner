using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLDesigner
{
    public class DashLine : ILine
    {
        public DashLine()
        {
        }

        public void Draw(Color color, int penWidth, Point startPoint, Point insidePoint1, Point insidePoint2, Point endPoint)
        {
            int height = 24;

            Pen penDash = new Pen(color, penWidth);
            var currentTmpGraphics = MyGraphics.GetInstance()._graphics;

            float[] dashPattern = new float[2] { 5f, 5f };
            penDash.DashPattern = dashPattern;

            if (endPoint.X > startPoint.X)
            {
                currentTmpGraphics.DrawLines(penDash, GetPoints(height).ToArray());
            }
            else
            {
                currentTmpGraphics.DrawLines(penDash, GetPoints(-height).ToArray());
            }

            List<Point> GetPoints(int endLineCutter = 0, int startLineCutter = 0)
            {
                List<Point> points = new List<Point>();

                points.Add(new Point(startPoint.X - startLineCutter, startPoint.Y));
                int middleX = (startPoint.X + endPoint.X) / 2;
                points.Add(new Point(middleX, startPoint.Y));
                points.Add(new Point(middleX, endPoint.Y));
                points.Add(new Point(endPoint.X - endLineCutter, endPoint.Y));
                return points;
            }
        }

    }
}
