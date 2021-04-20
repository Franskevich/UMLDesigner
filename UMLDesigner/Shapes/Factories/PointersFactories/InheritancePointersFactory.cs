using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLDesigner.Interfaces;

namespace UMLDesigner.Shapes
{
    public class InheritancePointersFactory : IFactory
    {
        IArrow _typeArrow;
        ILine _typeLine;
        public InheritancePointersFactory()
        {
            //_typeArrow = new InheritanceArrow();
            //_typeLine = new NormalLine();
        }
        public IShape GetShape()
        {
            _typeArrow = new InheritanceArrow();
            _typeLine = new NormalLine();
            AbstractPointer shape = new AbstractPointer(_typeArrow, _typeLine);
            return shape;
        }
    }
}
