using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static string LREalgorithm(string text)
        {
            string LREresult = "";
            text = text + " "; //i append the space in the end of text for reading the last char...
            char prev = text[0];
            int count = 0;
            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] == prev)
                {
                    count++;
                }
                else
                {
                    LREresult = LREresult+count+prev;
                    prev = text[i];
                    count = 0;
                }
            }

            return LREresult;
        }
        static void Main(string[] args)
        {
            string key = "AAAAAAABBBBBCCCCCDDDDDDDDD";
            Console.WriteLine(LREalgorithm(key));
            Console.ReadKey();
        }
    }
}
