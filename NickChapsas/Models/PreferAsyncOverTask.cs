using System;
using System.Threading.Tasks;

namespace NickChapsas_8MistakesToAvoid.Models
{
    public class PreferAsyncOverTask
    {        
        public Task<int> GetValue()
        {
            return Task.FromResult(1);
        }

        public async Task<int> GetValueAsync()
        {
            return await Task.FromResult(1);
        }
    }
}
