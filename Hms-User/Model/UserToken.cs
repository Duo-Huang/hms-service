namespace Hms_User.Model;

public record UserToken(
    string Jti,
    int UserId,
    string Subject,
    string Issuer,
    DateTime IssuedAt,
    DateTime NotBefore,
    DateTime Expiration);