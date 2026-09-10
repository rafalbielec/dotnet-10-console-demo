using System;
using System.Threading.Tasks;
using Abstractions;

namespace Examples;

public class SpanAndMemoryExample : IExample
{
    public Task RunExampleAsync()
    {
        ReadOnlySpan<char> sentence = "Example sentence in a ReadOnlySpan";
        ReadOnlySpan<char> firstWord = sentence[..sentence.IndexOf(' ')];
        Console.WriteLineInformation($"Zero-allocation slice via Span<char> {firstWord}");

        return Task.CompletedTask;
    }
}
