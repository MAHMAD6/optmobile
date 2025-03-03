
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OptMobile.Retailer.Helpers;
using OptMobile.Retailer.Models;
using OptMobile.Retailer.Services;
using OptMobile.Retailer.Views;
using System.Collections.ObjectModel;

namespace OptMobile.Retailer.ViewModels;


public partial class CustomerInvoiceViewModel : BaseViewModel, IQueryAttributable
{
    private readonly ISalesService _salesService;
    private readonly IPartyService _partyService;

    public CustomerInvoiceViewModel(ISalesService salesService, IPartyService partyService)
    {
        _salesService = salesService;
        _partyService = partyService;
        PropertyChanged += CustomerInvoiceViewModel_PropertyChanged;
    }

    public static List<SalesInvoiceMaster> SearchInvoices { get; set; } = new();

    [ObservableProperty]
    private string searchQuery;
    [ObservableProperty]
    public int partyID;
    [ObservableProperty]
    string partyName = "";
    [ObservableProperty]
    string partyMobile = "";

    [ObservableProperty]
    ObservableCollection<SalesInvoiceMaster> invoices;
    [ObservableProperty]
    ObservableCollection<SalesInvoiceMaster> filteredInvoices;
    [ObservableProperty]
    public PartyMaster party;

    private void CustomerInvoiceViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SearchQuery))
        {
            ApplySearchFilter();
        }
    }    

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        IsBusy = true;
        IsDataLoaded = false;

        if (query.ContainsKey(QueryPropertyKeys.ID))
        {
            int partyId = int.Parse(query[QueryPropertyKeys.ID].ToString());
            PartyID = partyId;
            if (Party == null)
            {
                Party = await _partyService.GetPartyByIDAsync(partyId);
            }
            if (Invoices == null || Invoices.Count == 0)
            {
                Invoices = new ObservableCollection<SalesInvoiceMaster>(await _salesService.GetByPartyIDAsync(partyId));
            }
        }

        if (Invoices != null)
            FilteredInvoices = new ObservableCollection<SalesInvoiceMaster>(Invoices);

        IsDataLoaded = true;
        IsBusy = false;
    }

    private void ApplySearchFilter()
    {
        if (string.IsNullOrWhiteSpace(SearchQuery))
        {
            FilteredInvoices = new ObservableCollection<SalesInvoiceMaster>(Invoices);
        }
        else
        {
            string query = SearchQuery.ToLower();
            var filtered = Invoices.Where(w => w.invoice_code.ToLower().Contains(query));
            FilteredInvoices = new ObservableCollection<SalesInvoiceMaster>(filtered);
        }
    }

    [RelayCommand]
    private async Task BackPageNavigation()
    {
        //await Shell.Current.GoToAsync("..");
        await Shell.Current.Navigation.PopAsync(true);
    }

    [RelayCommand]
    public async Task InvoiceDetails(SalesInvoiceMaster invoice)
    {
        if (invoice == null)
            return;
        await Shell.Current.GoToAsync($"{nameof(InvoiceDetailsPage)}?{QueryPropertyKeys.ID}={invoice.invoice_id}", true);
    }

    [RelayCommand]
    public async Task Payment()
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>
        {
             { QueryPropertyKeys.PARTY_ID, PartyID },
             { QueryPropertyKeys.PARTY, Party },
             { QueryPropertyKeys.INVOICES, Invoices }
        };

        await Shell.Current.GoToAsync($"{nameof(PaymentPage)}", true, parameters);
    }

    [RelayCommand]
    public async Task Refresh()
    {
        IsRefreshing = true;
        //Parties = new ObservableCollection<PartyMaster>(await _partyService.GetAllPartyAsync());
        IsRefreshing = false;
    }

    [RelayCommand]
    private async Task CartPageNavigation()
    {
        await Shell.Current.GoToAsync($"{nameof(CartPage)}", true);
    }
}
