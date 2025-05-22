using Hms.Common.Enums;

namespace Hms.Common.Model;

public class SystemRole : BaseModel
{
    public required int RoleId { get; set; }

    public required RoleTypeEnum RoleType { get; set; }

    public required string RoleName { get; set; }

    public string RoleDescription { get; set; }

    public required List<Permission> Permissions { get; set; }
}
