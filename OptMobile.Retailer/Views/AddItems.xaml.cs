using OptMobile.Retailer.ViewModels;

namespace OptMobile.Retailer.Views;

public partial class AddItems : ContentPage
{
	public AddItems(AddItemsViewModel addItemsViewModel)
	{
		InitializeComponent();
		BindingContext = addItemsViewModel;
	}
}