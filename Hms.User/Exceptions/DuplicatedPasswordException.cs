using Hms.Common.Enums;
using Hms.Common.Exceptions;

namespace Hms.User.Exceptions;

public class DuplicatedPasswordException() : BusinessException(ErrorCodeEnum.UserError109);