using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OptMobile.Retailer.Models;
using OptMobile.Retailer.Views;
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
        private bool isEditIndexOpen = false;
        [ObservableProperty]
        private bool isSearchOpen = false;
        [ObservableProperty]
        private bool isEditItemOpen = false;
        [ObservableProperty]
        private bool isAdditionalChargesListOpen = false;
        [ObservableProperty]
        private bool isAdditionalChargesOpen = false;
        [ObservableProperty]
        private bool isDiscountListOpen = false;
        [ObservableProperty]
        private bool isRoundOpen = false;
        [ObservableProperty]
        private bool isSelectBankdOpen = false;
        [ObservableProperty]
        private bool isNoteOpen = false;
        [ObservableProperty]
        private bool isCollectionVisible = true;
        [ObservableProperty]
        private double collectionTranslationY;

        [ObservableProperty]
        private bool isAdditionChargesVisible = true;
        [ObservableProperty]
        private double collectionAdditionalChargesTranslationY;

        [ObservableProperty]
        private bool addPrefixVisible = true;

        [ObservableProperty]
        private ObservableCollection<AdditionalCharge> additionalChargesList = new();

        public CreateInvoiceViewModel()
        {
            AdditionalChargesList = new ObservableCollection<AdditionalCharge>();
        }


        #region COMMANDS
        [RelayCommand]
        private void TogglePrefix()
        {
            AddPrefixVisible = !AddPrefixVisible;
        }

        [RelayCommand]
        private void OnToggleCollection()
        {
            IsCollectionVisible = !IsCollectionVisible;

            if (IsCollectionVisible)
            {
                // Slide in
                CollectionTranslationY = 0;
            }
            else
            {
                // Slide out
                CollectionTranslationY = GetCollectionHeight(); // You need to pass the height from the view
            }
        }
        public void SetCollectionHeight(double height)
        {
            CollectionTranslationY = height;
        }

        private double GetCollectionHeight()
        {
            // Return the height of the CollectionView (this should be set from the view)
            return CollectionTranslationY;
        }
        [RelayCommand]
        private void OnToggleCollectionAdditionalCharges()
        {
            IsAdditionChargesVisible = !IsAdditionChargesVisible;

            if (IsAdditionChargesVisible)
            {
                // Slide in
                CollectionAdditionalChargesTranslationY = 0;
            }
            else
            {
                // Slide out
                CollectionAdditionalChargesTranslationY = GetCollectionHeight(); // You need to pass the height from the view
            }
        }
        public void SetCollectionHeightAdditionalCharges(double height)
        {
            CollectionAdditionalChargesTranslationY = height;
        }

        private double GetCollectionHeightAdditionalCharges()
        {
            // Return the height of the CollectionView (this should be set from the view)
            return CollectionAdditionalChargesTranslationY;
        }

        [RelayCommand]
        private void InvoiceEdit()
        {
            IsEditIndexOpen = !IsEditIndexOpen;
        }
        [RelayCommand]
        private void SearchBottomSheet()
        {
            IsSearchOpen = !IsSearchOpen;
        }

        [RelayCommand]
        private async void AddItem()
        {
            await Shell.Current.GoToAsync($"{nameof(AddItems)}", true);
        }

        [RelayCommand]
        private async void DistributePage()
        {
            await Shell.Current.GoToAsync($"{nameof(DistributorPage)}", true);
        }

        [RelayCommand]
        private void EditItem()
        {
            IsEditItemOpen = !IsEditItemOpen;
        }

        [RelayCommand]
        private void AdditionChargesList()
        {
            IsAdditionalChargesListOpen = !IsAdditionalChargesListOpen;
        }
        [RelayCommand]
        private void AdditionCharges()
        {
            AdditionalChargesList.Add(new AdditionalCharge());
        }
        [RelayCommand]
        private void DiscountList()
        {
            IsDiscountListOpen = !IsDiscountListOpen;
        }
        [RelayCommand]
        private void RoundOff()
        {
            IsRoundOpen = !IsRoundOpen;
        }
        [RelayCommand]
        private void SelectBank()
        {
            IsSelectBankdOpen = !IsSelectBankdOpen;
        }
        [RelayCommand]
        private void Notes()
        {
            IsNoteOpen = !IsNoteOpen;
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
