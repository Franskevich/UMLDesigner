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
        public InterfaceRectangle()
        {
        }

        Graphics graphics = MyGraphics.GetInstance().GetMainGraphics();
        
        public Font nameFont = new Font("Arial", 18);

        public void Draw(AbstractRectangle rectangle)
        {

            Color color = rectangle.Color;
            float penWidth = rectangle.PenWidth;
            Point startPoint = rectangle.StartPoint;
            Font argumentFont = rectangle.ArgumentFont;
            string name = rectangle.Name;
            string properties = rectangle.Properties;
            string methods = rectangle.Methods;
            Point size = rectangle.EndPoint;



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

            int height = _nameHeight + _propertiesHeight + _methodsHeight;
            rectangle.EndPoint = new Point(rectangle.EndPoint.X, height);


        }
    }
}
