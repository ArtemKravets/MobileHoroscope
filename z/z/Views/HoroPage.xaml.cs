using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using z.Models;
using z.ViewModels;

namespace z.Views
{
    public partial class HoroPage : ContentPage
    {
        private readonly HoroViewModel _viewmodel;
        public string currentUserName;

        public void CurrentUserName(string UserName)
        {
            currentUserName = UserName;

        }

        public HoroPage()
        {
            InitializeComponent();
            _viewmodel = new HoroViewModel(this);

            //_viewmodel.GetGoroskop();
            BindingContext = _viewmodel;
            //DisplayAlert(currentUserName, currentUserName, "OK");


        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                var selection = e.SelectedItem as ZnaksModel;

                DisplayAlert("Гороскоп", selection.NameDec, "OK");

                //await Navigation.PushAsync(new OvenPage());
            }
            
        }

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();

        //    if (Loaded == false)
        //    {
        //        await _viewmodel.GetGoroskop();
        //        Loaded = true;
        //    }
        //}

    }
}