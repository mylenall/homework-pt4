using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._3
{
    class Program
    {
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static int Partition(int[] array, int start, int end)
        {
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                if (array[i] <= array[end])
                {
                    Swap(ref array[i], ref array[marker]);
                    marker += 1;
                }
            }
            return marker - 1;
        }

        static void QuickSort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pos = Partition(array, start, end);
            QuickSort(array, start, pos - 1);
            QuickSort(array, pos + 1, end);
        }

        static void Main(string[] args)
        {
            var array = new int[10];
            var rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(10);
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
            QuickSort(array, 0, 9);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
        }
    }
}