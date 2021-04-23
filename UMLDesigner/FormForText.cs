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

        public FormForText(AbstractRectangle abs)
        {
            abs.Fields.Add(TextField);
            _currentRectangle = abs;

            InitializeComponent();
        }
        

        // public List<string> TextName { get; set; } = new List<string>();
        public string TextField { get; set; }
        public string TextProperties { get; set; }
        public string TextMethod { get; set; }


        private void FormForText_Load(object sender, EventArgs e)
        {
            //textBoxFieldRectangle.Text = _currentRectangle.Fields.ToString();

            int count = _currentRectangle.Fields.Count;

            for (int i = 0; count > i; i++)
            {
                textBoxFieldRectangle.Text += _currentRectangle.Fields[i];
            }



        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            //TextName.Add(textBoxNameRectangle.Text);

            TextField = textBoxFieldRectangle.Text;

            //TextProperties = textBoxPropertiesRectangle.Text;
            //TextMethod = textBoxMethodRectangle.Text;

            _currentRectangle.ChangeText(TextField);

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }
        
    }
}
