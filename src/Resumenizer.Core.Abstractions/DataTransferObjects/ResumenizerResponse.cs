namespace Resumenizer.Core.Abstractions.DataTransferObjects;

public record ResumenizerResponse<TObject>(bool IsSuccess, TObject Data, string? ErrorMessage = null)
{
    public static ResumenizerResponse<TObject> Success(TObject result) => new(true, result);
    public static ResumenizerResponse<TObject> Failure(string errorMessage) => new(false, default!, errorMessage);
}