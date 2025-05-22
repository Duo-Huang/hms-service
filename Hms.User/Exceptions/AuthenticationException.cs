using Hms.Common.Enums;
using Hms.Common.Exceptions;

namespace Hms.User.Exceptions;

public class AuthenticationException() : BusinessException(ErrorCodeEnum.UserError101);