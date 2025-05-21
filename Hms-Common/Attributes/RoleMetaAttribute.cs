using Hms_Common.Enums;

namespace Hms_Common.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class RoleMetaAttribute(RoleTypeEnum roleType, string roleName) : Attribute
{
    public RoleTypeEnum RoleType { get; } = roleType;
    public string RoleName { get; } = roleName;
}