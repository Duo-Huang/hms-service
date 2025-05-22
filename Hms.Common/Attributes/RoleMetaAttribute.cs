using Hms.Common.Enums;

namespace Hms.Common.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class RoleMetaAttribute(RoleTypeEnum roleType, string roleName) : Attribute
{
    public RoleTypeEnum RoleType { get; } = roleType;
    public string RoleName { get; } = roleName;
}