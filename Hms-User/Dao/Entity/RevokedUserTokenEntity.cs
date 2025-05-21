using Hms_Common.Dao.Entity;

namespace Hms_User.Dao.Entity;

public class RevokedUserTokenEntity : BaseEntity
{
    public required int Id { get; set; }

    public required string Jti { get; set; }

    public required DateTime Expiration { get; set; }

    public required int UserId { get; set; }
}