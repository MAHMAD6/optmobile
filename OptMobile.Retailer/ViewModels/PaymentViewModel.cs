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
[QueryProperty(nameof(CountPickedInvoice), QueryPropertyKeys.COUNT_PICKED_INVOICE)]
public partial class PaymentViewModel : BaseViewModel
{
    private readonly ISalesService _salesService;
    private readonly IPartyService _partyService;

    public PaymentViewModel(ISalesService salesService, IPartyService partyService)
    {
        _salesService = salesService;
        _partyService = partyService;

        LoadDropDownData();
    }
    [ObservableProperty]
    private int _partyId;
    [ObservableProperty]
    ObservableCollection<SalesInvoiceMaster> _invoices;
    [ObservableProperty]
    private PartyMaster _party;

    [ObservableProperty]
    public ObservableCollection<PaymentModeMaster> paymentModes = new();
    [ObservableProperty]
    private ObservableCollection<BankMaster> bankMasters = new();
    [ObservableProperty]
    private string selectedPaymentMode;
    [ObservableProperty]
    private string selectedBank;
    [ObservableProperty]
    private int _countPickedInvoice;

    private void LoadDropDownData()
    {
        this.PaymentModes = new ObservableCollection<PaymentModeMaster>();
        this.PaymentModes.Add(new PaymentModeMaster { payment_mode_id = 1, payment_mode = "Cash", transaction_type_id = 1, isactive = true });
        this.PaymentModes.Add(new PaymentModeMaster { payment_mode_id = 2, payment_mode = "Cheque", transaction_type_id = 2, isactive = true });
        this.PaymentModes.Add(new PaymentModeMaster { payment_mode_id = 3, payment_mode = "NEFT", transaction_type_id = 1, isactive = true });
        this.PaymentModes.Add(new PaymentModeMaster { payment_mode_id = 4, payment_mode = "RTGS", transaction_type_id = 1, isactive = true });
        this.PaymentModes.Add(new PaymentModeMaster { payment_mode_id = 5, payment_mode = "DD", transaction_type_id = 1, isactive = true });
        this.PaymentModes.Add(new PaymentModeMaster { payment_mode_id = 6, payment_mode = "ATM Withdraw", transaction_type_id = 1, isactive = true });
        this.PaymentModes.Add(new PaymentModeMaster { payment_mode_id = 7, payment_mode = "Bank Charges", transaction_type_id = 1, isactive = true });
        this.PaymentModes.Add(new PaymentModeMaster { payment_mode_id = 8, payment_mode = "Other", transaction_type_id = 1, isactive = true });
        this.PaymentModes.Add(new PaymentModeMaster { payment_mode_id = 9, payment_mode = "Paytm", transaction_type_id = 1, isactive = true });
        this.PaymentModes.Add(new PaymentModeMaster { payment_mode_id = 10, payment_mode = "PhonePe", transaction_type_id = 1, isactive = true });
        this.PaymentModes.Add(new PaymentModeMaster { payment_mode_id = 11, payment_mode = "GooglePay", transaction_type_id = 1, isactive = true });


        this.BankMasters = new ObservableCollection<BankMaster>();
        this.BankMasters.Add(new BankMaster { bank_id = 1, bank_name = "AU SMALL FINANCE BANK", account_id = 5193, isactive = true });

    }

    [RelayCommand]
    private async Task BackPageNavigation()
    {
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
    public void SavePayment()
    {
        //Consume api to save data on server
    }

    [RelayCommand]
    public async Task PaymentAmount(int id)
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { QueryPropertyKeys.PARTY_ID, id },
            { QueryPropertyKeys.PARTY, Party },
            { QueryPropertyKeys.INVOICES, Invoices }
        };

        await Shell.Current.GoToAsync($"{nameof(PaymentInvoicePage)}", true, parameters);
    }

    [RelayCommand]
    public async Task LinkedInvoiceNavigation(int id)
    {
        await Shell.Current.GoToAsync($"{nameof(PaymentInvoicePage)}?{QueryPropertyKeys.PARTY_ID}={id}", true);
    }
}
