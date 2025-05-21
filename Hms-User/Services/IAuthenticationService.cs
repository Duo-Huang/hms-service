using Hms_Common.Model;
using Hms_User.Model;

namespace Hms_User.Services;

public interface IAuthenticationService
{
    string GenerateToken(User user);

    bool ValidateToken(UserToken userToken);

    UserToken ParseToken(string token);

    bool IsTokenRevoked(UserToken userToken);

    void RevokeToken(UserToken userToken);
}