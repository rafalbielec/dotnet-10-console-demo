using System;
using System.Threading.Tasks;
using Abstractions;

namespace Examples;

public class FieldPropertyExample : IExample
{
    public Task RunExampleAsync()
    {
        Name = " Raf  ";
        Console.WriteLineInformation($"{nameof(Name)} is {Name}.");
        Console.WriteLineInformation($"{nameof(SelfAssigned)} is {SelfAssigned}.");

        return Task.CompletedTask;
    }

    private string Name
    {
        get;
        set => field = string.IsNullOrWhiteSpace(value) ? string.Empty : value.Trim();
    }

    private string SelfAssigned
    {
        get => field ??= nameof(Examples);
    }
}
