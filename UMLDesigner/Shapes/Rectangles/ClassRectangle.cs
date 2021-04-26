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
    public class ClassRectangle : IRectangle
    {      
        public ClassRectangle()
        {
        }

        public Font nameFont = new Font("Arial", 18);
        Graphics graphics = MyGraphics.GetInstance().GetMainGraphics();

        public void Draw(BaseRectangle rectangle)
        {
            Color color = rectangle.Color;
            float penWidth = rectangle.PenWidth;
            Point startPoint = rectangle.StartPoint;
            Point size = rectangle.EndPoint;
            Font argumentFont = rectangle.ArgumentFont;
            string name = rectangle.Name;
            string properties = rectangle.Properties;
            string fields = rectangle.Fields;
            string methods = rectangle.Methods;

            Pen pen = new Pen(color, penWidth);

            int nameHeight = 30 + ((int)graphics.MeasureString(name, nameFont).Width / size.X) * ((int)graphics.MeasureString(name, nameFont).Height + 3);
            int propertiesHeight = 30 + ((int)graphics.MeasureString(properties, argumentFont).Width / size.X) * ((int)graphics.MeasureString(properties, argumentFont).Height + 3);
            int fieldsHeight = 30 + ((int)graphics.MeasureString(fields, argumentFont).Width / size.X) * ((int)graphics.MeasureString(fields, argumentFont).Height + 3);
            int methodsHeight = 100 + ((int)graphics.MeasureString(methods, argumentFont).Width / size.X) * ((int)graphics.MeasureString(methods, argumentFont).Height + 3);

            Rectangle nameRect = new Rectangle(startPoint.X, startPoint.Y, size.X, nameHeight);
            Rectangle propertiesRect = new Rectangle(startPoint.X, startPoint.Y + nameHeight, size.X, propertiesHeight);
            Rectangle fieldsRect = new Rectangle(startPoint.X, startPoint.Y + nameHeight + propertiesHeight, size.X, fieldsHeight);
            Rectangle methodRect = new Rectangle(startPoint.X, startPoint.Y + nameHeight + propertiesHeight + fieldsHeight, size.X, methodsHeight);

            MyGraphics.GetInstance().GetMainGraphics();
            Graphics currentTmpGraphics = MyGraphics.GetInstance()._graphics;

            currentTmpGraphics.DrawRectangle(pen, nameRect);
            currentTmpGraphics.DrawRectangle(pen, propertiesRect);
            currentTmpGraphics.DrawRectangle(pen, fieldsRect);
            currentTmpGraphics.DrawRectangle(pen, methodRect);

            TextDrawing.DrawTextName(nameRect, nameFont, color, name);
            TextDrawing.DrawText(propertiesRect, argumentFont, color, properties);
            TextDrawing.DrawText(fieldsRect, argumentFont, color, fields);
            TextDrawing.DrawText(methodRect, argumentFont, color, methods);

            int height = nameHeight + propertiesHeight + fieldsHeight + methodsHeight;
            rectangle.EndPoint = new Point(rectangle.EndPoint.X, height);
        }

    }
}
