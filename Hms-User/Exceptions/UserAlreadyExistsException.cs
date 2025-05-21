using Hms_Common.Enums;
using Hms_Common.Exceptions;

namespace Hms_User.Exceptions;

public class UserAlreadyExistsException() : BusinessException(ErrorCodeEnum.UserError103)
{
}