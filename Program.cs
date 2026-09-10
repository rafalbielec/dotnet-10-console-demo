using Abstractions;
using Implementations;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Runtime.InteropServices;
using System;
using Extra;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;
using Examples;

internal class Program
{
    private static async Task Main(string[] args)
    {
        // Configuration without web builder since this is a console app.
        IConfiguration config = new ConfigurationBuilder()
          .SetBasePath(AppContext.BaseDirectory)
          .AddJsonFile("appsettings.json", optional: false)
          .Build();

        var appConfig = config.GetSection("AppOptions").Get<AppOptions>();

        // Use the DI container on its own. 
        var services = new ServiceCollection();

        services.AddSingleton<IOptions<AppOptions>>(Options.Create(appConfig));
        services.AddSingleton<IIntroContentProvider, IntroContentProvider>();
        services.AddSingleton<IMenuRunner, MenuRunner>();
        services.AddSingleton<IExample, GCExample>();
        services.AddSingleton<IExample, SpanAndMemoryExample>();
        services.AddSingleton<IGreeter, Greeter>();

        using var provider = services.BuildServiceProvider();
        using var ctx = new CancellationTokenSource();

        Action<PosixSignalContext> quit = context =>
        {
            Console.Clear();
            Console.WriteLineWarning("Application has been stopped.");
            context.Cancel = true;
            ctx.Cancel();
            Environment.Exit(0);
        };

        // Register hooks for both Ctrl+C (SIGINT) and termination signals (SIGTERM)
        using var signInt = PosixSignalRegistration.Create(PosixSignal.SIGINT, quit);
        using var signTerm = PosixSignalRegistration.Create(PosixSignal.SIGTERM, quit);

        var greeter = provider.GetRequiredService<IGreeter>();
        var menuRunner = provider.GetRequiredService<IMenuRunner>();

        greeter.RunIntro();

        await menuRunner.RunMenuAsync(ctx.Token);
    }
}
