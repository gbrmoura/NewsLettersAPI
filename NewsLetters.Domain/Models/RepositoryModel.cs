namespace NewsLetters.Domain.Models;

public class BasicFilter
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}

public class AdvancedFilter : BasicFilter
{
    public string Search { get; set; }
}