using Hms.Common.Enums;

namespace Hms.Common.dto.request;

public interface IHmsRequestBody
{
    ErrorCodeEnum GetErrorCode();
}