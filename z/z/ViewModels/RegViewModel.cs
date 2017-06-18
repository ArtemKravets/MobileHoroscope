using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using z.Models;
using z.Views;

namespace z.ViewModels
{
    public class RegViewModel 
    {

        Picker picker = new Picker();
        

        private readonly Page _page;
        private ZnakModel signSelect;

        public ICommand RegCommand { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }


        List<string> sign = new List<string>
        {
            "ОВЕН (21 марта — 20 апреля)",
            "ТЕЛЕЦ (21 апреля — 20 мая)",
            "БЛИЗНЕЦЫ (21 мая — 21 июня)",
            "РАК (22 июня — 22 июля)",
            "ЛЕВ (23 июля — 23 августа)",
            "ДЕВА (24 августа — 23 сентября)",
            "ВЕСЫ (24 сентября — 23 октября)",
            "СКОРПИОН (24 октября 22 ноября)",
            "CТРЕЛЕЦ (22 декабря — 20 января)",
            "КОЗЕРОГ (22 декабря — 20 января)",
            "ВОДОЛЕЙ (21 января — 20 февраля)",
            "РЫБЫ (21 февраля —20 марта)",

        };

        public List<string> AllSign => sign;

        int signSelectedIndex;
        private string CurrentSign;

        public int SignSelectedIndex
        {
            get
            {
                return signSelectedIndex;
            }
            set
            {
                if (signSelectedIndex != value)
                {
                    signSelectedIndex = value;
                    CurrentSign = sign[signSelectedIndex];
                }
            }
        }

     

        /* public static MasterDetailPage MasterDetail { get; set; }
        public async static Task NavigateMasterDetail(Page page)
        {

        await StartView.MasterDetail.Detail.Navigation.PushAsync(page);

        }*/
        public RegViewModel(Page page)
        {
            _page = page;
            RegCommand = new Command(OpenReg);

            NavigationPage.SetHasNavigationBar(page, false);

            /* OpenDetail = new Command(async () =>
            {
            await _page.Navigation.PushAsync(new MasterPage());
            });*/
        }

        public RegViewModel()
        {
        }

        public RegViewModel(Page page, ZnakModel signSelect) : this(page)
        {
            this.signSelect = signSelect;
        }

        private async void OpenReg()
        {
            var DataServices = DataService.DataService.GetInstance();
            string status = await DataServices.RegisterAsync(UserName, Password, CurrentSign);
            if (status == "OK")
            {
                var app = (App)Application.Current;
                app.MainPage = new LoginPage();
            }
            else
            {
                await _page.DisplayAlert("Ошибка", "Не удалось выполнить регистрацию", "Закрыть");

            }

        }
    }
}
        
   