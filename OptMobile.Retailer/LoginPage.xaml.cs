using OptMobile.Retailer.ViewModels;

namespace OptMobile.Retailer;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}