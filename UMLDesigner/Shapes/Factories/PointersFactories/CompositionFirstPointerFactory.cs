using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLDesigner.Interfaces;
using UMLDesigner.Shapes.Arrows;

namespace UMLDesigner.Shapes.Factories
{
    public class CompositionFirstPointerFactory : IFactory
    {
        IArrow _typeArrow;
        ILine _typeLine;
        public CompositionFirstPointerFactory()
        {
        }

        public IShape GetShape()
        {
            _typeArrow = new CompositionFirstArrow();
            _typeLine = new NormalLine();
            AbstractPointer shape = new AbstractPointer(_typeArrow, _typeLine);
            return shape;
        }
    }
}
