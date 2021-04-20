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
    public class CompositionSecondPointerFactory : IFactory
    {
        IArrow _typeArrow;
        ILine _typeLine;
        public CompositionSecondPointerFactory()
        {
        }
        public IShape GetShape()
        {
            _typeArrow = new CompositionSecondArrow();
            _typeLine = new NormalLine();
            AbstractPointer shape = new AbstractPointer(_typeArrow, _typeLine);
            return shape;
        }
    }
}
