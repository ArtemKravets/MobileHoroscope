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
using Newtonsoft.Json;

namespace z.ViewModels
{
    public class ZnaksViewModel : ContentPage
    {

        public ObservableCollection<ZnakModel> CurrentSign { get; set; } = new ObservableCollection<ZnakModel>();

        public async Task GetSign()
        {
            var dataServices = DataService.DataService.GetInstance();
            var status = await dataServices.GetJsonString();

            foreach (var answer in status)
            {
                CurrentSign.Add(answer);
            }

        }

        public Command ExitCommand { get; set; }
        public Command ZnaksCommand { get; set; }

        private Page _page;
        public ZnaksViewModel(Page page)
        {
            _page = page;
            ExitCommand = new Command(Exit);
            ZnaksCommand = new Command(Znak);


        }
        public async void Exit()
        {

            var app = (App)Application.Current;
            app.MainPage = new NavigationPage(new LoginPage());
        }

        public async void Znak()
        {
            await _page.Navigation.PushAsync(new ZnaksPage());
        }

    }
}
