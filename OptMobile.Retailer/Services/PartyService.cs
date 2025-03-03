using Microsoft.Extensions.Logging;
using OptMobile.Retailer.Helpers;
using OptMobile.Retailer.Models;
using System.Text.Json;

namespace OptMobile.Retailer.Services;

public class PartyService : IPartyService
{
    private readonly ILogger<PartyService> _logger;
    private readonly AppVersionService _appVersionService;
    private readonly ApiConfigService _apiConfigService;
    private readonly JsonSerializerOptions _serializerOptions;

    public PartyService(ILogger<PartyService> logger, AppVersionService appVersionService, ApiConfigService apiConfigService)
    {
        _logger = logger;
        _appVersionService = appVersionService;
        _apiConfigService = apiConfigService;
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
    }

    public async Task<PartyMaster> GetPartyByIDAsync(int id)
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            _logger.LogWarning("No internet access.");
            return new PartyMaster();
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

            var response = await client.GetAsync($"/{PartyEndpoints.GetPartyById}/{id}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var resultSet = JsonSerializer
                      .Deserialize<ResponseFormatter<ResultSetData<List<PartyMaster>>>>(content, _serializerOptions);
            return resultSet?.data?.resultSet[0] ?? new PartyMaster();
        }
        catch (HttpRequestException httpEx)
        {
            _logger.LogError(httpEx, OptMedErrorMessage.NetworkError);
            return new PartyMaster();
        }
        catch (JsonException jsonEx)
        {
            _logger.LogError(jsonEx, OptMedErrorMessage.JsonDeserializationError);
            return new PartyMaster();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, OptMedErrorMessage.UnexpectedError);
            return new PartyMaster();
        }
    }

    public async Task<List<PartyMaster>> GetAllPartyAsync()
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            _logger.LogWarning("No internet access.");
            return new List<PartyMaster>();
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

            var response = await client.GetAsync($"/{PartyEndpoints.GetPartyAll}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var resultSet = JsonSerializer
                      .Deserialize<ResponseFormatter<ResultSetData<List<PartyMaster>>>>(content, _serializerOptions);
            return resultSet?.data?.resultSet ?? new List<PartyMaster>();
        }
        catch (HttpRequestException httpEx)
        {
            _logger.LogError(httpEx, OptMedErrorMessage.NetworkError);
            return new List<PartyMaster>();
        }
        catch (JsonException jsonEx)
        {
            _logger.LogError(jsonEx, OptMedErrorMessage.JsonDeserializationError);
            return new List<PartyMaster>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, OptMedErrorMessage.UnexpectedError);
            return new List<PartyMaster>();
        }
    }

    public static List<InvoiceMaster> AllInvoices => new List<InvoiceMaster>
    {
        new InvoiceMaster
        {
            InvoiceID = 1,
            PartyID = 1,
            InvoiceCode = "PS-1001",
            InvoiceDate = DateOnly.FromDateTime(DateTime.Now.Date),
            InvoiceAmount = 100,
            BalanceAmount = 0,
            IsMrNameVisible = true,
        },
        new InvoiceMaster
        {
            InvoiceID = 2,
            PartyID = 1,
            InvoiceCode = "PS-1002",
            InvoiceDate = DateOnly.FromDateTime(DateTime.Now.Date.AddDays(-4)),
            InvoiceAmount = 200,
            BalanceAmount = 200,
            IsMrNameVisible = true,
        },
        new InvoiceMaster
        {
            InvoiceID = 3,
            PartyID = 1,
            InvoiceCode = "PS-1003",
            InvoiceDate = DateOnly.FromDateTime(DateTime.Now.Date.AddDays(-5)),
            InvoiceAmount = 500,
            BalanceAmount = 500,
            IsMrNameVisible = false,
        },
        new InvoiceMaster
        {
            InvoiceID = 4,
            PartyID = 2,
            InvoiceCode = "PS-1004",
            InvoiceDate = DateOnly.FromDateTime(DateTime.Now.Date.AddDays(-7)),
            InvoiceAmount = 400,
            BalanceAmount = 400,
            IsMrNameVisible = false,
        },
        new InvoiceMaster
        {
            InvoiceID = 5,
            PartyID = 2,
            InvoiceCode = "PS-1005",
            InvoiceDate = DateOnly.FromDateTime(DateTime.Now.Date.AddDays(-8)),
            InvoiceAmount = 800,
            BalanceAmount = 560,
            IsMrNameVisible = true,
        },
        new InvoiceMaster
        {
            InvoiceID = 6,
            PartyID = 2,
            InvoiceCode = "PS-1006",
            InvoiceDate = DateOnly.FromDateTime(DateTime.Now.Date.AddDays(-10)),
            InvoiceAmount = 750,
            BalanceAmount = 280,
            IsMrNameVisible = true,
        },
        new InvoiceMaster
        {
            InvoiceID = 7,
            PartyID = 2,
            InvoiceCode = "PS-1007",
            InvoiceDate = DateOnly.FromDateTime(DateTime.Now.Date.AddDays(-10)),
            InvoiceAmount = 750,
            BalanceAmount = 280,
            IsMrNameVisible = true,
        },
        new InvoiceMaster
        {
            InvoiceID = 8,
            PartyID = 2,
            InvoiceCode = "PS-1008",
            InvoiceDate = DateOnly.FromDateTime(DateTime.Now.Date.AddDays(-10)),
            InvoiceAmount = 750,
            BalanceAmount = 280,
            IsMrNameVisible = true,
        },
        new InvoiceMaster
        {
            InvoiceID = 9,
            PartyID = 3,
            InvoiceCode = "PS-1009",
            InvoiceDate = DateOnly.FromDateTime(DateTime.Now.Date.AddDays(-10)),
            InvoiceAmount = 750,
            BalanceAmount = 280,
            IsMrNameVisible = false,
        },
        new InvoiceMaster
        {
            InvoiceID = 10,
            PartyID = 4,
            InvoiceCode = "PS-1010",
            InvoiceDate = DateOnly.FromDateTime(DateTime.Now.Date.AddDays(-10)),
            InvoiceAmount = 750,
            BalanceAmount = 280,
            IsMrNameVisible = true,
        },
    };
}
