namespace NewsLetters.Domain.Dtos;

public class NewsDto : BaseDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Image { get; set; }
    public string Author { get; set; }
    public DateTime Date { get; set; }
    public string Category { get; set; }
}