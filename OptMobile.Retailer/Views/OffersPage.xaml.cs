using OptMobile.Retailer.ViewModels;

namespace OptMobile.Retailer.Views;

public partial class OffersPage : ContentPage
{
    public OffersPage(OffersViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}