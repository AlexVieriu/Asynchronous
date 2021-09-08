namespace RowCoding_ByThread
{
    // https://youtu.be/il9gl8MH17s?t=518
    // https://www.linqpad.net/
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Line 1- Theard Number: " + Thread.CurrentThread.ManagedThreadId.ToString());            
            var client = new HttpClient();

            Console.WriteLine("Line 2 - Theard Number: " + Thread.CurrentThread.ManagedThreadId.ToString());
            var task = client.GetStringAsync("http://google.com");

            Console.WriteLine("Line 3 - Theard Number: " + Thread.CurrentThread.ManagedThreadId.ToString());
            var a = 0;
            for (int i = 0; i < 100_000_000; i++)
            {
                a += i;
            }

            Console.WriteLine("Line 4 - Theard Number: " + Thread.CurrentThread.ManagedThreadId.ToString());
            var page = await task;

            Console.WriteLine("Line 5 - Theard Number: " + Thread.CurrentThread.ManagedThreadId.ToString());

            Console.ReadLine();
        }
    }
}
