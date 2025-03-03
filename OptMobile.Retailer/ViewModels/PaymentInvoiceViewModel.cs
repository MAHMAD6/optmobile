using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OptMobile.Retailer.Helpers;
using OptMobile.Retailer.Models;
using OptMobile.Retailer.Services;
using OptMobile.Retailer.Views;
using System.Collections.ObjectModel;

namespace OptMobile.Retailer.ViewModels;

[QueryProperty(nameof(PartyId), QueryPropertyKeys.PARTY_ID)]
[QueryProperty(nameof(Party), QueryPropertyKeys.PARTY)]
[QueryProperty(nameof(Invoices), QueryPropertyKeys.INVOICES)]
public partial class PaymentInvoiceViewModel : BaseViewModel
{
    private readonly ISalesService _salesService;

    public PaymentInvoiceViewModel(ISalesService salesService)
    {
        _salesService = salesService;
    }

    [ObservableProperty]
    private int _partyId;
    [ObservableProperty]
    ObservableCollection<SalesInvoiceMaster> _invoices;
    [ObservableProperty]
    ObservableCollection<SalesInvoiceMaster> _selectedInvoices;
    [ObservableProperty]
    private PartyMaster _party;
    [ObservableProperty]
    private string _selectedPaymentMode;
    [ObservableProperty]
    private bool _isPaymentModeVisible = true;
    [ObservableProperty]
    private decimal _totalAmount;

    [RelayCommand]
    private async Task ClosePage()
    {
        await Shell.Current.Navigation.PopAsync();
    }

    [RelayCommand]
    private async Task CartPageNavigation()
    {
        await Shell.Current.GoToAsync($"{nameof(CartPage)}", true);
    }

    [RelayCommand]
    public async Task InvoiceDetails(int id)
    {
        if (id <= 0)
            return;
        await Shell.Current.GoToAsync($"{nameof(InvoiceDetailsPage)}?id={id}", true);
    }

    [RelayCommand]
    public async Task Calculate(decimal amount)
    {
        if(amount > 0)
        {
            //Calculate and adjust invoice amount
        }
    }

    [RelayCommand]
    public void InvoiceSelection(SalesInvoiceMaster salesInvoiceMaster)
    {
        //if sum of grand_total of SelectedInvoices is exceed TotalAmount then return
        if (SelectedInvoices != null && SelectedInvoices.Count > 0)
        {
            decimal total = SelectedInvoices.Sum(s => s.grand_total);
            if (total > TotalAmount)
            {
                salesInvoiceMaster.ispick = false;
                return;
            }
        }

        salesInvoiceMaster.ispick = !salesInvoiceMaster.ispick;

        if (salesInvoiceMaster.ispick)
        {
            if (SelectedInvoices == null)
                SelectedInvoices = new ObservableCollection<SalesInvoiceMaster>();
            if (!SelectedInvoices.Contains(salesInvoiceMaster))
                SelectedInvoices.Add(salesInvoiceMaster);
        }
        else
        {
            if (SelectedInvoices != null && SelectedInvoices.Contains(salesInvoiceMaster))
            {
                SelectedInvoices.Remove(salesInvoiceMaster);
            }
        }

        //Update ispick of Invoices collection
        var invoice = Invoices.FirstOrDefault(f => f.invoice_id == salesInvoiceMaster.invoice_id);
        if (invoice != null)
        {
            invoice.ispick = salesInvoiceMaster.ispick;
        }

        //after updating ipick I want to update Invoice so that observable property bind and refresh
        Invoices = new ObservableCollection<SalesInvoiceMaster>(Invoices);
    }

    [RelayCommand]
    public async Task SavePayment()
    {
        int count = Invoices.Where(w => w.ispick == true).Count();
        Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { QueryPropertyKeys.PARTY_ID, PartyId },
            { QueryPropertyKeys.PARTY, Party },
            { QueryPropertyKeys.INVOICES, Invoices },
            { QueryPropertyKeys.COUNT_PICKED_INVOICE, count }
        };
        await Shell.Current.GoToAsync("..", true, parameters);
    }
}
