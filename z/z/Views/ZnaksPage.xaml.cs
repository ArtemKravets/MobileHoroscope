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
    public partial class ZnaksPage : ContentPage
    {
        private readonly ZnaksViewModel _viewmodel;
        private bool Loaded = false;

        public ZnaksPage()
        {
            InitializeComponent();
            _viewmodel = new ZnaksViewModel(this);
             _viewmodel.GetSign();
            BindingContext = _viewmodel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (Loaded == false)
            {
                await _viewmodel.GetSign();
                Loaded = true;
            }
        }


    }
}
