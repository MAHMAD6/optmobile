using OptMobile.Retailer.Models;
using System.Collections.ObjectModel;

namespace OptMobile.Retailer.ViewModels;

public partial class ItemSubstituteViewModel : BaseViewModel
{
    private ObservableCollection<ItemMaster> products;

    // Property to bind to in the View
    public ObservableCollection<ItemMaster> Products
    {
        get => products;
        set => SetProperty(ref products, value);
    }

    // Method to update the products
    public void UpdateProducts(ObservableCollection<ItemMaster> newProducts)
    {
        Products = newProducts;
    }
}
