using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Sediste
    {
        public int Broj { get; set; }
        public string Status { get; set; } = "Slobodno";
        public string Tip { get; set; } = "Standard";
        public double Cena => Tip == "VIP" ? 1000 : (Tip == "Love" ? 800 : 500);
    }
}
