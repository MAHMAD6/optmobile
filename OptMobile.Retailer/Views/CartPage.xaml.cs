using OptMobile.Retailer.ViewModels;

namespace OptMobile.Retailer.Views;

public partial class CartPage : ContentPage
{
	public CartPage()
	{
		InitializeComponent();
        Shell.SetTabBarIsVisible(this, false);
        BindingContext = new CartViewModel();
    }
}