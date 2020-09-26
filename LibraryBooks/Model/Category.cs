using LibraryBooksClient.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooksClient.Model
{
    public class Category 
    {
        public Category()
        {
            Subjects = new HashSet<Subject>();
        }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public int? Counter { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
