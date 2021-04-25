using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UMLDesigner.Interfaces;

namespace UMLDesigner.Shapes.Rectangles
{
    public class InterfaceRectangle : IRectangle
    {
        //public string Name { get; set; }
        //public static int _countOfInterfaces = 0;

        //private Rectangle nameRect;
        //private Rectangle _fieldsRect;
        //private Rectangle _propetiesRect;
        //private Rectangle _otherRect;

        //private int _nameHeight = 50;
        //private int _fieldsHeight = 25;
        //private int _propertiesHeight = 25;
        //private int _otherHeight;

        //public bool isRollUp = false;
        //public int Height { get; private set; }
        //public List<string> Fields { get; set; }
        //public List<string> Properties { get; set; }
        //public List<string> Other { get; set; }
        //public List<PointerShape> Connections { get; set; }
       
        public InterfaceRectangle()
        {
            //Connections = new List<PointerShape>();
            //Fields = new List<string>();
            //Properties = new List<string>();
            //Other = new List<string>();
            //Name = "Interface" + _countOfInterfaces++;
        }

        Graphics graphics = MyGraphics.GetInstance().GetMainGraphics();
        
        public Font nameFont = new Font("Arial", 18);

        public void Draw(Color color, float penWidth, Point startPoint, Point size, Font argumentFont, string name, string properties, string fields, string methods)
        {
            Pen _pen = new Pen(color, penWidth);

            int _nameHeight = 30 + ((int)graphics.MeasureString(name, nameFont).Width/size.X) *((int)graphics.MeasureString(name, nameFont).Height+3);
            int _propertiesHeight = 30 + ((int)graphics.MeasureString(properties, argumentFont).Width / size.X) * ((int)graphics.MeasureString(properties, argumentFont).Height+3);
            int _methodsHeight = 100 + ((int)graphics.MeasureString(methods, argumentFont).Width / size.X) * ((int)graphics.MeasureString(methods, argumentFont).Height+3);


            Rectangle nameRect = new Rectangle(startPoint.X, startPoint.Y, size.X, _nameHeight);
            Rectangle propertiesRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight, size.X, _propertiesHeight);           
            Rectangle methodRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight + _propertiesHeight, size.X, _methodsHeight);

            MyGraphics.GetInstance().GetMainGraphics();

            Graphics currentTmpGraphics = MyGraphics.GetInstance()._graphics;

            currentTmpGraphics.DrawRectangle(_pen, nameRect);
            currentTmpGraphics.DrawRectangle(_pen, propertiesRect);
            currentTmpGraphics.DrawRectangle(_pen, methodRect);

            TextDrawing.DrawTextName(nameRect, nameFont, color, name);
            TextDrawing.DrawText(propertiesRect, argumentFont, color, properties);
            TextDrawing.DrawText(methodRect, argumentFont, color, methods);
       
        }
    }
}
