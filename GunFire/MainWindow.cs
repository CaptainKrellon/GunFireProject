using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GunFire.Classes;

namespace GunFire
{
    public partial class GunFire : Form
    {
        // This example assumes the existence of a form called Form1.
        BufferedGraphicsContext currentContext;
        BufferedGraphics myBuffer;
        private byte count;

        // Create a ship
        Ship _ship;

        const int horizontalShipSpeed = 3;
        const int verticalShipSpeed = 3;

        /// <summary>
        /// Main constructor
        /// </summary>
        public GunFire()
        {
            InitializeComponent();

            // Create a ship
            _ship = new Classes.Ship(100, 100);

            // Setup screen drawing styles
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // Gets reference to current BufferedGraphicsContext
            currentContext = BufferedGraphicsManager.Current;

            // Create BufferedGraphics instance associated with Form1. 
            // Set dimensions same as drawing surface of Form1.
            myBuffer = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);

            // Do first draw
            DrawToBuffer(myBuffer.Graphics);            
            
            // Kick off the timer
            timer1.Start();

            // Context no longer needed so dispose 
            currentContext.Dispose();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            myBuffer.Render(e.Graphics);
        }

        private void DrawToBuffer(Graphics graphicsSurface)
        {
            // Clear the graphics buffer every update.
            if (++count > 1)
            {
                count = 0; // Reset update counter
                myBuffer.Graphics.DrawImage(Properties.Resources.SpaceBackground, 0, 0, 1024, 768);

                //myBuffer.Graphics.FillRectangle(Brushes.Black, 0, 0, this.Width, this.Height);

                // Draw the ship
                _ship.DrawShip(graphicsSurface);

                if (_ship._firing)
                    _ship.DrawLaserBolt(graphicsSurface);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (API.GetAsyncKeyState((int)System.Windows.Forms.Keys.Right) != 0) _ship.ShipXAxis += horizontalShipSpeed;
            if (API.GetAsyncKeyState((int)System.Windows.Forms.Keys.Left) != 0) _ship.ShipXAxis -= horizontalShipSpeed;
            if (API.GetAsyncKeyState((int)System.Windows.Forms.Keys.Up) != 0) _ship.ShipYAxis -= verticalShipSpeed;
            if (API.GetAsyncKeyState((int)System.Windows.Forms.Keys.Down) != 0) _ship.ShipYAxis += verticalShipSpeed;

            // Shoot
            if (API.GetAsyncKeyState((int)System.Windows.Forms.Keys.Space) != 0)
                _ship._firing = true;
            else
                _ship._firing = false;

            DrawToBuffer(myBuffer.Graphics);
            myBuffer.Render(Graphics.FromHwnd(this.Handle)); 
        }


    }
}
