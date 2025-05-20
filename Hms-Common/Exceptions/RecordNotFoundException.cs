using Hms_Common.Enums;

namespace Hms_Common.Exceptions;

public class RecordNotFoundException(ErrorCodeEnum errorCodeEnum) : BusinessException(errorCodeEnum)
{
}