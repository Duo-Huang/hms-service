using System.Reflection;
using Hms.Service.Config;
using Microsoft.EntityFrameworkCore;

namespace Hms.Service.Extensions;

public static class SqlExecutorExtensions
{
    public static void ExecutePostMigrationSql(this AppDbContext context, string sqlFileName)
    {
        var sql = GetEmbeddedSql(sqlFileName);

        try
        {
            context.Database.ExecuteSqlRaw(sql);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Sql file {sqlFileName} failed to execute: {ex.Message}");
            throw;
        }
    }

    private static string GetEmbeddedSql(string resourceName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream == null)
            throw new Exception($"Sql file: {resourceName} not found.");

        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}