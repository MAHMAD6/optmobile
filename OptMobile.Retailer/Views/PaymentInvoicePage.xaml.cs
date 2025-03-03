using OptMobile.Retailer.ViewModels;

namespace OptMobile.Retailer.Views;

public partial class PaymentInvoicePage : ContentPage
{
	public PaymentInvoicePage(PaymentInvoiceViewModel viewModel)
	{
		InitializeComponent();
        Shell.SetNavBarIsVisible(this, false);
        Shell.SetTabBarIsVisible(this, false);
        BindingContext = viewModel;
    }
}