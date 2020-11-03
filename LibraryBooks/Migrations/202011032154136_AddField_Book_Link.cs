namespace LibraryBooksClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddField_Book_Link : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "link", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "link");
        }
    }
}
