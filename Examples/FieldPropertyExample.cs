using System;
using System.Threading.Tasks;
using Abstractions;

namespace Examples;

public class FieldPropertyExample : IExample
{
    private class Model
    {
        public int Number { get; set; }
    }

    public Task RunExampleAsync()
    {
        Name = " Raf  ";
        Console.WriteLineInformation($"{nameof(Name)} is {Name}.");
        Console.WriteLineInformation($"{nameof(SelfAssigned)} is {SelfAssigned}.");

        // Instance assignment without checking for null first
        Model m = null;
        m?.Number = 100;
        m?.Number += 100;

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
