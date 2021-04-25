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
    public partial class FormForText : Form
    {
        private AbstractRectangle _currentRectangle;

        public FormForText(AbstractRectangle rectangle)
        {
            InitializeComponent();
            _currentRectangle = rectangle;
        }

        private void FormForText_Load(object sender, EventArgs e)
        {
            textBoxName.Text = _currentRectangle.Name;
            textBoxProperties.Text = _currentRectangle.Properties;
            textBoxField.Text = _currentRectangle.Fields;
            textBoxMethods.Text = _currentRectangle.Methods;
            trackBarWidth.Value = _currentRectangle.PenWidth;
            buttonColor.BackColor = _currentRectangle.Color;

        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
                
        }

        private void textBoxProperties_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxField_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBoxMethods_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            _currentRectangle.ChangeText(textBoxName.Text, textBoxProperties.Text, textBoxField.Text, textBoxMethods.Text);
            this.Close();
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void trackBarWidth_Scroll(object sender, EventArgs e)
        {
            _currentRectangle.PenWidth = trackBarWidth.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            buttonColor.BackColor = colorDialog1.Color;
            _currentRectangle.Color = colorDialog1.Color;
        }

        private void buttonFont_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            //buttonColor.BackColor = colorDialog1.Color;
            _currentRectangle.ArgumentFont = fontDialog1.Font;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            MainForm.DeleteShape(_currentRectangle, MyGraphics.GetInstance().Shapes);
        }
    }
}
