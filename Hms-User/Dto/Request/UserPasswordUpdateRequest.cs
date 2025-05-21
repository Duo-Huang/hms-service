using Hms_Common.dto.request;
using Hms_Common.Enums;

namespace Hms_User.Dto.Request;

public record UserPasswordUpdateRequest(string OldPassword, string NewPassword) : IHmsRequestBody
{
    public ErrorCodeEnum GetErrorCode()
    {
        return ErrorCodeEnum.UserError107;
    }
}