** Project Architecture : A clean and modular folder structure
    - ProjectName
        - Models/                 # Contains all models that represent the data
        - Services/               # Contains API services and HTTP client logic
        - ViewModels/             # Contains ViewModels for MVVM binding
        - Views/                  # Contains the UI Pages (Views)
        - Resources/              # Contains styles, colors, images, etc.
        - Helpers/                # Utility classes, extensions, etc.
        - App.xaml.cs             # Main App file
        - App.xaml                # App.xaml file for global resources

** MAUI Awesome Toolkit :: https://github.com/jsuarezruiz/awesome-dotnet-maui

** BottomSheet :: 
    <?xml version="1.0" encoding="utf-8" ?>
    <resources>
	    <style name="Maui.MainTheme" parent="Theme.Material3.DayNight"></style>
    </resources>

** Barcode Scanner
	1. https://github.com/afriscic/BarcodeScanning.Native.Maui
	2. https://github.com/thomasgalliker/CameraScanner.Maui

** Camera
	1. https://github.com/hjam40/Camera.MAUI



Tab ::
	** Sharpnado.Tabs
		1. https://www.nuget.org/packages/Sharpnado.Tabs.Maui#readme-body-tab
		2. https://github.com/roubachof/Sharpnado.Tabs

** Platfrom specific button design
	<Button
        Grid.Row="0"
        Grid.RowSpan="2"
        Grid.Column="2"
        BackgroundColor="{StaticResource OptCardLight}"
        Command="{Binding PaymentCommand}"
        HeightRequest="30"
        Text="Payment">
        <Button.Padding>
            <OnPlatform x:TypeArguments="Thickness">
                <On Platform="iOS" Value="10,10,10,10" />
                <On Platform="Android" Value="10,5,10,5" />
            </OnPlatform>
        </Button.Padding>
    </Button>

** Set font from IconFont class
     <Label
        Margin="0,0,3,0"
        FontFamily="FontAwesomeSolid"
        FontSize="16"
        Text="{x:Static helper:IconFont.Whatsapp}"
        TextColor="Gray" />

** Shell Navigation
    route       =>	The route hierarchy will be searched for the specified route, upwards from the current position. The matching page will be pushed to the navigation stack.
    /route      =>	The route hierarchy will be searched from the specified route, downwards from the current position. The matching page will be pushed to the navigation stack.
    //route     =>	The route hierarchy will be searched for the specified route, upwards from the current position. The matching page will replace the navigation stack.
    ///route    =>	The route hierarchy will be searched for the specified route, downwards from the current position. The matching page will replace the navigation stack.

** Throw error & Catch Exception    
        catch (HttpRequestException httpEx)
        {
            _logger.LogError(httpEx, OptMedErrorMessage.NetworkError);
            throw new NetworkException(OptMedErrorMessage.NetworkError, httpEx);
        }
        catch (JsonException jsonEx)
        {
            _logger.LogError(jsonEx, OptMedErrorMessage.JsonDeserializationError);
            throw new SerializationException(OptMedErrorMessage.JsonDeserializationError, jsonEx);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, OptMedErrorMessage.UnexpectedError);
            return new List<YourObjectModel>();
        }

** SearchHandler
    1. CustomerSearchHandler => CustomersPage.xaml
        <!--<Shell.SearchHandler>
        <searchHandler:CustomerSearchHandler
                ClearIcon="close"
                DisplayMemberName="PartyName"
                NavigationRoute="CustomerInvoicePage"
                Parties="{x:Static viewModel:CustomerViewModel.SearchParties}"
                Placeholder="Search parties"
                QueryIcon="search"
                SearchBoxVisibility="Collapsible"
                ShowsResults="True">
                <searchHandler:CustomerSearchHandler.ItemTemplate>
                    <DataTemplate x:DataType="model:PartyMaster">
                        <Frame BorderColor="White">
                            <HorizontalStackLayout Spacing="5">
                                <Label FontSize="Medium" Text="{Binding party_name}" />
                            </HorizontalStackLayout>
                        </Frame>
                    </DataTemplate>
                </searchHandler:CustomerSearchHandler.ItemTemplate>
            </searchHandler:CustomerSearchHandler>
        </Shell.SearchHandler>-->

** Serialization using System.Text.Json
    
    private readonly JsonSerializerOptions _serializerOptions;
    _serializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            //PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        };

** Bind Data From Service Or Call Any Method On Page Load Constructor
    1. Task.Run(async () => lstViewControlName.ItemSource = await _anyServiceName.GetDataAsync());

** Use Font Icon For Button
    <ImageButton
        Command="{Binding Source={RelativeSource AncestorType={x:Type viewmodels:HomeViewModel}}, Path=IncrementPurchaseQuantityCommand}"
        CommandParameter="{Binding .}"
        HeightRequest="30"
        WidthRequest="30">
        <ImageButton.Source>
            <FontImageSource
                FontFamily="IconFontTypes"
                Glyph="{x:Static helpers:IconFont.Plus}"
                Size="20" />
        </ImageButton.Source>
    </ImageButton>

** IQueryAttributable
    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("partyid") && query["partyid"] != null)
        {
            int partyId;
            if (int.TryParse(query["partyid"].ToString(), out partyId))
            {
                Invoices = new ObservableCollection<SalesInvoiceMaster>(await _salesService.GetByPartyIDAsync(partyId));
            }
        }
    }