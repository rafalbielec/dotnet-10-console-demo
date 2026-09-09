using System;
using Abstractions;

namespace Implementations;

public class Greeter(IIntroContentProvider provider) : IGreeter
{
    public void RunIntro()
    {
        var text = provider.GetIntroArt();
        Console.WriteLineIntro(text);
    }
}
