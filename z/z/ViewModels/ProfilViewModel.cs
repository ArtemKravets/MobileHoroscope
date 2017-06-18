using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using z.Models;
using z.Views;
using z;
using z.Views;

namespace z.ViewModels
{
    public class ProfilViewModel : ContentPage
    {
        public ObservableCollection<ProfillModel> Profil { get; set; } = new ObservableCollection<ProfillModel>
        {
            new  ProfillModel
            {
                Name ="РАK",
                Price = "25.06",
                Login="INNIEO",
                Image ="http://orakul.com/img/new/social/signs/astro/cancer.png",

            },
          

        };


        public Command ExitCommand { get; set; }
        public Command HoroCommand { get; set; }

        private Page _page;

        public ProfilViewModel(Page page)
        {
            _page = page;
            ExitCommand = new Command(Exit);
            HoroCommand = new Command(Znak);


        }
        public async void Exit()
        {

            var app = (App)Application.Current;
            app.MainPage = new NavigationPage(new LoginPage());
        }
        public async void Znak()
        {
            await _page.Navigation.PushAsync(new HoroPage());
        }


    }
}
