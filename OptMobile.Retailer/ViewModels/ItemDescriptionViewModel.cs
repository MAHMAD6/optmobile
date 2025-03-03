using CommunityToolkit.Mvvm.ComponentModel;

namespace OptMobile.Retailer.ViewModels;

public partial class ItemDescriptionViewModel : BaseViewModel
{
    [ObservableProperty]
    private string passedParameter;
}
