using OptMobile.Retailer.ViewModels;

namespace OptMobile.Retailer.Views;

public partial class ItemSearchPage : ContentPage
{
    public ItemSearchPage(ItemSearchViewModel viewModel)
    {
        InitializeComponent();
        Shell.SetTabBarIsVisible(this, false);
        BindingContext = viewModel;
    }
}