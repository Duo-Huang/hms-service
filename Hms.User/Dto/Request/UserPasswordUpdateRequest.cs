using Hms.Common.dto.request;
using Hms.Common.Enums;

namespace Hms.User.Dto.Request;

public record UserPasswordUpdateRequest(string OldPassword, string NewPassword) : IHmsRequestBody
{
    public ErrorCodeEnum GetErrorCode()
    {
        return ErrorCodeEnum.UserError107;
    }
}