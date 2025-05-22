using Hms.Common.dto.request;
using Hms.Common.Enums;

namespace Hms.User.Dto.Request;

public record UserLoginRequest(string Username, string Password) : IHmsRequestBody
{
    public ErrorCodeEnum GetErrorCode()
    {
        return ErrorCodeEnum.UserError105;
    }
}