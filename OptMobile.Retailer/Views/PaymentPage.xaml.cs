using OptMobile.Retailer.ViewModels;

namespace OptMobile.Retailer.Views;

public partial class PaymentPage : ContentPage
{
    public PaymentPage(PaymentViewModel viewModel)
    {
        InitializeComponent();
        Shell.SetNavBarIsVisible(this, false);
        Shell.SetTabBarIsVisible(this, false);
        BindingContext = viewModel;
    }
}