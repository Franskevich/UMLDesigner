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
        public void Draw(AbstractRectangle rectangle);
        //public void Draw(Color color, float penWidth, Point startPoint, Point size, Font argumentFont, string name, string properties, string fields, string methods, AbstractRectangle rectangle);
        //public void Draw(Color color, float penWidth, Point startPoint, Point size, int line, Font nameFont, Font argumentFont);
    }
}
