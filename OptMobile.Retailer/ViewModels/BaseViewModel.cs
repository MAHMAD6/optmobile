using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OptMobile.Retailer.Models;
using System.Collections.ObjectModel;

namespace OptMobile.Retailer.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private bool _isRefreshing;

        [ObservableProperty]
        private bool _isDataLoaded;

        [ObservableProperty]
        private string _errorMessage;

        [ObservableProperty]
        private static ObservableCollection<Cart> carts = new();
        [ObservableProperty]
        private static decimal subtotal;
        [ObservableProperty]
        private static decimal total;

        public BaseViewModel()
        {
            // Subscribe to changes in the cart collection
            Carts.CollectionChanged += (sender, args) => UpdateSubtotal();
        }
        private decimal CalculateSubtotal()
        {
            return (decimal)Carts.Sum(cart => cart.product.Ptr * cart.product.Qty);
        }

        private void UpdateSubtotal()
        {
            Subtotal = CalculateSubtotal();
            Total = Subtotal;
        }

        [RelayCommand]
        private void EmptyCart()
        {
            Carts.Clear();
        }
        [RelayCommand]
        private void IncrementPurchaseQuantity(ItemMaster product)
        {
            if (product != null)
            {
                product.Qty++;
                product.IsMinusButtonVisible = product.Qty > 0;

                // Add or update the product in the cart
                var existingCartItem = Carts.FirstOrDefault(c => c.product.item_id == product.item_id);
                if (existingCartItem == null)
                {
                    Carts.Add(new Cart
                    {
                        ID = Carts.Count + 1,
                        user = new User(),
                        product = product
                    });
                }
            }
            UpdateSubtotal();
        }

        [RelayCommand]
        private void DecrementPurchaseQuantity(ItemMaster product)
        {
            if (product != null && product.Qty > 0)
            {
                product.Qty--;
                product.IsMinusButtonVisible = product.Qty > 0;

                // Remove the product from the cart if quantity is 0
                if (product.Qty == 0)
                {
                    var existingCartItem = Carts.FirstOrDefault(c => c.product.item_id == product.item_id);
                    if (existingCartItem != null)
                    {
                        Carts.Remove(existingCartItem);
                    }
                }
            }
            UpdateSubtotal();
        }
    }
}
