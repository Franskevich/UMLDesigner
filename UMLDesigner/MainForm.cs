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
using UMLDesigner.Shapes;
using UMLDesigner.Shapes.Factories;
using UMLDesigner.Shapes.Factories.RectanglesFactories;

namespace UMLDesigner
{
    public partial class MainForm : Form
    {
        public IShape _currentShape;
        public IFactory _currentFactory;
        // новое сверху
        ActShapes _act = ActShapes.Association;
        bool _mouseDown = false;
        bool _isEntity = false;
        Bitmap _mainBitmap;
        Bitmap _tempBitmap;
        //Graphics _graphics;
        Color _color;
        IShape _tmpShape;
        int _penWidth = 1;
        public List<IShape> _shapes;
        bool _drawArrow = true;
        MyGraphics _graphics;
        private Point _clickPoint;


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _graphics = MyGraphics.GetInstance();
            _graphics.SetPB(pictureBox1);

            ToolTip tAssociation = new ToolTip();
            tAssociation.SetToolTip(buttonAssociation, "Association");
            ToolTip tInheritance = new ToolTip();
            tInheritance.SetToolTip(buttonInheritance, "Inheritance");
            ToolTip tImplementation = new ToolTip();
            tImplementation.SetToolTip(buttonImplementation, "Implementation");
            ToolTip tAggregation1 = new ToolTip();
            tAggregation1.SetToolTip(buttonAggregationFirst, "Aggregation");
            ToolTip tAggregation2 = new ToolTip();
            tAggregation2.SetToolTip(buttonAggregationSecond, "Aggregation");
            ToolTip tComposition1 = new ToolTip();
            tComposition1.SetToolTip(buttonCompositionFirst, "Composition");
            ToolTip tComposition2 = new ToolTip();
            tComposition2.SetToolTip(buttonCompositionSecond, "Composition");

            
            _color = Color.Black;
            _graphics.Shapes = new List<IShape>();
            _shapes = _graphics.Shapes;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(_act == ActShapes.Move)
            {
                _currentShape = PickOut(e);
                if(_currentShape != null)
                {
                    MyGraphics.GetInstance().GetMainGraphics();
                    _clickPoint = e.Location;
                }
                else
                {
                   // MyGraphics.GetInstance().SetImageToMainBitmap();
                }
            }
            else if(!(_currentFactory is null))
            {
                if (_currentShape is AbstractPointer)
                {
                    AbstractPointer t = (AbstractPointer)_currentShape;
                    if (t._endCreate == true)
                    {
                        _currentShape = _currentFactory.GetShape();
                    }
                }
         
                if (_currentShape != null)
                {
                    _currentShape.OnMouseDown(e, _shapes);
                }
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_act == ActShapes.Move)
            {
                if (_currentShape is AbstractRectangle)
                {
                    //MyGraphics.GetInstance()._graphics.Clear(Color.White);
                    MyGraphics.GetInstance().GetMainGraphics().Clear(Color.White);
                    _currentShape.Move(e.X - _clickPoint.X, e.Y - _clickPoint.Y);
                    foreach (var shape in _shapes)
                    {
                        shape.Draw();
                    }
                    _clickPoint = e.Location;

                }
                else if(_currentShape is AbstractPointer)
                {
                    MyGraphics.GetInstance().GetMainGraphics().Clear(Color.Pink);
                }
            }

            if (_currentShape != null && _currentFactory != null)
            {
                _currentShape.OnMouseMove(e, _shapes);
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (_act == ActShapes.Move)
            {
                MyGraphics.GetInstance().GetMainGraphics();

                if (_currentShape != null)
                {
                    _currentShape = null;
                    MyGraphics.GetInstance().SetTmpBitmapAsMain();
                }

            }
            else if (_currentShape != null)
            {
                _currentShape.OnMouseUp(e);
                pictureBox1.Image = MyGraphics.GetInstance()._mainBitmap;
                if (_currentShape is AbstractPointer)
                {

                    AbstractPointer t = (AbstractPointer)_currentShape;
                    if (t._endCreate == true)
                    {
                        _shapes.Add(_currentShape);
                    }
                }
                else
                {
                    _shapes.Add(_currentShape);
                }
            }

            if (_currentShape is AbstractRectangle)
            {
                _currentShape = null;
                _currentFactory = null;
            }

        }
        private void SnapArrow(Point clickPoint)
        {
        }

        public IShape PickOut(MouseEventArgs e)
        {
            foreach(IShape _currentShape in _shapes)
            {
                if(_currentShape is AbstractRectangle)
                {
                    if(e.Location.X > _currentShape.StartPoint.X &&
                        e.Location.X < _currentShape.StartPoint.X + _currentShape.EndPoint.X &&
                        e.Location.Y > _currentShape.StartPoint.Y &&
                        e.Location.Y < _currentShape.StartPoint.Y + _currentShape.EndPoint.Y)
                    {
                        return _currentShape;
                    }
                }
                else
                {
                    AbstractPointer tmpPointer = (AbstractPointer)_currentShape;
                    Point point1 = tmpPointer.StartPoint;
                    Point point2 = tmpPointer.InsidePoint1;
                    Point point3 = tmpPointer.InsidePoint2;
                    Point point4 = tmpPointer.EndPoint;

                    if(point1.X > point4.X)
                    {
                        Point tmpPoint = point4;
                        point4 = point1;
                        point1 = tmpPoint;
                    }
                    if(point2.Y > point3.Y)
                    {
                        Point tmpPoint = point3;
                        point3 = point2;
                        point2 = tmpPoint;
                    }

                    if ((e.Location.X > point1.X &&
                        e.Location.X < point2.X &&
                        e.Location.Y > point1.Y-3 &&
                        e.Location.Y < point1.Y+3) || 
                        (e.Location.X > point3.X &&
                        e.Location.X < point4.X &&
                        e.Location.Y > point4.Y - 3 &&
                        e.Location.Y < point4.Y + 3) ||
                        (e.Location.X < point2.X + 3 &&
                        e.Location.X > point2.X - 3 &&
                        e.Location.Y > point2.Y &&
                        e.Location.Y < point3.Y)) 
                    {
                        return _currentShape;
                    }
                }
            }
            return _currentShape = null;
        }


