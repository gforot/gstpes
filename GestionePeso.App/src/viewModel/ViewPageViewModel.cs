using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using GestionePeso.App.Model;

namespace GestionePeso.App.VewModel
{
    public class ViewPageViewModel : ViewModelBase
    {
        private List<Pesata> _items;

        public ViewPageViewModel()
        {
            _items = Pesata.CreateTestData();
        }

        public List<Pesata> Items { get { return _items; } }
    }
}
