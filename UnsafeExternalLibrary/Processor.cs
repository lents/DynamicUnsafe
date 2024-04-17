using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   
    public static class Processor
    {

        [DllImport("SwapLib.dll")]
        static public unsafe extern void swapCPP(int* a, int* b);
        public static unsafe void MySwap(int* a, int* b) => swapCPP(a, b);
    }
}
