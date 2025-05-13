using Resumenizer.Core.ErrorCodes;

namespace Resumenizer.Core.Exceptions;

public class ResumenizerException(SpreaViewErrorCode errorCode, string message, Exception? innerException = null) : Exception(message, innerException)
{
    public SpreaViewErrorCode ErrorCode => errorCode;

}