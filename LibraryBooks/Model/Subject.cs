using LibraryBooksClient.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooksClient.Model
{
    public class Subject 
    {
        public Subject()
        {
            Books = new HashSet<Book>();
        }

        public int SubjectId { get; set; }

        public string Name { get; set; }

        public int? IdCategory { get; set; }

        public string Comment { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public virtual Category Category { get; set; }

    }
}
