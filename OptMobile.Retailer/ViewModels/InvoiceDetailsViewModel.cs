using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OptMobile.Retailer.Models;
using OptMobile.Retailer.Services;
using OptMobile.Retailer.Views;
using System.Collections.ObjectModel;

namespace OptMobile.Retailer.ViewModels;

public partial class InvoiceDetailsViewModel : BaseViewModel, IQueryAttributable
{
    public readonly ISalesService _salesService;
    public InvoiceDetailsViewModel(ISalesService salesService)
    {
        _salesService = salesService;
    }

    [ObservableProperty]
    SalesInvoiceMaster invoice = new();
    [ObservableProperty]
    ObservableCollection<SalesInvoiceTransaction> itemTransaction = new();
    [ObservableProperty]
    ItemMaster item;
    [ObservableProperty]
    private PartyMaster party;

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        IsBusy = true;
        IsDataLoaded = false;

        if (query.ContainsKey("id"))
        {
            int invoiceId;
            if (int.TryParse(query["id"].ToString(), out invoiceId))
            {
                Invoice = await _salesService.GetByIDAsync(invoiceId);
                ItemTransaction = new ObservableCollection<SalesInvoiceTransaction>(Invoice.InvoiceTransactions);
            }
            if (Invoice.party != null)
                Party = Invoice.party;
        }

        IsDataLoaded = true;
        IsBusy = false;
    }

    [RelayCommand]
    private async Task ClosePage()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    public async Task ItemDetails(SalesInvoiceTransaction transaction)
    {
        await Shell.Current.GoToAsync($"{nameof(ItemDetailsPage)}?id={transaction.item_id}");
    }

    //Follwoing code not working while tapping on mobile number
    [RelayCommand]
    public async Task OnPhoneNumberTapped(string mobileNumber)
    {
        var phoneNumber = string.Format("tel:{0}", mobileNumber);
        if (PhoneDialer.IsSupported)
        {
            PhoneDialer.Open(phoneNumber);
        }
        else
        {
            await Shell.Current.DisplayAlert("Oops!", "Phone dialing is not supported on this device.", "Got it!");
        }
    }

    [RelayCommand]
    public void ExportPdf()
    {

    }
}
