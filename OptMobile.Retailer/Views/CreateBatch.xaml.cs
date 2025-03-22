using OptMobile.Retailer.ViewModels;

namespace OptMobile.Retailer.Views;

public partial class CreateBatch : ContentPage
{
	public CreateBatch(CreateBatchViewModel createBatchViewModel)
	{
		InitializeComponent();
		BindingContext = createBatchViewModel;
	}
}