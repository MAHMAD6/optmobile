using OptMobile.Retailer.Models;

namespace OptMobile.Retailer.Handlers;

public class InvoiceSearchHandler : SearchHandler
{
    public IList<SalesInvoiceMaster> Invoices { get; set; }
    public string NavigationRoute { get; set; }

    protected override void OnQueryChanged(string oldValue, string newValue)
    {
        base.OnQueryChanged(oldValue, newValue);
        if (string.IsNullOrEmpty(newValue) || string.IsNullOrWhiteSpace(newValue))
            ItemsSource = null;
        else
            ItemsSource = Invoices.Where(t => t.invoice_code.Contains(newValue, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    protected override async void OnItemSelected(object item)
    {
        base.OnItemSelected(item);
        if (!string.IsNullOrEmpty(NavigationRoute) || !string.IsNullOrWhiteSpace(NavigationRoute))
        {
            var navigationParameter = new Dictionary<string, object>()
            {
                {"InvoiceDetailsPage", item }
            };
            await Shell.Current.GoToAsync(NavigationRoute, navigationParameter);
        }
    }
}
