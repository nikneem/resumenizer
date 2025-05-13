namespace Resumenizer.Core.Abstractions.DataTransferObjects;

public record ResumenizerListResponse<TObject>(
    bool IsSuccess,
    List<TObject> Data,
    int Page,
    int PageSize,
    int TotalPages,
    string? ErrorMessage = null)
{
    public static ResumenizerListResponse<TObject> Success(
        List<TObject> result,
        int page = 0,
        int pageSize = 0,
        int totalPages = 0) =>
        new(true, result, page, pageSize, totalPages);

    public static ResumenizerListResponse<TObject> Failure(string errorMessage) =>
        new(false, null!, 0, 0, 0, errorMessage);
}