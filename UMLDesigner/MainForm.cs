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
using UMLDesigner.Shapes;
using UMLDesigner.Shapes.Factories;
using UMLDesigner.Shapes.Factories.RectanglesFactories;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;


namespace UMLDesigner
{
    public partial class MainForm : Form
    {
        private ActShapes _act = ActShapes.Move;
        private Bitmap _mainBitmap;
        private List<IShape> _shapes;
        private MyGraphics _graphics;
        private Point _clickPoint;
        private Point _movePoint;
        private IShape _currentShape;
        private IFactory _currentFactory;

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
            ToolTip buttonWidth = new ToolTip();
            tComposition2.SetToolTip(buttonWidthRectangle, "Change");
            ToolTip buttonChoose = new ToolTip();
            tComposition2.SetToolTip(buttonMove, "Choose");

            _graphics.Shapes = new List<IShape>();
            _shapes = _graphics.Shapes;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((_act == ActShapes.ChangeWidth || _act == ActShapes.Move) && e.Button == MouseButtons.Left)
            {
                _currentShape = PickOut(e);
                _clickPoint = e.Location;
                SelectShape();
            }
            else if (_act == ActShapes.Move && e.Button == MouseButtons.Right )
            {
                _currentShape = PickOut(e);
                if (_currentShape is BasePointer)
                {
                    Options options = new Options(_currentShape);
                    SelectShape();
                    options.ShowDialog();
                }
                else if(_currentShape is BaseRectangle)
                {
                    FormForText formText = new FormForText((BaseRectangle)_currentShape);
                    formText.ShowDialog();
                }

                _currentShape = null;
                _currentFactory = null;
                MyGraphics.GetInstance().GetMainGraphics().Clear(Color.White);
                foreach (var shape in _shapes)
                {
                    shape.Draw();
                }
                MyGraphics.GetInstance().SetImageToMainBitmap();
            }
            else if (!(_currentFactory is null))
            {
                if (_currentShape is BasePointer)
                {
                    BasePointer t = (BasePointer)_currentShape;
                    if (t.EndCreate == true)
                    {
                        _currentShape = _currentFactory.GetShape();
                        _currentShape.Color = SetColor();
                        _currentShape.PenWidth = SetPenWidth();
                    }
                }
         
                if (_currentShape != null)
                {
                    _currentShape.Color = SetColor();
                    _currentShape.PenWidth = SetPenWidth();
                    _currentShape.OnMouseDown(e, _shapes);
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_act == ActShapes.Move && e.Button == MouseButtons.Left )
            {
                if (_currentShape != null)
                {
                    _movePoint = _currentShape.PickPoint(e);
                    MyGraphics.GetInstance().GetMainGraphics().Clear(Color.White);
                    _currentShape.Move(e.X - _clickPoint.X, e.Y - _clickPoint.Y);

                    foreach (var shape in _shapes)
                    {
                        shape.Draw();
                    }
                    MyGraphics.GetInstance().SetTmpBitmapAsMain();

                    _clickPoint = e.Location;
                }
            }
            else if (_act == ActShapes.ChangeWidth && e.Button == MouseButtons.Left )
            {
                if (_currentShape != null)
                {
                    _movePoint = _currentShape.PickPoint(e);
                    MyGraphics.GetInstance().GetMainGraphics().Clear(Color.White);
                    _currentShape.ChangeShape(_movePoint, e.X - _clickPoint.X, e.Y - _clickPoint.Y);

                    foreach (var shape in _shapes)
                    {
                        shape.Draw();
                    }
                    MyGraphics.GetInstance().SetTmpBitmapAsMain();

                    _clickPoint = e.Location;
                }
            }

            if (_currentShape != null && _currentFactory != null)
            {
                _currentShape.OnMouseMove(e, _shapes);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (_act == ActShapes.Move || _act == ActShapes.ChangeWidth)
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
                if (_currentShape is BasePointer)
                {

                    BasePointer t = (BasePointer)_currentShape;
                    if (t.EndCreate == true)
                    {
                        _shapes.Add(_currentShape);
                    }
                }
                else
                {
                    _shapes.Add(_currentShape);
                }
            }

            if (_currentShape is BaseRectangle)
            {
                _currentShape = null;
                _currentFactory = null;
            }

            MyGraphics.GetInstance().GetMainGraphics().Clear(Color.White);
            foreach (var shape in _shapes)
            {
                shape.Draw();
            }
        }

