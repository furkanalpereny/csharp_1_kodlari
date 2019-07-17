using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        public static List<int> mixList(List<int> list)
        {
            List<int> final = new List<int>();
            Random rand = new Random();
            int index = 0;
            int count = list.Count;

            for (int i = 0; i < count; i++)
            {
                index = rand.Next(0, list.Count);
                final.Add(list[index]);
                list.RemoveAt(index);
            }
            return final;
        }
        static void Main(string[] args)
        {
            int normalOgretim = 163301000;
            int ikinciOgretim = 163311000;
            List<int> normalOgretimList = new List<int>();
            List<int> ikinciOgretimList = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                normalOgretim += 1;
                normalOgretimList.Add(normalOgretim);
            }
            for (int i = 0; i < 12; i++)
            {
                ikinciOgretim += 1;
                ikinciOgretimList.Add(ikinciOgretim);
            }

            normalOgretimList = mixList(normalOgretimList);
            ikinciOgretimList = mixList(ikinciOgretimList);
            List<int> karistirilmisListe = new List<int>();
            int minCount = Math.Min(normalOgretimList.Count, ikinciOgretimList.Count);
            for (int i = 0; i < minCount; i++)
            {
                karistirilmisListe.Add(normalOgretimList[i]);
                karistirilmisListe.Add(ikinciOgretimList[i]);
            }
            
            Random rand = new Random();
            int max = Math.Max(ikinciOgretimList.Count, normalOgretimList.Count);
            int min = Math.Min(ikinciOgretimList.Count, normalOgretimList.Count);
            int random = rand.Next(karistirilmisListe.Count);
            for (int i = 0; i < max - min; i++)
            {
                if(max == ikinciOgretimList.Count)
                {
                    karistirilmisListe.Insert(random, ikinciOgretimList[i + min]);
                }
                else
                {
                    karistirilmisListe.Insert(random, normalOgretimList[i + min]);
                }
            }
            foreach (var item in karistirilmisListe)
            {
                Console.WriteLine((karistirilmisListe.IndexOf(item)+1)+". " + item);
            }

            Console.ReadLine();
        }
    }
}
