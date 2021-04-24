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
    public class DelegateRectangle : IRectangle
    {     
        public DelegateRectangle()
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

            DrawTextName(nameRect, nameFont, color, name);
            DrawText(methodRect, argumentFont, color, methods);           
        }
        public void DrawTextName(Rectangle nameRect, Font nameFont, Color color, string name)
        {
            SolidBrush brush = new SolidBrush(color);

            MyGraphics.GetInstance().GetMainGraphics();
            Graphics currentTmpGraphics = MyGraphics.GetInstance()._graphics;

            StringFormat stringFormat = new StringFormat();
            currentTmpGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            currentTmpGraphics.DrawString(name, nameFont, brush, nameRect, stringFormat);
        }
        public void DrawText(Rectangle rectangle, Font font, Color color, string text)
        {
            MyGraphics.GetInstance().GetMainGraphics();

            Graphics currentTmpGraphics = MyGraphics.GetInstance()._graphics;

            StringFormat _stringFormat = new StringFormat();
            currentTmpGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            _stringFormat.Alignment = StringAlignment.Near;
            _stringFormat.LineAlignment = StringAlignment.Near;

            currentTmpGraphics.DrawString(text, font, new SolidBrush(color), rectangle, _stringFormat);
        }
    }
}
