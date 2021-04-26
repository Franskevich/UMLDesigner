using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLDesigner
{
    public class BasePointer : IShape
    {
        public IArrow _typeArrow { get; set; }
        public ILine _typeLine { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public Point InsidePoint1 { get; set; }
        public Point InsidePoint2 { get; set; }
        public Color Color { get; set; }
        public int PenWidth { get; set; }
        public bool EndCreate { get; set; } 

        private int _sizeRectangle = 0;
        private bool _isMouseDown = false;
        private bool _drawArrow = true;

        public BasePointer(IArrow typeA, ILine typeL)
        {
            _typeArrow = typeA;
            _typeLine = typeL;
            EndCreate = false;
            Color = Color.Black;
            PenWidth = 1;
        }

        public void Draw()
        {
            _typeLine.Draw(Color, PenWidth, StartPoint, InsidePoint1, InsidePoint2, EndPoint);
            _typeArrow.Draw(Color, PenWidth, StartPoint, EndPoint);
        }

        public void OnMouseDown(MouseEventArgs e, List<IShape> shapes)
        {
            SnapArrow(e.Location, shapes);
            MyGraphics.GetInstance().GetTmpGraphics();
            Draw();
            MyGraphics.GetInstance().SetImageToTmpBitmap();
            _isMouseDown = true;
        }

        public void OnMouseMove(MouseEventArgs e, List<IShape> shapes)
        {
            if (!_drawArrow)
            {
                EndPoint = e.Location;
                InsidePoint1 = new Point((StartPoint.X + EndPoint.X) / 2, StartPoint.Y);
                InsidePoint2 = new Point((StartPoint.X + EndPoint.X) / 2, EndPoint.Y);

                MyGraphics.GetInstance().GetTmpGraphics();
                Draw();
                MyGraphics.GetInstance().SetImageToTmpBitmap();
            }
            else
            {
                if(StartPoint.X != 0 && StartPoint.Y != 0 && EndPoint.X != 0 && EndPoint.Y != 0)
                {
                    MyGraphics.GetInstance().GetMainGraphics();
                    Draw();
                    MyGraphics.GetInstance().SetImageToMainBitmap();
                }
            }
        }

        public void OnMouseMove(MouseEventArgs e, List<IShape> shapes, ActShapes act)
        {
        }

        public void OnMouseUp(MouseEventArgs e)
        {
            _isMouseDown = false;
        }

        private void SnapArrow(Point clickPoint, List<IShape> shapes)
        {
            foreach (IShape shape in shapes)
            {
                if (shape is BaseRectangle)
                {
                    BaseRectangle rectangle = (BaseRectangle)shape;
                    if (clickPoint.X > rectangle.StartPoint.X && 
                    clickPoint.X < rectangle.StartPoint.X + rectangle.EndPoint.X &&
                    clickPoint.Y > rectangle.StartPoint.Y &&
                    clickPoint.Y < rectangle.StartPoint.Y + rectangle.EndPoint.Y)
                    {
                        if (_drawArrow)
                        {
                            StartPoint = new Point(rectangle.StartPoint.X + rectangle.EndPoint.X/2, clickPoint.Y);
                            EndPoint = clickPoint;
                            InsidePoint1 = new Point((StartPoint.X + EndPoint.X) / 2, StartPoint.Y);
                            InsidePoint2 = new Point((StartPoint.X + EndPoint.X) / 2, EndPoint.Y);
                            rectangle.ConnectionsStart.Add(this);
                            _drawArrow = false;
                            _sizeRectangle = rectangle.EndPoint.X;
                        }
                        else
                        {
                            rectangle.ConnectionsEnd.Add(this);

                            if (StartPoint.X < clickPoint.X)
                            {
                                StartPoint = new Point(StartPoint.X + _sizeRectangle/2, StartPoint.Y);
                                EndPoint = new Point(rectangle.StartPoint.X, clickPoint.Y);
                            }
                            else
                            {
                                StartPoint = new Point(StartPoint.X - _sizeRectangle/2, StartPoint.Y);
                                EndPoint = new Point(rectangle.StartPoint.X + rectangle.EndPoint.X, clickPoint.Y);
                            }

                            int middleX = (StartPoint.X + EndPoint.X) / 2;
                            _drawArrow = true;
                            EndCreate = true;
                        }
                        break;
                    }
                }
            }
        }

        public Point PickPoint(MouseEventArgs e)
        {
            Point shangePoint = e.Location;
            Point point2 = InsidePoint1;
            Point point3 = InsidePoint2;

            if (point2.Y > point3.Y)
            {
                Point tmpPoint = point3;
                point3 = point2;
                point2 = tmpPoint;
            }

            if (EndPoint.X > StartPoint.X)
            {
                if (e.Location.X > StartPoint.X &&
                    e.Location.X < InsidePoint1.X &&
                    e.Location.Y < StartPoint.Y + 10 &&
                    e.Location.Y > StartPoint.Y - 10)
                {
                    shangePoint = StartPoint;
                }
                else if (e.Location.X > InsidePoint2.X &&
                    e.Location.X < EndPoint.X &&
                    e.Location.Y < EndPoint.Y + 10 &&
                    e.Location.Y > EndPoint.Y - 10)
                {
                    shangePoint = EndPoint;
                } 
            }
            else
            {
                if (e.Location.X < StartPoint.X &&
                    e.Location.X > InsidePoint1.X &&
                    e.Location.Y < StartPoint.Y + 10 &&
                    e.Location.Y > StartPoint.Y - 10)
                {
                    shangePoint = StartPoint;
                }
                else if (e.Location.X < InsidePoint2.X &&
                        e.Location.X > EndPoint.X &&
                        e.Location.Y < EndPoint.Y + 10 &&
                        e.Location.Y > EndPoint.Y - 10)
                {
                    shangePoint = EndPoint;
                }
            }

            if(e.Location.X < point2.X +10 &&
                e.Location.X > point2.X -10 &&
                e.Location.Y < point3.Y &&
                e.Location.Y > point2.Y)
            {
                return InsidePoint1;
            }

            return shangePoint;         
        }

        public void Move(int deltaX, int deltaY)
        {
        }

        public void ChangeShape(Point movePoint, int deltaX, int deltaY)
        {
            if (movePoint == StartPoint)
            {
                StartPoint = new Point(StartPoint.X, StartPoint.Y + deltaY);
                InsidePoint1 = new Point(InsidePoint1.X, InsidePoint1.Y + deltaY);
            }
            else if (movePoint == EndPoint)
            {
                EndPoint = new Point(EndPoint.X, EndPoint.Y + deltaY);
                InsidePoint2 = new Point(InsidePoint2.X, InsidePoint2.Y + deltaY );
            }
            else if (movePoint == InsidePoint1)
            {
                InsidePoint1 = new Point(InsidePoint1.X + deltaX, InsidePoint1.Y);
                InsidePoint2 = new Point(InsidePoint2.X + deltaX, InsidePoint2.Y);
            }
        }
    }
}
