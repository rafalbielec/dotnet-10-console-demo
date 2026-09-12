using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Abstractions;

namespace Implementations;

public class MenuRunner(IEnumerable<IExample> examples) : IMenuRunner
{
    public async Task RunMenuAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            var ex = examples.ToArray();
            var len = ex.Length;
            var keyDict = new Dictionary<char, int>();

            Console.WriteLineIntro("Choose an example (CTRL+C to quit): ");

            for (var i = 0; i < len; ++i)
            {
                Console.WriteLineInformation($"{i + 1:00} {ex[i]}");
                keyDict.Add((i + 1).ToString()[0], i);
            }

            var key = Console.ReadKey(intercept: true).KeyChar;
            if (keyDict.ContainsKey(key))
            {
                Console.Clear();
                var example = ex[keyDict[key]];
                await example.RunExampleAsync();
                Console.WriteLine();
            }
            else
            {
                Console.Clear();
            }
        }
    }
}
