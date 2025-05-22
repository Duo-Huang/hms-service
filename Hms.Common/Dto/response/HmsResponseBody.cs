using Hms.Common.Enums;
using Hms.Common.Extensions;

namespace Hms.Common.dto.response;

public record HmsResponseBody<T>(int Code, string? Message, T Data)
{
    public static HmsResponseBody<T?> Success(T? data = default)
    {
        return new HmsResponseBody<T?>(0, null, data);
    }

    public static HmsResponseBody<T?> Error(ErrorCodeEnum errorCodeEnum, T? data = default)
    {
        return new HmsResponseBody<T?>((int)errorCodeEnum, errorCodeEnum.GetMessage(), data);
    }

    public static HmsResponseBody<T?> Error(int code, string message, T? data = default)
    {
        return new HmsResponseBody<T?>(code, message, data);
    }
}