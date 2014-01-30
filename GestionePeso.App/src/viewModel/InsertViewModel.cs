using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GestionePeso.App.Model;

namespace GestionePeso.App.ViewModel
{
    public class InsertViewModel : ViewModelBase
    {
        public event EventHandler InsertRequested;
        public event EventHandler CancelRequested;

        public Pesata Pesata { get; private set; }

        public RelayCommand OkCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }

        public InsertViewModel()
        {
            Pesata = new Pesata(DateTime.Now, 75);

            OkCommand = new RelayCommand(Insert, CanInsert);
            CancelCommand = new RelayCommand(Cancel, CanCancel);
        }

        private void Insert()
        {
            if (InsertRequested != null)
            {
                InsertRequested(this, new EventArgs());
            }
        }
        
        private void Cancel()
        {
            if (CancelRequested != null)
            {
                CancelRequested(this, new EventArgs());
            }
        }

        private bool CanInsert() { return true; }

        private bool CanCancel() { return true; }

    }
}
