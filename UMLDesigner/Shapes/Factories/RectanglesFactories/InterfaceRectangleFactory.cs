﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLDesigner.Interfaces;
using UMLDesigner.Shapes.Rectangles;

namespace UMLDesigner.Shapes.Factories.RectanglesFactories
{
    public class InterfaceRectangleFactory : IFactory
    {
        IRectangle _typeRectangle;

        public InterfaceRectangleFactory()
        {
        }

        public IShape GetShape()
        {
            _typeRectangle = new InterfaceRectangle();
            BaseRectangle shape = new BaseRectangle(_typeRectangle, "<Interface>", new System.Drawing.Point(180, 160));
            return shape;
        }
    }
}
