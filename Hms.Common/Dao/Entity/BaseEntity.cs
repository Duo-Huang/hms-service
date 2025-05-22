namespace Hms.Common.Dao.Entity;

public class BaseEntity
{
    public required DateTime CreateAt { get; set; }

    public required DateTime UpdateAt { get; set; }
}