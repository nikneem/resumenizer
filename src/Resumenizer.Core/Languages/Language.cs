using Resumenizer.Core.Abstractions;
using Resumenizer.Core.ErrorCodes;
using Resumenizer.Core.Exceptions;

namespace Resumenizer.Core.Languages;

public sealed class Language
{
    public static ILanguage Dutch => new Dutch();
    public static ILanguage English => new English();
    public static ILanguage[] All => [Dutch, English];

    public static ILanguage GetByCode(string code)
    {
        if (All.Any(l => l.Code == code))
        {
            return All.First(l => l.Code == code);
        }

        throw new ResumenizerCoreException(ResumenizerCoreErrorCode.LanguageNotFound,
            $"The language with code {code} was not supported by Resumenizer");
    }
}

public sealed class Dutch : ILanguage
{
    public byte Id => 1;
    public string Code => "nl";
    public string NativeName => "Nederlands";
}

public sealed class English : ILanguage
{
    public byte Id => 2;
    public string Code => "en";
    public string NativeName => "English";
}