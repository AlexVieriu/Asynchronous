using System;
using System.Threading;
using System.Threading.Tasks;

namespace FrankLiu
{
    // https://www.youtube.com/watch?v=CrUrvVatAxo&ab_channel=FrankLiu
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");

            //Calculate_Sync();
            Calculate_Async();

            Console.Read();
        }

        static void Calculate_Sync()
        {
            Calculate1();
            Calculate2();
            Calculate3();
        }

        static void Calculate_Async()
        {
            Task.Run(() => Calculate1());
            Task.Run(() => Calculate2());
            Task.Run(() => Calculate3());
        }

        static int Calculate1()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Calculating result1");
            return 100;
        }

        static int Calculate2()
        {
            Console.WriteLine("Calculating result2");
            return 200;
        }

        static int Calculate3()
        {
            Console.WriteLine("Calculating result3");
            return 300;
        }
    }
}
