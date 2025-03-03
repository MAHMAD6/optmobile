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
    public partial class CartViewModel : BaseViewModel
    {
        
        [RelayCommand]
        private async void Back()
        {
            await Shell.Current.GoToAsync("..");
        }
        
        public CartViewModel()
        {
        }
    }
}
