namespace NewsLetters.Domain.Entities;

public class NewsEntity : BaseEntity
{
    public NewsEntity()
    {
        Title = string.Empty;
        Content = string.Empty;
        Image = string.Empty;
        Author = string.Empty;
        Category = string.Empty;
        Date = DateTime.Now;
    }
    
    public string Title { get; set; }
    public string Content { get; set; }
    public string Image { get; set; }
    public string Author { get; set; }
    public string Category { get; set; }
    public DateTime Date { get; set; }
}