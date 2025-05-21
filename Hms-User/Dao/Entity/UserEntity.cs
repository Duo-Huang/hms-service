using Hms_Common.Dao.Entity;

namespace Hms_User.Dao.Entity;

public class UserEntity : BaseEntity
{
    public required int UserId { get; set; }

    public required string Username { get; set; }

    public required string Password { get; set; }

    public required string Nickname { get; set; }
}