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
        public string Name { get; set; }
        public static int _countOfClasses = 0;
        Graphics currentTmpGraphics = MyGraphics.GetInstance()._graphics;


        private Rectangle nameRect;
        private Rectangle fieldsRect;
        private Rectangle _propetiesRect;
        private Rectangle _otherRect;

        private int _nameHeight = 50;
        private int _fieldsHeight = 25;
        private int _propertiesHeight = 25;
        private int _methodHeight;

        int _dlcHeight = 0;


        public int Height { get; private set; }


        public ClassRectangle()
        {
            Name = "Class" + _countOfClasses++;
        }



        public void Draw(Color color, float penWidth, Point startPoint, Point size, int line, Font nameFont, Font argumentFont, string textLabel, List<string> textFields, List<string> textProperties, string textMethods)
        {
            Pen _pen = new Pen(color, penWidth);
            SolidBrush blueBrush = new SolidBrush(Color.White);

            int _methodHeight = size.Y - _nameHeight - _fieldsHeight - _propertiesHeight + _dlcHeight;
            _nameHeight = 40 + (int)currentTmpGraphics.MeasureString(textLabel, argumentFont).Height;
            _fieldsHeight = 25;
            _propertiesHeight = 25;
            _methodHeight = 50;


            Rectangle nameRect = new Rectangle(startPoint.X, startPoint.Y, size.X, _nameHeight);
            Rectangle propertiesRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight, size.X, _propertiesHeight);
            Rectangle fieldsRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight + _propertiesHeight, size.X, _fieldsHeight); 
            Rectangle methodRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight + _fieldsHeight + _propertiesHeight, size.X, _methodHeight);


            currentTmpGraphics.FillRectangle(blueBrush, propertiesRect);
            currentTmpGraphics.DrawRectangle(_pen, propertiesRect);

            string str = "";
            foreach(string f in textFields)
            {
                str += f;
            }
            //SizeF siz = MyGraphics.GetInstance().GetMainGraphics().MeasureString(str, argumentFont);
            //Rectangle test = new Rectangle(new Point(startPoint.X, startPoint.Y + _nameHeight + _fieldsHeight), siz);
            //Rectangle test = new Rectangle(startPoint.X, startPoint.Y + _nameHeight + _propertiesHeight, size.X, 200+(int)siz.Height);
            //DrawTextOtherPlacel(currentTmpGraphics, str, fieldsRect, argumentFont);


            currentTmpGraphics.DrawRectangle(_pen, nameRect);

            if (line > 1)
                currentTmpGraphics.DrawRectangle(_pen, fieldsRect);
            if (line > 2)
                currentTmpGraphics.DrawRectangle(_pen, propertiesRect);
            if (line > 3)
                currentTmpGraphics.DrawRectangle(_pen, methodRect);
            DrawTextLabel(textLabel, nameRect, nameFont);
            DrawTextOtherPlacel(currentTmpGraphics, str, fieldsRect, argumentFont);

            //DrawTextLabel(currentTmpGraphics, nameRect, nameFont);



        }


        public void DrawTextLabel(string Name, Rectangle nameRect, Font nameLabel)
        {
            var brush = Brushes.Red;

            StringFormat stringFormat = new StringFormat();
            currentTmpGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            currentTmpGraphics.DrawString(Name, nameLabel, brush, nameRect, stringFormat);
        }

        public void DrawTextOtherPlacel(Graphics graphics, string wordsArgument,  Rectangle field, Font argumentFont)
        {
            var brush = Brushes.Blue;

            StringFormat stringFormat = new StringFormat();
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Near;

            graphics.DrawString(wordsArgument, argumentFont, brush, field, stringFormat);
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

        //    nameRect = new Rectangle(startPoint.X, startPoint.Y, size.X, _nameHeight);
        //    fieldsRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight, size.X, _fieldsHeight);
        //    _propetiesRect = new Rectangle(startPoint.X, fieldsRect.Y + _fieldsHeight, size.X, _propertiesHeight);
        //    _methodHeight = size.Y - _nameHeight - _fieldsHeight - _propertiesHeight;
        //    _otherRect = new Rectangle(startPoint.X, _propetiesRect.Y + _propertiesHeight, size.X, _methodHeight);

        //    MyGraphics.GetInstance().GetMainGraphics();
        //    var currentTmpGraphics = MyGraphics.GetInstance()._graphics;

        //    currentTmpGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        //    currentTmpGraphics.DrawRectangle(pen, nameRect);
        //    currentTmpGraphics.DrawString(Name, nameFont, drawBrush, nameRect, drawFormat);

        //    if (line > 1)
        //    {
        //        drawFormat.Alignment = StringAlignment.Near;
        //        if (Fields.Count >= 1)
        //        {
        //            _fieldsHeight = 25 * Fields.Count;
        //            fieldsRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight, size.X, _fieldsHeight);
        //            currentTmpGraphics.DrawRectangle(pen, fieldsRect);
        //            int tempY = 0;
        //            foreach (string s in Fields)
        //            {
        //                Rectangle tmpRect = new Rectangle(startPoint.X, fieldsRect.Y + tempY, size.X, 25);
        //                currentTmpGraphics.DrawString(s, argumentFont, drawBrush, tmpRect, drawFormat);
        //                tempY = tempY + 25;
        //            }
        //        }
        //        else
        //        {
        //            currentTmpGraphics.DrawRectangle(pen, fieldsRect);
        //        }
        //    }
        //    if (line > 2)
        //    {
        //        if (Properties.Count >= 1)
        //        {
        //            _propertiesHeight = 25 * Properties.Count;
        //            _propetiesRect = new Rectangle(startPoint.X, fieldsRect.Y + _fieldsHeight, size.X, _propertiesHeight);
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
        //            _propetiesRect = new Rectangle(startPoint.X, fieldsRect.Y + _fieldsHeight, size.X, _propertiesHeight);
        //            currentTmpGraphics.DrawRectangle(pen, _propetiesRect);
        //        }
        //    }
        //    if (line > 3)
        //    {
        //        if (Other.Count >= 1)
        //        {
        //            if (_methodHeight > Other.Count * 25)
        //            {
        //                currentTmpGraphics.DrawRectangle(pen, _otherRect);
        //            }
        //            else
        //            {
        //                _methodHeight = 25 * Other.Count;
        //                _otherRect = new Rectangle(startPoint.X, _propetiesRect.Y + _propertiesHeight, size.X, _methodHeight);
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
        //                _methodHeight = 25;
        //            }
        //            else
        //            {
        //                _methodHeight = size.Y - _nameHeight - _fieldsHeight - _propertiesHeight;
        //            }
        //            _otherRect = new Rectangle(startPoint.X, _propetiesRect.Y + _propertiesHeight, size.X, _methodHeight);
        //            currentTmpGraphics.DrawRectangle(pen, _otherRect);
        //        }
        //        Height = _nameHeight + _fieldsHeight + _propertiesHeight + _methodHeight;
        //    }
        //}




    }
}
