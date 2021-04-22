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
    public class AbstractRectangle : IShape
    {
        public IRectangle _typeRectangle;
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public Color Color { get; set; }
        
        public List<string> NameLabel { get; set; }
        public List<string> Fields { get; set; }
        public List<string> Properties { get; set; }
        public List<string> Methods { get; set; }

        public int PenWidth { get; set; }

        public Font NameFont = new Font("Arial", 6);
        public Font ArgumentFont = new Font("Arial", 8);

        public int line = 4;

        public bool _endCreate = false;
        public AbstractRectangle(IRectangle typeRectangle)
        {
            _typeRectangle = typeRectangle;
            _endCreate = false;
            Color = Color.Black;
            PenWidth = 1;
            EndPoint = new Point(160, 220);

            NameLabel = new List<string>();
            Fields = new List<string>();
            Properties = new List<string>();
            Methods = new List<string>();
        }

        public void Draw()
        {
            _typeRectangle.Draw(Color, PenWidth, StartPoint, EndPoint, 4, NameFont, ArgumentFont);
        }




        public void ChangeText(string TextField)
        {
            Fields.Clear();
            Fields.Add(TextField);
        }

        public override string ToString()
        {
           foreach(string words in Fields)
            {
                return words;
            }
            return "Miss List";
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

        public void Pick()
        {
            DrawDashEntity(Color, PenWidth, MyGraphics.GetInstance().GetTmpGraphics(), new Point(StartPoint.X-5, StartPoint.Y - 5), new Point(170, 230));
            MyGraphics.GetInstance().SetImageToTmpBitmap();
            MyGraphics.GetInstance().GetMainGraphics();
        }

        public void Move(int deltaX, int deltaY)
        {
            StartPoint = new Point(StartPoint.X + deltaX, StartPoint.Y + deltaY);

            MyGraphics.GetInstance().GetTmpGraphics();
            Draw();
            MyGraphics.GetInstance().SetImageToTmpBitmap();


        }


        //public static void AddTextForRectangel(Color color, Graphics graphics, Point palceRectangle) 
        //{ 
        //    foreach(IShape shape in Shapes)
        //    {
        //        if 
        //    }
        //}

        public void DrawTextInField(Graphics graphics, Rectangle field, string nameLabel)
        {
            var _brush = Brushes.Red;

            MyGraphics.GetInstance().GetMainGraphics();
            var currentTmpGraphics = MyGraphics.GetInstance()._graphics;

            StringFormat _stringFormat = new StringFormat();
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            _stringFormat.Alignment = StringAlignment.Center;
            _stringFormat.LineAlignment = StringAlignment.Center;
            graphics.DrawString(nameLabel, new System.Drawing.Font("Segoe Script", 12, FontStyle.Regular), _brush, field, _stringFormat);
        }


        public static AbstractRectangle GetCurrentRectangle(MouseEventArgs e)
        {

            foreach (AbstractRectangle shape in MyGraphics.GetInstance().Shapes)
            {
                //int _endX = shape.StartPoint.X + shape.EndPoint.X;
                //int _endY = shape.StartPoint.Y + shape.EndPoint.Y;

                //if ((e.X >= shape.StartPoint.X) && (e.Y >= shape.StartPoint.Y)
                // && (e.X <= _endX) && (e.Y <= _endY))
                //{

                //    return shape;

                //}

             
         
                    if (e.Location.X > shape.StartPoint.X &&
                        e.Location.X < shape.StartPoint.X + shape.EndPoint.X &&
                        e.Location.Y > shape.StartPoint.Y &&
                        e.Location.Y < shape.StartPoint.Y + shape.EndPoint.Y)
                    {
                        return shape;
                    }
        
            


            }

            return null;

            //if (_countSelect == 0)
            //{
            //    Graphics.FromImage(_mainBitmap).Clear(Color.White);
            //    foreach (IShape a in _shapes)
            //    {
            //        a.Draw(_graphics);
            //    }

            //    _graphics.DrawImage(_mainBitmap, 0, 0);
            //    pictureBox1.Image = _mainBitmap;
            //}
        }




    }
}
