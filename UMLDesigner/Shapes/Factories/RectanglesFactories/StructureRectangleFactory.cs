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
        }

        public IShape GetShape()
        {
            _typeRectangle = new StructureRectangle();
            BaseRectangle shape = new BaseRectangle(_typeRectangle, "Structure", new System.Drawing.Point(180, 190));
            return shape;
        }
    }
}
