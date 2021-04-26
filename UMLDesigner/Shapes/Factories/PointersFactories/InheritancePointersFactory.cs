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
        }

        public IShape GetShape()
        {
            _typeArrow = new InheritanceArrow();
            _typeLine = new NormalLine();
            BasePointer shape = new BasePointer(_typeArrow, _typeLine);
            return shape;
        }
    }
}
