using Hms.Common.Enums;
using Hms.Common.Extensions;

namespace Hms.Common.Exceptions;

public class RecordNotFoundException(ErrorCodeEnum errorCodeEnum) : BusinessException(errorCodeEnum)
{
}