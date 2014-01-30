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
    public partial class InsertPage : PhoneApplicationPage
    {
        private InsertViewModel _vm;

        public InsertPage()
        {
            InitializeComponent();

            _vm = new InsertViewModel();
            DataContext = _vm;
        }
    }
}