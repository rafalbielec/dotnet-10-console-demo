using System.Threading.Tasks;

namespace Abstractions;

public interface IExample
{
    Task RunExampleAsync();
    string GetInfo() => GetType().Name;
}
