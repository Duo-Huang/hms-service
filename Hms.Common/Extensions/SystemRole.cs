using System.Reflection;
using Hms.Common.Attributes;
using Hms.Common.Enums;

namespace Hms.Common.Extensions;

public static class SystemRole
{
    public static RoleTypeEnum GetRoleType(this SystemRoleEnum systemRoleEnum) => GetRoleMeta(systemRoleEnum).RoleType;

    public static string GetRoleName(this SystemRoleEnum systemRoleEnum) => GetRoleMeta(systemRoleEnum).RoleName;

    private static RoleMetaAttribute GetRoleMeta(SystemRoleEnum systemRoleEnum)
    {
        if (typeof(SystemRoleEnum).GetField(systemRoleEnum.ToString())?.GetCustomAttribute<RoleMetaAttribute>() is
            { } roleMetaAttribute)
        {
            return roleMetaAttribute;
        }

        throw new ArgumentException("Invalid SystemRoleEnum value");
    }
}