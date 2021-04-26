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
using UMLDesigner.Shapes.Rectangles;

namespace UMLDesigner
{
    public class BaseRectangle : IShape
    {
        public IRectangle TypeRectangle { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public Color Color { get; set; }
        public int PenWidth { get; set; }
        public Font NameFont { get; set; }
        public Font ArgumentFont { get; set; }
        
        public string Name { get; set; }
        public string Properties { get; set; }
        public string Fields { get; set; }
        public string Methods { get; set; }

        public List<BasePointer> ConnectionsStart { get; set; }
        public List<BasePointer> ConnectionsEnd { get; set; }

        private bool _endCreate = false;

        public BaseRectangle(IRectangle typeRectangle, string name)
        {
            Name = name;
            TypeRectangle = typeRectangle;
            Color = Color.Black;
            PenWidth = 1;
            EndPoint = new Point(180, 220);
            ConnectionsStart = new List<BasePointer>();
            ConnectionsEnd = new List<BasePointer>();
            NameFont = new Font("Arial", 18);
            ArgumentFont = new Font("Arial", 13);
        }

        public void Draw()
        {
            TypeRectangle.Draw(this);
        }

        public void OnMouseDown(MouseEventArgs e, List<IShape> shapes)
        {
            MyGraphics.GetInstance().GetMainGraphics();
            StartPoint = e.Location;
            Draw();
            _endCreate = true;
        }

        public void OnMouseMove(MouseEventArgs e, List<IShape> shapes)
        {
            if (_endCreate == false)
            {
                DrawDashEntity(Color.Black, 1, MyGraphics.GetInstance().GetTmpGraphics(), e.Location, new Point(160, 220));
                MyGraphics.GetInstance().SetImageToTmpBitmap();
            }
            else
            {
                Draw();
                MyGraphics.GetInstance().SetTmpBitmapAsMain();
            }
        }

        public void OnMouseUp(MouseEventArgs e)
        {
        }

        public static void DrawDashEntity(Color color, float penWidth, Graphics graphics, Point startPoint, Point size)
        {
            Pen _pen = new Pen(color, penWidth);
            float[] dashPattern = new float[2] { 5f, 5f };
            _pen.DashPattern = dashPattern;
            graphics.DrawRectangle(_pen, startPoint.X, startPoint.Y, size.X, size.Y);
        }

        public void ChangeText(string name, string properties, string fields, string methods)
        {
            Name = name;
            Properties = properties;
            Fields = fields;
            Methods = methods;
        }

        public Point PickPoint(MouseEventArgs e)
        {
            return e.Location;
        }

        public void Move(int deltaX, int deltaY)
        {
            StartPoint = new Point(StartPoint.X + deltaX, StartPoint.Y + deltaY);

            foreach (BasePointer pointer in ConnectionsEnd)
            {
                pointer.EndPoint = new Point(pointer.EndPoint.X + deltaX, pointer.EndPoint.Y + deltaY);
                pointer.InsidePoint1 = new Point((pointer.StartPoint.X + pointer.EndPoint.X) / 2, pointer.StartPoint.Y);
                pointer.InsidePoint2 = new Point((pointer.StartPoint.X + pointer.EndPoint.X) / 2, pointer.EndPoint.Y);
            }
            foreach (BasePointer pointer in ConnectionsStart)
            {
                pointer.StartPoint = new Point(pointer.StartPoint.X + deltaX, pointer.StartPoint.Y + deltaY);
                pointer.InsidePoint1 = new Point((pointer.StartPoint.X + pointer.EndPoint.X) / 2, pointer.StartPoint.Y);
                pointer.InsidePoint2 = new Point((pointer.StartPoint.X + pointer.EndPoint.X) / 2, pointer.EndPoint.Y);
            }

            MyGraphics.GetInstance().GetMainGraphics();
            Draw();
            MyGraphics.GetInstance().SetImageToTmpBitmap();
        }

        public void ChangeShape(Point point, int deltaX, int deltaY)
        {

            if ((EndPoint.X + deltaX) > 50)
            {
                EndPoint = new Point(EndPoint.X + deltaX, EndPoint.Y + deltaY);

                foreach (BasePointer pointer in ConnectionsEnd)
                {
                    if (pointer.EndPoint.X > StartPoint.X + EndPoint.X / 2)
                    {
                        pointer.EndPoint = new Point(pointer.EndPoint.X + deltaX, pointer.EndPoint.Y);
                    }
                }
                foreach (BasePointer pointer in ConnectionsStart)
                {
                    if (pointer.StartPoint.X > StartPoint.X + EndPoint.X / 2)
                    {
                        pointer.StartPoint = new Point(pointer.StartPoint.X + deltaX, pointer.StartPoint.Y);
                    }
                }
            }

            MyGraphics.GetInstance().GetMainGraphics();
            Draw();
            MyGraphics.GetInstance().SetImageToTmpBitmap();
        }
    }
}
