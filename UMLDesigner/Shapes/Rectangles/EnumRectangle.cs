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
    public class EnumRectangle : IRectangle
    {
        
        public EnumRectangle()
        {
            
        }
        
        Graphics graphics = MyGraphics.GetInstance().GetMainGraphics();
        public Font nameFont = new Font("Arial", 18);

        public void Draw(Color color, float penWidth, Point startPoint, Point size, Font argumentFont, string name, string properties, string fields, string methods)
        {
            Pen _pen = new Pen(color, penWidth);

            int _nameHeight = 30 + ((int)graphics.MeasureString(name, nameFont).Width / size.X) * ((int)graphics.MeasureString(name, nameFont).Height + 3);
            int _methodsHeight = 100 + ((int)graphics.MeasureString(methods, argumentFont).Width / size.X) * ((int)graphics.MeasureString(methods, argumentFont).Height + 3);


            Rectangle nameRect = new Rectangle(startPoint.X, startPoint.Y, size.X, _nameHeight);
            Rectangle methodRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight, size.X, _methodsHeight);

            MyGraphics.GetInstance().GetMainGraphics();
            Graphics currentTmpGraphics = MyGraphics.GetInstance()._graphics;

            currentTmpGraphics.DrawRectangle(_pen, nameRect);
            currentTmpGraphics.DrawRectangle(_pen, methodRect);

            TextDrawing.DrawTextName(nameRect, nameFont, color, name);
            TextDrawing.DrawText(methodRect, argumentFont, color, methods);

            //if (isRollUp == true)
            //{
            //    line = 1;
            //}
            //Pen pen = new Pen(color, penWidth);
            //SolidBrush drawBrush = new SolidBrush(Color.Black);

            //StringFormat drawFormat = new StringFormat();
            //drawFormat.Alignment = StringAlignment.Center;
            //drawFormat.LineAlignment = StringAlignment.Center;

            //_nameRect = new Rectangle(startPoint.X, startPoint.Y, size.X, _nameHeight);
            //_otherHeight = size.Y - _nameHeight;
            //_otherRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight, size.X, _otherHeight);


            //var currentTmpGraphics = MyGraphics.GetInstance()._graphics;


            //currentTmpGraphics.DrawRectangle(pen, _nameRect);
            //currentTmpGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            //currentTmpGraphics.DrawString(Name, nameFont, drawBrush, new RectangleF(_nameRect.X, _nameRect.Y + _nameRect.Height / 4, _nameRect.Width, _nameRect.Height / 2), drawFormat);
            //if (line > 1)
            //{
            //    drawFormat.Alignment = StringAlignment.Near;
            //    if (Other.Count >= 1)
            //    {
            //        if (_otherHeight > Other.Count * 25)
            //        {
            //            currentTmpGraphics.DrawRectangle(pen, _otherRect);
            //        }
            //        else
            //        {
            //            _otherHeight = 25 * Other.Count;
            //            _otherRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight, size.X, _otherHeight);
            //            currentTmpGraphics.DrawRectangle(pen, _otherRect);
            //        }
            //        int tempY = 0;
            //        foreach (string s in Other)
            //        {
            //            Rectangle tmpRect = new Rectangle(startPoint.X, _otherRect.Y + tempY, size.X, 25);
            //            currentTmpGraphics.DrawString(s, argumentFont, drawBrush, tmpRect, drawFormat);
            //            tempY = tempY + 25;
            //        }
            //    }
            //    else
            //    {
            //        if (size.Y <= _nameHeight + 25)
            //        {
            //            _otherHeight = 25;
            //        }
            //        else
            //        {
            //            _otherHeight = size.Y - _nameHeight;
            //        }
            //        _otherRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight, size.X, _otherHeight);
            //        currentTmpGraphics.DrawRectangle(pen, _otherRect);
            //    }
            //    Height = _nameHeight + _otherHeight;
            //}
        }
    }
}
