using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OptMobile.Retailer.Helpers;
using OptMobile.Retailer.Models;
using OptMobile.Retailer.Services;
using OptMobile.Retailer.Views;
using System.Collections.ObjectModel;

namespace OptMobile.Retailer.ViewModels;

public partial class HomeViewModel : BaseViewModel
{
    private readonly IItemService _itemService;

    public HomeViewModel(IItemService itemService)
    {
        _itemService = itemService;
        LoadHomeDataCommand.Execute(null);
    }

    [ObservableProperty]
    private ImageSource capturedImageSource;

    [ObservableProperty]
    private ObservableCollection<ItemMaster> items = new();
    [ObservableProperty]
    private ObservableCollection<ItemMaster> populars = new();
    [ObservableProperty]
    private ObservableCollection<ItemMaster> featrues = new();
    [ObservableProperty]
    private ObservableCollection<ItemMaster> recommended = new();
    [ObservableProperty]
    private ItemMaster selectedItem = new();
    [ObservableProperty]
    private ObservableCollection<ItemMaster> filteredItems;
    [ObservableProperty]
    private ObservableCollection<ItemMaster> cart = new();
    [ObservableProperty]
    private string searchQuery;

    [ObservableProperty]
    private ObservableCollection<DrugTypeMaster> drugTypes = new();

    public List<string> Brands => new List<string> { "Alloes", "Leeford", "Macleods", "Mankind", "Aristo" };

    [RelayCommand]
    public async Task LoadHomeData()
    {
        IsBusy = true;
        Populars = new ObservableCollection<ItemMaster>((await _itemService.GetByFeatureAsync(CuratedType.Popular.ToString())).Take(10));
        Recommended = new ObservableCollection<ItemMaster>((await _itemService.GetByFeatureAsync(CuratedType.Recommended.ToString())).Take(10));
        Featrues = new ObservableCollection<ItemMaster>((await _itemService.GetByFeatureAsync(CuratedType.Featrues.ToString())).Take(10));
        IsBusy = false;
        
        DrugTypes = new ObservableCollection<DrugTypeMaster>(await _itemService.GetDrugTypeAsync());

    }

    [RelayCommand]
    private async void FrameClick()
    {
        if (Items != null)
        {
            var navigationParameter = new Dictionary<string, object>
                {
                    { "Items", Items }
                };
            await Shell.Current.GoToAsync($"{nameof(ItemSearchPage)}", navigationParameter);
        }
    }

    [RelayCommand]
    private async void DetailPageNav(ItemMaster selectedProduct)
    {
        if (selectedProduct != null)
        {
            var navigationParameter = new Dictionary<string, object>
                {
                    { "SelectedProduct", selectedProduct }
                };
            await Shell.Current.GoToAsync($"{nameof(ItemDetailsPage)}?id={selectedProduct.item_id}", navigationParameter);
        }
    }


    [RelayCommand]
    private void SeeAllPopular(CuratedType curatedType)
    {
        string SearchType = curatedType.ToString();
        if (!string.IsNullOrWhiteSpace(SearchType))
        {
            Shell.Current.GoToAsync($"{nameof(ItemSearchPage)}?{QueryPropertyKeys.TYPE}={SearchType}", true);
        }
    }

    [RelayCommand]
    private void CategoryWiseItem(int id)
    {
        if (id > 0)
        {
            Shell.Current.GoToAsync($"{nameof(ItemSearchPage)}?{QueryPropertyKeys.DRUGTYPE_ID}={id}", true);
        }
    }

    [RelayCommand]
    private void CartPageNavigation()
    {
        Shell.Current.GoToAsync($"{nameof(CartPage)}", true);        
    }

    //Following code is commented because it is not used in the project.

    //public List<ItemMaster> Properties = ItemService.AllItems;
    //public ItemMaster SelectedProperty { get; set; }

    //public ICommand PropertySelected => new Command(obj =>
    //{
    //    if (SelectedProperty != null)
    //        //Application.Current.MainPage.Navigation.PushAsync(new ItemDetailsPage(SelectedProperty));

    //        SelectedProperty = null;
    //});


    [RelayCommand]
    public async Task Search()
    {
        await Shell.Current.GoToAsync($"{nameof(ItemSearchPage)}", true);
    }

    [RelayCommand]
    public void Location()
    {
        //_navigation.PushAsync(new LocationSearchPage());
    }

    [RelayCommand]
    public async Task Profile()
    {

    }

    [RelayCommand]
    public async Task OpenCamera()
    {
        try
        {
            //// Request permissions to use the camera
            //var cameraResult = await MediaPicker.RequestCameraPermissionAsync();
            //if (cameraResult != PermissionStatus.Granted)
            //{
            //    await Shell.Current.DisplayAlert("Permission Denied", "Camera access is required to take photos", "OK");
            //    return;
            //}

            // Take a photo using the camera
            var photo = await MediaPicker.CapturePhotoAsync();

            if (photo != null)
            {
                // Convert the photo to a stream and display it in the Image control                
                var stream = await photo.OpenReadAsync();
                CapturedImageSource = ImageSource.FromStream(() => stream);

                // Save the image to memory (byte array or temporary file)
                //var byteArray = await ConvertStreamToByteArray(stream);

                //We use this stream to display the photo in the Image control(CapturedImage).
                //<Image x:Name="CapturedImage" HeightRequest="300" WidthRequest="300" />
                //CapturedImage.Source = ImageSource.FromStream(() => stream);
            }
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
        }
    }

    [RelayCommand]
    public async Task OpenCreateInvoice()
    {
        await Shell.Current.GoToAsync($"{nameof(CreateInvoicePage)}", true);
    }

    private async Task<byte[]> ConvertStreamToByteArray(Stream stream)
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            await stream.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
