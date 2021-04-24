﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLDesigner
{
    public class AbstractPointer : IShape
    {
        IArrow _typeArrow { get; set; }
        ILine _typeLine { get; set; }

        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public Color Color { get; set; }
        public int PenWidth { get; set; }


        bool isMouseDown = false;
        bool _drawArrow = true;
        public bool _endCreate = false;
        public AbstractPointer(IArrow typeA, ILine typeL)
        {
            _typeArrow = typeA;
            _typeLine = typeL;
            _endCreate = false;
            Color = Color.Black;
            PenWidth = 1;
        }

        public void Draw()
        {
            _typeArrow.Draw(Color, PenWidth, StartPoint, EndPoint);
            _typeLine.Draw(Color, PenWidth, StartPoint, EndPoint);
        }

        public void OnMouseDown(MouseEventArgs e, List<IShape> shapes)
        {
            SnapArrow(e.Location, shapes);
            MyGraphics.GetInstance().GetTmpGraphics();
            Draw();
            MyGraphics.GetInstance().SetImageToTmpBitmap();
            isMouseDown = true;
        }

        public void OnMouseMove(MouseEventArgs e, List<IShape> shapes)
        {
            if (!_drawArrow)
            {
                EndPoint = e.Location;
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
        public void OnMouseUp(MouseEventArgs e)
        {
            isMouseDown = false;

        }

        public static List<Point> GetPoints(Point startPoint, Point endPoint, int endLineCutter = 0, int startLineCutter = 0 )
        {
            List<Point> points = new List<Point>();            

            if (endPoint.X > startPoint.X &&
                endPoint.X < startPoint.X + 160 + 48)
            {
                points.Add(new Point(startPoint.X, startPoint.Y));
                points.Add(new Point(endPoint.X + 48, startPoint.Y));
                points.Add(new Point(endPoint.X + 48, endPoint.Y));
                points.Add(new Point(endPoint.X, endPoint.Y));
                return points;
            }
            else if (endPoint.X < startPoint.X &&
               endPoint.X > startPoint.X - 160 -48)
            {
                points.Add(new Point(startPoint.X, startPoint.Y));
                points.Add(new Point(endPoint.X - 48, startPoint.Y));
                points.Add(new Point(endPoint.X - 48, endPoint.Y));
                points.Add(new Point(endPoint.X, endPoint.Y));
                return points;
            }
            else
            {
                points.Add(new Point(startPoint.X - startLineCutter, startPoint.Y));
                int middleX = (startPoint.X + endPoint.X) / 2;
                points.Add(new Point(middleX, startPoint.Y));
                points.Add(new Point(middleX, endPoint.Y));
                points.Add(new Point(endPoint.X - endLineCutter, endPoint.Y));
                return points;
            }
        }

        private static void ConsoleWriteLine()
        {
            throw new NotImplementedException();
        }

        private void SnapArrow(Point clickPoint, List<IShape> shapes)
        {
            foreach (IShape shape in shapes)
            {
                if (shape is AbstractRectangle)
                {
                    AbstractRectangle rectangle = (AbstractRectangle)shape;
                    if (clickPoint.X > rectangle.StartPoint.X && 
                    clickPoint.X < rectangle.StartPoint.X + rectangle.EndPoint.X &&
                    clickPoint.Y > rectangle.StartPoint.Y &&
                    clickPoint.Y < rectangle.StartPoint.Y + rectangle.EndPoint.Y)
                    {
                        if (_drawArrow)
                        {
                            StartPoint = new Point(rectangle.StartPoint.X+80, clickPoint.Y);
                            EndPoint = clickPoint;
                            _drawArrow = false;
                        }
                        else
                        {
                            if(rectangle.StartPoint.X+80 < StartPoint.X + 180 + 48 &&
                                rectangle.StartPoint.X + 80 > StartPoint.X - 180 - 48)
                            {
                                if(rectangle.StartPoint.X + 80 < StartPoint.X)
                                {
                                    StartPoint = new Point(StartPoint.X - 80, StartPoint.Y);
                                    EndPoint = new Point(rectangle.StartPoint.X, clickPoint.Y);
                                }
                                else
                                {
                                    StartPoint = new Point(StartPoint.X + 80, StartPoint.Y);
                                    EndPoint = new Point(rectangle.StartPoint.X + 160, clickPoint.Y);
                                }
                            }
                            else if (StartPoint.X < rectangle.StartPoint.X + 80) 
                            {
                                StartPoint = new Point(StartPoint.X + 80, StartPoint.Y);
                                EndPoint = new Point(rectangle.StartPoint.X, clickPoint.Y);

                                //if(rectangle.StartPoint.X + 80 > StartPoint.X &&
                                //    rectangle.StartPoint.X + 80 < StartPoint.X + 80 + 48)
                                //{
                                //    EndPoint = new Point(rectangle.StartPoint.X+160, clickPoint.Y);
                                //}
                            }
                            else
                            {
                                StartPoint = new Point(StartPoint.X - 80, StartPoint.Y);
                                EndPoint = new Point(rectangle.StartPoint.X+160, clickPoint.Y);

                                //if (rectangle.StartPoint.X + 80 < StartPoint.X &&
                                //    rectangle.StartPoint.X + 80 > StartPoint.X - 80 - 48)
                                //{
                                //    EndPoint = new Point(rectangle.StartPoint.X, clickPoint.Y);
                                //}
                            }
                            _drawArrow = true;
                            _endCreate = true;

                        }
                        break;
                    }
                }
            }

        }
    }
}
