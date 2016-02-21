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

        Classes.BaseImage _spaceShip;
        Classes.BaseImage _laserBolt;
        Classes.Ship _ship;

        const int horizontalShipSpeed = 4;
        const int verticalShipSpeed = 4;

        // API to poll keyboard
        [DllImport("User32.dll")] 
        public static extern short GetAsyncKeyState(int vKey);

        public GunFire()
        {
            InitializeComponent();

            _ship = new Classes.Ship();

            _spaceShip = new Classes.BaseImage(Properties.Resources.SpaceShipSm, new Rectangle(100, 100, 104, 80)); // X, Y, Width, Height
            _laserBolt = new Classes.BaseImage(Properties.Resources.LaserboltSm , new Rectangle(200, 132, 25, 15));
            
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // Gets a reference to the current BufferedGraphicsContext
            currentContext = BufferedGraphicsManager.Current;

            // Creates a BufferedGraphics instance associated with Form1, and with 
            // dimensions the same size as the drawing surface of Form1.
            myBuffer = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);

            DrawToBuffer(myBuffer.Graphics);            
            timer1.Start();
            currentContext.Dispose();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            myBuffer.Render(e.Graphics);
        }

        private void DrawToBuffer(Graphics g)
        {
            // Clear the graphics buffer every five updates.
            if (++count > 1)
            {
                count = 0;
                myBuffer.Graphics.FillRectangle(Brushes.Black, 0, 0, this.Width, this.Height);

                g.DrawImage(_spaceShip.Image, _spaceShip.Position);
                g.DrawImage(_laserBolt.Image, _laserBolt.Position);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GetAsyncKeyState((int)System.Windows.Forms.Keys.Right) != 0) _spaceShip.X += horizontalShipSpeed;
            if (GetAsyncKeyState((int)System.Windows.Forms.Keys.Left) != 0) _spaceShip.X -= horizontalShipSpeed;
            if (GetAsyncKeyState((int)System.Windows.Forms.Keys.Up) != 0) _spaceShip.Y -= verticalShipSpeed;
            if (GetAsyncKeyState((int)System.Windows.Forms.Keys.Down) != 0) _spaceShip.Y += verticalShipSpeed;
            
            DrawToBuffer(myBuffer.Graphics);

            myBuffer.Render(Graphics.FromHwnd(this.Handle)); 
            //this.Refresh();
        }

    }
}
