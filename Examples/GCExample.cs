using System;
using System.Threading.Tasks;
using Abstractions;

namespace Examples;

public class GCExample : IExample
{
    public Task RunExampleAsync()
    {
        Console.WriteLineIntro(nameof(GCExample));

        long memory = GC.GetTotalMemory(forceFullCollection: false);
        long allocated = GC.GetTotalAllocatedBytes();

        Console.WriteLineInformation($"GC Total Memory: {memory / 1024.0 / 1024.0:F2} MB");
        Console.WriteLineInformation($"GC Allocated: {allocated / 1024.0 / 1024.0:F2} MB");

        var info = GC.GetGCMemoryInfo();
        Console.WriteLineInformation($"GC Heap Size:           {info.HeapSizeBytes / 1024.0 / 1024.0:F2} MB");
        Console.WriteLineInformation($"GC Total Available:     {info.TotalAvailableMemoryBytes / 1024.0 / 1024.0:F2} MB");
        Console.WriteLineInformation($"GC High Memory Load:    {info.HighMemoryLoadThresholdBytes / 1024.0 / 1024.0:F2} MB");
        Console.WriteLineInformation($"GC Fragmented Bytes:    {info.FragmentedBytes / 1024.0:F2} KB");

        return Task.CompletedTask;
    }
}
