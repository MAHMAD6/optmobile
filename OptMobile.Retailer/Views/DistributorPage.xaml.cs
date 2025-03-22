using OptMobile.Retailer.ViewModels;

namespace OptMobile.Retailer.Views;

public partial class DistributorPage : ContentPage
{
    public DistributorPage(DistributionPageViewModel distributionPageViewModel)
    {
        InitializeComponent();
        BindingContext = distributionPageViewModel; 
    }
}