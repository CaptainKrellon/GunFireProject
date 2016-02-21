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
        private Image _laser;
        public  bool _firing { get; set; }

        /// <summary>
        /// Ships construector. Always need an image and location
        /// </summary>
        /// <param name="shipImage"></param>
        /// <param name="shipPosition"></param>
        public Ship(int X, int Y) 
        {
            // Create the Ship n Lasers
            _spaceShip = new Image(Properties.Resources.SpaceShipSm, new Rectangle(X, Y, Properties.Resources.SpaceShipSm.Width, Properties.Resources.SpaceShipSm.Height));
            _laser = new Image(Properties.Resources.LaserboltSm, new Rectangle(X+99, Y+44, Properties.Resources.LaserboltSm.Width, Properties.Resources.LaserboltSm.Height));
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

        public Rectangle ShipPosition 
        { 
            get 
            { 
                return new Rectangle(_spaceShip.X, _spaceShip.Y, _spaceShip.Width, _spaceShip.Height); 
            } 
        } 

        /// <summary>
        /// Draw the ship to a graphics object
        /// </summary>
        /// <param name="graphicsSurface"></param>
        public void DrawShip(Graphics graphicsSurface)
        {
            graphicsSurface.DrawImage(_spaceShip.GfxImage, _spaceShip.Position);
        }

        /// <summary>
        /// Draw the laser bolt to a graphics object
        /// </summary>
        /// <param name="graphicsSurface"></param>
        public void DrawLaserBolt(Graphics graphicsSurface)
        {

            _laser.X = _spaceShip.X + 99;
            _laser.Y = _spaceShip.Y + 44;

            graphicsSurface.DrawImage(_laser.GfxImage, _laser.Position);
        }

        //internal void Fire(Graphics graphicsSurface)
        //{

        //}
    }
}
