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
        private string generalPath = "C:\\Users\\andy.gasparini\\Documents\\CentareInterview\\KatasInterview\\Kata" + Path.DirectorySeparatorChar + "Outputs";

        public string GenerateKataTestsFromDivisionsAndDivisors(int numberToDivide)
        {
            KataClass k = new KataClass();
            int[] temp = k.DivisionsAndDivisors(numberToDivide);
            string result = "Assert.AreEqual(new int[] { ";

            for (int i = 0; i < temp.Length; i++)
            {
                result += temp[i];

                if (i != temp.Length - 1)
                {
                    result += ", ";
                }
            }

            result += @" }, kata.DivisionsAndDivisors(" + numberToDivide + @"));";

            return result;
        }

        public void LogTests(String testsName, string[] arguments)
        {
            using (StreamWriter writer = new StreamWriter(generalPath + Path.DirectorySeparatorChar + testsName + ".txt"))
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
