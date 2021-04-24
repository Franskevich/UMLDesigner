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
        }

    }
}
