using System;
using System.Collections.Generic;
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
        }

        public IShape GetShape()
        {
            _typeRectangle = new ClassRectangle();
            BaseRectangle shape = new BaseRectangle(_typeRectangle, "Class", new System.Drawing.Point(180, 190));
            return shape;
        }
    }
}
