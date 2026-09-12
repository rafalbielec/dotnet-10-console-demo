using System;
using System.Threading.Tasks;
using Abstractions;

namespace Examples;

public class CompoundAssignmentExample : IExample
{
    private struct Money
    {
        public decimal Value { get; }

        public Money(decimal value)
        {
            Value = value;
        }

        public static Money operator +(Money a, Money b) => new(a.Value + b.Value);
        public static Money operator ++(Money value) => new(value.Value + 1);

        public override string ToString()
        {
            return $"{Value:F2}";
        }
    }

    public Task RunExampleAsync()
    {
        Money total = new(100);
        total += new Money(25);
        total++;

        Console.WriteLineInformation($"Amount in total is {total}.");

        return Task.CompletedTask;
    }
}
