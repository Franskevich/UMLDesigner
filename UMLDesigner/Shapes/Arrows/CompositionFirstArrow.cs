﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLDesigner.Shapes.Arrows
{
    public class CompositionFirstArrow : IArrow
    {
        public CompositionFirstArrow()
        {}

        public void Draw(Color color, int penWidth, Point startPoint, Point endPoint)
        {
            int width = 15;
            int height = 24;

            Pen pen = new Pen(color, penWidth);
            var currentTmpGraphics = MyGraphics.GetInstance()._graphics;

            if (endPoint.X > startPoint.X)
            {
                Point[] curvePoints = { new Point(endPoint.X - 2 * height, endPoint.Y), new Point(endPoint.X - height, endPoint.Y - width), endPoint, new Point(endPoint.X - height, endPoint.Y + width) };
                currentTmpGraphics.FillPolygon(new SolidBrush(color), curvePoints);
                currentTmpGraphics.DrawPolygon(pen, curvePoints);
            }
            else
            {
                Point[] curvePoints = { new Point(endPoint.X + height, endPoint.Y - width), endPoint, new Point(endPoint.X + height, endPoint.Y + width), new Point(endPoint.X + 2 * height, endPoint.Y) };

                currentTmpGraphics.FillPolygon(new SolidBrush(color), curvePoints);
                currentTmpGraphics.DrawPolygon(pen, curvePoints);
            }
        }
    }
}
