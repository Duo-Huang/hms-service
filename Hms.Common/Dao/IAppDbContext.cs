using Microsoft.EntityFrameworkCore;

namespace Hms.Common.Dao;

public interface IAppDbContext<TEntity> where TEntity : class
{
    DbSet<TEntity> Entity { get; set; }
}