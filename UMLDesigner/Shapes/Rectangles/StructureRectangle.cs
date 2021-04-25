using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLDesigner.Interfaces;

namespace UMLDesigner.Shapes.Rectangles
{
    public class StructureRectangle : IRectangle
    {
        private int _nameHeight;
        private int _propertiesHeight;
        private int _fieldsHeight;
        private int _methodsHeight;
        private int _deltaX = 0;


        AbstractRectangle _absR;
        public Font nameFont = new Font("Arial", 18);
        Graphics graphics = MyGraphics.GetInstance().GetMainGraphics();

        public StructureRectangle()
        {
        }

        public void Draw(Color color, float penWidth, Point startPoint, Point size, Font argumentFont, string name, string properties, string fields, string methods)
        {
            Pen pen = new Pen(color, penWidth);

            _nameHeight = 30 + ((int)graphics.MeasureString(name, nameFont).Width / size.X) * ((int)graphics.MeasureString(name, nameFont).Height + 3);
            _propertiesHeight = 30 + ((int)graphics.MeasureString(properties, argumentFont).Width / size.X) * ((int)graphics.MeasureString(properties, argumentFont).Height + 3);
            _fieldsHeight = 30 + ((int)graphics.MeasureString(fields, argumentFont).Width / size.X) * ((int)graphics.MeasureString(fields, argumentFont).Height + 3);
            _methodsHeight = 90 + ((int)graphics.MeasureString(methods, argumentFont).Width / (size.X)) * ((int)graphics.MeasureString(methods, argumentFont).Height + 3);

            //int count = 0;
            //for(int i = 0; properties.Length > 0; i++)
            //{
            //    if(properties[i] == "\n") ;
            //    {
            //        count++;
            //    }

            //}

            string subString = "\n";
            if (!(properties is null))
            {
                ////int indexOfSubstring = properties.IndexOf(subString);
                //for (int i = 0; i < properties.Length; i++)
                //{
                //    properties[i] = subString;
                //}

                int iii = (int)graphics.MeasureString(properties, argumentFont).Width;
                if (iii > size.X)
                {
                    size.X = size.X + (int)(iii / 2);
                }
            }
            if (!(fields is null))
            {
                int iii = (int)graphics.MeasureString(fields, argumentFont).Width;
                if (iii > size.X)
                {
                    size.X = size.X + (int)(iii / 2);
                }
            }
            if (!(methods is null))
            {
                int iii = (int)graphics.MeasureString(methods, argumentFont).Width;
                if (iii > size.X)
                {
                    size.X = size.X + (int)(iii / 2);
                }
            }


            int propWidth = size.X;
            int fieldstWidth = size.X;
            int methodsWidth = size.X;


            //int propWidth = size.X + ((int)graphics.MeasureString(properties, argumentFont).Width / size.X) * ((int)graphics.MeasureString(properties, argumentFont).Height + 3);
            //int fieldstWidth = size.X + ((int)graphics.MeasureString(properties, argumentFont).Width / size.X) * ((int)graphics.MeasureString(properties, argumentFont).Height + 3);
            //int methodsWidth = size.X + ((int)graphics.MeasureString(properties, argumentFont).Width / size.X) * ((int)graphics.MeasureString(properties, argumentFont).Height + 3);

            Rectangle _nameRect = new Rectangle(startPoint.X, startPoint.Y, size.X, _nameHeight);
            //Rectangle _propertiesRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight, propWidth, _propertiesHeight);
            //Rectangle _fieldsRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight + _propertiesHeight, size.X, _fieldsHeight);
            //Rectangle _methodRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight + _propertiesHeight + _fieldsHeight, size.X, _methodsHeight);


            Rectangle _propertiesRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight, propWidth, _propertiesHeight);

            Rectangle _fieldsRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight + _propertiesHeight, fieldstWidth, _fieldsHeight);
            Rectangle _methodRect = new Rectangle(startPoint.X, startPoint.Y + _nameHeight + _propertiesHeight + _fieldsHeight, methodsWidth, _methodsHeight);

            MyGraphics.GetInstance().GetMainGraphics();
            var currentTmpGraphics = MyGraphics.GetInstance()._graphics;

            currentTmpGraphics.DrawRectangle(pen, _nameRect);
            currentTmpGraphics.DrawRectangle(pen, _propertiesRect);
            currentTmpGraphics.DrawRectangle(pen, _fieldsRect);
            currentTmpGraphics.DrawRectangle(pen, _methodRect);

            TextDrawing.DrawTextName(_nameRect, nameFont, color, name);
            TextDrawing.DrawText(_propertiesRect, argumentFont, color, properties);
            TextDrawing.DrawText(_fieldsRect, argumentFont, color, fields);
            TextDrawing.DrawText(_methodRect, argumentFont, color, methods);

        }

        //public Point GetNewsizeRectangle()
        //{

        //}
    }
}
