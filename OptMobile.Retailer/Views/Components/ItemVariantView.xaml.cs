using OptMobile.Retailer.Models;
using OptMobile.Retailer.ViewModels;
using System.Collections.ObjectModel;

namespace OptMobile.Retailer.Views.Components;

public partial class ItemVariantView : ContentView
{
	public ItemVariantView()
	{
		InitializeComponent();
    }

    public static readonly BindableProperty ProductsProperty =
        BindableProperty.Create(nameof(Products), typeof(ObservableCollection<ItemMaster>), typeof(ItemSubstituteView), null, propertyChanged: OnProductsChanged);

    public ObservableCollection<ItemMaster> Products
    {
        get => (ObservableCollection<ItemMaster>)GetValue(ProductsProperty);
        set => SetValue(ProductsProperty, value);
    }
    // Called when the Products property changes
    private static void OnProductsChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var view = (ItemVariantView)bindable;
        if (newValue is ObservableCollection<ItemMaster> products)
        {
            var viewModel = view.BindingContext as ItemVariantViewModel;
            viewModel?.UpdateProducts(products);
        }
    }
}