namespace OptMobile.Retailer.Helpers;

public class ResponseFormatter<T>
{
    public int code { get; set; }
    public bool success { get; set; }
    public string? message { get; set; }
    public T? data { get; set; }
    public Pagination pagination { get; set; }
}
public class ResultSetData<T>
{
    public T resultSet { get; set; }
}
public class ResultSetPartyData<T>
{
    public T party { get; set; }
}

public class Pagination
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public bool HasPrevious { get; set; }
    public bool HasNext { get; set; }
}
