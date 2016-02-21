using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunFire.Classes
{
    /// <summary>
    /// Image manager
    /// </summary>
    public class Image : IImage
    {
        private Bitmap _image;
        private Rectangle _position;

        public Image(){}

        public Image(Bitmap image, Rectangle position)
        {
            GfxImage = image;
            Position = position;
        }

        public Bitmap GfxImage 
        { 
            get
            {
                return _image;
            }
            set
            {
                _image = value;
            }
        }
        public Rectangle Position 
        {
            get
            {
                return _position; 
            }
            set 
            {
                _position = value;
            }

        }

        public int X 
        { 
            get 
            { 
                return _position.X; 
            } 
            set
            {
                _position.X = value;
            }
        }
        public int Y 
        {
            get
            {
                return _position.Y;
            }
            set
            {
                _position.Y = value;
            }
        }
        public int Width 
        {
            get
            {
                return _position.Width;
            }
            set
            {
                _position.Width = value;
            }
        }
        public int Height 
        {
            get
            {
                return _position.Height;
            }
            set
            {
                _position.Height = value;
            }
        }
    }
}
