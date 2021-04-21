﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLDesigner.Interfaces;
using UMLDesigner.Shapes.Rectangles;

namespace UMLDesigner.Shapes.Factories.RectanglesFactories
{
    public class DelegateRectangleFactory : IFactory
    {
        IRectangle _typeRectangle;

        public DelegateRectangleFactory()
        {
        }

        public IShape GetShape()
        {
            _typeRectangle = new DelegateRectangle();
            AbstractRectangle shape = new AbstractRectangle(_typeRectangle);
            return shape;
        }
    }
}
