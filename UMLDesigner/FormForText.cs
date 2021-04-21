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
        public FormForText()
        {
            InitializeComponent();
        }

        public static string TextName { get; set; }
        public static string TextField { get; set; }
        public string TextProperties { get; set; }
        public string TextMethod { get; set; }


        private void buttonOK_Click(object sender, EventArgs e)
        {
            TextName = textBoxNameRectangle.Text;
            TextField = textBoxFieldRectangle.Text;
            TextProperties = textBoxPropertiesRectangle.Text;
            TextMethod = textBoxMethodRectangle.Text;
            

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
