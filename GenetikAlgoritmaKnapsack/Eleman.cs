using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenetikAlgoritmaKnapsack
{
    public class Eleman
    {
        private int agirlik;
        private int deger;
        private int alindiMi;

        public Eleman(int agirlik, int deger, int alindiMi)
        {
            Agirlik = agirlik;
            Deger = deger;
            AlindiMi = alindiMi;
        }

        public int Agirlik { get => agirlik; set => agirlik = value; }
        public int Deger { get => deger; set => deger = value; }
        public int AlindiMi { get => alindiMi; set => alindiMi = value; }
    }
}
