using System.Threading;
using System.Threading.Tasks;

namespace Abstractions;

public interface IMenuRunner
{
    Task RunMenuAsync(CancellationToken cancellationToken);
}
