
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OptMobile.Retailer.Models;
using OptMobile.Retailer.Services;
using OptMobile.Retailer.Views;
using System.Collections.ObjectModel;


namespace OptMobile.Retailer.ViewModels;

public partial class CustomerViewModel : BaseViewModel
{
    private readonly IPartyService _partyService;

    public CustomerViewModel(IPartyService partyService)
    {
        _partyService = partyService;
        LoadPartiesCommand = new AsyncRelayCommand(LoadParties);
        PropertyChanged += CustomerViewModel_PropertyChanged;

        LoadPartiesCommand.Execute(null);
    }

    private void CustomerViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SearchQuery))
        {
            ApplySearchFilter();
        }
    }

    public static List<PartyMaster> SearchParties { get; set; } = new();

    [ObservableProperty]
    private ObservableCollection<PartyMaster> parties;

    [ObservableProperty]
    private ObservableCollection<PartyMaster> filteredParties;

    [ObservableProperty]
    private string searchQuery;

    [ObservableProperty]
    private PartyMaster selectedParty;

    public IAsyncRelayCommand LoadPartiesCommand { get; }

    private async Task LoadParties()
    {
        try
        {
            IsBusy = true;
            IsDataLoaded = false;

            var partiesList = await _partyService.GetAllPartyAsync();
            Parties = new ObservableCollection<PartyMaster>(partiesList ?? new List<PartyMaster>());
            FilteredParties = new ObservableCollection<PartyMaster>(Parties);

            IsDataLoaded = true;
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., log them)
            ErrorMessage = ex.Message;
        }
        finally
        {
            IsBusy = false;
        }
    }

    private void ApplySearchFilter()
    {
        if (string.IsNullOrWhiteSpace(SearchQuery))
        {
            FilteredParties = new ObservableCollection<PartyMaster>(Parties);
        }
        else
        {
            string query = SearchQuery.ToLower();
            var filtered = Parties.Where(w => w.party_name.ToLower().Contains(query));
            FilteredParties = new ObservableCollection<PartyMaster>(filtered);
        }
    }

    [RelayCommand]
    public async Task Search(PartyMaster selectedParty)
    {
        if (selectedParty == null) return;
        await Shell.Current.GoToAsync($"{nameof(CustomerInvoicePage)}?name={selectedParty.party_name}");
    }

    [RelayCommand]
    public async Task CreateCustomer()
    {
        await Shell.Current.GoToAsync($"{nameof(NewCustomerPage)}");
    }

    [RelayCommand]
    public async Task PartyInvoice(PartyMaster partyMaster)
    {
        if (partyMaster == null) return;
        await Shell.Current.GoToAsync($"{nameof(CustomerInvoicePage)}?id={partyMaster.party_id}&name={partyMaster.party_name}");
    }

    [RelayCommand]
    public async Task Payment()
    {
        await Shell.Current.GoToAsync($"{nameof(PaymentPage)}", true);
    }

    [RelayCommand]
    public async Task Refresh()
    {
        IsRefreshing = true;
        await LoadParties();
        IsRefreshing = false;
    }

    [RelayCommand]
    private async Task CartPageNavigation()
    {
        await Shell.Current.GoToAsync($"{nameof(CartPage)}", true);
    }
}
