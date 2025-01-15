using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    internal class Statek
    {
        public int PozycjaX {  get; set; }
        public int PozycjaY { get; set; }
        public Statek (int x, int y)
        {
            PozycjaX = x;
            PozycjaY = y;
        }
    }
}
