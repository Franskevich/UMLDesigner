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
        }

        public IShape GetShape()
        {
            _typeRectangle = new EnumRectangle();
            BaseRectangle shape = new BaseRectangle(_typeRectangle, "Enum", new System.Drawing.Point(180, 130));
            return shape;
        }
    }
}
