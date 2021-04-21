﻿using System;
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
        public ClassRectangle()
        {
            Connections = new List<PointerShape>();
            Fields = new List<string>();
            Properties = new List<string>();
            Other = new List<string>();
            Name = "Class" + _countOfClasses++;
        }

        //public void Draw()
        //{

        //    Pen _pen = new Pen(Color, PenWidth);
        //    int __nameHeight = 50;
        //    int __fieldsHeight = 30;
        //    int __otherHeight = EndPoint.Y - __nameHeight - __fieldsHeight;

        //    Rectangle __nameRect = new Rectangle(StartPoint.X, StartPoint.Y, EndPoint.X, __nameHeight);
        //    Rectangle __fieldsRect = new Rectangle(StartPoint.X, StartPoint.Y + __nameHeight, EndPoint.X, __fieldsHeight);
        //    Rectangle __otherRect = new Rectangle(StartPoint.X, StartPoint.Y + __nameHeight + __fieldsHeight, EndPoint.X, __otherHeight);
        //    my._graphics.DrawRectangle(_pen, __nameRect);
        //    if (line > 1)
        //        my._graphics.DrawRectangle(_pen, __fieldsRect);
        //    if (line > 2)
        //        my._graphics.DrawRectangle(_pen, __otherRect);

        //    DrawTextLabel(__nameRect, ("NewClass"));
        //}
        public void Draw(Color color, float penWidth, Point startPoint, Point size, int line, Font nameFont, Font argumentFont)
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
            _fieldsRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight, size.X, _fieldsHeight);
            _propetiesRect = new Rectangle(startPoint.X, _fieldsRect.Y + _fieldsHeight, size.X, _propertiesHeight);
            _otherHeight = size.Y - _nameHeight - _fieldsHeight - _propertiesHeight;
            _otherRect = new Rectangle(startPoint.X, _propetiesRect.Y + _propertiesHeight, size.X, _otherHeight);



            MyGraphics.GetInstance().GetMainGraphics();
            var currentTmpGraphics = MyGraphics.GetInstance()._graphics;

            currentTmpGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            currentTmpGraphics.DrawRectangle(pen, _nameRect);
            currentTmpGraphics.DrawString(Name, nameFont, drawBrush, _nameRect, drawFormat);


            if (line > 1)
            {
                drawFormat.Alignment = StringAlignment.Near;
                if (Fields.Count >= 1)
                {
                    _fieldsHeight = 25 * Fields.Count;
                    _fieldsRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight, size.X, _fieldsHeight);
                    currentTmpGraphics.DrawRectangle(pen, _fieldsRect);
                    int tempY = 0;
                    foreach (string s in Fields)
                    {
                        Rectangle tmpRect = new Rectangle(startPoint.X, _fieldsRect.Y + tempY, size.X, 25);
                        currentTmpGraphics.DrawString(s, argumentFont, drawBrush, tmpRect, drawFormat);
                        tempY = tempY + 25;
                    }
                }
                else
                {
                    currentTmpGraphics.DrawRectangle(pen, _fieldsRect);
                }
            }
            if (line > 2)
            {
                if (Properties.Count >= 1)
                {
                    _propertiesHeight = 25 * Properties.Count;
                    _propetiesRect = new Rectangle(startPoint.X, _fieldsRect.Y + _fieldsHeight, size.X, _propertiesHeight);
                    currentTmpGraphics.DrawRectangle(pen, _propetiesRect);
                    int tempY = 0;
                    foreach (string s in Properties)
                    {
                        Rectangle tmpRect = new Rectangle(startPoint.X, _propetiesRect.Y + tempY, size.X, 25);
                        currentTmpGraphics.DrawString(s, argumentFont, drawBrush, tmpRect, drawFormat);
                        tempY = tempY + 25;
                    }
                }
                else
                {
                    _propetiesRect = new Rectangle(startPoint.X, _fieldsRect.Y + _fieldsHeight, size.X, _propertiesHeight);
                    currentTmpGraphics.DrawRectangle(pen, _propetiesRect);
                }
            }
            if (line > 3)
            {
                if (Other.Count >= 1)
                {
                    if (_otherHeight > Other.Count * 25)
                    {
                        currentTmpGraphics.DrawRectangle(pen, _otherRect);
                    }
                    else
                    {
                        _otherHeight = 25 * Other.Count;
                        _otherRect = new Rectangle(startPoint.X, _propetiesRect.Y + _propertiesHeight, size.X, _otherHeight);
                        currentTmpGraphics.DrawRectangle(pen, _otherRect);
                    }
                    if (Other.Count > 1)
                    {
                        int tempY = 0;
                        foreach (string s in Other)
                        {
                            Rectangle tmpRect = new Rectangle(startPoint.X, _otherRect.Y + tempY, size.X, 25);
                            currentTmpGraphics.DrawString(s, argumentFont, drawBrush, tmpRect, drawFormat);
                            tempY = tempY + 25;
                        }
                    }
                }
                else
                {
                    if (size.Y <= _nameHeight + _fieldsHeight + _propertiesHeight + 25)
                    {
                        _otherHeight = 25;
                    }
                    else
                    {
                        _otherHeight = size.Y - _nameHeight - _fieldsHeight - _propertiesHeight;
                    }
                    _otherRect = new Rectangle(startPoint.X, _propetiesRect.Y + _propertiesHeight, size.X, _otherHeight);
                    currentTmpGraphics.DrawRectangle(pen, _otherRect);
                }
                Height = _nameHeight + _fieldsHeight + _propertiesHeight + _otherHeight;
            }
        }

        //public void DrawTextLabel(Rectangle field, string nameLabel)
        //{
        //    var _brush = Brushes.Red;
        //    MyGraphics my = MyGraphics.GetInstanse();
        //    my.GetMainGraphics();


        //    StringFormat _stringFormat = new StringFormat();
        //    my._graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        //    _stringFormat.Alignment = StringAlignment.Center;
        //    _stringFormat.LineAlignment = StringAlignment.Center;
        //    my._graphics.DrawString(nameLabel, new System.Drawing.Font("Segoe Script", 12, FontStyle.Regular), _brush, field, _stringFormat);
        //}
    }
}
