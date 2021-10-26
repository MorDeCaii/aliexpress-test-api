using Categories.Core.Entities;
using FluentMigrator;

namespace Categories.DAL.Migrations
{
    [Migration(202110250002)]
    public class SeedData_202110250002 : Migration
    {
        public override void Down()
        {
            Delete.FromTable("categories").AllRows();
        }

        public override void Up()
        {
            Insert.IntoTable("categories")
                .Row(new
                {
                    Id = RawSql.Insert("DEFAULT"),
                    Name = "PC & Perepherals",
                    ParentId = 0
                });
            
            Insert.IntoTable("categories")
                .Row(new
                {
                    Id = RawSql.Insert("DEFAULT"),
                    Name = "Food",
                    ParentId = 0
                });
            
            Insert.IntoTable("categories")
                .Row(new
                {
                    Id = RawSql.Insert("DEFAULT"),
                    Name = "Monitors",
                    ParentId = 1
                });
            
            Insert.IntoTable("categories")
                .Row(new
                {
                    Id = RawSql.Insert("DEFAULT"),
                    Name = "Keyboards",
                    ParentId = 1
                });
            
            Insert.IntoTable("categories")
                .Row(new
                {
                    Id = RawSql.Insert("DEFAULT"),
                    Name = "Graphic cards",
                    ParentId = 1
                });
            
            Insert.IntoTable("categories")
                .Row(new
                {
                    Id = RawSql.Insert("DEFAULT"),
                    Name = "Standard",
                    ParentId = 3
                });
            
            Insert.IntoTable("categories")
                .Row(new
                {
                    Id = RawSql.Insert("DEFAULT"),
                    Name = "Ultrawide",
                    ParentId = 3
                });
            
            Insert.IntoTable("categories")
                .Row(new
                {
                    Id = RawSql.Insert("DEFAULT"),
                    Name = "Fruits & Vegegtables",
                    ParentId = 2
                });
            
            Insert.IntoTable("categories")
                .Row(new
                {
                    Id = RawSql.Insert("DEFAULT"),
                    Name = "Drinks",
                    ParentId = 2
                });
            
            Insert.IntoTable("categories")
                .Row(new
                {
                    Id = RawSql.Insert("DEFAULT"),
                    Name = "Toys",
                    ParentId = 0
                });
        }
    }
}