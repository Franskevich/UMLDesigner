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

namespace UMLDesigner
{
    public class MyGraphics
    {
        public  List<IShape> Shapes { get; set;}
        public PictureBox pictureBox { get; set;}

        private static MyGraphics _instance;
        public Graphics _graphics;
        public Bitmap _mainBitmap;
        public Bitmap _tmpBitmap;


        public static MyGraphics GetInstance()
        {
            if(_instance is null)
            {
                _instance = new MyGraphics();
            }
            return _instance;
        }

        private MyGraphics()
        {
            _mainBitmap = new Bitmap(1920, 1080);
            _graphics = Graphics.FromImage(_mainBitmap);
        }

        public void SetPB(PictureBox pb)
        {
            pictureBox = pb;
        }

        public Graphics GetTmpGraphics()
        {
            _tmpBitmap = (Bitmap)_mainBitmap.Clone();
            _graphics = Graphics.FromImage(_tmpBitmap);
            return _graphics;
        }      
        
        public void SetImageToTmpBitmap()
        {
            pictureBox.Image = _tmpBitmap;
            GC.Collect();
        }
        
        public void SetImageToMainBitmap()
        {
            pictureBox.Image = _mainBitmap;
            GC.Collect();
        }
        
       public Graphics GetMainGraphics()
       { 
           _graphics = Graphics.FromImage(_mainBitmap);
           return _graphics;
       }

        public void SetTmpBitmapAsMain()
        {
            _mainBitmap = _tmpBitmap;
        }

        public  Graphics GetGraphics()
        {
            if (_graphics is null)
            {
                _mainBitmap = new Bitmap(1000, 1000);
                _graphics = Graphics.FromImage(_mainBitmap);
            }
            return _graphics;
        }

        public  Bitmap GetBitmap()
        {
            return _mainBitmap;
        }

        public void Clear()
        {
            _graphics.Clear(Color.White);
        }
    }
}
