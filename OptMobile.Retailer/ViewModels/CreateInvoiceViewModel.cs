using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OptMobile.Retailer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptMobile.Retailer.ViewModels
{
    public partial class CreateInvoiceViewModel : BaseViewModel
    {
        //[ObservableProperty]
        //private ObservableCollection<CollapsibleItem> items = new();
        [ObservableProperty]
        private bool _isEditIndexOpen = false;

        #region COMMANDS

        [RelayCommand]
        private void InvoiceEdit()
        {
            IsEditIndexOpen = !IsEditIndexOpen;
        }

        [RelayCommand]
        private void InvoiceSettings()
        {

        }

        [RelayCommand]
        private void Back()
        {

        }
        #endregion

    }
}
