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
        public string Name { get; set; }
        public static int _countOfEnums = 0;

        private Rectangle _nameRect;
        private Rectangle _fieldsRect;
        private Rectangle _propetiesRect;
        private Rectangle _otherRect;

        private int _nameHeight = 50;
        private int _fieldsHeight = 25;
        private int _propertiesHeight = 25;
        private int _otherHeight;

        public bool isRollUp = false;
        public int Height { get; private set; }
        public List<string> Fields { get; set; }
        public List<string> Properties { get; set; }
        public List<string> Other { get; set; }
        public List<PointerShape> Connections { get; set; }
        public EnumRectangle()
        {
            Connections = new List<PointerShape>();
            Fields = new List<string>();
            Properties = new List<string>();
            Other = new List<string>();
            Name = "Enum" + _countOfEnums++;
        }


        public void Draw(Color color, float penWidth, Point startPoint, Point size, int line, Font nameFont, Font argumentFont, string textLabel, List<string> textFields, List<string> textProperties, string textMethods)
        {
            if (isRollUp == true)
            {
                line = 1;
            }
            Pen pen = new Pen(color, penWidth);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            drawFormat.LineAlignment = StringAlignment.Center;

            _nameRect = new Rectangle(startPoint.X, startPoint.Y, size.X, _nameHeight);
            _otherHeight = size.Y - _nameHeight;
            _otherRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight, size.X, _otherHeight);


            var currentTmpGraphics = MyGraphics.GetInstance()._graphics;


            currentTmpGraphics.DrawRectangle(pen, _nameRect);
            currentTmpGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            currentTmpGraphics.DrawString(Name, nameFont, drawBrush, new RectangleF(_nameRect.X, _nameRect.Y + _nameRect.Height / 4, _nameRect.Width, _nameRect.Height / 2), drawFormat);
            if (line > 1)
            {
                drawFormat.Alignment = StringAlignment.Near;
                if (Other.Count >= 1)
                {
                    if (_otherHeight > Other.Count * 25)
                    {
                        currentTmpGraphics.DrawRectangle(pen, _otherRect);
                    }
                    else
                    {
                        _otherHeight = 25 * Other.Count;
                        _otherRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight, size.X, _otherHeight);
                        currentTmpGraphics.DrawRectangle(pen, _otherRect);
                    }
                    int tempY = 0;
                    foreach (string s in Other)
                    {
                        Rectangle tmpRect = new Rectangle(startPoint.X, _otherRect.Y + tempY, size.X, 25);
                        currentTmpGraphics.DrawString(s, argumentFont, drawBrush, tmpRect, drawFormat);
                        tempY = tempY + 25;
                    }
                }
                else
                {
                    if (size.Y <= _nameHeight + 25)
                    {
                        _otherHeight = 25;
                    }
                    else
                    {
                        _otherHeight = size.Y - _nameHeight;
                    }
                    _otherRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight, size.X, _otherHeight);
                    currentTmpGraphics.DrawRectangle(pen, _otherRect);
                }
                Height = _nameHeight + _otherHeight;
            }
        }
    }
}
