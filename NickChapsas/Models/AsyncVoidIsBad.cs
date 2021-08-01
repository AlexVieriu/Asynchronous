using System;
using System.Threading.Tasks;

namespace NickChapsas_8MistakesToAvoid
{
    class AsyncVoidIsBad
    {
        public async Task<int> GetValueAsync()
        {
            return await Task.FromResult(1);
        }

        public async void VoidAsync()
        {
            var result = await GetValueAsync();
            await Task.Delay(2000);
            throw new Exception("Mail failed");

            Console.WriteLine($"The number is {result}");
        }

        public async Task TaskAsync()
        {
            var result = await GetValueAsync();
            await Task.Delay(2000);
            throw new Exception("Mail failed");

            Console.WriteLine($"The number is {result}");
        }
    }
}