        private void buttonColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            buttonColor.BackColor = colorDialog1.Color;
            _color = colorDialog1.Color;
        }

        private void buttonAssociation_Click(object sender, EventArgs e)
        {
            _currentFactory = new AssotiationPointerFactory();
            _currentShape = _currentFactory.GetShape();
            _act = ActShapes.Pointer;

            //_act = ActShapes.Association;
        }

        private void buttonInheritance_Click(object sender, EventArgs e)
        {
            //_act = ActShapes.Inheritance;
            _currentFactory = new InheritancePointersFactory();
            _currentShape = _currentFactory.GetShape();
            _act = ActShapes.Pointer;

        }

        private void buttonImplementation_Click(object sender, EventArgs e)
        {
            //_act = ActShapes.Implementation;
            _currentFactory = new ImplementationsPointersFactory();
            _act = ActShapes.Pointer;

            _currentShape = _currentFactory.GetShape();
        }

        private void buttonAggregationFirst_Click(object sender, EventArgs e)
        {
            _currentFactory = new AggregationFirstPointerFactory();
            _currentShape = _currentFactory.GetShape();
            _act = ActShapes.Pointer;


        }

        private void buttonAggregationSecond_Click(object sender, EventArgs e)
        {
            _currentFactory = new AggregationSecondPointerFactory();
            _currentShape = _currentFactory.GetShape();
            _act = ActShapes.Pointer;

        }

        private void buttonCompositionFirst_Click(object sender, EventArgs e)
        {            
            _currentFactory = new CompositionFirstPointerFactory();
            _currentShape = _currentFactory.GetShape();
            _act = ActShapes.Pointer;

        }

        private void buttonCompositionSecond_Click(object sender, EventArgs e)
        {
            _currentFactory = new CompositionSecondPointerFactory();
            _currentShape = _currentFactory.GetShape();
            _act = ActShapes.Pointer;
        }

        private void buttonClass_Click(object sender, EventArgs e)
        {
            _currentFactory = new ClassRectangleFactory();
            _currentShape = _currentFactory.GetShape();
            _act = ActShapes.Retangle;
        }

        private void buttonInterface_Click(object sender, EventArgs e)
        {
            _currentFactory = new InterfaceRectangleFactory();
            _currentShape = _currentFactory.GetShape();
            _act = ActShapes.Retangle;
        }

        private void buttonStackClass_Click(object sender, EventArgs e)
        {
            _currentFactory = new StackRectangleFactory();
            _currentShape = _currentFactory.GetShape();
            _act = ActShapes.Retangle;
        }

        private void buttonEnum_Click(object sender, EventArgs e)
        {
            _currentFactory = new EnumRectangleFactory();
            _currentShape = _currentFactory.GetShape();
            _act = ActShapes.Retangle;
        }

        private void buttonStructure_Click(object sender, EventArgs e)
        {
            _currentFactory = new StructureRectangleFactory();
            _currentShape = _currentFactory.GetShape();
            _act = ActShapes.Retangle;
        }

        private void buttonDelegate_Click(object sender, EventArgs e)
        {
            _currentFactory = new DelegateRectangleFactory();
            _currentShape = _currentFactory.GetShape();
            _act = ActShapes.Retangle;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            _penWidth = trackBar1.Value;

            /*Graphics grafTemporary;
            grafTemporary = Graphics.FromImage(_tempBitmap);
            grafTemporary.Clear(Color.White);
            foreach (var shape in _shapes)
            {
                shape.PenWidth = _penWidth;
                shape.Draw(grafTemporary);
            }*/
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {

            Graphics.FromImage(MyGraphics.GetInstance()._mainBitmap).Clear(Color.White);
            //MyGraphics.GetInstance().SetTmpBitmapAsMain;
            Graphics.FromImage(MyGraphics.GetInstance()._tmpBitmap).Clear(Color.White);
            _shapes.Clear();
            _currentShape = null;
            _currentFactory = null;

            //_graphics.DrawImage(_mainBitmap, 0, 0);
            pictureBox1.Image = _mainBitmap;
        }


        private void buttonСancel_Click(object sender, EventArgs e)
        {
            Cancel();     /*вывел в отдельный метод чтобы потом сделать возможность использовать метод    
                           cancel по нажатию на клавиши ctrl + z*/
        }

        private void Cancel()
        {

            Graphics.FromImage(MyGraphics.GetInstance()._mainBitmap).Clear(Color.White);
            _currentShape = null;
            _currentFactory = null;

            _shapes.RemoveAt(_shapes.Count - 1);
            MyGraphics.GetInstance().GetMainGraphics();

            foreach (var shape in _shapes)
            {
                shape.Draw();
            }
            pictureBox1.Image = MyGraphics.GetInstance()._mainBitmap;
            MyGraphics.GetInstance().GetTmpGraphics();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = _shapes.Count + "";
        }

        private void ButtonMove_Click(object sender, EventArgs e)
        {
            _act = ActShapes.Move;
            _currentShape = null;
        }
    }
}
