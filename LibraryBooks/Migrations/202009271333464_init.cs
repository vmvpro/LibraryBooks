namespace LibraryBooksClient.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "first_name", c => c.String(maxLength: 50,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "annotationIx",
                        new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { Name: IX_FullName, Order: 1, IsClustered: False, IsUnique: True }")
                    },
                    { 
                        "IX_FullName",
                        new AnnotationValues(oldValue: "{ Order: 1, IsUnique: True }", newValue: null)
                    },
                }));
            AlterColumn("dbo.Authors", "last_name", c => c.String(maxLength: 50,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "annotationIx",
                        new AnnotationValues(oldValue: null, newValue: "IndexAnnotation: { Name: IX_FullName, Order: 2, IsClustered: False, IsUnique: True }")
                    },
                    { 
                        "IX_FullName",
                        new AnnotationValues(oldValue: "{ Order: 2, IsUnique: True }", newValue: null)
                    },
                }));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "last_name", c => c.String(maxLength: 50,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "annotationIx",
                        new AnnotationValues(oldValue: "IndexAnnotation: { Name: IX_FullName, Order: 2, IsClustered: False, IsUnique: True }", newValue: null)
                    },
                    { 
                        "IX_FullName",
                        new AnnotationValues(oldValue: null, newValue: "{ Order: 2, IsUnique: True }")
                    },
                }));
            AlterColumn("dbo.Authors", "first_name", c => c.String(maxLength: 50,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "annotationIx",
                        new AnnotationValues(oldValue: "IndexAnnotation: { Name: IX_FullName, Order: 1, IsClustered: False, IsUnique: True }", newValue: null)
                    },
                    { 
                        "IX_FullName",
                        new AnnotationValues(oldValue: null, newValue: "{ Order: 1, IsUnique: True }")
                    },
                }));
        }
    }
}