        public void SelectShape()
        {
            if (_currentShape is BaseRectangle)
            {
                MyGraphics.GetInstance().GetMainGraphics();
            }
            else if (_currentShape is BasePointer)
            {
                SolidBrush tmpBrusn = new SolidBrush(Color.Red);
                BasePointer tpmPointer = (BasePointer)_currentShape;
                Graphics tmpGraphics = MyGraphics.GetInstance().GetTmpGraphics();
                tmpGraphics.FillEllipse(tmpBrusn, tpmPointer.StartPoint.X - (tpmPointer.PenWidth + 5) / 2, tpmPointer.StartPoint.Y - (tpmPointer.PenWidth + 5) / 2, tpmPointer.PenWidth + 5, tpmPointer.PenWidth + 5);
                tmpGraphics.FillEllipse(tmpBrusn, tpmPointer.EndPoint.X - (tpmPointer.PenWidth + 5) / 2, tpmPointer.EndPoint.Y - (tpmPointer.PenWidth + 5) / 2, tpmPointer.PenWidth + 5, tpmPointer.PenWidth + 5);
                tmpGraphics.FillEllipse(tmpBrusn, tpmPointer.InsidePoint1.X - (tpmPointer.PenWidth + 5) / 2, tpmPointer.InsidePoint1.Y - (tpmPointer.PenWidth + 5) / 2, tpmPointer.PenWidth + 5, tpmPointer.PenWidth + 5);
                tmpGraphics.FillEllipse(tmpBrusn, tpmPointer.InsidePoint2.X - (tpmPointer.PenWidth + 5) / 2, tpmPointer.InsidePoint2.Y - (tpmPointer.PenWidth + 5) / 2, tpmPointer.PenWidth + 5, tpmPointer.PenWidth + 5);
                MyGraphics.GetInstance().SetImageToTmpBitmap();
                MyGraphics.GetInstance().GetMainGraphics();
            }
            else
            {
                MyGraphics.GetInstance().GetMainGraphics().Clear(Color.White);
                foreach (var shape in _shapes)
                {
                    shape.Draw();
                }
                MyGraphics.GetInstance().SetImageToMainBitmap();
            }
        }

