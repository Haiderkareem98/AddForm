namespace jobForm.Models.Dto.Global;

public class GlobalResponse<T>(T? data = default, string? message = null, bool error = false)
{
    public string? Message { get; set; } = message;
    public T? Data { get; set; } = data;
    public bool Error { get; set; } = error;
}

public class GlobalResponseEmpty(string? message = null, bool error = false)
    : GlobalResponse<object>(null, message, error);

public class ListCount<T>(List<T>? data = default, int count = 0)
{
    public List<T>? Data { get; set; } = data;
    public int Count { get; set; } = count;
}