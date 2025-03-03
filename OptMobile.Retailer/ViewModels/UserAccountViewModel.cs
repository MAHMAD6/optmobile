using CommunityToolkit.Mvvm.Input;

namespace OptMobile.Retailer.ViewModels
{
    public partial class UserAccountViewModel : BaseViewModel
    {
        public UserAccountViewModel()
        {
        }

        [RelayCommand]
        public async Task UserLogout()
        {
            Preferences.Clear();
            Application.Current.MainPage = new AppShell();
        }
    }
}
