namespace NewsLetters.Domain.Models;

public class DefaultResponse
{
    public int Code { get; set; }
    public object Message { get; set; }
    public object Error { get; set; }
    public object Response { get; set; }
}