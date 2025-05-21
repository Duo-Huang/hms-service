using Hms_Common.Enums;

namespace Hms_Common.Exceptions;

public abstract class BusinessException(ErrorCodeEnum errorCodeEnum) : Exception
{
    protected ErrorCodeEnum ErrorCodeEnum { get; init; } = errorCodeEnum;
}