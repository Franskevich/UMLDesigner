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
            Pen pen = new Pen(color, penWidth);
            Graphics currentTmpGraphics = MyGraphics.GetInstance()._graphics;

            List<Point> points = new List<Point>();
            points.Add(startPoint);
            points.Add(insidePoint1);
            points.Add(insidePoint2);
            points.Add(endPoint);
            currentTmpGraphics.DrawLines(pen, points.ToArray());
        }
    }
}
