using Hms.User.Model;

namespace Hms.User.Services;

public interface IAuthenticationService
{
    string GenerateToken(Common.Model.User user);

    bool ValidateToken(UserToken userToken);

    UserToken ParseToken(string token);

    bool IsTokenRevoked(UserToken userToken);

    void RevokeToken(UserToken userToken);
}