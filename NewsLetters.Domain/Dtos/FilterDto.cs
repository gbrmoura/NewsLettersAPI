namespace NewsLetters.Domain.Dtos;

public class FilterDto
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string Search { get; set; }
}