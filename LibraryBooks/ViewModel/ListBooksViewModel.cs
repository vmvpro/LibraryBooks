using LibraryBooksClient.LibraryDbContext;
using LibraryBooksClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace LibraryBooksClient.ViewModel
{
    public class ListBooksViewModel : ViewModelBase
    {
        public LibraryContext Context { get; }
        public ObservableCollection<Book> Books { get; }

		public ListBooksViewModel()
		{
			Context = new LibraryContext();

			Books = new ObservableCollection<Book>(Context.Books);
			BindingOperations.EnableCollectionSynchronization(Books, new object());
			BooksView = CollectionViewSource.GetDefaultView(Books);
			BooksView.GroupDescriptions.Add(new PropertyGroupDescription("Subject.Category.Name"));
		}
		public ListBooksViewModel(LibraryContext context)
		{
			Context = context;
		}

		//public List<Book> Books => Context.Books.ToList();

		public ICollectionView BooksView { get; set; }

    }
}
