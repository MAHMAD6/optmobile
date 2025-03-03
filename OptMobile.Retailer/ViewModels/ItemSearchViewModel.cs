using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OptMobile.Retailer.Helpers;
using OptMobile.Retailer.Models;
using OptMobile.Retailer.Services;
using OptMobile.Retailer.Views;
using System.Collections.ObjectModel;

namespace OptMobile.Retailer.ViewModels;

public partial class ItemSearchViewModel : BaseViewModel, IQueryAttributable
{
    private readonly IItemService _itemService;

    public ItemSearchViewModel(IItemService itemService)
    {
        _itemService = itemService;
        LoadDefaultItemCommand.Execute(null);
        //PropertyChanged += ItemSearchViewModel_PropertyChanged;
    }

    [ObservableProperty]
    private string searchQuery;
    [ObservableProperty]
    private ObservableCollection<ItemMaster> defaultItems = new();
    [ObservableProperty]
    private ObservableCollection<ItemMaster> searchItems = new();
    [ObservableProperty]
    private ObservableCollection<ItemMaster> items = new(); 
    [ObservableProperty]
    private ObservableCollection<ItemMaster> cart = new();


    private async void ItemSearchViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SearchQuery))
        {
            if (!string.IsNullOrWhiteSpace(SearchQuery) && SearchQuery.Length > 2)
                await LoadDefaultItem();
        }
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        IsBusy = true;
        IsDataLoaded = false;

        if (query.ContainsKey(QueryPropertyKeys.TYPE) && query[QueryPropertyKeys.TYPE] != null)
        {
            string itemType = query[QueryPropertyKeys.TYPE].ToString();
            SearchItems = new ObservableCollection<ItemMaster>(await _itemService.GetByFeatureAsync(itemType));
        }

        if (query.ContainsKey(QueryPropertyKeys.DRUGTYPE_ID) && query[QueryPropertyKeys.DRUGTYPE_ID] != null)
        {
            int drugTypeId = int.Parse(query[QueryPropertyKeys.DRUGTYPE_ID].ToString());
            SearchItems = new ObservableCollection<ItemMaster>(await _itemService.GetByDrugTypeIDAsync(drugTypeId));
        }

        IsDataLoaded = true;
        IsBusy = false;
    }

    [RelayCommand]
    public async Task LoadDefaultItem()
    {
        DefaultItems = new();
        IsBusy = true;
        try
        {
            var items = await _itemService.GetByNameAsync(SearchQuery);
            SearchItems = new ObservableCollection<ItemMaster>(items);
            //DefaultItems = new ObservableCollection<ItemMaster>(items);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async void SearchItem()
    {
        if (!string.IsNullOrWhiteSpace(SearchQuery) && SearchQuery.Length > 2)
        {
            await LoadDefaultItem();
        }
    }


    [RelayCommand]
    private async void DetailPageNav(ItemMaster selectedProduct)
    {
        if (selectedProduct != null)
        {
            var navigationParameter = new Dictionary<string, object>
                {
                    { "SelectedProduct", selectedProduct },
                    { "Cart", Cart }
                };
            await Shell.Current.GoToAsync($"{nameof(ItemDetailsPage)}?id={selectedProduct.item_id}", navigationParameter);
        }
    }

    [RelayCommand]
    private async Task BackPageNavigation()
    {
        //await Shell.Current.GoToAsync("..");
        await Shell.Current.Navigation.PopAsync(true);
    }

    [RelayCommand]
    private async Task CartPageNavigation()
    {
        await Shell.Current.GoToAsync($"{nameof(CartPage)}", true);
    }
}
