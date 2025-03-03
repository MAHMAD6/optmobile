using OptMobile.Retailer.ViewModels;

namespace OptMobile.Retailer.Views;

public partial class CustomersPage : ContentPage
{
    public CustomersPage(CustomerViewModel customerViewModel)
    {
        InitializeComponent();
        Shell.SetNavBarIsVisible(this, false);
        BindingContext = customerViewModel;
    }
}