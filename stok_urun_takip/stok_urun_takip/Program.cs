using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stok_urun_takip
{
    class Urun
    {
        private string UrunAdi { get; set; }
        private string ID { get; set; }
        private decimal adet { get; set; }

        public Urun(string UrunAdi, string ID, decimal adet)
        {
            this.UrunAdi = UrunAdi;
            this.ID = ID;
            this.adet = adet;
        }

        public override string ToString()
        {
            return ID + " : " + UrunAdi;
        }

        public static Urun operator + (Urun urun, decimal artiStokKodu)
        {
            decimal yeniID = Convert.ToDecimal(urun.ID) + artiStokKodu;
            return new Urun(urun.UrunAdi, yeniID.ToString() , urun.adet);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
