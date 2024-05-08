using jobForm.Common;
using jobForm.Models.Form.Global;
using Microsoft.EntityFrameworkCore;
using TatweerSwissTool.Common;
namespace jobForm.Models.Dto.Global;

public class PaginationResponse<T>(
    IList<T>? data = default,
    string? message = null,
    bool error = false,
    int pageNumber = 1,
    int pageSize = 10,
    int count = 0)
    : GlobalResponse<IList<T>>(data, message, error)
{
    public int PageNumber { get; set; } = pageNumber;
    public int PageSize { get; set; } = pageSize;
    public int Count { get; set; } = count;

    public static async Task<PaginationResponse<T>> CreateAsync(IQueryable<T> source, Pagination pagination,
        string message = "Users fetched successfully")
    {
        var count = await source.CountAsync();
        var items = await source.OrderByDescending(item => (item as FullAuditableEntity)!.CreatedAt)
            .Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize)
            .ToListAsync();

        return new PaginationResponse<T>(items, null, false, pagination.PageNumber, pagination.PageSize, count);
    }
}

public class PaginationResponseEmpty(
    string? message = null,
    bool error = false,
    int pageNumber = 1,
    int pageSize = 10) : PaginationResponse<object>(new List<object>(), message, error, pageNumber, pageSize);