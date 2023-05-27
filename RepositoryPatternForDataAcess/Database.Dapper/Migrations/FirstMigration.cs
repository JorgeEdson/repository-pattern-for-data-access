using FluentMigrator;
namespace Database.Dapper.Migrations
{
    [Migration(1)]
    public class FirstMigration : Migration
    {
        public override void Up()
        {
            Create.Table("MainEntities")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("SpecificProperty").AsInt32().NotNullable()
                .WithColumn("SecondEntityId").AsGuid()
                .WithColumn("ThirdEntityId").AsGuid();

            Create.Table("SecondEntities")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable()
                .WithColumn("SpecificProperty").AsString().NotNullable()
                .WithColumn("MainEntityId").AsGuid().ForeignKey("MainEntities", "Id");

            Create.Table("ThirdEntities")
              .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
              .WithColumn("Name").AsString(50).NotNullable()
              .WithColumn("CreationDate").AsDateTime().NotNullable()
              .WithColumn("SpecificProperty").AsDecimal().NotNullable();

            Create.ForeignKey("ForeignKey_MainEntities_SecondEntities")
                .FromTable("MainEntities")
                .ForeignColumn("SecondEntityId")
                .ToTable("SecondEntities")
                .PrimaryColumn("Id");

            Create.ForeignKey("ForeignKey_MainEntities_ThirdEntities")
                .FromTable("MainEntities")
                .ForeignColumn("ThirdEntityId")
                .ToTable("ThirdEntities")
                .PrimaryColumn("Id");

            Create.Table("FourthEntities")
             .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
             .WithColumn("Name").AsString(50).NotNullable()
             .WithColumn("CreationDate").AsDateTime().NotNullable()
             .WithColumn("SpecificProperty").AsByte().NotNullable();

            Create.Table("MainFourthEntities")
             .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
             .WithColumn("SpecificProperty").AsBoolean().NotNullable()
             .WithColumn("MainEntityId").AsGuid().ForeignKey("MainEntities", "Id")
             .WithColumn("FourthEntityId").AsGuid().ForeignKey("FourthEntities", "Id");
        }

        public override void Down()
        {
            Delete.Table("MainFourthEntities");
            Delete.Table("ThirdEntities");
            Delete.Table("FourthEntities");
            Delete.Table("SecondEntities");
            Delete.Table("MainEntities");
        }
    }
}
