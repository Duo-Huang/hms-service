using Hms.Common.Enums;

namespace Hms.Common.Exceptions;

public abstract class BusinessException(ErrorCodeEnum errorCodeEnum) : Exception
{
    protected ErrorCodeEnum ErrorCodeEnum { get; init; } = errorCodeEnum;
}