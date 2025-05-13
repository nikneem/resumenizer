using Resumenizer.Core.ErrorCodes;
using Resumenizer.Core.Exceptions;
using Resumenizer.Core.Languages;

namespace Resumenizer.Core.Tests.Languages;

public class LanguageTests
{
    [Theory]
    [InlineData("en")]
    [InlineData("nl")]
    public void GetByCode_WhenLanguageExists_ShouldReturnLanguage(string code)
    {
        // Arrange
        var language = Language.GetByCode(code);

        // Assert
        Assert.Equal(language.Code, code);
    }

    [Theory]
    [InlineData("es")]
    [InlineData("")]
    [InlineData(null)]
    public void GetByCode_WhenLanguageDoesNotExist_ShouldThrowException(string code)
    {
        // Act
        var exception = Assert.Throws<ResumenizerCoreException>(() => Language.GetByCode(code));
        // Assert
        Assert.Equal(ResumenizerCoreErrorCode.LanguageNotFound.Code, exception.ErrorCode.Code);
    }
}