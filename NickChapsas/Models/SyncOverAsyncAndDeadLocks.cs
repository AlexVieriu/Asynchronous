using System.Threading.Tasks;

namespace NickChapsas_8MistakesToAvoid
{
    class SyncOverAsyncAndDeadLocks
    {
        public async Task<int> GetValueAsync(int number)
        {
            await Task.Delay(2000);
            return number;
        }
    }
}
