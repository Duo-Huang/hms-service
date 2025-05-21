using System.ComponentModel;
using Hms_Common.Attributes;

namespace Hms_Common.Enums;

public enum SystemRoleEnum
{
    [RoleMeta(RoleTypeEnum.SystemRole, "家庭管理员")]
    HomeAdmin = 0, 
    
    [RoleMeta(RoleTypeEnum.SystemRole, "家庭成员")]
    HomeMember = 1,
}