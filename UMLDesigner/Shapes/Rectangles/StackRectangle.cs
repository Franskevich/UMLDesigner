using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLDesigner.Interfaces;

namespace UMLDesigner.Shapes.Rectangles
{
    public class StackRectangle : IRectangle
    {        
        public StackRectangle()
        {
        }
       
        private Graphics _graphics = MyGraphics.GetInstance().GetMainGraphics();
        public Font nameFont = new Font("Arial", 18);

        public void Draw(AbstractRectangle rectangle)
        {

            Color color = rectangle.Color;
            float penWidth = rectangle.PenWidth;
            Point startPoint = rectangle.StartPoint;
            Font argumentFont = rectangle.ArgumentFont;
            string name = rectangle.Name;
            string properties = rectangle.Properties;
            string fields = rectangle.Fields;
            string methods = rectangle.Methods;
            Point size = rectangle.EndPoint;

            Pen _pen = new Pen(color, penWidth);

            int _nameHeight = 30 + ((int)_graphics.MeasureString(name, nameFont).Width / size.X) * ((int)_graphics.MeasureString(name, nameFont).Height + 3);
            int _propertiesHeight = 30 + ((int)_graphics.MeasureString(properties, argumentFont).Width / size.X) * ((int)_graphics.MeasureString(properties, argumentFont).Height + 3);
            int _fieldsHeight = 30 + ((int)_graphics.MeasureString(fields, argumentFont).Width / size.X) * ((int)_graphics.MeasureString(fields, argumentFont).Height + 3);
            int _methodsHeight = 100 + ((int)_graphics.MeasureString(methods, argumentFont).Width / size.X) * ((int)_graphics.MeasureString(methods, argumentFont).Height + 3);
            int bigLineVertical = _nameHeight + _propertiesHeight + _fieldsHeight + _methodsHeight;

            Rectangle _nameRect = new Rectangle(startPoint.X, startPoint.Y, size.X, _nameHeight);
            Rectangle _propertiesRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight, size.X, _propertiesHeight);
            Rectangle _fieldsRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight + _propertiesHeight, size.X, _fieldsHeight);
            Rectangle _methodRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight + _propertiesHeight + _fieldsHeight, size.X, _methodsHeight);

            MyGraphics.GetInstance().GetMainGraphics();
            var currentTmpGraphics = MyGraphics.GetInstance()._graphics;

            currentTmpGraphics.DrawRectangle(_pen, _nameRect);
            currentTmpGraphics.DrawRectangle(_pen, _propertiesRect);
            currentTmpGraphics.DrawRectangle(_pen, _fieldsRect);
            currentTmpGraphics.DrawRectangle(_pen, _methodRect);

            TextDrawing.DrawTextName(_nameRect, nameFont, color, name);
            TextDrawing.DrawText(_propertiesRect, argumentFont, color, properties);
            TextDrawing.DrawText(_fieldsRect, argumentFont, color, fields);
            TextDrawing.DrawText(_methodRect, argumentFont, color, methods);

            
            int smalLineY = 10;
            int indentLastX = 15;
            AddShadowLinesRectangle(_pen, color, penWidth, size, currentTmpGraphics, startPoint, smalLineY, indentLastX, bigLineVertical);
            Point nextPointForLine = new Point((startPoint.X - indentLastX), (startPoint.Y - smalLineY));
            AddShadowLinesRectangle(_pen, color, penWidth, size, currentTmpGraphics, nextPointForLine, smalLineY, indentLastX, bigLineVertical);

            int height = _nameHeight + _propertiesHeight + _fieldsHeight + _methodsHeight;
            rectangle.EndPoint = new Point(rectangle.EndPoint.X, height);

        }

        public void AddShadowLinesRectangle(Pen pen, Color color, float penWidth, Point size, Graphics graphics, Point startPoint, int smalLineY, int indentLastX, int bigLineVertical)
        {
            int smallLineVertical = smalLineY;
            int indentRectangle = indentLastX;
            int bigLineHorizontal = size.X;

            graphics.DrawLine(pen, (startPoint.X + size.X - indentRectangle), (startPoint.Y), (startPoint.X + size.X - indentRectangle), (startPoint.Y - smallLineVertical));
            graphics.DrawLine(pen, (startPoint.X + size.X - indentRectangle), (startPoint.Y - smallLineVertical), (startPoint.X + size.X - indentRectangle - bigLineHorizontal), (startPoint.Y - smallLineVertical));
            graphics.DrawLine(pen, (startPoint.X + size.X - indentRectangle - bigLineHorizontal), (startPoint.Y - smallLineVertical), (startPoint.X + size.X - indentRectangle - bigLineHorizontal), (startPoint.Y - smallLineVertical + bigLineVertical));
            graphics.DrawLine(pen, (startPoint.X + size.X - indentRectangle - bigLineHorizontal), (startPoint.Y - smallLineVertical + bigLineVertical), (startPoint.X + size.X - indentRectangle - bigLineHorizontal + indentRectangle), (startPoint.Y - smallLineVertical + bigLineVertical));
        }
    }
}
