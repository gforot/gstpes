using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GestionePeso.App.Model;

namespace GestionePeso.App.ViewModel
{
    public class CloseEditUserEventArgs : EventArgs
    {
        public bool Confirm { get; private set; }

        public CloseEditUserEventArgs(bool confirm)
            : base()
        {
            Confirm = confirm;
        }
    }

    public class EditUserViewModel : ViewModelBase
    {
        public event EventHandler CloseRequested;

        public User User { get; set; }

        public RelayCommand OkCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }

        public EditUserViewModel()
        {
            OkCommand = new RelayCommand(Confirm);
            CancelCommand = new RelayCommand(Cancel, CanCancel);

            if (App.User == null)
            {
                User = new User();
                User.Username = "username1";
            }
            else
            {
                User = App.User.Clone();
            }
        }

        private void Confirm()
        {
            App.User = new User(User.Username, User.Age, User.Gender, User.Altezza);
            Close(true);
        }

        private bool CanCancel()
        {
            return App.User != null;
        }

        private void Cancel()
        {
            Close(false);
        }

        private void Close(bool confirm)
        {
            if (CloseRequested != null)
            {
                CloseRequested(this, new CloseEditUserEventArgs(confirm));
            }
        }
    }
}
