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
    class AbstractRectangle : IShape
    {
        public IRectangle _typeRectangle { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public Color Color { get; set; }
        public int PenWidth { get; set; }
        public Font NameFont = new Font("Arial", 18);
        public Font ArgumentFont = new Font("Arial", 16);
        
        public List<AbstractPointer> ConnectionsStart { get; set; }
        public List<AbstractPointer> ConnectionsEnd { get; set; }


        public int line = 4;

        public bool _endCreate = false;
        public AbstractRectangle(IRectangle typeRectangle)
        {
            _typeRectangle = typeRectangle;
            _endCreate = false;
            Color = Color.Black;
            PenWidth = 1;
            EndPoint = new Point(160, 220);
            ConnectionsStart = new List<AbstractPointer>();
            ConnectionsEnd = new List<AbstractPointer>();

        }

        public void Draw()
        {
            _typeRectangle.Draw(Color, PenWidth, StartPoint, EndPoint, 4, NameFont, ArgumentFont);
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

        public Point PickPoint(MouseEventArgs e)
        {
            //DrawDashEntity(Color, PenWidth, MyGraphics.GetInstance().GetTmpGraphics(), new Point(StartPoint.X-5, StartPoint.Y - 5), new Point(170, 230));
            //MyGraphics.GetInstance().SetImageToTmpBitmap();
            //MyGraphics.GetInstance().GetMainGraphics();
            return e.Location;
        }

        public void Move(int deltaX, int deltaY)
        {
            StartPoint = new Point(StartPoint.X + deltaX, StartPoint.Y + deltaY);

            foreach (AbstractPointer pointer in ConnectionsEnd)
            {
                pointer.EndPoint = new Point(pointer.EndPoint.X + deltaX, pointer.EndPoint.Y + deltaY);
                pointer.InsidePoint1 = new Point((pointer.StartPoint.X + pointer.EndPoint.X) / 2, pointer.StartPoint.Y);
                pointer.InsidePoint2 = new Point((pointer.StartPoint.X + pointer.EndPoint.X) / 2, pointer.EndPoint.Y);
            }
            foreach (AbstractPointer pointer in ConnectionsStart)
            {
                pointer.StartPoint = new Point(pointer.StartPoint.X + deltaX, pointer.StartPoint.Y + deltaY);
                pointer.InsidePoint1 = new Point((pointer.StartPoint.X + pointer.EndPoint.X) / 2, pointer.StartPoint.Y);
                pointer.InsidePoint2 = new Point((pointer.StartPoint.X + pointer.EndPoint.X) / 2, pointer.EndPoint.Y);
            }
            //Draw();

            MyGraphics.GetInstance().GetTmpGraphics();
            Draw();
            MyGraphics.GetInstance().SetImageToTmpBitmap();


        }

        public void ChangeShape(Point point, int deltaX, int deltaY)
        {

        }
    }
}
