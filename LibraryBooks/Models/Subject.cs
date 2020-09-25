using LibraryBooks.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBooks.Model
{
    public class Subject : Notifier
    {

        private int _subjectId;

        public int SubjectId
        {
            get { return _subjectId; }
            set
            {
                if (value == _subjectId) return;
                _subjectId = value;
                OnPropertyChanged();
            }
        }


        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }


        private Category _idCategory;

        public Category IdCategory
        {
            get { return _idCategory; }
            set
            {
                if (value == _idCategory) return;
                _idCategory = value;
                OnPropertyChanged();
            }
        }

    }
}
