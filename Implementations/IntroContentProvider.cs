using System.IO;
using Abstractions;
using Extra;
using Microsoft.Extensions.Options;

namespace Implementations;

public class IntroContentProvider(IOptions<AppOptions> options) : IIntroContentProvider
{
    public ReferenceResult<string> GetIntroArt()
    {
        var name = options.Value.IntroFile;
        var file = new FileInfo(name);
        if (file.Exists)
        {
            return File.ReadAllText(file.FullName);
        }

        return new Error(ErrorCode.BrokenIntroFile);
    }
}
