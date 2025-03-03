using OptMobile.Retailer.ViewModels;

namespace OptMobile.Retailer.Views;

public partial class UserAccountPage : ContentPage
{
    public UserAccountPage(UserAccountViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}