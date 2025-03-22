using CommunityToolkit.Mvvm.Input;
using OptMobile.Retailer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptMobile.Retailer.ViewModels
{
    public partial class AddItemsViewModel : BaseViewModel
    {
        [RelayCommand]
        private async void Newbranch()
        {
            await Shell.Current.GoToAsync($"{nameof(CreateBatch)}", true);
        }
    }
}
