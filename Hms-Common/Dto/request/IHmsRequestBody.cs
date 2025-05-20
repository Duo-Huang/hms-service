using Hms_Common.Enums;

namespace Hms_Common.dto.request;

public interface IHmsRequestBody
{
    ErrorCodeEnum GetErrorCode();
}