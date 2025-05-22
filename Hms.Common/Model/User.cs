namespace Hms.Common.Model;

public class User : BaseModel
{
    public required int UserId { get; set; }

    public required string Username { get; set; }

    public string Nickname { get; set; }
}