using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLDesigner
{
    public class TextDrawing
    {
        public static void DrawTextName(Rectangle nameRect, Font nameFont, Color color, string name)
        {
            Brush brush = Brushes.Black;
            MyGraphics.GetInstance().GetMainGraphics();
            Graphics currentTmpGraphics = MyGraphics.GetInstance()._graphics;
            StringFormat stringFormat = new StringFormat();
            currentTmpGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            currentTmpGraphics.DrawString(name, nameFont, brush, nameRect, stringFormat);
        }

        public static void DrawText(Rectangle rectangle, Font font, Color color, string text)
        {
            MyGraphics.GetInstance().GetMainGraphics();
            Graphics currentTmpGraphics = MyGraphics.GetInstance()._graphics;
            StringFormat stringFormat = new StringFormat();
            currentTmpGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Near;
            currentTmpGraphics.DrawString(text, font, new SolidBrush(color), rectangle, stringFormat);
        }
    }
}
