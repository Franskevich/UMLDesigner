using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLDesigner.Interfaces;
using UMLDesigner.Shapes.Rectangles;

namespace UMLDesigner.Shapes.Factories.RectanglesFactories
{
    public class ClassRectangleFactory : IFactory
    {
        IRectangle _typeRectangle;
        public ClassRectangleFactory()
        {
            //_typeRectangle = new ClassRectangle();
        }
        public IShape GetShape()
        {
            _typeRectangle = new ClassRectangle();
            AbstractRectangle shape = new AbstractRectangle(_typeRectangle, "Class", new Point(1000, 1000));
            return shape;
        }
    }
}
