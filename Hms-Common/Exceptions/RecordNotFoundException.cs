using Hms_Common.Enums;
using Hms_Common.Extensions;

namespace Hms_Common.Exceptions;

public class RecordNotFoundException(ErrorCodeEnum errorCodeEnum) : BusinessException(errorCodeEnum)
{
}