using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLDesigner.Interfaces;

namespace UMLDesigner.Shapes.Arrows
{
    public class CompositionSecondArrow : IArrow
    {
        public CompositionSecondArrow()
        { }

        public void Draw(Color color, int penWidth, Point startPoint, Point endPoint)
        {
            int width = 15;
            int height = 24;

            Pen pen = new Pen(color, penWidth);
            var currentTmpGraphics = MyGraphics.GetInstance()._graphics;

            if (endPoint.X > startPoint.X)
            {
                Point[] curvePoints = { new Point(endPoint.X - height, endPoint.Y - width), endPoint, new Point(endPoint.X - height, endPoint.Y + width) };
                currentTmpGraphics.DrawLines(pen, curvePoints);

                Point[] rhombusPoints = { startPoint, new Point(startPoint.X + height, startPoint.Y - width), new Point(startPoint.X + 2 * height, startPoint.Y), new Point(startPoint.X + height, startPoint.Y + width) };
                currentTmpGraphics.FillPolygon(new SolidBrush(Color.Black), rhombusPoints);
                currentTmpGraphics.DrawPolygon(pen, rhombusPoints);
            }
            else
            {
                Point[] curvePoints = { new Point(endPoint.X + height, endPoint.Y - width), endPoint, new Point(endPoint.X + height, endPoint.Y + width) };
                currentTmpGraphics.DrawLines(pen, curvePoints);

                Point[] rhombusPoints = { startPoint, new Point(startPoint.X - height, startPoint.Y - width), new Point(startPoint.X - 2 * height, startPoint.Y), new Point(startPoint.X - height, startPoint.Y + width) };
                currentTmpGraphics.FillPolygon(new SolidBrush(Color.Black), rhombusPoints);
                currentTmpGraphics.DrawPolygon(pen, rhombusPoints);
            }
        }
    }
}
