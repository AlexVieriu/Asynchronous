// https://www.youtube.com/watch?v=il9gl8MH17s&ab_channel=RawCoding

namespace RowCoding;

class Program
{
    // Task  : the bridge between the state machine that async creates
    // await : are the checkpoints within your state machine

    static async Task Main(string[] args)
    {
        var tea_sync = MakeTea_Sync();
        Console.WriteLine(tea_sync);

        //var tea_async = await MakeTea_Async();
        //Console.WriteLine(tea_async);

        Console.ReadLine();
    }

    #region Synchronous Programming
    public static string MakeTea_Sync()
    {
        var boilingWater = BoilWater_Sync();

        Task.Delay(5000).GetAwaiter().GetResult();

        Console.WriteLine("Take the cups out - (thread 1)");
        
        // make another task 
        var a = 0;
        for (int i = 0; i < 100_000_000; i++)
        {
            a += 1;
        }
        //  
        
        Console.WriteLine("Put tea in cups - (thread 1)");
        Console.WriteLine();


        Task.Delay(5000).GetAwaiter().GetResult();
        var water = boilingWater;
        var tea = $"Pour {water} in cups - (thread 1)";

        return tea;
    }

    public static string BoilWater_Sync()
    {
        Console.WriteLine("Put kettle on fire - (thred 1)");
        Console.WriteLine("Start the kettle  - (thread 1)");
        Console.WriteLine("Waiting for the kettle - (thread 1)");

        Task.Delay(5000).GetAwaiter().GetResult();

        Console.WriteLine();
        Console.WriteLine("Kettle finished boiling - (thread 1)");
        Console.WriteLine();

        return "water";
    }
    #endregion

    #region Asynchronous Programming
    public static async Task<string> MakeTea_Async()
    {
        var boilingWater = BoilWater_Async();

        await Task.Delay(10000);
        Console.WriteLine();
        Console.WriteLine("Take the cups out - (thred 2 is running)");

        // make another task 
        var a = 0;
        for (int i = 0; i < 1_000_000_000; i++)
        {
            a += 1;
        }
        //  

        Console.WriteLine("Put tea in cups - (thead 2)");
        Console.WriteLine();

        var water = await boilingWater;
        var tea = $"Pour {water} in cups - (thread 2)";

        return tea;
    }

    public static async Task<string> BoilWater_Async()
    {            
        Console.WriteLine("Put kettle on fire - (thred 1)");
        Console.WriteLine("Start the kettle - (thred 1)");
        Console.WriteLine("Waiting for the water to boil - (thred 1 is waiting)");
        await Task.Delay(30000);          

        // this appear after the other task is completed
        Console.WriteLine("Kettle finished boiling - (thred 1)"); 
        Console.WriteLine();

        return "water";
    }
    #endregion
}       
