using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLDesigner.Interfaces
{
    public interface IFactory
    {
        public IShape GetShape();
    }
}
