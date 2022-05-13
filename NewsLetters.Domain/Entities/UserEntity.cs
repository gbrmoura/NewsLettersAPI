namespace NewsLetters.Domain.Entities;

public class UserEntity : BaseEntity
{
    public UserEntity()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}