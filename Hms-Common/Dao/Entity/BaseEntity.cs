namespace Hms_Common.Dao.Entity;

public class BaseEntity
{
    protected BaseEntity()
    {
    }

    protected BaseEntity(DateTime createAt, DateTime updateAt)
    {
        CreateAt = createAt;
        UpdateAt = updateAt;
    }

    public DateTime CreateAt { get; set; }

    public DateTime UpdateAt { get; set; }
}