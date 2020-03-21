using System;
using System.Diagnostics;
using System.Linq;

namespace LinqSpeedTestComparison
{
    class Program
    {
        const int arraySize = 20000;
        static Random r = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("This is speed comparison between Where(condition).FirstOrDefault() and FirstOrDefault(condition) \n" +
                "found on this link https://wp.secretnest.info/archives/2991");

            Console.WriteLine("----------------------------------------------------------------");
            double[][] bigArry = new double[arraySize][];
            for (int i = 0; i < arraySize; i++)
                bigArry[i] = RandomArrayGenerator();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Test1(bigArry);
            stopwatch.Stop();
            Console.WriteLine($"Result for \"Where(condition)=>FirstOrDefault()\" test is {stopwatch.ElapsedMilliseconds} milliseconds");
            stopwatch.Restart();
            Test2(bigArry);
            stopwatch.Stop();
            Console.WriteLine($"Result for \"FirstOrDefault(condition)\" test is {stopwatch.ElapsedMilliseconds} milliseconds");
            stopwatch.Reset();
            Console.WriteLine("----------------------------------------------------------------");

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        static double[] RandomArrayGenerator()
        {
            double[] resultArray = new double[arraySize];

            for (int i = 0; i < arraySize; i++)
                resultArray[i] = r.NextDouble();

            return resultArray;
        }

        static void Test1(double[][] array)
        {
            for (int i = 0; i < arraySize; i++)
            {
                array[i].Where(x => x == array[i][i]).FirstOrDefault();
                array[i].Where(x => x == 2).FirstOrDefault();
            }
        }

        static void Test2(double[][] array)
        {
            for (int i = 0; i < arraySize; i++)
            {
                array[i].FirstOrDefault(x => x == array[i][i]);
                array[i].FirstOrDefault(x => x == 2);
            }
        }
    }
}
