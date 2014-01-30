using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace GestionePeso.App.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        public event EventHandler InsertRequested;
        public event EventHandler ViewRequested;
        public event EventHandler EditUserRequested;

        public RelayCommand InsertCommand { get; private set; }
        public RelayCommand ViewCommand { get; private set; }
        public RelayCommand EditUserCommand { get; private set; }

        public MainPageViewModel()
        {
            InsertCommand = new RelayCommand(Insert, CanInsert);
            ViewCommand = new RelayCommand(View, CanView);
            EditUserCommand = new RelayCommand(EditUser, CanEditUser);
        }

        /// <summary>
        /// Inserisce una pesata: naviga fino alla pagina di Inserimento pesata
        /// </summary>
        private void Insert()
        {
            if (InsertRequested != null)
            {
                InsertRequested(this, new EventArgs());
            }
        }

        /// <summary>
        /// Passa alla visualizzazione
        /// </summary>
        private void View()
        {
            if (ViewRequested != null)
            {
                ViewRequested(this, new EventArgs());
            }
        }

        /// <summary>
        /// Passa alla modifica dell'utente
        /// </summary>
        private void EditUser()
        {
            if (EditUserRequested != null)
            {
                EditUserRequested(this, new EventArgs());
            }
        }

        private bool CanEditUser()
        {
            return true;
        }

        private bool CanView()
        {
            return App.User != null;
        }

        private bool CanInsert()
        {
            return App.User != null;
        }
    }
}
