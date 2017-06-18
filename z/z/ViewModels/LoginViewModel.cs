using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using z.DataService;
using z.Views;

namespace z.ViewModels
{
    public class LoginViewModel : ContentPage
    {


        private readonly Page _page;
        public ICommand RegCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public LoginViewModel(Page page)
        {
            _page = page;
            RegCommand = new Command(OpenReg);
            LoginCommand = new Command(OpenLog);
            NavigationPage.SetHasNavigationBar(page, true);
        }
        private void OpenReg()
        {

            var app = (App)Application.Current;
            app.MainPage = new RegPage();

        }
        private async void OpenLog()
        {
            var DataServices = DataService.DataService.GetInstance();
            string status = await DataServices.LoginAsync(UserName, Password);
            if (status == "OK")
            {
                var app = (App)Application.Current;
                app.MainPage = new NavigationPage(new HoroPage());

                //HoroPage horopage = new HoroPage();
                //await Navigation.PushAsync(horopage);
                //horopage.CurrentUserName(UserName);
            }
            else
            {
                await _page.DisplayAlert("Ошибка", "Не удалось выполнить вход", "Закрыть");
            }
           
        }
    }
}
