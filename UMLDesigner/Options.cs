using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLDesigner
{
    public partial class Options : Form
    {
        private IShape _currentShape;

        public Options(IShape shape)
        {
            _currentShape = shape;
            InitializeComponent();
        }
        private void Options_Load(object sender, EventArgs e)
        {
            trackBarWidthLine.Value = _currentShape.PenWidth;
            buttonColor.BackColor = _currentShape.Color;
            AbstractPointer currentPointer = (AbstractPointer)_currentShape;
            if(currentPointer._typeLine is DashLine)
            {
                comboBoxTypeArrow.Text = "Implementation";
            }
            else if(currentPointer._typeArrow is InheritanceArrow)
            {
                comboBoxTypeArrow.Text = "Inheritance";
            }
            else if(currentPointer._typeArrow is CompositionFirstArrow)
            {
                comboBoxTypeArrow.Text = "Composition 1";
            }
            else if(currentPointer._typeArrow is CompositionSecondArrow)
            {
                comboBoxTypeArrow.Text = "Composition 2";
            }
            else if(currentPointer._typeArrow is AggregationFirstArrow)
            {
                comboBoxTypeArrow.Text = "Aggregation 1";
            }
            else if(currentPointer._typeArrow is AggregationSecondArrow)
            {
                comboBoxTypeArrow.Text = "Aggregation 2";
            }
            else
            {
                comboBoxTypeArrow.Text = "Association";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            buttonColor.BackColor = colorDialog1.Color;
            _currentShape.Color = colorDialog1.Color;
        }

        private void trackBarWidthLine_Scroll(object sender, EventArgs e)
        {
            _currentShape.PenWidth = trackBarWidthLine.Value;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            //MyGraphics.GetInstance().GetMainGraphics().Clear(Color.White);
            //foreach (var shape in MyGraphics.GetInstance().Shapes)
            //{
            //    shape.Draw();
            //}
            //MyGraphics.GetInstance().SetImageToMainBitmap();
            this.Close();

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            MainForm.DeleteShape(_currentShape, MyGraphics.GetInstance().Shapes);
            this.Close();

        }

        private void comboBoxTypeArrow_SelectedIndexChanged(object sender, EventArgs e)
        {
            AbstractPointer tmpPointer = (AbstractPointer)_currentShape;
            switch (comboBoxTypeArrow.Text)
            {
                case "Association":
                    tmpPointer._typeArrow = new AssociationArrow();
                    tmpPointer._typeLine = new NormalLine();
                    break;
                case "Aggregation 1":
                    tmpPointer._typeArrow = new AggregationFirstArrow();
                    tmpPointer._typeLine = new NormalLine();
                    break;
                case "Aggregation 2":
                    tmpPointer._typeArrow = new AggregationSecondArrow();
                    tmpPointer._typeLine = new NormalLine();
                    break;
                case "Composition 1":
                    tmpPointer._typeArrow = new CompositionFirstArrow();
                    tmpPointer._typeLine = new NormalLine();
                    break;
                case "Composition 2":
                    tmpPointer._typeArrow = new CompositionSecondArrow();
                    tmpPointer._typeLine = new NormalLine();
                    break;
                case "Implementation":
                    tmpPointer._typeArrow = new ImplementationsArrow();
                    tmpPointer._typeLine = new DashLine();
                    break;
                case "Inheritance":
                    tmpPointer._typeArrow = new InheritanceArrow();
                    tmpPointer._typeLine = new NormalLine();
                    break;
            }
        }
    }
}
