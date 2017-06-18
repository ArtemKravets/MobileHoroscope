using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using z.ViewModels;
using z.ViewModels;

namespace z.Views
{
    public partial class ProfilPage : ContentPage
    {
        private readonly ProfilViewModel _viewmodel;
        

        public ProfilPage()
        {
            InitializeComponent();
            _viewmodel = new ProfilViewModel(this);
            BindingContext = _viewmodel;
        }

        private async void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            _viewmodel.HoroCommand.Execute(null);
        }

        
    }
}
