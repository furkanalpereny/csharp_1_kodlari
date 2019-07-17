using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ogrenci_dosyaIslemleri
{
    class Ogrenci
    {
        public string adi { get; set; }
        public string soyadi { get; set; }
        private int yas { get; set; }
        private DateTime dogumTarihi;
        public DateTime _dogumTarihi
        {
            get
            {
                return dogumTarihi;
            }
            set
            {
                this.dogumTarihi = _dogumTarihi;
                TimeSpan fark = DateTime.Today - dogumTarihi;
                this.yas = ( DateTime.Today - dogumTarihi ).Days / 365;
            }
        }
        public string numarasi { get; set; }
        public int vize { get; set; }
        public int final { get; set; }
        public int butunleme { get; set; }
        public Ogrenci(Ogrenci ogrenci)
        {
            this.adi = ogrenci.adi;
            this.soyadi = ogrenci.soyadi;
            this.yas = ogrenci.yas;
            this.dogumTarihi = ogrenci.dogumTarihi;
            this.numarasi = ogrenci.numarasi;
            this.vize = ogrenci.vize;
            this.final = ogrenci.final;
            this.butunleme = ogrenci.butunleme;
        }
        public Ogrenci() { }
    }
    class Program
    {
        public static List<Ogrenci> Birlestir()
        {
            List<string> d1 = new List<string>();
            d1 = readTxt("d1.txt", d1);
            List<string> d2 = new List<string>();
            d2 = readTxt("d2.txt", d2);
            List<string> d3 = new List<string>();
            d3 = readTxt("d3.txt", d3);
            List<Ogrenci> ogrenciler = new List<Ogrenci>();
            foreach (var d1_rows in d1)
            {
                if (d1_rows!=null)
                {
                    string[] splits = d1_rows.Split('|');
                    Ogrenci ogrenci = new Ogrenci();
                    ogrenci.numarasi = splits[0];
                    ogrenci.adi = splits[1];
                    ogrenci.soyadi = splits[2];
                    ogrenciler.Add(ogrenci);
                } 
            }

            foreach (var d2_rows in d2)
            {
                if (d2_rows != null)
                {
                    string[] splits = d2_rows.Split('|');
                    foreach (var ogrenci in ogrenciler)
                    {
                        if (splits[0] == ogrenci.numarasi)
                        {
                            if (splits[1] != "")
                            {
                                ogrenci.vize = Convert.ToInt32(splits[1]);
                                break;
                            }
                        }
                    }
                }
            }

            foreach (var d3_rows in d3)
            {
                if (d3_rows != null)
                {
                    string[] splits = d3_rows.Split('|');
                    foreach (var ogrenci in ogrenciler)
                    {
                        if (splits[0] == ogrenci.numarasi)
                        {
                            if (splits[1] != "")
                            {
                                ogrenci.final = Convert.ToInt32(splits[1]);
                                break;
                            }
                        }
                    }
                }
            }

            foreach (var ogrenci in ogrenciler)
            {
                Console.WriteLine(ogrenci.numarasi + ", " + 
                    ogrenci.adi + " " + 
                    ogrenci.soyadi + 
                    " Vize: " + ogrenci.vize + 
                    " Final: " + ogrenci.final);
            }

            return ogrenciler;
        }

        public static List<Ogrenci> SiraliButListe (List<Ogrenci> ogrenciler)
        {
            List<Ogrenci> butunlemeOgrencileri = new List<Ogrenci>();
            foreach (var ogrenci in ogrenciler)
            {
                if ((ogrenci.vize*0.4)+(ogrenci.final*0.6) < 60)
                {
                    butunlemeOgrencileri.Add(ogrenci);
                    Console.WriteLine(ogrenci.adi+", "+ ((ogrenci.vize * 0.4) + (ogrenci.final * 0.6)));
                }
            }
            return butunlemeOgrencileri;
        }

        public static List<string> readTxt(string path, List<string> rows)
        {
            string file_path = path;
            FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
            string row = "";
            while (row != null)
            {
                row = sw.ReadLine();
                rows.Add(row);
            }
            sw.Close();
            fs.Close();
            return rows;
        }

        static void Main(string[] args)
        {
            List<Ogrenci> ogrenciler = new List<Ogrenci>();
            ogrenciler = Birlestir();
            SiraliButListe(ogrenciler);
            Console.ReadLine();
        }
    }
}
