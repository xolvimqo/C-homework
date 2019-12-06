using System;

namespace ArrayExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean targetFound = false;
            int[] array1;
            int[] tempArray;
            int size = 5;
            array1 = new int[size];
            tempArray = new int[size];

            for(int i = 0; i < size; i++)
            {
                array1[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Array Elements");

            for (int i = 0; i < array1.Length; i++)
            {
                Console.Write("Array1[" + i + "] = ");
                Console.WriteLine(array1[i]);
            }
            
            for (int i = 0; i < array1.Length; i++)
            {
                for (int j = i + 1; j < array1.Length; j++)
                {
                    if (array1[i] > array1[j])
                    {
                        int temp = array1[i];
                        array1[i] = array1[j];
                        array1[j] = temp;
                    }
                }
            }
            Console.WriteLine("Sorted Array Elements");
            for (int i = 0; i < array1.Length; i++)
            {
                Console.WriteLine("array1[" + i + "] = " + array1[i]);
            }

            Console.WriteLine("Please enter a value which you want to find: ");
            int target = int.Parse(Console.ReadLine());
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] == target)
                {
                    Console.WriteLine("array1[" + i + "] = " + array1[i]);
                    targetFound = true;
                }
            }
            if (!targetFound)
            {
                Console.WriteLine("There is no " + target + " in the array1.");
            }
            Console.Read();
        }
    }
}
