using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLDesigner
{
    public class NormalLine : ILine
    {
        public NormalLine()
        {}
        public void Draw(Color color, int penWidth, Point startPoint, Point insidePoint1, Point insidePoint2, Point endPoint)
        {
            int width = 15;
            int height = 24;

            var currentTmpGraphics = MyGraphics.GetInstance()._graphics;

            Pen pen = new Pen(color, penWidth);

            if (endPoint.X > startPoint.X)
            {
                //Point[] curvePoints = { new Point(EndPoint.X - height, EndPoint.Y - width), EndPoint, new Point(EndPoint.X - height, EndPoint.Y + width) };
                //graphics.DrawPolygon(pen, curvePoints);
                List<Point> points = new List<Point>();
                points.Add(startPoint);
                points.Add(insidePoint1);
                points.Add(insidePoint2);
                points.Add(endPoint);

                currentTmpGraphics.DrawLines(pen, points.ToArray());
            }
            else
            {
                //Point[] curvePoints = { new Point(EndPoint.X + height, EndPoint.Y - width), EndPoint, new Point(EndPoint.X + height, EndPoint.Y + width) };
                //graphics.DrawPolygon(pen, curvePoints);
                currentTmpGraphics.DrawLines(pen, AbstractPointer.GetPoints(startPoint, endPoint).ToArray());
            }
        }
    }
}
