using LibraryBooksClient.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooksClient.Model
{
    public class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int AuthorId { get; set; }

        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public string Comment { get; set; }

        //public virtual Book Book { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
