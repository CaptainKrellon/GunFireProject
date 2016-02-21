using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunFire.Classes
{
    public class Ship
    {
        private Image _spaceShip;
        private List<Image> _laserBolts = new List<Image>();
        
        /// <summary>
        /// Ships construector. Always need an image and location
        /// </summary>
        /// <param name="shipImage"></param>
        /// <param name="shipPosition"></param>
        public Ship(Bitmap shipImage, Rectangle shipPosition) 
        {
            _spaceShip = new Image(shipImage, shipPosition);
        }

        /// <summary>
        /// Add laser bolts. Might be more than one gun so make a list
        /// </summary>
        /// <param name="laserbBoltImage"></param>
        /// <param name="laserBoltPosition"></param>
        public void AddLaserBolt(Bitmap laserbBoltImage, Rectangle laserBoltPosition)
        {
            _laserBolts.Add(new Image(laserbBoltImage, laserBoltPosition));
        }

        /// <summary>
        /// Ship X axis property
        /// </summary>
        public int ShipXAxis 
        {
            set
            { 
                _spaceShip.X = value;
            }

            get
            { 
                return _spaceShip.X;              
            }
        }

        /// <summary>
        /// Ship y axis property
        /// </summary>
        public int ShipYAxis
        {
            set
            {
                _spaceShip.Y = value;
            }

            get
            {
                return _spaceShip.Y;
            }
        }

        /// <summary>
        /// Updates the ship and associated graphics postions
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public void UpdateShipPosition(int X, int Y)
        {
            // Need to update ship and laser bolts
            _spaceShip.X = X;
            _spaceShip.X = Y;

            foreach (var _laserBolt in _laserBolts)
            {
                _laserBolt.X = X;
                _laserBolt.Y = Y;
            }
        }

        /// <summary>
        /// Draw the ship to a graphics object
        /// </summary>
        /// <param name="graphicsSurface"></param>
        public void DrawShip(Graphics graphicsSurface)
        {
            graphicsSurface.DrawImage(_spaceShip.GfxImage, _spaceShip.Position);

            foreach (var _laserBolt in _laserBolts)
            {
                graphicsSurface.DrawImage(_laserBolt.GfxImage, _laserBolt.Position);
            }
        }
    }
}
