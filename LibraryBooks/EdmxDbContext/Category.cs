namespace LibraryBooksClient
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Subjects = new HashSet<Subject>();
        }

        [Key]
        public int category_id { get; set; }

        [Required]
        [StringLength(50)]
        public string category_name { get; set; }

        [StringLength(255)]
        public string comment { get; set; }

        public int? counter { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [NotMapped]
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
