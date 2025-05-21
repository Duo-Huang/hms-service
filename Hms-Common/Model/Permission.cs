namespace Hms_Common.Model;

public class Permission : BaseModel
{
    public required int PermissionId { get; set; }

    public required string PermissionCode { get; set; }

    public string PermissionDescription { get; set; }
}