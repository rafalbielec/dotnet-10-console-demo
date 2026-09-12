using System;
using System.Threading.Tasks;
using Abstractions;

namespace Examples;

public partial class ConstructorExample
{
    public partial ConstructorExample();
}

public partial class ConstructorExample : IExample
{
    public partial ConstructorExample() { }

    public Task RunExampleAsync()
    {
        var self = new ConstructorExample();
        Console.WriteLineInformation($"{nameof(ConstructorExample)} is not null: {self is not null}.");

        return Task.CompletedTask;
    }
}
