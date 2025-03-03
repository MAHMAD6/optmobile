
using OptMobile.Retailer.Models;

namespace OptMobile.Retailer.Handlers;

public class CustomerSearchHandler : SearchHandler
{
    public IList<PartyMaster> Parties { get; set; }
    public string NavigationRoute { get; set; }

    protected override void OnQueryChanged(string oldValue, string newValue)
    {
        base.OnQueryChanged(oldValue, newValue);
        if (string.IsNullOrEmpty(newValue) || string.IsNullOrWhiteSpace(newValue))
            ItemsSource = null;
        else
            ItemsSource = Parties.Where(t => t.party_name.Contains(newValue, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    protected override async void OnItemSelected(object item)
    {
        base.OnItemSelected(item);
        if (!string.IsNullOrEmpty(NavigationRoute) || !string.IsNullOrWhiteSpace(NavigationRoute))
        {
            var navigationParameter = new Dictionary<string, object>()
                {
                    {"CustomerInvoicePage", item }
                };
            await Shell.Current.GoToAsync(NavigationRoute, navigationParameter);
        }
    }
}
