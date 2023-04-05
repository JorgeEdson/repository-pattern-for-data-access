using Dapper;
using Database.Dapper.Migrations;
using FluentMigrator.Runner;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Reflection;

namespace Database.Dapper
{
    public  class DapperContext
    {
        private IDbConnection CreateConnection()
            => new SqlConnection(ConnectionStrings.SQL_CONNECTION);

        private IDbConnection CreateMasterConnection()
            => new SqlConnection(ConnectionStrings.MASTER_CONNECTION);

        public DapperContext(string paramNameDatabase)
        {
            CreateDatabase(paramNameDatabase);
        }

        private  void CreateDatabase(string paramNameDatabase)
        {            
            try
            {
                var query = "SELECT * FROM sys.databases WHERE name = @name";
                var parameters = new DynamicParameters();
                parameters.Add("name", paramNameDatabase);
                using (var connection = CreateMasterConnection())
                {
                    var records = connection.Query(query, parameters);
                    if (!records.Any())
                        connection.Execute($"CREATE DATABASE {paramNameDatabase}");
                }                
            }
            catch
            {                
                throw;
            }
        }

        public void ApplyMigrations() 
        {
            using (var serviceProvider = CreateServices())
            using (var scope = serviceProvider.CreateScope())
            {
                
                UpdateDatabase(scope.ServiceProvider);
            }
        }

        private static ServiceProvider CreateServices()
        {
            return new ServiceCollection()
                
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb                    
                    .AddSqlServer()                    
                    .WithGlobalConnectionString(ConnectionStrings.SQL_CONNECTION)                    
                    .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())                
                .AddLogging(lb => lb.AddFluentMigratorConsole())                
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {            
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();            
            runner.ListMigrations();
            runner.MigrateUp();
        }        

    }
}
