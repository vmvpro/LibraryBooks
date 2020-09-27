using LibraryBooksClient.LibraryDbContext;
using LibraryBooksClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace LibraryBooksClient.ViewModel
{
    public class ListBooksViewModel : ViewModelBase
    {
        public LibraryContext Context { get; }

        public ListBooksViewModel()
        { }
        public ListBooksViewModel(LibraryContext context)
        {
            Context = context;
        }

        public List<Book> Books => Context.Books.ToList();



    }
}
