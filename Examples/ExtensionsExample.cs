using System;
using System.Threading.Tasks;
using Abstractions;

namespace Examples;

// Field-scoped class
file static class StringExtensions
{
    extension(string value)
    {
        public bool IsEmpty => string.IsNullOrWhiteSpace(value);

        public string Reverse()
        {
            var s = value;
            if (!s.IsEmpty)
            {
                var len = s.Length;
                Span<char> span = new char[len];
                for (int i = 0; i < len; ++i)
                {
                    span[i] = s[len - i - 1];
                }

                return span.ToString();
            }

            return s;
        }
    }
}

public class ExtensionsExample : IExample
{
    public Task RunExampleAsync()
    {
        string nullName = null;
        var name = nameof(ExtensionsExample);
        var empty = !name.IsEmpty;
        var word = empty ? "not" : string.Empty;

        Console.WriteLineInformation($"String {nameof(nullName)} is empty: {nullName.IsEmpty}.");
        Console.WriteLineInformation($"String {nameof(name)} is {word} empty.");
        Console.WriteLineInformation($"String {name} in reverse is {name?.Reverse()}.");

        return Task.CompletedTask;
    }
}
