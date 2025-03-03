using OptMobile.Retailer.ViewModels;

namespace OptMobile.Retailer.Views;

public partial class CreateInvoicePage : ContentPage
{
	public CreateInvoicePage(CreateInvoiceViewModel createInvoiceViewModel)
	{
		InitializeComponent();
		//BindingContext = createInvoiceViewModel;

		collection.ItemsSource = new List<string>() { "gekk" };
	}

}