
using CommunityToolkit.Mvvm.ComponentModel;

namespace OptMobile.Retailer.ViewModels;

public class CustomerCreateViewModel : ObservableObject
{
    private int _selectedViewModelIndex;

    // This property is the one that will be bound to the SelectedIndex of TabHostView and ViewSwitcher
    public int SelectedViewModelIndex
    {
        get => _selectedViewModelIndex;
        set => SetProperty(ref _selectedViewModelIndex, value);  // SetProperty automatically handles OnPropertyChanged
    }
}
