using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._5
{
    class Program
    {
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void MoveColumns(int[,] array, int column1, int column2)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Swap(ref array[i, column1], ref array[i, column2]);
            }
        }

        static void PrintArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write("{0} ", array[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void SortArray(int[,] array)
        {            
            for (int i = 0; i < array.GetLength(1) - 1; i++)
            {
                for (int j = i + 1; j < array.GetLength(1); j++)
                {
                    if (array[0, i] > array[0, j])
                    {
                        MoveColumns(array, i, j);
                    }
                }
            }            
        }

        static void Main(string[] args)
        {
            var n = Int32.Parse(Console.ReadLine());
            var m = Int32.Parse(Console.ReadLine());
            var array = new int[n, m];
            var rnd = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rnd.Next(10);
                }
            }
            PrintArray(array);    
            SortArray(array);
            PrintArray(array);
        }
    }
}
