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
            FirstName = "";
            LastName = "";

        }

        public int AuthorId { get; set; }

        public string FirstName { get; set; } // = "";

        public string LastName { get; set; } // = "";

        public virtual string FullName
        {
            get
            {
                if (!String.IsNullOrEmpty(FirstName))
                {

                }

                if (!String.IsNullOrEmpty(LastName))
                {

                }

                return "";
            }
        }

        public string Comment { get; set; }

        //public virtual Book Book { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
