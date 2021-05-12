using CodeGen;
using System;
using System.Collections.Generic;

namespace Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            KataClass classK = new KataClass();

            Console.WriteLine(classK.CyclicPermutations(4));
            Console.ReadLine();
        }
    }
}