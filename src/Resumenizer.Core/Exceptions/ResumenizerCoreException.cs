using Resumenizer.Core.ErrorCodes;

namespace Resumenizer.Core.Exceptions;

public class ResumenizerCoreException(
    ResumenizerCoreErrorCode errorCode,
    string message,
    Exception? innerException = null) : ResumenizerException(errorCode, message, innerException);