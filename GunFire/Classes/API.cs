using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GunFire.Classes
{
    public static class API
    {
        // API to poll keyboard
        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(int vKey);
    }
}
