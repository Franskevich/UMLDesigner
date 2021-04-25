using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLDesigner.Interfaces;

namespace UMLDesigner.Shapes.Rectangles
{
    public class StructureRectangle : IRectangle
    {
        private int _nameHeight;
        private int _propertiesHeight;
        private int _fieldsHeight;
        private int _methodsHeight;
        public Font nameFont = new Font("Arial", 18);
        Graphics graphics = MyGraphics.GetInstance().GetMainGraphics();

        public StructureRectangle()
        {
        }

        public void Draw(Color color, float penWidth, Point startPoint, Point size, Font argumentFont, string name, string properties, string fields, string methods)
        {
            Pen pen = new Pen(color, penWidth);

            _nameHeight = 30 + ((int)graphics.MeasureString(name, nameFont).Width / size.X) * ((int)graphics.MeasureString(name, nameFont).Height + 3);
            _propertiesHeight = 30 + (1 + (int)graphics.MeasureString(properties, argumentFont).Width / size.X) * ((int)graphics.MeasureString(properties, argumentFont).Height + 3);
            _fieldsHeight = 30 + (1 + (int)graphics.MeasureString(fields, argumentFont).Width / size.X) * ((int)graphics.MeasureString(fields, argumentFont).Height + 3);
            _methodsHeight = 90 + (0 + (int)graphics.MeasureString(methods, argumentFont).Width / (size.X)) * ((int)graphics.MeasureString(methods, argumentFont).Height + 3);

            Rectangle _nameRect = new Rectangle(startPoint.X, startPoint.Y, size.X, _nameHeight);
            Rectangle _propertiesRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight, size.X, _propertiesHeight);
            Rectangle _fieldsRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight + _propertiesHeight, size.X, _fieldsHeight);
            Rectangle _methodRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight + _propertiesHeight + _fieldsHeight, size.X, _methodsHeight);

            MyGraphics.GetInstance().GetMainGraphics();
            var currentTmpGraphics = MyGraphics.GetInstance()._graphics;

            currentTmpGraphics.DrawRectangle(pen, _nameRect);
            currentTmpGraphics.DrawRectangle(pen, _propertiesRect);
            currentTmpGraphics.DrawRectangle(pen, _fieldsRect);
            currentTmpGraphics.DrawRectangle(pen, _methodRect);

            TextDrawing.DrawTextName(_nameRect, nameFont, color, name);
            TextDrawing.DrawText(_propertiesRect, argumentFont, color, properties);
            TextDrawing.DrawText(_fieldsRect, argumentFont, color, fields);
            TextDrawing.DrawText(_methodRect, argumentFont, color, methods);
        }
    }
}
