using Hms.Common.dto.request;
using Hms.Common.Enums;

namespace Hms.User.Dto.Request;

public record UserRegistrationRequest(string Username, string Password) : IHmsRequestBody
{
    public ErrorCodeEnum GetErrorCode()
    {
        return ErrorCodeEnum.UserError104;
    }
};