using System.Threading.Tasks;
using Extra;

namespace Abstractions;

public interface IExample
{
    Task RunExampleAsync();
    string GetInfo() => GetType().Name;
    string SourceCode => SourceReader.For(GetType());
}
