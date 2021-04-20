using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLDesigner
{
    public class PointerShape : IShape
    {
        private ActShapes _act;
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }   
        public Color Color { get; set; }
        public int PenWidth { get; set; }
        public PointerShape(Color color, int penWidth, ActShapes act)
        {
            _act = act;
            Color = color;
            PenWidth = penWidth;
        }
        public PointerShape(Point startPoint, Color color, int penWidth, ActShapes act)
        {
            _act = act;
            Color = color;
            PenWidth = penWidth;
            StartPoint = startPoint;
            EndPoint = new Point(StartPoint.X + 1, StartPoint.Y + 1);
        }
        public PointerShape()
        {
            StartPoint = new Point(0, 0);
            EndPoint = new Point(0, 0);
        }
        public void Draw(Graphics graphics)
        {
            switch (_act)
            {
                case ActShapes.Association:
                    MakeAssociation(Color, PenWidth, graphics, StartPoint, EndPoint);
                    break;
                case ActShapes.Inheritance:
                    MakeInheritance(Color, PenWidth, graphics, StartPoint, EndPoint);
                    break;
                case ActShapes.Implementation:
                    MakeImplementation(Color, PenWidth, graphics, StartPoint, EndPoint);
                    break;
                case ActShapes.AggregationFirst: 
                    MakeAggregation(Color, PenWidth, graphics, StartPoint, EndPoint);
                    break;
                case ActShapes.AggregationSecond: 
                    MakeAggregation(Color, PenWidth, graphics, StartPoint, EndPoint, false);
                    break;
                case ActShapes.CompositionFirst: 
                    MakeComposition(Color, PenWidth, graphics, StartPoint, EndPoint);
                    break;
                case ActShapes.CompositionSecond: 
                    MakeComposition(Color, PenWidth, graphics, StartPoint, EndPoint, false);
                    break;
            }
        }
        public void MakeAssociation(Color color, float penWidth, Graphics graphics, Point startPoint, Point currentPoint)
        {
            int width = 15;
            int height = 24;

            Pen pen = new Pen(color, penWidth);


            if (EndPoint.X > StartPoint.X)
            {
                Point[] curvePoints = { new Point(EndPoint.X - height, EndPoint.Y - width), EndPoint, new Point(EndPoint.X - height, EndPoint.Y + width) };                         
                graphics.DrawLines(pen, curvePoints);
                graphics.DrawLines(pen, GetPoints().ToArray());
            }
            else
            {
                Point[] curvePoints = { new Point(EndPoint.X + height, EndPoint.Y - width), EndPoint, new Point(EndPoint.X + height, EndPoint.Y + width) };
                graphics.DrawLines(pen, curvePoints);
                graphics.DrawLines(pen, GetPoints().ToArray());
            }
        }
        public void MakeInheritance(Color color, float penWidth, Graphics graphics, Point startPoint, Point currentPoint)
        {
            int width = 15;
            int height = 24; 

            Pen pen = new Pen(color, penWidth);
            
            if (EndPoint.X > StartPoint.X)
            {
                Point[] curvePoints = { new Point(EndPoint.X - height, EndPoint.Y - width), EndPoint, new Point(EndPoint.X - height, EndPoint.Y + width) };
                graphics.DrawPolygon(pen, curvePoints);
                graphics.DrawLines(pen, GetPoints(height).ToArray());
            }
            else
            {
                Point[] curvePoints = { new Point(EndPoint.X + height, EndPoint.Y - width), EndPoint, new Point(EndPoint.X + height, EndPoint.Y + width) };
                graphics.DrawPolygon(pen, curvePoints);
                graphics.DrawLines(pen, GetPoints(-height).ToArray());
            }            
        }
        public void MakeImplementation(Color color, float penWidth, Graphics graphics, Point startPoint, Point currentPoint)
        {
            int width = 15;
            int height = 24;

            Pen penDash = new Pen(color, penWidth);

            float[] dashPattern = new float[2] { 5f, 5f };
            penDash.DashPattern = dashPattern;

            Pen penArrow = new Pen(color, penWidth);

            if (EndPoint.X > StartPoint.X)
            {
                Point[] curvePoints = { new Point(EndPoint.X - height, EndPoint.Y - width), EndPoint, new Point(EndPoint.X - height, EndPoint.Y + width) };
                graphics.DrawPolygon(penArrow, curvePoints);
                graphics.DrawLines(penDash, GetPoints(height).ToArray());
            }
            else
            {
                Point[] curvePoints = { new Point(EndPoint.X + height, EndPoint.Y - width), EndPoint, new Point(EndPoint.X + height, EndPoint.Y + width) };
                graphics.DrawPolygon(penArrow, curvePoints);
                graphics.DrawLines(penDash, GetPoints(-height).ToArray());
            }            
            //graphics.DrawPolygon(penArrow, curvePoints);
        }
        public void MakeAggregation(Color color, float penWidth, Graphics graphics, Point startPoint, Point currentPoint, bool version = true)
        {
            int width = 15;
            int height = 24;

            Pen pen = new Pen(color, penWidth);

  
            if (version == true)
            {
 
                if (EndPoint.X > StartPoint.X)
                {
                    Point[] curvePoints = { EndPoint, new Point(EndPoint.X - height, EndPoint.Y - width), new Point(EndPoint.X - 2 * height, EndPoint.Y), new Point(EndPoint.X - height, EndPoint.Y + width) };
                    graphics.DrawPolygon(pen, curvePoints);
                    graphics.DrawLines(pen, GetPoints(2 * height).ToArray());
                }
                else
                {
                    Point[] curvePoints = { EndPoint, new Point(EndPoint.X + height, EndPoint.Y - width), new Point(EndPoint.X + 2 * height, EndPoint.Y), new Point(EndPoint.X + height, EndPoint.Y + width) };
                    graphics.DrawPolygon(pen, curvePoints);
                    graphics.DrawLines(pen, GetPoints(-2 * height).ToArray());
                }                
            }
            else
            {
    

                if (EndPoint.X > startPoint.X) 
                {
                    Point[] curvePoints = { StartPoint, new Point(StartPoint.X + height, StartPoint.Y - width), new Point(StartPoint.X + 2 * height, StartPoint.Y), new Point(StartPoint.X + height, StartPoint.Y + width) };
                    graphics.DrawPolygon(pen, curvePoints);
                    graphics.DrawLines(pen, GetPoints(0, -2 * height).ToArray());

                    Point[] arrowPoints = { new Point(EndPoint.X - height, EndPoint.Y - width), EndPoint, new Point(EndPoint.X - height, EndPoint.Y + width) };
                    graphics.DrawLines(pen, arrowPoints);
                }
                else
                {
                    Point[] curvePoints = { StartPoint, new Point(StartPoint.X - height, StartPoint.Y - width), new Point(StartPoint.X - 2 * height, StartPoint.Y), new Point(StartPoint.X - height, StartPoint.Y + width) };
                    graphics.DrawPolygon(pen, curvePoints);
                    graphics.DrawLines(pen, GetPoints(0, 2 * height).ToArray());

                    Point[] arrowPoints = { new Point(EndPoint.X + height, EndPoint.Y - width), EndPoint,  new Point(EndPoint.X + height, EndPoint.Y + width) };
                    graphics.DrawLines(pen, arrowPoints);
                }

            }

        }
        public void MakeComposition(Color color, float penWidth, Graphics graphics, Point startPoint, Point currentPoint, bool version = true)
        {
            int width = 15;
            int height = 24;

            Pen pen = new Pen(color, penWidth);
            SolidBrush brush = new SolidBrush(color);

            if (version == true)
            {
  

                if (EndPoint.X > StartPoint.X)
                {
                    Point[] curvePoints = { EndPoint, new Point(EndPoint.X - height, EndPoint.Y - width), new Point(EndPoint.X - 2 * height, EndPoint.Y), new Point(EndPoint.X - height, EndPoint.Y + width) };
                    graphics.DrawPolygon(pen, curvePoints);
                    graphics.DrawLines(pen, GetPoints(2 * height).ToArray());
                    graphics.FillPolygon(brush, curvePoints);
                }
                else
                {
                    Point[] curvePoints = { EndPoint, new Point(EndPoint.X + height, EndPoint.Y - width), new Point(EndPoint.X + 2 * height, EndPoint.Y), new Point(EndPoint.X + height, EndPoint.Y + width) };
                    graphics.DrawPolygon(pen, curvePoints);
                    graphics.DrawLines(pen, GetPoints(-2 * height).ToArray());
                    graphics.FillPolygon(brush, curvePoints);
                }
            }
            else
            {


                if (EndPoint.X > startPoint.X)
                {
                    Point[] curvePoints = { StartPoint, new Point(StartPoint.X + height, StartPoint.Y - width), new Point(StartPoint.X + 2 * height, StartPoint.Y), new Point(StartPoint.X + height, StartPoint.Y + width) };
                    graphics.DrawPolygon(pen, curvePoints);
                    graphics.DrawLines(pen, GetPoints(0, -2 * height).ToArray());

                    Point[] arrowPoints = { new Point(EndPoint.X - height, EndPoint.Y - width), EndPoint,  new Point(EndPoint.X - height, EndPoint.Y + width) };
                    graphics.DrawLines(pen, arrowPoints);
                    graphics.FillPolygon(brush, curvePoints);
                }
                else
                {
                    Point[] curvePoints = { StartPoint, new Point(StartPoint.X - height, StartPoint.Y - width), new Point(StartPoint.X - 2 * height, StartPoint.Y), new Point(StartPoint.X - height, StartPoint.Y + width) };
                    graphics.DrawPolygon(pen, curvePoints);
                    graphics.DrawLines(pen, GetPoints(0, 2 * height).ToArray());

                    Point[] arrowPoints = { new Point(EndPoint.X + height, EndPoint.Y - width), EndPoint,new Point(EndPoint.X + height, EndPoint.Y + width) };
                    graphics.DrawLines(pen, arrowPoints);
                    graphics.FillPolygon(brush, curvePoints);
                }
            }
        }

        public List<Point> GetPoints(int endLineCutter = 0, int startLineCutter = 0)
        {
            List <Point> points = new List<Point>();

            //if()
            points.Add(new Point(StartPoint.X - startLineCutter, StartPoint.Y));
            int middleX = (StartPoint.X + EndPoint.X) / 2;
            points.Add(new Point(middleX, StartPoint.Y));
            points.Add(new Point(middleX, EndPoint.Y));
            points.Add(new Point(EndPoint.X - endLineCutter, EndPoint.Y));
            return points;
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
    }
}

