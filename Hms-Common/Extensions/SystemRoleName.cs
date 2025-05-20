using Hms_Common.Enums;

namespace Hms_Common.Extensions;

public static class SystemRoleName
{
    private static readonly Dictionary<SystemRole, string> ErrorMessagesMap = new()
    {
        { SystemRole.HomeAdmin, "家庭管理员" },
        { SystemRole.HomeMember, "家庭成员" },
    };

    public static string GetRoleName(SystemRole systemRole)
    {
        return ErrorMessagesMap.GetValueOrDefault(systemRole, "未知角色");
    }
}