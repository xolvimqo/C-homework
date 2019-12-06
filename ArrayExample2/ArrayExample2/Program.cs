using System;

namespace ArrayExample2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array1 = new int[10, 10];
            int[,] array2 = new int[10, 10];
            int[,] array3 = new int[10, 10];
            int[,,] matrix = new int[10, 10, 10];

            Console.Write("Enter no of row = ");
            int row = int.Parse(Console.ReadLine());
            Console.Write("Enter no of column = ");
            int column = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter array elements");
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    array1[i, j] = new Random().Next(0, 100);
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    //Console.Write("array1[" + i + ", " + j + "] = " + array1[i, j] + " ");
                    Console.Write(array1[i, j] + "\t");
                }

                Console.WriteLine();
            }

            Console.WriteLine("Enter second array elements");
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    array2[i, j] = new Random().Next(0, 100);
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    //Console.Write("array2[" + i + ", " + j + "] = " + array2[i, j] + " ");
                    Console.Write(array2[i, j] + "\t");
                }

                Console.WriteLine();
            }

            Console.WriteLine("Addition");
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    array3[i, j] = array1[i, j] + array2[i, j];
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    //Console.Write("array3[" + i + ", " + j + "] = " + array3[i, j] + " ");
                    Console.Write(array3[i, j] + "\t");
                }

                Console.WriteLine();
            }
            Console.Read();
        }
    }
}
