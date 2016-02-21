using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunFire.Classes
{
    public class Ship : BaseImage
    {
        private BaseImage _spaceShip = new BaseImage();
        private List<BaseImage> _laserBolt;

        /// <summary>
        /// Ships construector. Always need an image and location
        /// </summary>
        /// <param name="shipImage"></param>
        /// <param name="shipPosition"></param>
        public Ship(Bitmap shipImage, Rectangle shipPosition) : base(shipImage, shipPosition) { }

        /// <summary>
        /// Add laser bolts. Might be more than one gun so make a list
        /// </summary>
        /// <param name="laserbBoltImage"></param>
        /// <param name="laserBoltPosition"></param>
        public void AddLaserBolt(Bitmap laserbBoltImage, Rectangle laserBoltPosition)
        {
            _laserBolt.Add(new BaseImage(laserbBoltImage, laserBoltPosition));
        }

        public void UpdateShipPosition(int X, int Y)
        {
            // Need to update ship and laser bolts
        }
    }
}
