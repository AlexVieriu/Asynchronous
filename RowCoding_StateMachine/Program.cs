namespace RowCoding_StateMachine;

// https://youtu.be/il9gl8MH17s?t=920
class Program
{
    static async Task Main(string[] args)
    {
        #region Ex 1
        //var client = new HttpClient();
        //var task = client.GetStringAsync("https://google.com");

        //// Part 2
        //int a = 0;
        //for (int i = 0; i < 1_000_000; i++)
        //{
        //    a = i + 1;
        //}

        //// Part 3
        //var page = await task;
        #endregion

        #region Ex 2
        // Part 1 
        //var client = new HttpClient();
        //var task1 = await client.GetStringAsync("https://google.com");

        //// Part 2
        //int a = 0;
        //for (int i = 0; i < 1_000_000; i++)
        //{
        //    a = i + 1;
        //}

        //// Part 3
        //var task2 = await client.GetStringAsync("https://google.com");

        #endregion

        Console.WriteLine("Hello World");
        Console.ReadLine();
    }
}
