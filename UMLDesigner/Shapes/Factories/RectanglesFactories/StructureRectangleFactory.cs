using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLDesigner.Interfaces;
using UMLDesigner.Shapes.Rectangles;

namespace UMLDesigner.Shapes.Factories.RectanglesFactories
{
    public class StructureRectangleFactory : IFactory
    {
        IRectangle _typeRectangle;
        public StructureRectangleFactory()
        {
            //_typeRectangle = new ClassRectangle();
        }
        public IShape GetShape()
        {
            _typeRectangle = new StructureRectangle();
            AbstractRectangle shape = new AbstractRectangle(_typeRectangle);
            return shape;
        }
    }
}
