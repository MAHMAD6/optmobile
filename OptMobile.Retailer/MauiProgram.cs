using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;
using OptMobile.Retailer.Services;
using OptMobile.Retailer.ViewModels;
using OptMobile.Retailer.Views;
using Plugin.Maui.BottomSheet.Hosting;
using Syncfusion.Licensing;
using Syncfusion.Maui.Core.Hosting;
using Syncfusion.Maui.Toolkit.Hosting;

namespace OptMobile.Retailer
{
    //Syncfusion 27.XX license key => MzU4NDY2MEAzMjM3MmUzMDJlMzBrdjNJSks1bk5Nbk9lblpVTHA3WUdwQStKVitnbkQzVFZvbGlSbUhCQmU0PQ==
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseBottomSheet()
                .ConfigureSyncfusionCore()
                .ConfigureSyncfusionToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                    fonts.AddFont("fontello.ttf", "Icons");
                    fonts.AddFont("Rubik-Regular.ttf", "RubikRegular");
                    fonts.AddFont("Rubik-Light.ttf", "RubikLight");

                    //Login Page Font and Icon
                    fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
                    fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
                    fonts.AddFont("Poppins-BoldItalic.ttf", "PoppinsBoldItalic");
                    fonts.AddFont("Poppins-Medium.ttf", "PoppinsMedium");
                    fonts.AddFont("materialdesignicons-webfont.ttf", "IconFontTypes");


                    fonts.AddFont("fa-solid-900.ttf", "FontAwesomeSolid");
                });

            SyncfusionLicenseProvider.RegisterLicense("MzU4NDY2MEAzMjM3MmUzMDJlMzBrdjNJSks1bk5Nbk9lblpVTHA3WUdwQStKVitnbkQzVFZvbGlSbUhCQmU0PQ==");

#if DEBUG
            builder.Logging.AddDebug();
#endif

            #region(Register Page ======================================================)
            builder.Services.AddTransient<CartPage>();
            builder.Services.AddTransient<CustomersPage>();
            builder.Services.AddTransient<CustomerDetailsPage>();
            builder.Services.AddTransient<NewCustomerPage>();

            builder.Services.AddTransient<CustomerInvoicePage>();
            builder.Services.AddTransient<InvoicesPage>();
            builder.Services.AddTransient<InvoiceDetailsPage>();
            builder.Services.AddTransient<ItemDetailsPage>();
            builder.Services.AddTransient<NewInvoicePage>();

            builder.Services.AddTransient<PaymentPage>();
            builder.Services.AddTransient<PaymentHistoryPage>();
            builder.Services.AddTransient<PaymentInvoicePage>();

            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<SignUpPage>();
            builder.Services.AddTransient<UserAccountPage>();

            builder.Services.AddTransient<CreateInvoicePage>();
            builder.Services.AddTransient<AddItems>();
            builder.Services.AddTransient<CreateBatch>();
            builder.Services.AddTransient<DistributorPage>();
            #endregion

            #region(Register ViewModel =================================================)
            builder.Services.AddSingleton<CustomerViewModel>();
            builder.Services.AddTransient<CustomerInvoiceViewModel>();
            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<InvoiceDetailsViewModel>();
            builder.Services.AddSingleton<ItemDetailsViewModel>();
            builder.Services.AddSingleton<ItemSearchViewModel>();
            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<OffersViewModel>();
            builder.Services.AddSingleton<OtpViewModel>();
            builder.Services.AddSingleton<PaymentViewModel>();
            builder.Services.AddSingleton<PaymentInvoiceViewModel>();
            builder.Services.AddSingleton<UserAccountViewModel>();
            builder.Services.AddSingleton<CreateInvoiceViewModel>();
            builder.Services.AddSingleton<CreateBatchViewModel>();
            builder.Services.AddSingleton<AddItemsViewModel>();
            builder.Services.AddSingleton<DistributionPageViewModel>();
            #endregion

            #region(Register Service ===================================================)
            //builder.Services.AddTransient<IAuthService, AuthService>();
            builder.Services.AddSingleton<IItemService, ItemService>();
            builder.Services.AddSingleton<IPartyService, PartyService>();
            builder.Services.AddSingleton<ISalesService, SalesService>();
            #endregion

            builder.Services.AddSingleton<INavigationService>(serviceProvider =>
            {
                var navigation = Shell.Current.Navigation;
                return new NavigationService(navigation);
            });



            // UI HANDLERS
            DatePickerHandler.Mapper.AppendToMapping(nameof(DatePicker), (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.Background = null; 
                handler.PlatformView.SetPadding(0, 0, 0, 0);
#endif
            });

           



            builder.Services.AddSingleton<ApiConfigService>();
            builder.Services.AddSingleton<AppVersionService>();

            // Enable version tracking
            VersionTracking.Track();

            return builder.Build();
        }
    }
}