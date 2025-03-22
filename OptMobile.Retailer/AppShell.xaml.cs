using Microsoft.Maui.Controls;
using OptMobile.Retailer.Views;

namespace OptMobile.Retailer
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CartPage), typeof(CartPage));
            Routing.RegisterRoute(nameof(CustomerInvoicePage), typeof(CustomerInvoicePage));
            Routing.RegisterRoute(nameof(InvoiceDetailsPage), typeof(InvoiceDetailsPage));
            Routing.RegisterRoute(nameof(ItemDetailsPage), typeof(ItemDetailsPage));
            Routing.RegisterRoute(nameof(ItemSearchPage), typeof(ItemSearchPage));

            Routing.RegisterRoute(nameof(NewCustomerPage), typeof(NewCustomerPage));
            Routing.RegisterRoute(nameof(PaymentPage), typeof(PaymentPage));
            Routing.RegisterRoute(nameof(PaymentInvoicePage), typeof(PaymentInvoicePage));

            Routing.RegisterRoute(nameof(CreateInvoicePage), typeof(CreateInvoicePage));
            Routing.RegisterRoute(nameof(AddItems), typeof(AddItems));
            Routing.RegisterRoute(nameof(CreateBatch), typeof(CreateBatch));
            Routing.RegisterRoute(nameof(DistributorPage), typeof(DistributorPage));
        }

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);
            System.Diagnostics.Debug.WriteLine($"OptMedLog :: A navigation was performed: {args.Source}, from {args.Previous?.Location} to {args.Current?.Location}");
        }

        protected override void OnNavigating(ShellNavigatingEventArgs args)
        {
            base.OnNavigating(args);
        }
    }
}
