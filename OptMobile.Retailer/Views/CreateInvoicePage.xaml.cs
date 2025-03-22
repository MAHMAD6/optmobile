using OptMobile.Retailer.ViewModels;

namespace OptMobile.Retailer.Views;

public partial class CreateInvoicePage : ContentPage
{
	public CreateInvoicePage(CreateInvoiceViewModel createInvoiceViewModel)
	{
		InitializeComponent();
		BindingContext = createInvoiceViewModel;

		collection.ItemsSource = new List<string>() { "gekk" };

        Dispatcher.Dispatch(() =>
        {
            createInvoiceViewModel.SetCollectionHeight(collection.Height);
            createInvoiceViewModel.SetCollectionHeightAdditionalCharges(AdditionalChargesCollection.Height);
        });
    }
    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        if (BindingContext is CreateInvoiceViewModel viewModel)
        {
            viewModel.SetCollectionHeight(collection.Height);
            viewModel.SetCollectionHeightAdditionalCharges(AdditionalChargesCollection.Height);
        }
    }
}