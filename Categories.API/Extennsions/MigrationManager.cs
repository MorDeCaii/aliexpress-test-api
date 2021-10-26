using Categories.DAL.Migrations;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Categories.API.Extennsions
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var databaseService = scope.ServiceProvider.GetRequiredService<Database>();
                var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
                try
                {
                    databaseService.EnsureDatabase("postgres");
                    migrationService.ListMigrations();
                    migrationService.MigrateUp();
                }
                catch
                {
                    throw;
                }
            }
            return host;
        }
    }
}