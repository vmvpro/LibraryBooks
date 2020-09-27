using LibraryBooksClient.LibraryDbContext;
using LibraryBooksClient.Migrations;
using LibraryBooksClient.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryBooksClient.View
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private LibraryContext Context { get; }

		public MainWindow()
		{
			InitializeComponent();
			Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LibraryContext>());

			Context = new LibraryContext();

			Fill(); // uncomment if you want to fill database with default values

			//ClientsTab.DataContext = new ClientsTabViewModel(Context);
			//RoomsTab.DataContext = new RoomsTabViewModel(Context);

		}

		private void Fill()
		{
			Context.Books.RemoveRange(Context.Books);

			Context.Books.AddRange(new List<Book>()
			{
				new Book() { Name = "CLR via C# .NET 4.5", Year=2012 },
				new Book() { Name = "VB 6.0 (Intuit)", Year=2010 }
			});

			Context.SaveChanges();
		}
	}
}
