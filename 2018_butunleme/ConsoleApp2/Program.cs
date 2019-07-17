using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 2018 bütünleme sınavı cevapları
namespace ConsoleApp2
{
    // 2018 bütünleme sınavı cevapları
    sealed class Personel
    {
        private string adi { get; set; }
        private string soyadi { get; set; }
        private decimal maas { get; set; }

        public Personel(string adi, string soyadi, decimal maas)
        {
            this.adi = adi;
            this.soyadi = soyadi;
            this.maas = maas;
        }
        public Personel(string adi, string soyadi): this(adi, soyadi,3000)
        {
        }
        public Personel(Personel personel)
        {
            this.adi = personel.adi;
            this.soyadi = personel.soyadi;
            this.maas = personel.maas;
        }
        public static Personel operator + (Personel personel, decimal eklenecekMaas)
        {
            decimal yeniMaas = personel.maas + eklenecekMaas;
            return new Personel(personel.adi, personel.soyadi, yeniMaas);
        }
        public override string ToString()
        {
            return adi+" "+soyadi+" - Maaş : "+maas;
        }

        static Personel[] array = new Personel[10];
        public static void Add(Personel personel)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                {
                    array[i] = personel;
                    break;
                }
            }
        }

        public static Personel Get(int index)
        {
            Personel personel = array[index];
            return personel;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Personel p1 = new Personel("Tahir", "Sağ");
            Console.WriteLine(p1.ToString());

            Personel p2 = new Personel("Nevzat", "Örnek", 15000);
            Console.WriteLine(p2.ToString());

            Personel p3 = p2 + 3000;
            Console.WriteLine(p3.ToString());

            Personel p4 = new Personel(p3 + 1000);
            Console.WriteLine(p4.ToString());
            
            Personel.Add(p1);
            Personel.Add(p2);
            Personel.Add(p3);
            Personel.Add(p4);
            Console.WriteLine(Personel.Get(2).ToString());
            Console.ReadLine();

            
        }
    }
}
