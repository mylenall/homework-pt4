using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4
{
    class Program
    {
        static void SpiralWalk(int[,] array)
        {
            int k = 1;
            int x = array.GetLength(0) / 2;
            int y = array.GetLength(0) / 2;
            while (k <= array.GetLength(0) * array.GetLength(0))
            {
                Console.Write($"{array[x, y]} ");
                if (x + 1 <= y && x + y < array.GetLength(0) - 1)
                    ++y;
                else if (x < y && x + y >= array.GetLength(0) - 1)
                    ++x;
                else if (x >= y && x + y > array.GetLength(0) - 1)
                    --y;
                else
                    --x;
                ++k;
            }
        }

        static void Main(string[] args)
        {
            var n = Int32.Parse(Console.ReadLine());
            var array = new int[n, n];
            var rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = rnd.Next(10);
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
            SpiralWalk(array);
        }
    }
}
