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
    public class ClassRectangle : IRectangle
    {      
        public Font nameFont = new Font("Arial", 18);
        Graphics graphics = MyGraphics.GetInstance().GetMainGraphics();

        public ClassRectangle()
        {
        }

        public void Draw(Color color, float penWidth, Point startPoint, Point size, Font argumentFont, string name, string properties, string fields, string methods)
        {
            Pen _pen = new Pen(color, penWidth);

            int _nameHeight = 30 + ((int)graphics.MeasureString(name, nameFont).Width/size.X) *((int)graphics.MeasureString(name, nameFont).Height+3);
            int _propertiesHeight = 30 + ((int)graphics.MeasureString(properties, argumentFont).Width / size.X) * ((int)graphics.MeasureString(properties, argumentFont).Height + 3);
            int _fieldsHeight = 30 + ((int)graphics.MeasureString(fields, argumentFont).Width / size.X) * ((int)graphics.MeasureString(fields, argumentFont).Height + 3);
            int _methodsHeight = 90 + ((int)graphics.MeasureString(methods, argumentFont).Width / size.X) * ((int)graphics.MeasureString(methods, argumentFont).Height + 3);

            Rectangle _nameRect = new Rectangle(startPoint.X, startPoint.Y, size.X , _nameHeight);
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
        }

        //public void Draw(Color color, float penWidth, Point startPoint, Point size, int line, Font nameFont, Font argumentFont)
        //{
        //    if (isRollUp == true)
        //    {
        //        line = 1;
        //    }
        //    Pen pen = new Pen(color, penWidth);
        //    SolidBrush drawBrush = new SolidBrush(Color.Black);

        //    StringFormat drawFormat = new StringFormat();
        //    drawFormat.Alignment = StringAlignment.Center;
        //    drawFormat.LineAlignment = StringAlignment.Center;

        //    _nameRect = new Rectangle(startPoint.X, startPoint.Y, size.X, _nameHeight);
        //    _fieldsRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight, size.X, _fieldsHeight);
        //    _propetiesRect = new Rectangle(startPoint.X, _fieldsRect.Y + _fieldsHeight, size.X, _propertiesHeight);
        //    _otherHeight = size.Y - _nameHeight - _fieldsHeight - _propertiesHeight;
        //    _otherRect = new Rectangle(startPoint.X, _propetiesRect.Y + _propertiesHeight, size.X, _otherHeight);

        //    MyGraphics.GetInstance().GetMainGraphics();
        //    var currentTmpGraphics = MyGraphics.GetInstance()._graphics;

        //    currentTmpGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        //    currentTmpGraphics.DrawRectangle(pen, _nameRect);
        //    currentTmpGraphics.DrawString(Name, nameFont, drawBrush, _nameRect, drawFormat);

        //    if (line > 1)
        //    {
        //        drawFormat.Alignment = StringAlignment.Near;
        //        if (Fields.Count >= 1)
        //        {
        //            _fieldsHeight = 25 * Fields.Count;
        //            _fieldsRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight, size.X, _fieldsHeight);
        //            currentTmpGraphics.DrawRectangle(pen, _fieldsRect);
        //            int tempY = 0;
        //            foreach (string s in Fields)
        //            {
        //                Rectangle tmpRect = new Rectangle(startPoint.X, _fieldsRect.Y + tempY, size.X, 25);
        //                currentTmpGraphics.DrawString(s, argumentFont, drawBrush, tmpRect, drawFormat);
        //                tempY = tempY + 25;
        //            }
        //        }
        //        else
        //        {
        //            currentTmpGraphics.DrawRectangle(pen, _fieldsRect);
        //        }
        //    }
        //    if (line > 2)
        //    {
        //        if (Properties.Count >= 1)
        //        {
        //            _propertiesHeight = 25 * Properties.Count;
        //            _propetiesRect = new Rectangle(startPoint.X, _fieldsRect.Y + _fieldsHeight, size.X, _propertiesHeight);
        //            currentTmpGraphics.DrawRectangle(pen, _propetiesRect);
        //            int tempY = 0;
        //            foreach (string s in Properties)
        //            {
        //                Rectangle tmpRect = new Rectangle(startPoint.X, _propetiesRect.Y + tempY, size.X, 25);
        //                currentTmpGraphics.DrawString(s, argumentFont, drawBrush, tmpRect, drawFormat);
        //                tempY = tempY + 25;
        //            }
        //        }
        //        else
        //        {
        //            _propetiesRect = new Rectangle(startPoint.X, _fieldsRect.Y + _fieldsHeight, size.X, _propertiesHeight);
        //            currentTmpGraphics.DrawRectangle(pen, _propetiesRect);
        //        }
        //    }
        //    if (line > 3)
        //    {
        //        if (Other.Count >= 1)
        //        {
        //            if (_otherHeight > Other.Count * 25)
        //            {
        //                currentTmpGraphics.DrawRectangle(pen, _otherRect);
        //            }
        //            else
        //            {
        //                _otherHeight = 25 * Other.Count;
        //                _otherRect = new Rectangle(startPoint.X, _propetiesRect.Y + _propertiesHeight, size.X, _otherHeight);
        //                currentTmpGraphics.DrawRectangle(pen, _otherRect);
        //            }
        //            if (Other.Count > 1)
        //            {
        //                int tempY = 0;
        //                foreach (string s in Other)
        //                {
        //                    Rectangle tmpRect = new Rectangle(startPoint.X, _otherRect.Y + tempY, size.X, 25);
        //                    currentTmpGraphics.DrawString(s, argumentFont, drawBrush, tmpRect, drawFormat);
        //                    tempY = tempY + 25;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            if (size.Y <= _nameHeight + _fieldsHeight + _propertiesHeight + 25)
        //            {
        //                _otherHeight = 25;
        //            }
        //            else
        //            {
        //                _otherHeight = size.Y - _nameHeight - _fieldsHeight - _propertiesHeight;
        //            }
        //            _otherRect = new Rectangle(startPoint.X, _propetiesRect.Y + _propertiesHeight, size.X, _otherHeight);
        //            currentTmpGraphics.DrawRectangle(pen, _otherRect);
        //        }
        //        Height = _nameHeight + _fieldsHeight + _propertiesHeight + _otherHeight;
        //    }
        //}




    }
}
