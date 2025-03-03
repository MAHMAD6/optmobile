using OptMobile.Retailer.ViewModels;

namespace OptMobile.Retailer.Views;

public partial class InvoiceDetailsPage : ContentPage
{
    public InvoiceDetailsPage(InvoiceDetailsViewModel viewModel)
    {
        InitializeComponent();
        Shell.SetTabBarIsVisible(this, false);
        BindingContext = viewModel;
    }
}