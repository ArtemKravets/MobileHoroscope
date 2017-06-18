using Xamarin.Forms;

namespace z.ViewModels
{
    public class MainPageViewModel
    {
        private INavigation _navigation;

        public MainPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
        }
    }
}