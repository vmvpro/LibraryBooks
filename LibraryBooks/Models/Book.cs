using LibraryBooks.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LibraryBooks.Model
{
    public class Book : Notifier
    {

        private int _bookId;
        public int BookId
        {
            get { return _bookId; }
            set
            {
                if (value == _bookId) return;
                _bookId = value;
                OnPropertyChanged();
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value == name) return;
                name = value;
                OnPropertyChanged();
            }
        }

        private int? _year;
        public int? Year
        {
            get { return _year; }
            set
            {
                if (value == _year) return;
                _year = value;
                OnPropertyChanged();
            }
        }


        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (value == _description) return;
                _description = value;
                OnPropertyChanged();
            }
        }


        private Author _idAuthor;
        public Author IdAuthor
        {
            get { return _idAuthor; }
            set
            {
                if (value == _idAuthor) return;
                _idAuthor = value;
                OnPropertyChanged();
            }
        }

        private Subject _idSubject;
        public Subject IdSubject
        {
            get { return _idSubject; }
            set
            {
                if (value == _idSubject) return;
                _idSubject = value;
                OnPropertyChanged();
            }
        }


        private Image _image;
        public Image Image
        {
            get { return _image; }
            set
            {
                if (value == _image) return;
                _image = value;
                OnPropertyChanged();
            }
        }

        private string _tags;
        public string Tags
        {
            get { return _tags; }
            set
            {
                if (value == _tags) return;
                _tags = value;
                OnPropertyChanged();
            }
        }

    }
}
