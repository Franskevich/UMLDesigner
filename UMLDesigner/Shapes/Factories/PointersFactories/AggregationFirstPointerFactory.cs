using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLDesigner.Interfaces;

namespace UMLDesigner.Shapes
{
    public class AggregationFirstPointerFactory : IFactory
    {
        IArrow _typeArrow;
        ILine _typeLine;

        public AggregationFirstPointerFactory()
        {
        }

        public IShape GetShape()
        {
            _typeArrow = new AggregationFirstArrow();
            _typeLine = new NormalLine();
            BasePointer shape = new BasePointer(_typeArrow, _typeLine);
            return shape;
        }
    }
}
