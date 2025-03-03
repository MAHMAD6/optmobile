using Microsoft.Extensions.Logging;
using OptMobile.Retailer.Helpers;
using OptMobile.Retailer.Models;
using System.Text.Json;

namespace OptMobile.Retailer.Services;

public class ApiConfigService
{
    private const string ApiUrlKey = "BaseApiUrl";
    private readonly ILogger<ApiConfigService> _logger;
    public string BaseApiUrl
    {
        get => Preferences.Get(ApiUrlKey, string.Empty);
        private set => Preferences.Set(ApiUrlKey, value);
    }

    public ApiConfigService(ILogger<ApiConfigService> logger)
    {
        _logger = logger;
    }

    public async Task InitializeApiBaseUrlAsync()
    {
        try
        {
            if (!string.IsNullOrEmpty(BaseApiUrl))
            {
                // URL is already set, no need to call API Gateway
                return;
            }

            // Replace this with your actual API Gateway endpoint
            var _httpClient = new HttpClient();
            var response = await _httpClient.GetAsync(ApiUrlEndpoints.GATEWAY_URL);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ApiGatewayResponse>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (result != null && !string.IsNullOrEmpty(result.url))
            {
                
                BaseApiUrl = result.url;
                ApiUrlEndpoints.BASE_URL = BaseApiUrl;
                _logger.LogInformation("API Base URL initialized: {BaseUrl}", BaseApiUrl);
            }
            else
            {
                throw new Exception("API Gateway response is invalid.");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to fetch API Base URL from Gateway.");
            throw new Exception("Unable to initialize the API URL. Please try again.", ex);
        }
    }

    // Reset the API Base URL (used on logout)
    public void ResetApiBaseUrl()
    {
        Preferences.Remove(ApiUrlKey);
        _logger.LogInformation("API Base URL reset.");
    }
}
