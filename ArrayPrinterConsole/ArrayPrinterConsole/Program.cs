using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayPrinterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Version 1: create empty string array
            // Assign into the array
            string[] animals = new string[3];
            animals[0] = "deer";
            animals[1] = "moose";
            animals[2] = "boars";
            Console.WriteLine("Array 1: " + animals.Length);

            // Version 2: use array initializer
            string[] animal2 = new string[] {"deer", "moose", "boars"};
            Console.WriteLine("Array 2: " + animal2.Length);

            // Version 3: a shorter array initializer
            string[] animal3 = {"deer", "moose", "boars"};
            Console.WriteLine("Array 3: " + animal3.Length);

            Console.WriteLine(animals[0] + " " + animals[animals.Length - 1]);

            Console.Read();
        }
    }
}
