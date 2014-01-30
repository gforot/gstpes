using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using GestionePeso.App.ViewModel;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace GestionePeso.App.src.gui
{
    /// <summary>
    /// Pagina che permette di creare o modificare i dati dell'utente
    /// </summary>
    public partial class EditUserPage : PhoneApplicationPage
    {
        private EditUserViewModel _vm;

        public EditUserPage()
        {
            InitializeComponent();

            _vm = new EditUserViewModel();
            _vm.CloseRequested += _vm_CloseRequested;

            DataContext = _vm;
        }

        void _vm_CloseRequested(object sender, EventArgs e)
        {
            CloseEditUserEventArgs args = e as CloseEditUserEventArgs;
           

            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}