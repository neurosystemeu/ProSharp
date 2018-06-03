using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSharp.TestApp.Test
{
    public class Pracownik
    {
        public string Nazwisko { get; set; }
        public string Imie { get; set; }
        public int RokUrodzenia { get; set; }
        public int RozmiarButa { get; set; }

        public string GenerujRaport()
        {
            var ret = Imie + " " + Nazwisko + " : ";
            int i = 1;
            i = i + RozmiarButa + RokUrodzenia;

            var d = 1.4 * RozmiarButa + i;

            for (int j=0; j < RozmiarButa; j++)
            {
                ret += j;
            }

            return ret;
        }
    }
}
