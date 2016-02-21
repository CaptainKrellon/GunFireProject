using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GunFire
{
    public partial class GunFire : Form
    {
        // This example assumes the existence of a form called Form1.
        BufferedGraphicsContext currentContext;
        BufferedGraphics myBuffer;
        private byte count;

        Classes.Ship _ship;

        const int horizontalShipSpeed = 4;
        const int verticalShipSpeed = 4;

        // API to poll keyboard
        [DllImport("User32.dll")] 
        public static extern short GetAsyncKeyState(int vKey);

        /// <summary>
        /// Main constructor
        /// </summary>
        public GunFire()
        {
            InitializeComponent();

            // Create the Ship n Lasers
            _ship = new Classes.Ship(Properties.Resources.SpaceShipSm, new Rectangle(100, 100, 104, 80));
            _ship.AddLaserBolt(Properties.Resources.LaserboltSm , new Rectangle(200, 132, 25, 15));
            
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

                myBuffer.Graphics.FillRectangle(Brushes.Black, 0, 0, this.Width, this.Height);

                // Draw the ship
                _ship.DrawShip(graphicsSurface);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GetAsyncKeyState((int)System.Windows.Forms.Keys.Right) != 0) _ship.ShipXAxis += horizontalShipSpeed;
            if (GetAsyncKeyState((int)System.Windows.Forms.Keys.Left) != 0) _ship.ShipXAxis -= horizontalShipSpeed;
            if (GetAsyncKeyState((int)System.Windows.Forms.Keys.Up) != 0) _ship.ShipYAxis -= verticalShipSpeed;
            if (GetAsyncKeyState((int)System.Windows.Forms.Keys.Down) != 0) _ship.ShipYAxis += verticalShipSpeed;
            
            DrawToBuffer(myBuffer.Graphics);

            myBuffer.Render(Graphics.FromHwnd(this.Handle)); 
            //this.Refresh();
        }

    }
}
