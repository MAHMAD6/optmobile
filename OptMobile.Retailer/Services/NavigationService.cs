using OptMobile.Retailer.Views;

namespace OptMobile.Retailer.Services;

public interface INavigationService
{
    Task NavigateToAsync(string pageKey);
}

public class NavigationService : INavigationService
{
    private readonly INavigation _navigation;

    public NavigationService(INavigation navigation)
    {
        _navigation = navigation ?? throw new ArgumentNullException(nameof(navigation));
    }

    public async Task NavigateToAsync(string pageKey)
    {
        // Perform the navigation here
        switch (pageKey)
        {
            case nameof(NewCustomerPage):
                await _navigation.PushAsync(new NewCustomerPage());//await Shell.Current.GoToAsync(nameof(PaymentPage));
                break;
            //case nameof(PaymentPage):
            //    await _navigation.PushAsync(new PaymentPage());//await Shell.Current.GoToAsync(nameof(PaymentPage));
            //    break;
            //case nameof(InvoiceDetailsPage):
            //    await _navigation.PushAsync(new InvoiceDetailsPage());//await Shell.Current.GoToAsync(nameof(PaymentPage));
            //    break;
            default:
                throw new ArgumentException("OptMed Exception => NavigateToAsync :: Page key is not recognized.");
        }
    }
}
