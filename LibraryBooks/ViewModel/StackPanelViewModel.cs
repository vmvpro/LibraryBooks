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
using LibraryBooksClient.Infrastructure;
using System.IO;
using System.Collections;
using System.Windows.Input;
using Microsoft.Win32;
using System.Windows;

namespace LibraryBooksClient.ViewModel
{
    public class StackPanelViewModel : ViewModelBase
    {
        private bool flagDataLoadDb = false;

        public LibraryContext Context { get; }

        public StackPanelViewModel()
        {
            IEnumerable<Book> books = null;

            ButtonCommand = new RelayCommand(voidInsertImage, boolInsertImage);

        }

        public RelayCommand ButtonCommand { get; }

        void voidInsertImage()
        {
            var opd = new OpenFileDialog();
            //opd.Multiselect = true;
            opd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (opd.ShowDialog() == true)
            {
               

                if (flagDataLoadDb)
                {
                    MessageBox.Show("fileName: " + opd.FileName);
                }
                else
                {

                }


            }
        }

        bool boolInsertImage()
        {
            return true;
        }

    }
}
