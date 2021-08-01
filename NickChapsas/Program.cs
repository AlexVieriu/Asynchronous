using System;
using System.Threading;
using System.Threading.Tasks;

namespace NickChapsas_8MistakesToAvoid
{
    // https://www.youtube.com/watch?v=lQu-eBIIh-w&t=4s&ab_channel=NickChapsas
    class Program
    {
        /*
            1. Once Async always async
            2. Async void is bad 
            3. Prefer from result over run from precomputed stuff
            4. Sync Over Async And DeadLocks
            5. Prefer await over ContinueWith
            6. Prefer await over ContinueWith
            7. Always pass CancellationToken
            8. Async in constructors is bad (i don't understand the example) ???
         */
        static async Task Main(string[] args)
        {
            // Once async always async
            var ex1 = new OnceAsyncAlwaysAsync();
            var number = await ex1.GetValueAsync();

            Console.WriteLine($"The number is {number}");

            // Async void is bad 
            var ex2 = new AsyncVoidIsBad();

            ex2.VoidAsync();                // bad way, app will crash
            await Task.Run(ex2.TaskAsync);  // good way


            // Prefer From Result Over Run For Precomputed
            var ex3 = new PreferFromResultOverRunForPrecomputed();
            var number2 = await ex3.GetValueAsync(10);
            var number3 = await ex3.GetValueTaskAsync(10);

            Console.WriteLine($"The number is {number2}");
            Console.WriteLine($"The number is {number3}");


            // Sync Over Async And DeadLocks
            var ex4 = new SyncOverAsyncAndDeadLocks();

            var number4 = ex4.GetValueAsync(5).Result; // can cause DeadLocks, it will use 2 threads instead of 1

            // the good aproach
            var number5 = await ex4.GetValueAsync(5);

            Console.WriteLine($"The number is {number4}");
            Console.WriteLine($"The number is {number5}");

            // Prefer await over ContinueWith
            var ex5 = new PreferAwaitOverContinueWith();
            var number6 = await ex5.GetValueAsync(5).ContinueWith(task => task.Result + 2); // bad way

            var number7 = await ex5.GetValueAsync(5);
            var finalnumber = number7 + 2;              //good way 

            Console.WriteLine($"The number is {number6}");
            Console.WriteLine($"The number is {finalnumber}");

            // Always pass CancellationToken(11:19)
            var ex6 = new AlwaysPassCancelationToken();

            var cancellationtoken = new CancellationToken();

            var list1 = await ex6.GetValuesWithCancellationAsync(cancellationtoken);
            var list2 = await ex6.GetValuesWithOutCancellationAsync();

            foreach (var item in list1)
                Console.WriteLine($"item");

            foreach (var item in list2)
                Console.WriteLine($"item");


            // Async in constructors is bad


            Console.ReadLine();
        }
    }
}
