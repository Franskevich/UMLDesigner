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
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public Color Color { get; set; }
        public int PenWidth { get; set; }


        public void OnMouseMove(MouseEventArgs e, List<IShape> shapes);
        public void OnMouseDown(MouseEventArgs e, List<IShape> shapes);
        public void OnMouseUp(MouseEventArgs e);
        public void Draw();
        public void Pick();
        public void Move(int deltaX, int deltaY);
    }
}
