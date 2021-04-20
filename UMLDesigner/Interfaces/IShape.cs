using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UMLDesigner
{
    public interface IShape
    {
        public void OnMouseMove(MouseEventArgs e, List<IShape> shapes);
        public void OnMouseDown(MouseEventArgs e, List<IShape> shapes);
        public void OnMouseUp(MouseEventArgs e);
        public void Draw();
    }
}
