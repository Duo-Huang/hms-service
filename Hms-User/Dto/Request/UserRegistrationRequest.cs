using Hms_Common.dto.request;
using Hms_Common.Enums;

namespace Hms_User.Dto.Request;

public record UserRegistrationRequest(string Username, string Password) : IHmsRequestBody
{
    public ErrorCodeEnum GetErrorCode()
    {
        return ErrorCodeEnum.UserError104;
    }
};