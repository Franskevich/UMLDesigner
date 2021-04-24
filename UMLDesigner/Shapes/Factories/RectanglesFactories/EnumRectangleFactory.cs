using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLDesigner.Interfaces;
using UMLDesigner.Shapes.Rectangles;

namespace UMLDesigner.Shapes.Factories.RectanglesFactories
{
    public class EnumRectangleFactory : IFactory
    {
        IRectangle _typeRectangle;
        public EnumRectangleFactory()
        {
            //_typeRectangle = new ClassRectangle();
        }
        public IShape GetShape()
        {
            _typeRectangle = new EnumRectangle();
            AbstractRectangle shape = new AbstractRectangle(_typeRectangle, "Enum");
            return shape;
        }
    }
}
