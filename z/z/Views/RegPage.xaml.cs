using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using z.ViewModels;

namespace z.Views
{
    public partial class RegPage : ContentPage
    {


        RegViewModel vm;
        public RegPage()
        {
            InitializeComponent();
            this.BindingContext = vm = new RegViewModel(this);
        }

    }
}
