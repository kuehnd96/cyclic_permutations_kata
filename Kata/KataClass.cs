using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Kata
{
    public class KataClass
    {

        #region Kata 1

        // Kata 1

        /// <summary>
        /// Implement the cyclic permutation method, the method should be able to output the full string of permutations
        /// given a set number n
        ///
        /// The results MUST NOT BE HARD CODED!
        ///
        /// Example:
        /// n = 5
        ///
        /// 12345
        /// 51234
        /// 45123
        /// 34512
        /// 23451
        ///
        /// n = 4
        ///
        /// 1234
        /// 4123
        /// 3412
        /// 2341
        ///
        /// ;) Enjoy!
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public String CyclicPermutations(int number)
        {
            const string NewLine = "\n";

            if (number < 1)                                                                                                                                                                                                                                                                    
            {
                return string.Empty;
            }

            if (number == 1)
            {
                return "1";
            }

            // Create initial flow
            var permutationBuilder = new StringBuilder();

            for (int i=1; i<= number; i++)
            {
                permutationBuilder.Append(i);
            }

            string permutation = permutationBuilder.ToString();
            permutationBuilder.Append(NewLine);

            // Create the rest of the permutations
            for (int p=1; p <= number-1; p++)
            {
                char lastNumber = permutation.Last();

                permutation = lastNumber + permutation.Substring(0, number - 1);

                permutationBuilder.Append(permutation);

                if (p < number-1)
                {
                    permutationBuilder.Append(NewLine);
                }
            }

            return permutationBuilder.ToString();
        }


        public void InterviewerPrint(StringBuilder sb)
        {
            string temp = sb.ToString();
            string[] arr = temp.Split("\n");

            string str = "";

            for (int i = 0; i < arr.Length; i++)
            {
                str += @"\n" + arr[i].Trim();
            }

            Console.WriteLine(str);
        }

        #endregion


        #region Kata 2

        // Kata 2
        /// <summary>
        /// Produce the divisors of a number n
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[] DivisionsAndDivisors(int n)
        {
            int eSize = 0;

            for (int i = 2; i < n; i++)
            {
                if ((n % i) == 0)
                {
                    eSize++;
                }
            }

            int[] divisors = new int[eSize];

            int cursor = 0;

            for (int i = 2; i < n; i++)
            {
                if ((n % i) == 0)
                {
                    divisors[cursor] = i;
                    cursor++;
                }
            }

            return divisors;
        }

        #endregion

        #region Kata 3

        // Kata 3
        /// <summary>
        /// Figure out what type of encryption it is, then try to make the encryption
        /// and decryption methods pass the tests!
        /// </summary>
        /// <param name="word"></param>
        /// <param name="map"></param>
        /// <param name="shifts"></param>
        /// <returns></returns>
        public string Encrypter(string word, Dictionary<string, int> map, int shifts)
        {
            char[] toChars = word.ToCharArray();
            StringBuilder result = new StringBuilder();

            Dictionary<int, string> reverseMap = new Dictionary<int, string>();

            foreach (string str in map.Keys)
            {
                reverseMap.Add(map[str], str);
            }

            for (int i = 0; i < toChars.Length; i++)
            {
                int n = map[toChars[i] + ""];
                int totalShifts = (n + shifts);

                if (reverseMap.ContainsKey(totalShifts))
                {
                    result.Append(reverseMap[totalShifts]);
                }
                else
                {
                    result.Append(reverseMap[totalShifts - reverseMap.Count]);
                }
            }

            return result.ToString();
        }

        public string Decrypter(string encryptedWord, Dictionary<string, int> map, int shifts)
        {
            char[] toChars = encryptedWord.ToCharArray();
            StringBuilder result = new StringBuilder();

            Dictionary<int, string> reverseMap = new Dictionary<int, string>();

            foreach (string str in map.Keys)
            {
                reverseMap.Add(map[str], str);
            }

            for (int i = 0; i < toChars.Length; i++)
            {
                int n = map[toChars[i] + ""];
                int totalShifts = (n - shifts);

                if (reverseMap.ContainsKey(totalShifts))
                {
                    result.Append(reverseMap[totalShifts]);
                }
                else
                {
                    if (totalShifts < 0)
                    {
                        totalShifts = totalShifts + reverseMap.Count;
                    }

                    result.Append(reverseMap[totalShifts]);
                }
            }

            return result.ToString();
        }

        #endregion

        // END KATA 3 //

        #region Kata 4

        // Kata 4

        /// <summary>
        /// Figure out the fizz buzz paradigm
        ///
        ///
        /// For interviewer: This is mainly a little breather or warm up exercise, easy enough for juniors and seniors. This is mainly
        /// made for practicing peer programming and seen how a programmer does in a group when programming with others.
        /// This is easy enough and probably something someone would prepare before an interview, thus you can see if the person wants
        /// to do it on it's own for glory or just piggy backs!
        /// </summary>
        /// <returns></returns>
        public static string PrintFizzBuzz()
        {
            var resultFizzBuzz = string.Empty;
            resultFizzBuzz = GetNumbers(resultFizzBuzz);
            return resultFizzBuzz;
        }

        public static string PrintFizzBuzz(int number)
        {
            CanThrowArgumentExceptionWhenNumberNotInRule(number);

            var result = GetFizzBuzzResult(number);

            if (string.IsNullOrEmpty(result))
                result = GetFizzResult(number);
            if (string.IsNullOrEmpty(result))
                result = GetBuzzResult(number);

            return string.IsNullOrEmpty(result) ? number.ToString(CultureInfo.InvariantCulture) : result;
        }

        private static string GetFizzBuzzResult(int number)
        {
            string result = null;
            if (IsFizz(number) && IsBuzz(number)) result = "FizzBuzz";
            return result;
        }

        private static string GetBuzzResult(int number)
        {
            string result = null;
            if (IsBuzz(number)) result = "Buzz";
            return result;
        }

        private static string GetFizzResult(int number)
        {
            string result = null;
            if (IsFizz(number)) result = "Fizz";
            return result;
        }

        private static void CanThrowArgumentExceptionWhenNumberNotInRule(int number)
        {
            if (number > 100 || number < 1)
                throw new ArgumentException(
                    string.Format(
                        "entered number is [{0}], which does not meet rule, entered number should be between 1 to 100.",
                        number));
        }

        private static string GetNumbers(string resultFizzBuzz)
        {
            for (var i = 1; i <= 100; i++)
            {
                var printNumber = string.Empty;
                if (IsFizz(i)) printNumber += "Fizz";
                if (IsBuzz(i)) printNumber += "Buzz";
                if (IsNumber(printNumber))
                    printNumber = (i).ToString(CultureInfo.InvariantCulture);
                resultFizzBuzz += " " + printNumber;
            }

            return resultFizzBuzz.Trim();
        }

        private static string GetNumbersUsingLinq(string resultFizzBuzz)
        {
            Enumerable.Range(1, 100)
                .Select(fb => String.Format("{0}{1}", fb % 3 == 0 ? "Fizz" : "", fb % 5 == 0 ? "Buzz" : ""))
                .Select(fb =>
                    fb != null ? (String.IsNullOrEmpty(fb) ? fb.ToString(CultureInfo.InvariantCulture) : fb) : null)
                .ToList()
                .ForEach(x => resultFizzBuzz = x);
            return resultFizzBuzz.Trim();
        }

        private static bool IsNumber(string printNumber)
        {
            return String.IsNullOrEmpty(printNumber);
        }

        private static bool IsBuzz(int i)
        {
            return i % 5 == 0;
        }

        private static bool IsFizz(int i)
        {
            return i % 3 == 0;
        }
    }

    #endregion
}