﻿using FluentMigrator;

namespace Database.Dapper.Migrations
{
    [Migration(1)]
    public class FirstMigration : Migration
    {
        public override void Down()
        {
            Delete.Table("ConcreteEntities");
        }

        public override void Up()
        {
            Create.Table("ConcreteEntities")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable();
        }
    }
}
