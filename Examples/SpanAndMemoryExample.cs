using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abstractions;

namespace Examples;

public class SpanAndMemoryExample : IExample
{
    private const int Total = 10;

    public async Task RunExampleAsync()
    {
        // Short-lived buffer without GC
        Span<char> tmp = stackalloc char[16];
        tmp[0] = '.';
        tmp[1] = 'N';
        tmp[2] = 'e';
        tmp[3] = 't';
        var slice = tmp[0..4];
        // Span<T> — a ref + length over any contiguous memory 
        // (array, string, stackalloc); slicing copies nothing.
        Console.WriteLineInformation($"{nameof(slice)} is {slice}");

        // Substring without allocation
        ReadOnlySpan<char> word = "This is a string".AsSpan(0, 4);
        Console.WriteLineInformation($"{nameof(word)} is {word}");

        // Heap allocated equivalent of Span
        Memory<int> mem = new int[Total].AsMemory();
        await SomeAsyncOperationAsync(mem);

        Console.WriteLineInformation($"{nameof(mem)} is {string.Join(" ", mem.ToArray())}");
    }

    // Cannot pass Span to async so we use Memory
    private static async Task SomeAsyncOperationAsync(Memory<int> memory)
    {
        int counter = 0;
        await foreach (var value in YielderAsync())
        {
            memory.Span[counter++] = value;
        }
    }

    // Async yield just for fun
    private static async IAsyncEnumerable<int> YielderAsync()
    {
        for (var i = 0; i < Total; ++i)
        {
            await Task.Delay(1);
            yield return Factorial(i);
        }
    }

    // Recursive factorial method
    private static int Factorial(int n)
    {
        return n == 0 ? 1 : n * Factorial(n - 1);
    }
}
