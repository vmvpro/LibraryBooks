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
                        AuthorId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Year = c.Int(),
                        Description = c.String(),
                        Tags = c.String(),
                        IdAuthor_AuthorId = c.Int(nullable: false),
                        Subject_SubjectId = c.Int(),
                        IdSubject_SubjectId = c.Int(),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Authors", t => t.IdAuthor_AuthorId)
                .ForeignKey("dbo.Subjects", t => t.Subject_SubjectId)
                .ForeignKey("dbo.Subjects", t => t.IdSubject_SubjectId)
                .Index(t => t.IdAuthor_AuthorId)
                .Index(t => t.Subject_SubjectId)
                .Index(t => t.IdSubject_SubjectId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        IdCategory_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.SubjectId)
                .ForeignKey("dbo.Categories", t => t.IdCategory_CategoryId)
                .Index(t => t.IdCategory_CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "IdSubject_SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "IdCategory_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Books", "Subject_SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Books", "IdAuthor_AuthorId", "dbo.Authors");
            DropIndex("dbo.Subjects", new[] { "IdCategory_CategoryId" });
            DropIndex("dbo.Books", new[] { "IdSubject_SubjectId" });
            DropIndex("dbo.Books", new[] { "Subject_SubjectId" });
            DropIndex("dbo.Books", new[] { "IdAuthor_AuthorId" });
            DropTable("dbo.Categories");
            DropTable("dbo.Subjects");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
