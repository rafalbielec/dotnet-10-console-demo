using System;
using System.IO;

namespace Extra;

public static class SourceReader
{
    public static string For(Type type)
    {
        var name = $"{type.Name}";

        using var stream = type.Assembly.GetManifestResourceStream(name)
            ?? throw new InvalidOperationException($"{name} doesn't exit.");

        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}

