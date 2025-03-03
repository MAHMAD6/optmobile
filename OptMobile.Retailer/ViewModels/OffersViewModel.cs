using CommunityToolkit.Mvvm.Input;
using OptMobile.Retailer.Services;
using OptMobile.Retailer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptMobile.Retailer.ViewModels;

public partial class OffersViewModel : BaseViewModel
{
    private readonly IItemService _itemService;

    public OffersViewModel(IItemService itemService)
    {
        _itemService = itemService;
    }

    [RelayCommand]
    private async Task CartPageNavigation()
    {
        await Shell.Current.GoToAsync($"{nameof(CartPage)}", true);
    }
}
