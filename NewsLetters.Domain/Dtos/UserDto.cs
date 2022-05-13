namespace NewsLetters.Domain.Dtos;

public class UserDto : BaseDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}