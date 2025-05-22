using System.ComponentModel;
using Hms.Common.Attributes;

namespace Hms.Common.Enums;

public enum SystemRoleEnum
{
    [RoleMeta(RoleTypeEnum.SystemRole, "家庭管理员")]
    HomeAdmin = 0, 
    
    [RoleMeta(RoleTypeEnum.SystemRole, "家庭成员")]
    HomeMember = 1,
}