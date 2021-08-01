using System;
using System.Threading;
using System.Threading.Tasks;


// https://www.youtube.com/watch?v=il9gl8MH17s&ab_channel=RawCoding
namespace RowCoding
{
    class Program
    {
        // Task  : the bridge between the state machine that async creates
        // await : are the checkpoints within your state machine

        static async Task Main(string[] args)
        {
            //var tea_sync = MakeTea_Sync();
            //Console.WriteLine(tea_sync);

            //var tea_async = await MakeTea_Async();
            //Console.WriteLine(tea_async);

            Console.ReadLine();
        }

        #region Synchronous Programming
        public static string MakeTea_Sync()
        {
            var water = BoilWater_Sync();

            Console.WriteLine("take the cups out");
            Console.WriteLine("put tea in cups");
            var tea = $"pour {water} in cups";

            return tea;
        }

        public static string BoilWater_Sync()
        {
            Console.WriteLine("Start the kettle");
            Console.WriteLine("Waiting for the kettle");

            Task.Delay(3000).GetAwaiter().GetResult();

            Console.WriteLine();
            Console.WriteLine("kettle finished boiling");

            return "water";
        }
        #endregion

        #region Asynchronous Programming
        public static async Task<string> MakeTea_Async()
        {
            var boilingWater = BoilWater_Async();

            Console.WriteLine();
            Console.WriteLine("Take the cups out");

            // make another task 
            var a = 0;
            for (int i = 0; i < 1_000_000; i++)
            {
                a += i;
            }
            //  

            Console.WriteLine(a);
            Console.WriteLine("Put tea in cups");            

            var water = await boilingWater;
            var tea = $"Pour {water} in cups";

            return tea;
        }

        public static async Task<string> BoilWater_Async()
        {
            Console.WriteLine("Start the kettle");
            Console.WriteLine("Waiting for the water to boil");
            await Task.Delay(1500);
            Console.WriteLine();

            Console.WriteLine("Kettle finished boiling");
            Console.WriteLine();

            return "water";
        }
        #endregion
    }       
}
