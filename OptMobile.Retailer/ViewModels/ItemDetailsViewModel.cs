using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OptMobile.Retailer.Models;
using OptMobile.Retailer.Services;
using OptMobile.Retailer.Views;
using System.Collections.ObjectModel;

namespace OptMobile.Retailer.ViewModels;

public partial class ItemDetailsViewModel : BaseViewModel, IQueryAttributable
{
    private readonly IItemService _itemService;

    public ItemDetailsViewModel(IItemService itemService)
    {
        _itemService = itemService;
    }

    [ObservableProperty]
    ItemMaster item = new();

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        IsBusy = true;
        IsDataLoaded = false;

        if (query.TryGetValue("SelectedProduct", out var product) && product is ItemMaster itemMaster)
        {
            Item = itemMaster;
        }

        else if (query.ContainsKey("id") && query["id"] != null)
        {
            int itemId;
            if (int.TryParse(query["id"].ToString(), out itemId))
            {
                Item = await _itemService.GetByIDAsync(itemId);
            }
        }

        IsDataLoaded = true;
        IsBusy = false;
    }

    [RelayCommand]
    private async Task ClosePage()
    {
        await Shell.Current.GoToAsync("..");
    }

    [ObservableProperty]
    private ObservableCollection<ItemMaster> cart = new();

    [ObservableProperty]
    private ItemMaster selectedProduct = new();

    [ObservableProperty]
    private ObservableCollection<ItemMaster> products = new();

    [ObservableProperty]
    private Product product = new();

    public ObservableCollection<string> ImageList { get; set; } = new ObservableCollection<string>
        {
            "home.png",
            "cart.png",
            "card.png"
        };

    [RelayCommand]
    private async Task Back()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task CartNav()
    {
        await Shell.Current.GoToAsync($"{nameof(CartPage)}");
    }

    [RelayCommand]
    private async Task CartPageNavigation()
    {
        await Shell.Current.GoToAsync($"{nameof(CartPage)}", true);
    }
}