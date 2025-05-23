using System.Text;
using Hms.Common.Dao;
using Hms.Common.Dao.Entity;
using Hms.User.Dao.Entity;
using Microsoft.EntityFrameworkCore;

namespace Hms.Service.Config;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IAppDbContext<UserEntity>
{
    public DbSet<UserEntity> Users { get; set; }

    DbSet<UserEntity> IAppDbContext<UserEntity>.Entity
    {
        get => Users;
        set => Users = value;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.HasDefaultSchema("hms_schema");

        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            // 设置表名
            entity.SetTableName(ToSnakeCase(entity.GetTableName()));
            
            var clrType = entity.ClrType;

            if (typeof(BaseEntity).IsAssignableFrom(clrType))
            {
                // 获取对应的实体类型构建器
                var entityBuilder = modelBuilder.Entity(clrType);

                // 统一配置，比如设置默认值
                entityBuilder.Property(nameof(BaseEntity.CreatedAt))
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAdd();
                entityBuilder.Property(nameof(BaseEntity.UpdatedAt))
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAddOrUpdate();
            }
    
            foreach (var property in entity.GetProperties())
            {
                // 转换属性名为 snake_case
                var snakeCaseName = ToSnakeCase(property.Name);
                property.SetColumnName(snakeCaseName);
            }
        }
    }
    
    private static string? ToSnakeCase(string? input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        var stringBuilder = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            var c = input[i];
            if (char.IsUpper(c))
            {
                // 添加下划线（除非是第一个字符）
                if (i > 0)
                    stringBuilder.Append('_');
                stringBuilder.Append(char.ToLower(c));
            }
            else
            {
                stringBuilder.Append(c);
            }
        }
        return stringBuilder.ToString();
    }
}