using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLDesigner
{
    class EntityShape : IShape
    {
        private ActShapes _act;
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public Color Color { get; set; }
        public int PenWidth { get; set; }

        public EntityShape(Color color, int penWidth, ActShapes act)
        {
            Color = color;
            PenWidth = penWidth;
            _act = act;
        }
        public EntityShape(Point startPoint, Color color, int penWidth, ActShapes act)
        {
            Color = color;
            PenWidth = penWidth;
            _act = act;
            StartPoint = startPoint;
            EndPoint = new Point(160, 220);
        }
        public EntityShape()
        {
            StartPoint = new Point(0, 0);
            EndPoint = new Point(0, 0);
        }
        public void Draw(Graphics graphics)
        {
            switch (_act)
            {
                case ActShapes.Class: 
                    DrawClassEntity(Color, PenWidth, graphics, StartPoint, EndPoint);
                    break;
                case ActShapes.Interface: 
                    DrawInterfaceEntity(Color, PenWidth, graphics, StartPoint, EndPoint);
                    break;
                case ActShapes.StackClass: 
                    DrawClassWithFourEntity(Color, PenWidth, graphics, StartPoint, EndPoint);
                    AddShadowLinesRectangle(Color, PenWidth, graphics, StartPoint, 10, 15);
                    Point _p = new Point((StartPoint.X - 15), (StartPoint.Y - 10));
                    AddShadowLinesRectangle(Color, PenWidth, graphics, _p, 10, 15);
                    break;
                case ActShapes.ClassWithFourRectangle: 
                    DrawClassWithFourEntity(Color, PenWidth, graphics, StartPoint, EndPoint);
                    break;
                case ActShapes.Structure: 
                    DrawClassEntity(Color, PenWidth, graphics, StartPoint, EndPoint);
                    break;
                case ActShapes.Delegate: 
                    DrawInterfaceEntity(Color, PenWidth, graphics, StartPoint, EndPoint);
                    break;
            }
        }
        public void DrawClassEntity(Color color, float penWidth, Graphics graphics, Point startPoint, Point size, int line = 3)
        {
            Pen _pen = new Pen(color, penWidth);
            int _nameHeight = 50;
            int _fieldsHeight = 30;
            int _otherHeight = size.Y - _nameHeight - _fieldsHeight;

            Rectangle _nameRect = new Rectangle(startPoint.X, startPoint.Y, size.X, _nameHeight);
            Rectangle _fieldsRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight, size.X, _fieldsHeight);
            Rectangle _otherRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight + _fieldsHeight, size.X, _otherHeight);
            graphics.DrawRectangle(_pen, _nameRect);
            if(line > 1)
                graphics.DrawRectangle(_pen, _fieldsRect);
            if (line > 2)
                graphics.DrawRectangle(_pen, _otherRect);

            DrawTextLabel(graphics, _nameRect, ("NewClass"));
        }
        public void DrawInterfaceEntity(Color color, float penWidth, Graphics graphics, Point startPoint, Point size, int line = 2)
        {
            Pen _pen = new Pen(color, penWidth);
            int _nameHeight = 50;
            int _otherHeight = size.Y - _nameHeight;
            Rectangle _nameRect = new Rectangle(startPoint.X, startPoint.Y, size.X, _nameHeight);
            Rectangle _otherRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight, size.X, _otherHeight);
            graphics.DrawRectangle(_pen, _nameRect);
            if (line > 1)
                graphics.DrawRectangle(_pen, _otherRect);

            DrawTextLabel(graphics, _nameRect, ("NewInterfaces"));
        }
        public void DrawClassWithFourEntity(Color color, float penWidth, Graphics graphics, Point startPoint, Point size, int line = 4)
        {
            Pen _pen = new Pen(color, penWidth);
            int _nameHeight = 50;
            int _fieldsHeight = 30;
            int _propertiesHeight = 60;
            int _methodHeight = size.Y - _nameHeight - _fieldsHeight - _propertiesHeight;

            Rectangle _nameRect = new Rectangle(startPoint.X, startPoint.Y, size.X, _nameHeight);
            Rectangle _fieldsRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight, size.X, _fieldsHeight);
            Rectangle _propertiesRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight + _fieldsHeight, size.X, _propertiesHeight);
            Rectangle _methodRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight + _fieldsHeight + _propertiesHeight, size.X, _methodHeight);
            graphics.DrawRectangle(_pen, _nameRect);
            if (line > 1)
                graphics.DrawRectangle(_pen, _fieldsRect);
            if (line > 2)
                graphics.DrawRectangle(_pen, _propertiesRect);
            if (line > 3)
                graphics.DrawRectangle(_pen, _methodRect);

            DrawTextLabel(graphics, _nameRect, ("NewClass"));
        }
        public void AddShadowLinesRectangle(Color color, float penWidth, Graphics graphics, Point startPoint, int smalLineY, int indentLastX)
        {
            Pen _pen = new Pen(color, penWidth);
            int _smallLineVertical = smalLineY;
            int _indentRectangle = indentLastX;
            int _bigLineHorizontal = EndPoint.X;
            int _bigLineVertical = EndPoint.Y;

            graphics.DrawLine(_pen, (startPoint.X + EndPoint.X - _indentRectangle), (startPoint.Y), (startPoint.X + EndPoint.X - _indentRectangle), (startPoint.Y - _smallLineVertical));
            graphics.DrawLine(_pen, (startPoint.X + EndPoint.X - _indentRectangle), (startPoint.Y - _smallLineVertical), (startPoint.X + EndPoint.X - _indentRectangle - _bigLineHorizontal), (startPoint.Y - _smallLineVertical));
            graphics.DrawLine(_pen, (startPoint.X + EndPoint.X - _indentRectangle - _bigLineHorizontal), (startPoint.Y - _smallLineVertical), (startPoint.X + EndPoint.X - _indentRectangle - _bigLineHorizontal), (startPoint.Y - _smallLineVertical + _bigLineVertical));
            graphics.DrawLine(_pen, (startPoint.X + EndPoint.X - _indentRectangle - _bigLineHorizontal), (startPoint.Y - _smallLineVertical + _bigLineVertical), (startPoint.X + EndPoint.X - _indentRectangle - _bigLineHorizontal + _indentRectangle), (startPoint.Y - _smallLineVertical + _bigLineVertical));
        }
        public static void DrawDashEntity(Color color, float penWidth, Graphics graphics, Point startPoint, Point size)
        {
            Pen _pen = new Pen(color, penWidth);
            float[] dashPattern = new float[2] { 5f, 5f };
            _pen.DashPattern = dashPattern;
            graphics.DrawRectangle(_pen, startPoint.X, startPoint.Y, size.X, size.Y);
        }

        public void DrawTextLabel(Graphics graphics, Rectangle field, string nameLabel)
        {
            var _brush = Brushes.Red;

            StringFormat _stringFormat = new StringFormat();
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            _stringFormat.Alignment = StringAlignment.Center;
            _stringFormat.LineAlignment = StringAlignment.Center;
            graphics.DrawString(nameLabel, new System.Drawing.Font("Segoe Script", 12, FontStyle.Regular), _brush, field, _stringFormat);
        }

        public bool IsItYou(Point point)
        {
            int xMax;
            int xMin;
            int yMax;
            int yMin;

            xMin = StartPoint.X;
            xMax = StartPoint.X + EndPoint.X;
            yMin = StartPoint.Y;
            yMax = StartPoint.Y + EndPoint.Y;

            if (point.X <= xMax && point.X >= xMin
             && point.Y <= yMax && point.Y >= yMin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        ///

        public void Draw()
        {

        }

        public void OnMouseDown(MouseEventArgs e, List<IShape> shapes)
        {

        }

        public void OnMouseMove(MouseEventArgs e, List<IShape> shapes)
        {

        }

        public void OnMouseUp(MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Pick()
        {
            throw new NotImplementedException();
        }

        public void Move(int deltaX, int deltaY)
        {
            throw new NotImplementedException();
        }

        public Point PickPoint(MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ChangeShape(Point point, int deltaX, int deltaY)
        {
            throw new NotImplementedException();
        }
    }
}
