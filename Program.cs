using Abstractions;
using Implementations;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using Extra;
using Microsoft.Extensions.Options;

internal class Program
{
    private static void Main(string[] args)
    {
        IConfiguration config = new ConfigurationBuilder()
          .SetBasePath(AppContext.BaseDirectory)
          .AddJsonFile("appsettings.json", optional: false)
          .Build();

        var appConfig = config.GetSection("AppOptions").Get<AppOptions>();

        // Use the DI container on its own. 
        var services = new ServiceCollection();

        services.AddSingleton<IOptions<AppOptions>>(Options.Create(appConfig));
        services.AddSingleton<IGreeter, Greeter>();
        services.AddSingleton<IIntroContentProvider, IntroContentProvider>();

        using var provider = services.BuildServiceProvider();
        var greeter = provider.GetRequiredService<IGreeter>();

        greeter.RunIntro();
    }
}
