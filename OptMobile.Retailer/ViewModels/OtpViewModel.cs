using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OptMobile.Retailer.Helpers;
using OptMobile.Retailer.Models;
using OptMobile.Retailer.Services;
using OptMobile.Retailer.Views;
using System.Net.Http.Json;
using System.Text.Json;

namespace OptMobile.Retailer.ViewModels;

public partial class OtpViewModel : BaseViewModel
{
    private readonly ApiConfigService _apiConfigService;
    private int _remainingTime = 30;

    public OtpViewModel(ApiConfigService apiConfigService)
    {
        _apiConfigService = apiConfigService;

        OtpResendTimer();
    }

    [ObservableProperty]
    public string firstNumber = "";
    [ObservableProperty]
    public string secondNumber = "";
    [ObservableProperty]
    public string thirdNumber = "";
    [ObservableProperty]
    public string fourthNumber = "";

    [ObservableProperty]
    public bool isResendCodeVisible = false;
    [ObservableProperty]
    public bool isOtpTimerVisible = true;
    [ObservableProperty]
    public bool isCancelVisible = false;
    [ObservableProperty]
    public string resendCodeTimerText = "";

    private void OtpResendTimer()
    {
        Device.StartTimer(TimeSpan.FromSeconds(1), () =>
        {
            if (_remainingTime > 1)
            {
                _remainingTime--;
                ResendCodeTimerText = string.Format("Resend code in : {0}", _remainingTime.ToString());
            }
            else
            {
                IsOtpTimerVisible = false;
                IsResendCodeVisible = true;
                IsCancelVisible = true;
                return false;  // Stop the timer
            }

            return true;  // Continue the timer
        });
    }

    [RelayCommand]
    public async Task SubmitOtp()
    {
        if (string.IsNullOrWhiteSpace(Convert.ToString(FirstNumber))
            || string.IsNullOrWhiteSpace(Convert.ToString(SecondNumber))
            || string.IsNullOrWhiteSpace(Convert.ToString(ThirdNumber))
            || string.IsNullOrWhiteSpace(Convert.ToString(FourthNumber)))
        {
            await Shell.Current.DisplayAlert("Oops!", "It looks like you forgot to enter otp. Please provide it to continue.", "Got it!");
            return;
        }

        string userCode = Preferences.Default.Get<string>(SessionKeys.USER_CODE, string.Empty);
        string concatenatedString = FirstNumber + SecondNumber + ThirdNumber + FourthNumber;
        int otpValue = int.Parse(concatenatedString);

        CallOtpApi(userCode, otpValue);
    }

    public async void CallOtpApi(string userCode, int otp)
    {
        try
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                return;

            var otpMaster = new OtpMaster()
            {
                user_code = userCode,
                otp = otp,
                fcm_token = ""
            };

            var client = new HttpClient();
            client.BaseAddress = new System.Uri(_apiConfigService.BaseApiUrl);
            client.DefaultRequestHeaders.Clear();

            client.DefaultRequestHeaders.Add(ApiHeaderEndpoints.ACCEPT, ApiHeaderEndpoints.CONTENT_TYPE);

            var msg = new HttpRequestMessage(HttpMethod.Post, $"/{LoginEndpoints.LoginOtpValidate}");
            msg.Content = JsonContent.Create<OtpMaster>(otpMaster);
            var response = await client.SendAsync(msg).ConfigureAwait(false); //ConfigureAwait(false) => if you're calling SendAsync in a method where you shouldn't block the main thread
            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer
                              .DeserializeAsync<LoginResponse>(responseStream, new JsonSerializerOptions
                              {
                                  PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                              });

                    Preferences.Default.Set<string>(SessionKeys.TOKEN, data.token);
                    Preferences.Default.Set<string>(SessionKeys.REFRESH_TOKEN, data.refreshToken);
                    Preferences.Default.Set<string>(SessionKeys.USER_CODE, data.userCode);
                    Preferences.Default.Set<string>(SessionKeys.TENANT, data.tenant);

                    await Shell.Current.GoToAsync($"//{nameof(HomePage)}");

                    ClearOtpFields();
                }
            }

            return;
        }
        catch (Exception)
        {
            return;
        }
    }

    [RelayCommand]
    public void ResendOtp()
    {
        _remainingTime = 30;
        IsOtpTimerVisible = true;
        IsResendCodeVisible = false;
        IsCancelVisible = false;
        ResendCodeTimerText = string.Format("Resend code in : {0}", _remainingTime.ToString());
        OtpResendTimer();
    }

    [RelayCommand]
    public async Task CancelOtp()
    {
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }

    public void ClearOtpFields()
    {
        FirstNumber = string.Empty;
        SecondNumber = string.Empty;
        ThirdNumber = string.Empty;
        FourthNumber = string.Empty;
    }
}
