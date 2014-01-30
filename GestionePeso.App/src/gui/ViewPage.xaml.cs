using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using GestionePeso.App.VewModel;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace GestionePeso.App.src.gui
{
    public partial class ViewPage : PhoneApplicationPage
    {
        ViewPageViewModel _vm;

        public ViewPage()
        {
            InitializeComponent();

            _vm = new ViewPageViewModel();
            DataContext = _vm;
        }
    }
}