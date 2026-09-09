using Extra;

namespace Abstractions;

public interface IIntroContentProvider
{
    ReferenceResult<string> GetIntroArt();
}
