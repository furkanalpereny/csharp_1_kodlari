using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[2, 2];

            for (int i = 0; i < 2; ++i)
            {
                for (int j = 0; j < 2; ++j)
                {
                    arr[i, j] = 17 * i + 17 * i;
                    Console.Write(arr[i,j]+" ");
                }
            }
            Console.ReadLine();
        }
    }
}
