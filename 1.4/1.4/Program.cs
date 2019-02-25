using System;

namespace _1._4
{
    class Program
    {
        static void SpiralWalk(int[,] array)
        {
            int k = 1;
            int x = array.GetLength(0) / 2;
            int y = array.GetLength(1) / 2;
            while (k <= array.GetLength(0) * array.GetLength(1))
            {
                Console.Write($"{array[x, y]} ");
                if (x + 1 <= y && x + y < array.GetLength(0) - 1)
                {
                    ++y;
                }
                else if (x < y && x + y >= array.GetLength(0) - 1)
                {
                    ++x;
                }
                else if (x >= y && x + y > array.GetLength(0) - 1)
                {
                    --y;
                }
                else
                {
                    --x;
                }
                ++k;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter the size of array");
            var n = Int32.Parse(Console.ReadLine());
            if (n <= 0 || n%2 == 0)
            {
                Console.WriteLine("Size of array must be positive odd number");
                return;
            }
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
