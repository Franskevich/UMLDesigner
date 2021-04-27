using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLDesigner.Interfaces;


namespace UMLDesigner.Shapes.Factories
{
    public class AggregationSecondPointerFactory : IFactory
    {
        IArrow _typeArrow;
        ILine _typeLine;

        public AggregationSecondPointerFactory()
        {
        }

        public IShape GetShape()
        {
            _typeArrow = new AggregationSecondArrow();
            _typeLine = new NormalLine();
            BasePointer shape = new BasePointer(_typeArrow, _typeLine);
            return shape;
        }
    }
}
