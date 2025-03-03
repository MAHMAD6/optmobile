using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OptMobile.Retailer.Helpers;
using OptMobile.Retailer.Models;
using OptMobile.Retailer.Services;
using OptMobile.Retailer.Views;
using System.Net.Http.Json;
using System.Text.Json;

namespace OptMobile.Retailer.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    private readonly ApiConfigService _apiConfigService;

    public LoginViewModel(ApiConfigService apiConfigService)
    {
        _apiConfigService = apiConfigService;

        string userCode = Preferences.Default.Get<string>(SessionKeys.TOKEN, string.Empty);
        //if (!string.IsNullOrEmpty(userCode))
        //{
        //    CheckAlreadyLoggedIn();
        //}
        if (string.IsNullOrEmpty(userCode))
        {
            CheckAlreadyLoggedIn();
        }
    }

    public async void CheckAlreadyLoggedIn()
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }

    [ObservableProperty]
    public string mobileNumber = "";

    [RelayCommand]
    public async Task Login()
    {
        if (string.IsNullOrWhiteSpace(MobileNumber))
        {
            await Shell.Current.DisplayAlert("Oops!", "It looks like you forgot to enter your mobile number. Please provide it to continue.", "Got it!");
            return;
        }
        else if (MobileNumber.Length < 10)
        {
            await Shell.Current.DisplayAlert("Oops!", "It looks like your number is too short. Please enter a valid 10-digit number.", "Got it!");
            return;
        }

        await _apiConfigService.InitializeApiBaseUrlAsync();
        CallLoginApi();
    }

    private async void CallLoginApi()
    {
        try
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return;

            var login = new SignUpMaster()
            {
                mobile = MobileNumber,
                ismobile = true
            };
            var client = new HttpClient();
            client.BaseAddress = new System.Uri(_apiConfigService.BaseApiUrl);
            client.DefaultRequestHeaders.Add(ApiHeaderEndpoints.ACCEPT, ApiHeaderEndpoints.CONTENT_TYPE);

            var msg = new HttpRequestMessage(HttpMethod.Post, $"/{LoginEndpoints.LoginByMobile}");
            msg.Content = JsonContent.Create<SignUpMaster>(login);
            var response = await client.SendAsync(msg);
            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer
                              .DeserializeAsync<SignUpResponse>(responseStream, new JsonSerializerOptions
                              {
                                  PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                              });

                    Preferences.Default.Set<string>(SessionKeys.USER_CODE, data.user_code);
                    await Shell.Current.GoToAsync($"//{nameof(OtpPage)}");
                }
            }
        }
        catch (Exception)
        {
            return;
        }
    }

    [RelayCommand]
    public async void CreateAccount()
    {
        //await Shell.Current.GoToAsync($"{nameof(SignUpPage)}");        
        await Shell.Current.DisplayAlert("Alert", "Please contact administrator", "Okay");
    }
}
