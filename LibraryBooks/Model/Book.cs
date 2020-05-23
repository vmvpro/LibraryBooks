using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.Model
{
    public class Book
    {
	    public int BookId { get; set; }
	    public string Name { get; set; }
	    public int Year { get; set; }
	    public string Description { get; set; }
	    public Author IdAuthor { get; set; }
	    public Subject IdSubject { get; set; }
		public byte Image { get; set; }
	    public string Tags { get; set; }

	}
}
