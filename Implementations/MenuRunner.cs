using System.Threading;
using System.Threading.Tasks;
using Abstractions;

namespace Implementations;

public class MenuRunner : IMenuRunner
{
    public async Task RunMenuAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            await Task.Delay(1000);
        }
    }
}
