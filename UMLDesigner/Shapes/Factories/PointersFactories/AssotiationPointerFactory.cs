using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLDesigner.Interfaces;

namespace UMLDesigner.Shapes
{
    public class AssotiationPointerFactory: IFactory
    {
        IArrow _typeArrow;
        ILine _typeLine;

        public AssotiationPointerFactory()
        {
        }

        public IShape GetShape()
        {
            _typeArrow = new AssociationArrow();
            _typeLine = new NormalLine();
            BasePointer shape = new BasePointer(_typeArrow, _typeLine);
            return shape;
        }
    }
}
