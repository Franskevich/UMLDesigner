using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLDesigner
{
    public class ImplementationsArrow : IArrow
    {
        public ImplementationsArrow()
        {
        }

        public void Draw(Color color, int penWidth, Point startPoint, Point endPoint)
        {
            int width = 15;
            int height = 24;

            Pen penArrow = new Pen(color, penWidth);
            var currentTmpGraphics = MyGraphics.GetInstance()._graphics;

            if (endPoint.X > startPoint.X)
            {
                Point[] curvePoints = { new Point(endPoint.X - height, endPoint.Y - width), endPoint, new Point(endPoint.X - height, endPoint.Y + width) };
                currentTmpGraphics.DrawPolygon(penArrow, curvePoints);
            }
            else
            {
                Point[] curvePoints = { new Point(endPoint.X + height, endPoint.Y - width), endPoint, new Point(endPoint.X + height, endPoint.Y + width) };
                currentTmpGraphics.DrawPolygon(penArrow, curvePoints);
            }

        }
    }
}