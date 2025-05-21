using Hms_Common.Enums;
using Hms_Common.Exceptions;

namespace Hms_User.Exceptions;

public class DuplicatedPasswordException() : BusinessException(ErrorCodeEnum.UserError109);