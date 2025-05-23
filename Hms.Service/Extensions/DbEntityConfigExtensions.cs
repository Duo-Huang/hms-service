using Hms.Common.Dao;
using Hms.Service.Config;
using Hms.User.Dao.Entity;

namespace Hms.Service.Extensions;

public static class DbEntityConfigExtensions
{
    public static void AddEntities(this IServiceCollection services)
    {
        services.AddScoped<IAppDbContext<UserEntity>, AppDbContext>();
    }
}