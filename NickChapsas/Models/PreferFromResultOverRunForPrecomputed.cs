using System.Threading.Tasks;

namespace NickChapsas_8MistakesToAvoid
{
    class PreferFromResultOverRunForPrecomputed
    {
        public async Task<int> GetValueAsync(int numberToAdd)
        {
            // (6:01)
            // return await Task.Run(() => numberToAdd * 2); // will waste a thred from the thredpull, without doing anywthing with it
            return await Task.FromResult(numberToAdd * 2); // good way           
        }

        // best approach 
        public async ValueTask<int> GetValueTaskAsync(int numberToAdd)
        {
            return await new ValueTask<int>(numberToAdd * 2);
        }
    }
}
