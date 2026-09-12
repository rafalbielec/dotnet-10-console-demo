using System;
using System.Threading.Tasks;
using Abstractions;

namespace Examples;

public class LambdaExample : IExample
{
    public Task RunExampleAsync()
    {
        // You can use ref, in, and out on lambda parameters
        // without explicitly writing their types.

        var n = 10;
        var divide = (ref int number) => number /= 0b10;
        divide(ref n);

        Console.WriteLineInformation($"{n}");

        return Task.CompletedTask;
    }
}
