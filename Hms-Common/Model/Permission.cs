namespace Hms_Common.Model;

public class Permission : BaseModel
{
    public int PermissionId { get; set; }

    public string PermissionCode { get; set; }

    public string PermissionDescription { get; set; }
}