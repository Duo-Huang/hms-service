using Hms.Common.Config;
using Hms.Service.Config;
using Hms.Service.Extensions;
using Hms.User.Dao.Entity;
using Microsoft.EntityFrameworkCore;

namespace Hms.Service;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.Configure<AppConfig>(builder.Configuration.GetSection(nameof(AppConfig)));
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("RuntimeConnection")));


        // 注册DBContext接口实现,子项目只能通过接口访问
        builder.Services.AddEntities();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            var factory = new DesignDbContext();
            using (var dbContext = factory.CreateDbContext([]))
            {
                dbContext.Database.Migrate();
                dbContext.ExecutePostMigrationSql("Hms.Service.Migrations.Scripts.create-trigger-to-all-tables.sql");

                dbContext.Users.Add(new UserEntity()
                {
                    Username = "hahaha",
                    Password = "12345435"
                });

                dbContext.SaveChanges();
            }


            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}