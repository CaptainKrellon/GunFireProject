using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunFire.Classes
{
    interface IImage
    {
        // holder for the image itself
        Bitmap Image {get; set;}

        // Holder for image location and dimension
        Rectangle Position {get; set;}
    }
}
