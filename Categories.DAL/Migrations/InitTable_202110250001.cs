using FluentMigrator;

namespace Categories.DAL.Migrations
{
    [Migration(202110250001)]
    public class InitTable_202110250001 : Migration
    {
        public override void Down()
        {
            Delete.Table("categories");
        }

        public override void Up()
        {
            Create.Table("categories")
                .WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString(100).NotNullable()
                .WithColumn("ParentId").AsInt64().NotNullable().WithDefaultValue(0);
        }
    }
}