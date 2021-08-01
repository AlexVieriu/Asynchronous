using System.Threading.Tasks;

namespace NickChapsas_8MistakesToAvoid
{
    class OnceAsyncAlwaysAsync
    {
        public async Task<int> GetValueAsync()
        {
            await Task.Delay(200);
            return 5;
        }
    }
}
