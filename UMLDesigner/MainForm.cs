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

        bool _changerText = false;

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


            if (!(_currentFactory is null))
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
            if (_currentShape != null && _currentFactory != null)
            {
                _currentShape.OnMouseMove(e, _shapes);
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (_currentShape != null)
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


            if (_changerText == true)
            {
                var appleR = AbstractRectangle.GetCurrentRectangle(e);

                if (!(appleR is null))
                {
                    //MyGraphics.GetInstance().GetMainGraphics();


                    appleR.NameFont = new Font("Arial", 42);
                    
                    _changerText = false;
                    MyGraphics.GetInstance().SetTmpBitmapAsMain();
                   //pictureBox1.Image = MyGraphics.GetInstance()._mainBitmap;
                }
            }


        }




        //public IShape PickOut(MouseEventArgs e)
        //{
        //    foreach (IShape _currentShape in _shapes)
        //    {
        //        if (_currentShape is AbstractRectangle)
        //        {
        //            if (e.Location.X > _currentShape.StartPoint.X &&
        //                e.Location.X < _currentShape.StartPoint.X + _currentShape.EndPoint.X &&
        //                e.Location.Y > _currentShape.StartPoint.Y &&
        //                e.Location.Y < _currentShape.StartPoint.Y + _currentShape.EndPoint.Y)
        //            {
        //                return _currentShape;
        //            }
        //        }
        //    }
        //    return _currentShape = null;
        //}

        private void SnapArrow(Point clickPoint)
        {
            //bool z = false;
            //foreach (IShape shape in _shapes)
            //{
            //    if (shape is EntityShape &&
            //        clickPoint.X > shape.StartPoint.X &&
            //        clickPoint.X < shape.StartPoint.X + shape.EndPoint.X &&
            //        clickPoint.Y > shape.StartPoint.Y &&
            //        clickPoint.Y < shape.StartPoint.Y + shape.EndPoint.Y)           /*логика зависит от ширины квадрата. Переписать когда енд поин будут обозначать 
            //                                                                         * координату а не ширину*/
        //    {
        //        z = true;
        //        if (_drawArrow)
        //        {
        //            _tmpShape = new PointerShape(new Point(shape.StartPoint.X, clickPoint.Y), _color, _penWidth, _act);
        //            _drawArrow = false;
        //            _mainBitmap = _tempBitmap;
        //        }
        //        else
        //        {
        //            if (_tmpShape.StartPoint.X < clickPoint.X)
        //            {
        //                _tmpShape.EndPoint = new Point(shape.StartPoint.X, clickPoint.Y);
        //                _tmpShape.StartPoint = new Point(_tmpShape.StartPoint.X + 160, _tmpShape.StartPoint.Y);
        //            }
        //            else
        //            {
        //                _tmpShape.EndPoint = new Point(shape.StartPoint.X + 160, clickPoint.Y);
        //            }
        //            _drawArrow = true;
        //            _shapes.Add(_tmpShape);
        //            _mainBitmap = _tempBitmap;

        //            Graphics.FromImage(_mainBitmap).Clear(Color.White);
        //            foreach (IShape a in _shapes)
        //            {
        //                a.Draw(_graphics);
        //            }
        //            _graphics.DrawImage(_mainBitmap, 0, 0);
        //            pictureBox1.Image = _mainBitmap;

        //        }
        //        break;
        //    }

        //}

        //if (!z)
        //{
        //    foreach (IShape shape in _shapes)
        //        if (shape is EntityShape)
        //        {
        //            EntityShape temp = (EntityShape)shape;
        //            if (!(clickPoint.X > temp.StartPoint.X &&
        //       clickPoint.X < temp.StartPoint.X + temp.EndPoint.X &&
        //       clickPoint.Y > temp.StartPoint.Y &&
        //       clickPoint.Y < temp.StartPoint.Y + temp.EndPoint.Y))
        //            {
        //                _graphics.Clear(Color.White);
        //                foreach (var s in _shapes)
        //                {
        //                    s.Draw(_graphics);
        //                    pictureBox1.Image = _mainBitmap;
        //                }
        //                _drawArrow = true;
        //            }
        //        }
        //}
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
            //_act = ActShapes.Association;
        }

        private void buttonInheritance_Click(object sender, EventArgs e)
        {
            //_act = ActShapes.Inheritance;
            _currentFactory = new InheritancePointersFactory();
            _currentShape = _currentFactory.GetShape();
        }

        private void buttonImplementation_Click(object sender, EventArgs e)
        {
            //_act = ActShapes.Implementation;
            _currentFactory = new ImplementationsPointersFactory();
            _currentShape = _currentFactory.GetShape();
        }

        private void buttonAggregationFirst_Click(object sender, EventArgs e)
        {
            _currentFactory = new AggregationFirstPointerFactory();
            _currentShape = _currentFactory.GetShape();
            
        }

        private void buttonAggregationSecond_Click(object sender, EventArgs e)
        {
            _currentFactory = new AggregationSecondPointerFactory();
            _currentShape = _currentFactory.GetShape();
        }

        private void buttonCompositionFirst_Click(object sender, EventArgs e)
        {            
            _currentFactory = new CompositionFirstPointerFactory();
            _currentShape = _currentFactory.GetShape();
        }

        private void buttonCompositionSecond_Click(object sender, EventArgs e)
        {
            //_act = ActShapes.CompositionSecond;
            _currentFactory = new CompositionSecondPointerFactory();
            _currentShape = _currentFactory.GetShape();
        }

        private void buttonClass_Click(object sender, EventArgs e)
        {
            _currentFactory = new ClassRectangleFactory();
            _currentShape = _currentFactory.GetShape();
        }

        private void buttonInterface_Click(object sender, EventArgs e)
        {
            _currentFactory = new InterfaceRectangleFactory();
            _currentShape = _currentFactory.GetShape();
        }

        private void buttonStackClass_Click(object sender, EventArgs e)
        {
            _currentFactory = new StackRectangleFactory();
            _currentShape = _currentFactory.GetShape();
        }

        private void buttonEnum_Click(object sender, EventArgs e)
        {
            _currentFactory = new EnumRectangleFactory();
            _currentShape = _currentFactory.GetShape();
        }

        private void buttonStructure_Click(object sender, EventArgs e)
        {
            _currentFactory = new StructureRectangleFactory();
            _currentShape = _currentFactory.GetShape();
        }

        private void buttonDelegate_Click(object sender, EventArgs e)
        {
            _currentFactory = new DelegateRectangleFactory();
            _currentShape = _currentFactory.GetShape();

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
            foreach (var shape in _shapes)
            {
                shape.Draw();
            }
            pictureBox1.Image = MyGraphics.GetInstance()._mainBitmap;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = _shapes.Count + "";
        }

        private void buttonChangeText_Click(object sender, EventArgs e)
        {
            _changerText = true;
           
        }
    }
}
