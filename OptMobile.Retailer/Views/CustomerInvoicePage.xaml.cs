using OptMobile.Retailer.ViewModels;

namespace OptMobile.Retailer.Views;

public partial class CustomerInvoicePage : ContentPage
{
    public CustomerInvoicePage(CustomerInvoiceViewModel viewModel)
    {
        InitializeComponent();
        Shell.SetNavBarIsVisible(this, false);
        Shell.SetTabBarIsVisible(this, false);
        BindingContext = viewModel;
    }
}