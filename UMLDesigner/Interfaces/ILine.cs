using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLDesigner
{
    public interface ILine
    {
        public void Draw(Color color, int penWidth, Point startPoint, Point endPoint);
    }
}
