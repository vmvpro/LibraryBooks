namespace LibraryBooksClient.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "id_author", "dbo.Authors");
            DropIndex("dbo.Authors", "ix_AutorFullName");
            DropPrimaryKey("dbo.Authors");
            AlterColumn("dbo.Authors", "author_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Authors", "first_name", c => c.String(nullable: false, maxLength: 50,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "defaultValue",
                        new AnnotationValues(oldValue: "", newValue: "System.Data.Entity.Infrastructure.Annotations.AnnotationValues")
                    },
                }));
            AddPrimaryKey("dbo.Authors", "author_id");
            CreateIndex("dbo.Authors", new[] { "first_name", "last_name" }, unique: true, name: "ix_AutorFullName");
            AddForeignKey("dbo.Books", "id_author", "dbo.Authors", "author_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "id_author", "dbo.Authors");
            DropIndex("dbo.Authors", "ix_AutorFullName");
            DropPrimaryKey("dbo.Authors");
            AlterColumn("dbo.Authors", "first_name", c => c.String(maxLength: 50,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "defaultValue",
                        new AnnotationValues(oldValue: "System.Data.Entity.Infrastructure.Annotations.AnnotationValues", newValue: "")
                    },
                }));
            AlterColumn("dbo.Authors", "author_id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Authors", "author_id");
            CreateIndex("dbo.Authors", new[] { "first_name", "last_name" }, unique: true, name: "ix_AutorFullName");
            AddForeignKey("dbo.Books", "id_author", "dbo.Authors", "author_id");
        }
    }
}
