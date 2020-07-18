using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenetikAlgoritmaKnapsack
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 10;
            double Pc = 0.75, Pm = 0.1;

           

            VeriOkuma veri = new VeriOkuma();
            int elemanlarcount = veri.elemanlarListesi().Count;
            RastgeleSayi sayi = new RastgeleSayi();
            Knapsack knapsack = new Knapsack(N);
            int rastgele;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < elemanlarcount; j++)
                {
                    int agirlik = knapsack.CantaAgirligi(knapsack.Cantalar[i]);
                    if (agirlik <= veri.Kapasite)
                    {
                        rastgele = sayi.BetweenInteger(0, elemanlarcount - 1);

                        int esyaIndisi = knapsack.RastgeleSecim(knapsack.Cantalar[i]);
                        knapsack.CantayaElemanEkle(knapsack.Cantalar[i], veri.elemanlarListesi()[esyaIndisi]);
                    }
                    else break;
                }

            }
            RuletiCevir(N, veri.Kapasite, FitnesslariHesapla(N, elemanlarcount, knapsack.Cantalar, veri.Kapasite), Pc, Pm, knapsack.Cantalar);
            
            Console.ReadKey();
        }

        public static List<int> FitnesslariHesapla(int N, int elemanlarCount, List<List<Eleman>> knapsack, int kapasite)
        {
            List<int> Fitnes = new List<int>();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < knapsack[i].Count; j++)
                {
                    Fitnes.Add(knapsack[i][j].Agirlik);
                }
            }

            return Fitnes;
        }

        public static List<double> RuletiCevir(int N, int kapasite, List<int> fitnessListesi, double Pc, double Pm, List<List<Eleman>> knapsack)
        {
            double toplam = 0;
            double hesap = 0;
            RastgeleSayi olasilik = new RastgeleSayi();
            List<double> ruletOlasiliklari = new List<double>();

            for (int i = 0; i < N; i++)
            {
                toplam += fitnessListesi[i];
            }
            toplam -= N * kapasite;
            for (int i = 0; i < fitnessListesi.Count; i++)
            {
                hesap = (1 - (fitnessListesi[i] / toplam)) / (fitnessListesi.Count - 1);
                ruletOlasiliklari.Add(hesap);
            }
            List<double> pastaOranlari = new List<double>(PastaOlasiliklariniHesapla(ruletOlasiliklari));

            for (int i = 0; i < fitnessListesi.Count; i++)
            {
                double rastgele = olasilik.BetweenDouble(0, 1);
                if (Pc < rastgele)
                {
                    rastgele = olasilik.BetweenDouble(0, 1);
                    if (rastgele < pastaOranlari[i + 1] && rastgele > pastaOranlari[i - 1])
                        Caprazlama(knapsack, i, AraligiBul(pastaOranlari, rastgele));
                }
                rastgele = olasilik.BetweenDouble(0, 1);
                if (Pm > rastgele)
                {
                    Mutasyon(knapsack[i]);
                }

            }
            return ruletOlasiliklari;


        }
        public static void Mutasyon(List<Eleman> canta)
        {
            RastgeleSayi sayi = new RastgeleSayi();
            int indis = sayi.BetweenInteger(0, canta.Count - 1);

            canta[indis].AlindiMi = 1 - canta[indis].AlindiMi;
        }

        public static void Caprazlama(List<List<Eleman>> cantalar, int canta1, int canta2)
        {
            RastgeleSayi rastgele = new RastgeleSayi();
            List<Eleman> canta = new List<Eleman>();
            int rastgeleSayi = rastgele.BetweenInteger(0, cantalar[0].Count - 1);

            for (int i = 0; i < rastgeleSayi; i++)
            {
                canta.Add(cantalar[canta1][i]);
            }

            for (int i = rastgeleSayi; i < cantalar[i].Count; i++)
            {
                canta.Add(cantalar[canta2][i]);
            }

            cantalar[canta1] = canta;
        }

        public static int AraligiBul(List<double> pastaOranlari, double sayi)
        {
            int indis = 0;
            for (int i = 0; i < pastaOranlari.Count - 1; i++)
            {
                if (sayi > pastaOranlari[i] && sayi < pastaOranlari[i + 1])
                {
                    indis = i;
                }
                else
                {
                    if (sayi < pastaOranlari[0])
                    {
                        indis = 0;
                    }
                }
            }
            return indis;
        }

        public static List<double> PastaOlasiliklariniHesapla(List<double> oranlar)
        {
            List<double> oran = new List<double>();
            double sum = 0;
            for (int i = 0; i < oranlar.Count; i++)
            {
                for (int j = i; j <= i; j++)
                {
                    sum += oranlar[j];
                }
                oran.Add(sum);
            }

            foreach (var i in oran)
                Console.WriteLine(i);


            return oran;

        }
    }
}
