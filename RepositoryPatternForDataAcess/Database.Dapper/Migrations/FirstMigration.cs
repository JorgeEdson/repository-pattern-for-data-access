using FluentMigrator;

namespace Database.Dapper.Migrations
{
    [Migration(1)]
    public class FirstMigration : Migration
    {
        public override void Down()
        {
            Delete.Table("MainEntities");
        }

        public override void Up()
        {
            Create.Table("MainEntities")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable();
        }
    }
}
