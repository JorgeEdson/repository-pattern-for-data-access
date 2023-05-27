using Database.Dapper;
var context = new DapperContext("ExampleWithDapperDb");
context.ApplyMigrations();


