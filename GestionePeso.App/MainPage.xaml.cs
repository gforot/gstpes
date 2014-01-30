using System;
using System.Collections.Generic;
using System.Windows;
using GestionePeso.App.Model;
using GestionePeso.App.Storage;
using GestionePeso.App.ViewModel;
using Microsoft.Phone.Controls;

namespace GestionePeso.App
{
    public partial class MainPage : PhoneApplicationPage
    {
        private MainPageViewModel _vm;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            _vm = new MainPageViewModel();
            _vm.InsertRequested += _vm_InsertRequested;
            _vm.ViewRequested += _vm_ViewRequested;
            _vm.EditUserRequested += _vm_EditUserRequested;
            this.DataContext = _vm;
        }

        void _vm_EditUserRequested(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/src/gui/EditUserPage.xaml", UriKind.Relative));
        }

        void _vm_ViewRequested(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/src/gui/ViewPage.xaml", UriKind.Relative));
        }

        void _vm_InsertRequested(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/src/gui/InsertPage.xaml", UriKind.Relative));
        }

        //private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        //{
        //    if (App.User == null)
        //    {
        //        NavigationService.Navigate(new Uri("/src/gui/EditUserPage.xaml", UriKind.Relative));
        //    }
        //}


        //private void btnSaveUser_Click(object sender, RoutedEventArgs e)
        //{
        //    UserXmlParser.SaveUser(new Model.User("gforot", new DateTime(1977, 7, 30), Model.Gender.Male, 185));
        //}

        //private void btnReadUser_Click(object sender, RoutedEventArgs e)
        //{
        //    Model.User user = UserXmlParser.ReadUser();
        //    if (user == null)
        //    {
        //        MessageBox.Show("Utente non trovato!!");
        //    }
        //    else
        //    {
        //        MessageBox.Show(string.Format("Trovato l'utente : {0}!!", user));
        //    }

        //}

        //private void btnSavePesate_Click(object sender, RoutedEventArgs e)
        //{
        //    PesateXmlParser.SavePesate(new[] { new Pesata(DateTime.Now, 87.5f), new Pesata(DateTime.Now.AddDays(-2), 87.5f), });
        //}

        //private void btnReadPesate_Click(object sender, RoutedEventArgs e)
        //{
        //    List<Pesata> pesate = PesateXmlParser.ReadPesate();
        //    if (pesate == null)
        //    {
        //        MessageBox.Show("Pesate non trovate");
        //    }
        //    else
        //    {
                
        //        MessageBox.Show(string.Format("Trovate {0} pesate!!", pesate.Count));
        //    }
        //}
    }
}