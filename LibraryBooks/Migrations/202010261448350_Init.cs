namespace LibraryBooksClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        author_id = c.Int(nullable: false, identity: true),
                        first_name = c.String(maxLength: 50),
                        last_name = c.String(maxLength: 50),
                        comment = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.author_id)
                .Index(t => new { t.first_name, t.last_name }, unique: true, name: "ix_AutorFullName");
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        book_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50),
                        year = c.Int(),
                        description = c.String(),
                        id_author = c.Int(),
                        id_subject = c.Int(),
                        image = c.Binary(maxLength: 8000, fixedLength: true),
                        tags = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.book_id)
                .ForeignKey("dbo.Subjects", t => t.id_subject)
                .ForeignKey("dbo.Authors", t => t.id_author)
                .Index(t => t.id_author, name: "IX_IdAuthor")
                .Index(t => t.id_subject, name: "IX_IdSubject");
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        subject_id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 50),
                        id_category = c.Int(),
                        comment = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.subject_id)
                .ForeignKey("dbo.Categories", t => t.id_category)
                .Index(t => t.id_category, name: "IX_IdCategory");
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        category_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50),
                        comment = c.String(maxLength: 255),
                        counter = c.Int(),
                    })
                .PrimaryKey(t => t.category_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "id_author", "dbo.Authors");
            DropForeignKey("dbo.Subjects", "id_category", "dbo.Categories");
            DropForeignKey("dbo.Books", "id_subject", "dbo.Subjects");
            DropIndex("dbo.Subjects", "IX_IdCategory");
            DropIndex("dbo.Books", "IX_IdSubject");
            DropIndex("dbo.Books", "IX_IdAuthor");
            DropIndex("dbo.Authors", "ix_AutorFullName");
            DropTable("dbo.Categories");
            DropTable("dbo.Subjects");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
