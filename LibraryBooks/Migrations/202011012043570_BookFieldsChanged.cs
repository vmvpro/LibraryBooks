namespace LibraryBooksClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookFieldsChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "image", c => c.Binary(storeType: "image"));
            AlterColumn("dbo.Books", "tags", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "tags", c => c.String(maxLength: 50));
            AlterColumn("dbo.Books", "image", c => c.Binary(maxLength: 8000, fixedLength: true));
        }
    }
}
