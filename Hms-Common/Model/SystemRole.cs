using Hms_Common.Enums;

namespace Hms_Common.Model;

public class SystemRole
{
    public int RoleId { get; set; }

    public RoleTypeEnum RoleType { get; set; }

    public string RoleName { get; set; }

    public string RoleDescription { get; set; }

    public List<Permission> Permissions { get; set; }
}