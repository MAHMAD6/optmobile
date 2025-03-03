using Microsoft.Extensions.Logging;
using OptMobile.Retailer.Helpers;
using OptMobile.Retailer.Models;
using System.Text.Json;

namespace OptMobile.Retailer.Services;

public class SalesService : ISalesService
{
    private readonly ILogger<PartyService> _logger;
    private readonly AppVersionService _appVersionService;
    private readonly ApiConfigService _apiConfigService;
    private readonly JsonSerializerOptions _serializerOptions;
    
    public SalesService(ILogger<PartyService> logger, AppVersionService appVersionService, ApiConfigService apiConfigService)
    {
        _logger = logger;
        _appVersionService = appVersionService;
        _apiConfigService = apiConfigService;
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
    }

    public async Task<SalesInvoiceMaster> GetByCodeAsync(string code)
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            _logger.LogWarning("No internet access.");
            return new SalesInvoiceMaster();
        }
        try
        {
            string Token = Preferences.Default.Get<string>(SessionKeys.TOKEN, string.Empty);
            string Tenant = Preferences.Default.Get<string>(SessionKeys.TENANT, string.Empty);
            string baseUrl = _apiConfigService.BaseApiUrl;

            var client = new HttpClient();
            client.BaseAddress = new System.Uri(baseUrl);
            client.DefaultRequestHeaders.Add(ApiHeaderEndpoints.APP_VERSION, _appVersionService.AppVersion);
            client.DefaultRequestHeaders.Add(ApiHeaderEndpoints.ACCEPT, ApiHeaderEndpoints.CONTENT_TYPE);
            client.DefaultRequestHeaders.Add(ApiHeaderEndpoints.AUTHORIZATION, Token);
            client.DefaultRequestHeaders.Add(ApiHeaderEndpoints.TENANT, Tenant);

            var response = await client.GetAsync($"/{SalesEndpoints.GetByCode}/{code}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var resultSet = JsonSerializer
                      .Deserialize<ResponseFormatter<ResultSetData<SalesInvoiceMaster>>>(content, _serializerOptions);
            return resultSet?.data?.resultSet ?? new SalesInvoiceMaster();
        }
        catch (HttpRequestException httpEx)
        {
            _logger.LogError(httpEx, OptMedErrorMessage.NetworkError);
            return new SalesInvoiceMaster();
        }
        catch (JsonException jsonEx)
        {
            _logger.LogError(jsonEx, OptMedErrorMessage.JsonDeserializationError);
            return new SalesInvoiceMaster();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, OptMedErrorMessage.UnexpectedError);
            return new SalesInvoiceMaster();
        }
    }

    public async Task<SalesInvoiceMaster> GetByIDAsync(int id)
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            _logger.LogWarning("No internet access.");
            return new SalesInvoiceMaster();
        }
        try
        {
            string Token = Preferences.Default.Get<string>(SessionKeys.TOKEN, string.Empty);
            string Tenant = Preferences.Default.Get<string>(SessionKeys.TENANT, string.Empty);
            string baseUrl = _apiConfigService.BaseApiUrl;

            var client = new HttpClient();
            client.BaseAddress = new System.Uri(baseUrl);
            client.DefaultRequestHeaders.Add(ApiHeaderEndpoints.APP_VERSION, _appVersionService.AppVersion);
            client.DefaultRequestHeaders.Add(ApiHeaderEndpoints.ACCEPT, ApiHeaderEndpoints.CONTENT_TYPE);
            client.DefaultRequestHeaders.Add(ApiHeaderEndpoints.AUTHORIZATION, Token);
            client.DefaultRequestHeaders.Add(ApiHeaderEndpoints.TENANT, Tenant);

            var response = await client.GetAsync($"/{SalesEndpoints.GetById}/{id}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var resultSet = JsonSerializer
                      .Deserialize<ResponseFormatter<ResultSetData<List<SalesInvoiceMaster>>>>(content, _serializerOptions);
            return resultSet?.data?.resultSet[0] ?? new SalesInvoiceMaster();
        }
        catch (HttpRequestException httpEx)
        {
            _logger.LogError(httpEx, OptMedErrorMessage.NetworkError);
            return new SalesInvoiceMaster();
        }
        catch (JsonException jsonEx)
        {
            _logger.LogError(jsonEx, OptMedErrorMessage.JsonDeserializationError);
            return new SalesInvoiceMaster();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, OptMedErrorMessage.UnexpectedError);
            return new SalesInvoiceMaster();
        }
    }

    public async Task<List<SalesInvoiceMaster>> GetByPartyIDAsync(int id)
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            _logger.LogWarning("No internet access.");
            return new List<SalesInvoiceMaster>();
        }
        try
        {
            string Token = Preferences.Default.Get<string>(SessionKeys.TOKEN, string.Empty);
            string Tenant = Preferences.Default.Get<string>(SessionKeys.TENANT, string.Empty);
            string baseUrl = _apiConfigService.BaseApiUrl;

            var client = new HttpClient();
            client.BaseAddress = new System.Uri(baseUrl);
            client.DefaultRequestHeaders.Add(ApiHeaderEndpoints.APP_VERSION, _appVersionService.AppVersion);
            client.DefaultRequestHeaders.Add(ApiHeaderEndpoints.ACCEPT, ApiHeaderEndpoints.CONTENT_TYPE);
            client.DefaultRequestHeaders.Add(ApiHeaderEndpoints.AUTHORIZATION, Token);
            client.DefaultRequestHeaders.Add(ApiHeaderEndpoints.TENANT, Tenant);

            var response = await client.GetAsync($"/{SalesEndpoints.GetByPartyId}/{id}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var resultSet = JsonSerializer
                      .Deserialize<ResponseFormatter<ResultSetData<List<SalesInvoiceMaster>>>>(content, _serializerOptions);
            return resultSet?.data?.resultSet ?? new List<SalesInvoiceMaster>();
        }
        catch (HttpRequestException httpEx)
        {
            _logger.LogError(httpEx, OptMedErrorMessage.NetworkError);
            return new List<SalesInvoiceMaster>();
        }
        catch (JsonException jsonEx)
        {
            _logger.LogError(jsonEx, OptMedErrorMessage.JsonDeserializationError);
            return new List<SalesInvoiceMaster>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, OptMedErrorMessage.UnexpectedError);
            return new List<SalesInvoiceMaster>();
        }
    }
}
