using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        private const int ARRAY_LENGTH = 10;
        private static Random rnd = new Random();
        static void Main(string[] args)
        {
            var task = Task.Factory.StartNew(() => CreateArrayOfRandomInt(ARRAY_LENGTH))
                .ContinueWith(i => WriteAndContinue(i.Result))
                .ContinueWith(i => MultiplyArrayWithRandomInt((int[])i.Result))
                .ContinueWith(i => WriteAndContinue(i.Result))
                .ContinueWith(i => SortArraySc((int[])i.Result))
                .ContinueWith(i => WriteAndContinue(i.Result))
                .ContinueWith(i => CalculateAvg((int[])i.Result));

            WritePreviousResult(task.Result);
            Console.ReadLine();
        }

        private static void WritePreviousResult(object prevResult)
        {
            switch (prevResult.GetType())
            {
                    
            }
            Console.WriteLine((prevResult is IEnumerable<int>) ? String.Join(", ", (IEnumerable<int>)prevResult) : prevResult.ToString());
        }

        private static object WriteAndContinue(object result)
        {
            WritePreviousResult(result);
            return result;
        }

        private static int[] CreateArrayOfRandomInt(int length)
        {
            var result = new List<int>(length);
            for (int i = 0; i < length; i++)
            {
                result.Add(rnd.Next());
            }
            return result.ToArray();
        }

        private static int[] MultiplyArrayWithRandomInt(int[] arrInts)
        {

            var multiplier = rnd.Next();
            for (int i = 0; i < arrInts.Length; i++)
            {
                arrInts[i] = arrInts[i] * multiplier;
            }

            return arrInts;
        }

        private static int[] SortArraySc(int[] arrInts)
        {

            var tmpList = arrInts.ToList();
            tmpList.Sort();
            return tmpList.ToArray();
        }

        private static float CalculateAvg(int[] arrInts)
        {

            int sum = 0;
            foreach (var item in arrInts)
            {
                sum += item;
            }

            return sum / arrInts.Length;
        }


    }
}
