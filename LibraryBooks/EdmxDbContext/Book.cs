namespace LibraryBooksClient
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [Key]
        public int book_id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        public int? year { get; set; }

        public int? id_author { get; set; }

        public int? id_subject { get; set; }

        [Column(TypeName = "image")]
        public byte[] image { get; set; }

        [StringLength(255)]
        public string link { get; set; }

        [StringLength(255)]
        public string tags { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        public int? counter { get; set; }

        public virtual Author Author { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
