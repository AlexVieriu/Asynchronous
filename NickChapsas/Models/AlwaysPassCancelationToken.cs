using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NickChapsas_8MistakesToAvoid
{
    class AlwaysPassCancelationToken
    {
        public async Task<List<int>> GetValuesWithCancellationAsync(CancellationToken cancellationToken)
        {
            var nrRandom = new Random();
            var list = new List<int>();

            return await Task.Run(async () =>
            {
                await Task.Delay(5000, cancellationToken);
                Console.WriteLine("Waited for 5 seconds");

                for (int i = 0; i < 10; i++)
                {
                    list.Add(nrRandom.Next(1,10));
                }

                return list;

            }, cancellationToken);
        }

        public async Task<List<int>> GetValuesWithOutCancellationAsync()
        {
            var nrRandom = new Random();
            var list = new List<int>();

            return await Task.Run(async () =>
            {
                await Task.Delay(5000);
                Console.WriteLine("Waited for 5 seconds");

                for (int i = 0; i < 10; i++)
                {
                    list.Add(nrRandom.Next(1, 10));
                }

                return list;
            });
        }
    }
}
