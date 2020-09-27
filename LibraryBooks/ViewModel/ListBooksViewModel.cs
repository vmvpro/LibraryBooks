using LibraryBooksClient.LibraryDbContext;
using LibraryBooksClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace LibraryBooksClient.ViewModels
{
    public class ListBooksViewModel: ViewModelBase
    {
        List<Book> listSelectionWork;
        private LibraryContext Context { get; }
        public ListBooksViewModel(LibraryContext context)
        {
            Context = context;
            //listSelectionWork = context.Books.ToList();
        }

        public List<Book> Books { get; } = new List<Book>();




    }
}
