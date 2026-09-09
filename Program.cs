using Abstractions;
using Implementations;

using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        // Use the DI container on its own. 
        var services = new ServiceCollection();
        services.AddSingleton<IGreeter, Greeter>();
        services.AddSingleton<IIntroContentProvider, IntroContentProvider>();

        using var provider = services.BuildServiceProvider();
        var greeter = provider.GetRequiredService<IGreeter>();

        greeter.RunIntro();
    }
}
