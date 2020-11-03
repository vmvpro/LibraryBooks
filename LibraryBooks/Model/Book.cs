using LibraryBooksClient.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LibraryBooksClient.Model
{
    public class Book 
    {

        public int BookId { get; set; }

        public string Name { get; set; }

        public int? Year { get; set; }

        public string Description { get; set; }

        public int? IdAuthor { get; set; }
        public virtual Author Author { get; set; }

        public int? IdSubject { get; set; }
        public virtual Subject Subject { get; set; }

        public string Link { get; set; }

        public byte[] Image { get; set; }

        public string Tags { get; set; }

    }
}
