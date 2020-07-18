using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenetikAlgoritmaKnapsack
{
    public class Knapsack
    {
        List<List<Eleman>> cantalar = new List<List<Eleman>>();
        RastgeleSayi rastgele = new RastgeleSayi();
        public List<List<Eleman>> Cantalar { get => cantalar; set => cantalar = value; }
        public RastgeleSayi Rastgele { get => rastgele; set => rastgele = value; }

        public Knapsack(int cantaSayisi)
        {
            for (int i = 0; i < cantaSayisi; i++)
                Cantalar.Add(new List<Eleman>());
        }

        public List<Eleman> SecilmemislerElemanlar(List<Eleman> canta)
        {
            List<Eleman> secilmemisler = new List<Eleman>();

            for (int i = 0; i < canta.Count; i++)
                if (canta[i].AlindiMi == 0)
                    secilmemisler.Add(canta[i]);

            return secilmemisler;
        }

        public int RastgeleSecim(List<Eleman> elemanlar)
        {
            return Rastgele.BetweenInteger(0, elemanlar.Count);
        }

        public int CantaAgirligi(List<Eleman> canta)
        {
            int toplam = 0;
            for (int i = 0; i < canta.Count; i++)
            {
                if (canta[i].AlindiMi == 1)
                    toplam += canta[i].Agirlik;
            }
            return toplam;
        }

        public void CantayaElemanEkle(List<Eleman> canta, Eleman eleman)
        {
            canta.Add(eleman);
            canta[canta.IndexOf(eleman)].AlindiMi = 1;
        }
    }
}
