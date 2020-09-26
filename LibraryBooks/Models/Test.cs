using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooksClient.Model
{
    public class Student
    {
	    public int StudentId { get; set; }
	    public string Name { get; set; }

		// Ссылка на классы
		public Grade Grade { get; set; }
	}

	public class Grade
	{
		public int GradeId { get; set; }
		public string Name { get; set; }

		// Ссылка на студента
		public ICollection<Student> Students { get; set; }

		
	}


}
