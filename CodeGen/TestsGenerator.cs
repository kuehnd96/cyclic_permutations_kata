using Kata;
using System;
using System.Collections.Generic;
using System.IO;

namespace CodeGen
{
    // Please insert here your tests generators
    // In case you are making new katas or you want
    // to change the testing this is a great cozy place to be!
    public class TestsGenerator
    {
        private string generalPath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Outputs";
        

        public string GenerateKataTestsFromDivisionsAndDivisors(int numberToDivide)
        {
            KataClass k = new KataClass();
            int number = 1000204;
            int[] temp = k.DivisionsAndDivisors(number);
            string result = "Assert.AreEqual(new int[] { ";

            for (int i = 0; i < temp.Length; i++)
            {
                result += temp[i] + ", ";
            }

            result += @" }, kata.DivisionsAndDivisors(" + number + @"));";

            return result;
        }

        public void LogTests(String testsName, string[] arguments)
        {
            if (!File.Exists(generalPath + Path.DirectorySeparatorChar + testsName))
            {
                File.Create(generalPath + Path.DirectorySeparatorChar + testsName);
            }

            using (StreamWriter writer = new StreamWriter(generalPath + Path.DirectorySeparatorChar + testsName))
            {
                for (int i = 0; i < arguments.Length; i++)
                {
                    writer.WriteLine(arguments[i]);
                }

                writer.Flush();
                writer.Close();
            }
        }
    }
}
