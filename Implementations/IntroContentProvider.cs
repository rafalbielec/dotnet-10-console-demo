using System.IO;
using Abstractions;

namespace Implementations;

public class IntroContentProvider : IIntroContentProvider
{
    public string GetIntroArt()
    {
        var file = new FileInfo("intro.txt");
        if (file.Exists)
        {
            return File.ReadAllText(file.FullName);
        }

        return null;
    }
}
