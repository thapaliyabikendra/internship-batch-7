using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assisment.Contract;

public class ResponseData
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public object? Data { get; set; }
}

public class ResponseData<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
}


public class PaginatedResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<T> Data { get; set; } = new List<T>();

    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalRecords { get; set; }
    public int TotalPages { get; set; }
}
