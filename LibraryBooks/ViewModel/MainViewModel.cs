using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LibraryBooksClient.Infrastructure;
using LibraryBooksClient.LibraryDbContext;
using LibraryBooksClient.Model;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace LibraryBooksClient.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        private bool flagDataLoadDb = false;

        public LibraryContext Context { get; set; }
        public ListBox listBox { get; set; }

        //public Book SelectedBook { get; set; }

        private Book _selectedBook;
        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Book> Books { get; set; }

        public MainViewModel()
        {
            IEnumerable<Book> books = null;

            //InsertImageCommand = new RelayCommand(voidInsertImage, boolInsertImage);

            #region InsertCommand

            Fill();
            books = ListBook;

            #endregion

            //if (flagDataLoadDb)

            //{
            //    Context = new LibraryContext();
            //    books = new ObservableCollection<Book>(Context.Books);
            //}
            //else
            //{

            //}

            //--------------------------------------------------------

            Books = new ObservableCollection<Book>(books);
            BindingOperations.EnableCollectionSynchronization(Books, new object());
            BooksView = CollectionViewSource.GetDefaultView(Books);
            BooksView.GroupDescriptions.Add(new PropertyGroupDescription("Subject.Category.Name"));

            SelectedBook = (Book)BooksView.CurrentItem;
        }

        public MainViewModel(LibraryContext context, ref ListBox lstListBooks, ref Image image)
        {
            Context = context;
            listBox = lstListBooks;
            //_image = image;

            //listBox.SelectedIndex = 1;

            var items = listBox.SelectedItems.Cast<IEnumerable>();

            Books = new ObservableCollection<Book>(Context.Books);
            BindingOperations.EnableCollectionSynchronization(Books, new Book());
            BooksView = CollectionViewSource.GetDefaultView(Books);
            BooksView.GroupDescriptions.Add(new PropertyGroupDescription("Subject.Category.Name"));

            BooksView.CurrentChanged += BooksView_CurrentChanged;
            BooksView.CollectionChanged += BooksView_CollectionChanged;

            InsertImageCommand = new RelayCommand<Book>(voidInsertImage, boolInsertImage());
            UpdateCommand = new RelayCommand(voidUpdate, boolInsertImage());

            //SelectedBook = Context.Books.FirstOrDefault(book => book.BookId == ((Book)BooksView.CurrentItem).BookId);
            SelectedBook = (Book)BooksView.CurrentItem;



        }

        private void BooksView_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

            //var obj = (Book)sender;
        }

        private void BooksView_CurrentChanged(object sender, EventArgs e)
        {
            //listBox.SelectedIndex = BooksView.CurrentPosition;
            //var obj = (Book)sender;
            //throw new NotImplementedException();

        }

        public RelayCommand<Book> InsertImageCommand { get; }


        void voidInsertImage(Book item)
        {
            listBox.SelectedItem = item;

            //SelectedBook = item;
            //_selectedBook = BooksView.CollectionChanged

            //var yyy = listBo

            //BooksView. = (object)item;
            SelectedBook = item;

            var opd = new OpenFileDialog();

            //opd.Multiselect = true;
            opd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (opd.ShowDialog() == true)
            {
                //Context.Books.Add(new Book() { BookId = 3, Name = "vmv" });

                //Context.Books.Find(SelectedBook.BookId).Tags = "vmv";
                SelectedBook.Image = ConvertImage.ImageToBytes(opd.FileName);
                //Image.Source = ConvertImage.BytesToImageSource(SelectedBook.Image);
                //SelectedBook.Tags = opd.FileName;

                Context.SaveChanges();

                BooksView.Refresh();


            }
        }

        bool boolInsertImage()
        {
            //return true;
            //return SelectedBook == null ? false : true;
            return _selectedBook == null ? false : true;
        }

        public RelayCommand UpdateCommand { get; }

        void voidUpdate()
        {
            var item = (Book)listBox.SelectedItem;
            SelectedBook = item;

            //Context.Books.Add(new Book() { BookId = 3, Name = "vmv" });

            //Context.Books.Find(SelectedBook.BookId).Tags = "vmv";
            //SelectedBook.Name = item.Name;

            //SelectedBook.Tags = opd.FileName;

            Context.SaveChanges();

            BooksView.Refresh();



        }


        //public List<Book> Books => Context.Books.ToList();
        public IEnumerable<Book> ItemsSourceBook => Context.Books;

        public ICollectionView BooksView { get; set; }

        public List<Book> ListBook { get; set; }

        private void Fill()
        {
            var category = new Category() { Name = "Programming" };

            ListBook = new List<Book>();

            var pathImage =
                    Path.GetFullPath(
                        Path.Combine(@"D:\Doc\Work\1_MyApplication\LibraryBooks\LibraryBooks\Converters", @"01_sunset_long.jpg"));


            ListBook.AddRange(new List<Book>()
            {
                new Book()
                {
                    Name = "CLR via C# .NET 4.5", Year=2012,
                    Author = new Author() { FirstName = "Дж.", LastName = "Рихтер"},
                    Subject = new Subject()
                    {
                        Name = "C#",
                        Category = category
                    },

                    Image = ConvertImage.ImageToBytes(pathImage)
                },
                new Book()
                {
                    Name = "VB 6.0 (Intuit)", Year=2010,
                    Author = new Author() { FirstName = "Школа", LastName = "Интуит"},
                    Subject = new Subject()
                    {
                        Name = "VB 6.0",
                        Category = category
                    },

                    Image = ConvertImage.ImageToBytes(pathImage)


                },

                new Book()
                {
                    Name = "Самое длинное название новой книги", Year=2010,
                    Author = new Author()
                    {
                        FirstName = "Неизвестное имя автора",
                        LastName = "Неизвестная фамилия автора"
                    },
                    Subject = new Subject()
                    {
                        Name = "Кулинария",
                        Category = new Category(){ Name = "Others"}
                    },

                    Image = ConvertImage.ImageToBytes(pathImage)


                }
            });

        }

    }
}