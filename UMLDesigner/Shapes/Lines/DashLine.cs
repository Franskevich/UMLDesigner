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

            List<Point> points = new List<Point>();
            points.Add(startPoint);
            points.Add(insidePoint1);
            points.Add(insidePoint2);
            points.Add(endPoint);
            currentTmpGraphics.DrawLines(penDash, points.ToArray());


        }

    }
}
