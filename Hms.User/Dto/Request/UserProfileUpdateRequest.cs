using Hms.Common.dto.request;
using Hms.Common.Enums;

namespace Hms.User.Dto.Request;

public record UserProfileUpdateRequest(string Nickname) : IHmsRequestBody
{
    public ErrorCodeEnum GetErrorCode()
    {
        return ErrorCodeEnum.UserError106;
    }
}