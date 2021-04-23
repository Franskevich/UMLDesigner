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
using UMLDesigner.Shapes.Rectangles;

namespace UMLDesigner.Interfaces
{
    public interface IRectangle
    {
        public void Draw(Color color, float penWidth, Point startPoint, Point size, int line, Font nameFont, Font argumentFont, string textLabel, List<string> textFields, List<string> textProperties, string textMethods);
    }
}
