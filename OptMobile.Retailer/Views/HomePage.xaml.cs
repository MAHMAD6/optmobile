using OptMobile.Retailer.ViewModels;

namespace OptMobile.Retailer.Views;

public partial class HomePage : ContentPage
{
    public HomePage(HomeViewModel viewModel)
    {
        InitializeComponent();
        Shell.SetNavBarIsVisible(this, false);
        BindingContext = viewModel;
    }
}