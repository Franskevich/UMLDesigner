using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLDesigner.Interfaces;

namespace UMLDesigner.Shapes.Factories
{
    public class ImplementationsPointersFactory : IFactory
    {
        IArrow _typeArrow;
        ILine _typeLine;

        public ImplementationsPointersFactory()
        {
        }

        public IShape GetShape()
        {
            _typeArrow = new ImplementationsArrow();
            _typeLine = new DashLine();
            BasePointer shape = new BasePointer(_typeArrow, _typeLine);
            return shape;
        }
    }
}