        public IShape PickOut(MouseEventArgs e)
        {
            foreach(IShape _currentShape in _shapes)
            {
                if(_currentShape is BaseRectangle)
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
                    BasePointer tmpPointer = (BasePointer)_currentShape;
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
                        e.Location.Y > point1.Y-10 &&
                        e.Location.Y < point1.Y+10) || 
                        (e.Location.X > point3.X &&
                        e.Location.X < point4.X &&
                        e.Location.Y > point4.Y - 10 &&
                        e.Location.Y < point4.Y + 10) ||
                        (e.Location.X < point2.X + 10 &&
                        e.Location.X > point2.X - 10 &&
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
        }

        public Color SetColor()
        {
            return colorDialog1.Color;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
        }

        public static void DeleteShape(IShape shape, List<IShape> shapes)
        {
            shapes.Remove(shape);
            if(shape is BaseRectangle)
            {
                BaseRectangle shapeRectangle = (BaseRectangle)shape;
                foreach(BasePointer pointer in shapeRectangle.ConnectionsStart)
                {
                    shapes.Remove(pointer);
                }
                foreach(BasePointer pointer in shapeRectangle.ConnectionsEnd)
                {
                    shapes.Remove(pointer);
                }
            }
            MyGraphics.GetInstance().GetMainGraphics().Clear(Color.White);
            foreach (IShape currentShape in shapes)
            {
                currentShape.Draw();
            }
            MyGraphics.GetInstance().SetImageToMainBitmap();
        }

        public int SetPenWidth()
        {
            return trackBar1.Value;
        }

        private void buttonAssociation_Click(object sender, EventArgs e)
        {
            _currentFactory = new AssotiationPointerFactory();
            _currentShape = _currentFactory.GetShape();
            _act = ActShapes.Pointer;
        }

        private void buttonInheritance_Click(object sender, EventArgs e)
        {
            _currentFactory = new InheritancePointersFactory();
            _currentShape = _currentFactory.GetShape();
            _act = ActShapes.Pointer;

        }

        private void buttonImplementation_Click(object sender, EventArgs e)
        {
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
            _act = ActShapes.Rectangle;
        }

        private void buttonInterface_Click(object sender, EventArgs e)
        {
            _currentFactory = new InterfaceRectangleFactory();
            _currentShape = _currentFactory.GetShape();
            _act = ActShapes.Rectangle;
        }

        private void buttonStackClass_Click(object sender, EventArgs e)
        {
            _currentFactory = new StackRectangleFactory();
            _currentShape = _currentFactory.GetShape();
            _act = ActShapes.Rectangle;
        }

        private void buttonEnum_Click(object sender, EventArgs e)
        {
            _currentFactory = new EnumRectangleFactory();
            _currentShape = _currentFactory.GetShape();
            _act = ActShapes.Rectangle;
        }

        private void buttonStructure_Click(object sender, EventArgs e)
        {
            _currentFactory = new StructureRectangleFactory();
            _currentShape = _currentFactory.GetShape();
            _act = ActShapes.Rectangle;
        }

        private void buttonDelegate_Click(object sender, EventArgs e)
        {
            _currentFactory = new DelegateRectangleFactory();
            _currentShape = _currentFactory.GetShape();
            _act = ActShapes.Rectangle;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Graphics.FromImage(MyGraphics.GetInstance()._mainBitmap).Clear(Color.White);
            Graphics.FromImage(MyGraphics.GetInstance()._tmpBitmap).Clear(Color.White);
            _shapes.Clear();
            _currentShape = null;
            _currentFactory = null;
            pictureBox1.Image = _mainBitmap;
        }


        private void buttonСancel_Click(object sender, EventArgs e)
        {
            Cancel();     
        }

        private void Cancel()
        {
            if( _shapes.Count != 0)
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
        }

        private void ButtonMove_Click(object sender, EventArgs e)
        {
            _act = ActShapes.Move;
            _currentShape = null;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {                             
            if(pictureBox1.Image != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Сохранить картинку как...";
                sfd.OverwritePrompt = true;
                sfd.CheckPathExists = true;
                sfd.Filter = "Image Files(*.QQQ;*.PNG)|*.QQQ;*.PNG";
                //sfd.Filter = "Image Files(*.QQQ)|*.QQQ";
                //sfd.Filter = "Image Files(*.PNG)|*.PNG";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        String path = sfd.FileName;                    
                        string s1 = path;
                        string s2 = ".QQQ";
                        bool b = s1.Contains(s2);
                        if (b)
                        {
                            using (StreamWriter sw = new StreamWriter(path, false))
                            {
                                var serialized = JsonConvert.SerializeObject(_shapes, Formatting.Indented,
                                    new JsonSerializerSettings
                                    {
                                        TypeNameHandling = TypeNameHandling.All
                                    });

                                sw.WriteLine(serialized);
                            }
                        }
                        else
                        {
                            pictureBox1.Image.Save(sfd.FileName);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.QQQ;*.PNG)|*.QQQ;*.PNG";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    String path = ofd.FileName;                      
                    string s1 = path;
                    string s2 = ".QQQ";
                    bool b = s1.Contains(s2);
                    if (b)
                    {
                        using (StreamReader sr = new StreamReader(path))
                        {
                            var desirialized = JsonConvert.DeserializeObject<List<IShape>>(sr.ReadToEnd(),
                                new JsonSerializerSettings
                                {
                                    TypeNameHandling = TypeNameHandling.All
                                });
                            _shapes = desirialized;

                            Graphics.FromImage(MyGraphics.GetInstance()._mainBitmap).Clear(Color.White);
                            foreach (var shape in _shapes)
                            {
                                shape.Draw();
                            }
                            pictureBox1.Image = MyGraphics.GetInstance()._mainBitmap;
                        }
                    }
                    else
                    {
                        pictureBox1.Image = new Bitmap(ofd.FileName);
                    }
                }
                catch
                {
                    MessageBox.Show("Невозможно сохранить", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void buttonWidthRectangle_Click(object sender, EventArgs e)
        {
            _act = ActShapes.ChangeWidth;
            _currentShape = null;
        }
    }
}
