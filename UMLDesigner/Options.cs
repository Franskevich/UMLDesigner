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
            this.Close();
        }
    }
}
