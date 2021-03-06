﻿using LibraryBooksClient.LibraryDbContext;
using LibraryBooksClient.Model;
using LibraryBooksClient.ViewModel;
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
        private LibraryContext Context { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Context = new LibraryContext();

            lstListBooks.DataContext = new ListBooksViewModel(Context, ref lstListBooks, ref imgSelected);

            //Fill(); 

        }

        private void Fill()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LibraryContext>());
            
            var Context = new LibraryContext();

            Context.Books.RemoveRange(Context.Books);
			Context.Authors.RemoveRange(Context.Authors);
			Context.Subjects.RemoveRange(Context.Subjects);
			Context.Categories.RemoveRange(Context.Categories);

			List<Book> listBook = new List<Book>()
            {
                new Book() { Name = "CLR via C# .NET 4.5", Year=2012 },
                new Book() { Name = "VB 6.0 (Intuit)", Year=2010 }
            };

            var category = new Category() { Name = "Programming" };

            Context.Books.AddRange(new List<Book>()
            {
                new Book()
                {
                    Name = "CLR via C# .NET 4.5", Year=2012,
                    Author = new Author() { FirstName = "Дж.", LastName = "Рихтер"},
                    Subject = new Subject() 
                    { 
                        Name = "C#",
                        Category = category
                    }
                },
                new Book() 
                { 
                    Name = "VB 6.0 (Intuit)", Year=2010,
                    Author = new Author() { FirstName = "Школа", LastName = "Интуит"},
                    Subject = new Subject() 
                    { 
                        Name = "VB 6.0",
                        Category = category
                    }
                }
            });

            Context.SaveChanges();

            return;

            Context.Authors.AddRange(new List<Author>()
            {
                //new Author() { FirstName = "Дж.", LastName = "Рихтер"},
                
            });

            Context.Subjects.AddRange(new List<Subject>()
            {
                new Subject() { Name = "C#" },
                new Subject() { Name = "VB 6.0"}
            });

            Context.Categories.AddRange(new List<Category>()
            {
                new Category() { Name = "Programming" },
                new Category() { Name = "Other"}
            });

            Context.SaveChanges();
        }

        private void lstListBooks_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Hello!");

        }
    }
}
