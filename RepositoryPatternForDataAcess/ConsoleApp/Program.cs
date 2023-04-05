// See https://aka.ms/new-console-template for more information
using Database.Dapper;
var context = new DapperContext("ExampleWithDapperDb");
context.ApplyMigrations();


