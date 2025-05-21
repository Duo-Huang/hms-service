using Hms_Common.dto.request;
using Hms_Common.Enums;

namespace Hms_User.Dto.Request;

public record UserProfileUpdateRequest(string Nickname) : IHmsRequestBody
{
    public ErrorCodeEnum GetErrorCode()
    {
        return ErrorCodeEnum.UserError106;
    }
}