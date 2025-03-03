using Microsoft.Extensions.Logging;
using OptMobile.Retailer.Helpers;
using OptMobile.Retailer.Models;
using System.Text.Json;

namespace OptMobile.Retailer.Services;

public class ItemService : IItemService
{
    private readonly ILogger<ItemService> _logger;
    private readonly AppVersionService _appVersionService;
    private readonly ApiConfigService _apiConfigService;
    private readonly JsonSerializerOptions _serializerOptions;

    public ItemService(ILogger<ItemService> logger, AppVersionService appVersionService, ApiConfigService apiConfigService)
    {
        _logger = logger;
        _appVersionService = appVersionService;
        _apiConfigService = apiConfigService;
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }
    public static List<ItemMaster> AllItems => new List<ItemMaster>
    {
        new ItemMaster
        {
            item_id = 1,
            item_code = "ITM-001",
            item_name="Zerodol-SP, IPCA",
            mrp=34078,
            image_url="https://cdn.pixabay.com/photo/2017/04/10/22/28/residence-2219972_1280.jpg",
        },
        new ItemMaster
        {
            item_id = 2,
            item_code = "ITM-002",
            item_name="Zerodol-MR, IPCA",
            mrp=34078,
            image_url="https://cdn.pixabay.com/photo/2017/04/10/22/28/residence-2219972_1280.jpg",
        },
        new ItemMaster
        {
            item_id = 3,
            item_code = "ITM-003",
            item_name="Coldfresh Pro Tab, Smart",
            mrp=34078,
            image_url="https://cdn.pixabay.com/photo/2017/04/10/22/28/residence-2219972_1280.jpg",
        },
        new ItemMaster
        {
            item_id = 4,
            item_code = "ITM-004",
            item_name="Ketoscore-6 Cream, Smart",
            mrp=34078,
            image_url="https://cdn.pixabay.com/photo/2017/04/10/22/28/residence-2219972_1280.jpg",
        },
        new ItemMaster
        {
            item_id = 5,
            item_code = "ITM-005",
            item_name="Aldigesic SP Tab, Alkem",
            mrp=34078,
            image_url="https://cdn.pixabay.com/photo/2017/04/10/22/28/residence-2219972_1280.jpg",
        },
        new ItemMaster
        {
            item_id = 6,
            item_code = "ITM-006",
            item_name="Clearbend 6 15cm, Om Surgical",
            mrp=34078,
            image_url="https://cdn.pixabay.com/photo/2017/04/10/22/28/residence-2219972_1280.jpg",
        },
        new ItemMaster
        {
            item_id = 7,
            item_code = "ITM-007",
            item_name="Ketoscore-6 Cream, Smart",
            mrp=34078,
            image_url="https://cdn.pixabay.com/photo/2017/04/10/22/28/residence-2219972_1280.jpg",
        },
        new ItemMaster
        {
            item_id = 8,
            item_code = "ITM-008",
            item_name="Ketoscore-6 Cream, Smart",
            mrp=34078,
            image_url="https://cdn.pixabay.com/photo/2017/04/10/22/28/residence-2219972_1280.jpg",
        },
    };

    public async Task<List<ItemMaster>> GetAllAsync()
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            _logger.LogWarning("No internet access.");
            return new List<ItemMaster>();
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

            var response = await client.GetAsync($"/{ItemEndpoints.GetAll}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var resultSet = JsonSerializer
                      .Deserialize<ResponseFormatter<ResultSetData<List<ItemMaster>>>>(content, _serializerOptions);
            return resultSet?.data?.resultSet ?? new List<ItemMaster>();
        }
        catch (HttpRequestException httpEx)
        {
            _logger.LogError(httpEx, OptMedErrorMessage.NetworkError);
            return new List<ItemMaster>();
        }
        catch (JsonException jsonEx)
        {
            _logger.LogError(jsonEx, OptMedErrorMessage.JsonDeserializationError);
            return new List<ItemMaster>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, OptMedErrorMessage.UnexpectedError);
            return new List<ItemMaster>();
        }
    }

    public async Task<ItemMaster> GetByIDAsync(int id)
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            _logger.LogWarning("No internet access.");
            return new ItemMaster();
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

            var response = await client.GetAsync($"/{ItemEndpoints.GetByID}/{id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var resultSet = JsonSerializer
                      .Deserialize<ResponseFormatter<ResultSetData<ItemMaster>>>(content, _serializerOptions);
            return resultSet?.data?.resultSet ?? new ItemMaster();
        }
        catch (HttpRequestException httpEx)
        {
            _logger.LogError(httpEx, OptMedErrorMessage.NetworkError);
            return new ItemMaster();
        }
        catch (JsonException jsonEx)
        {
            _logger.LogError(jsonEx, OptMedErrorMessage.JsonDeserializationError);
            return new ItemMaster();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, OptMedErrorMessage.UnexpectedError);
            return new ItemMaster();
        }
    }

    public async Task<List<ItemMaster>> GetByNameAsync(string name)
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            _logger.LogWarning("No internet access.");
            return new List<ItemMaster>();
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

            var response = await client.GetAsync($"/{ItemEndpoints.GetByName}/{name}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var resultSet = JsonSerializer
                      .Deserialize<ResponseFormatter<ResultSetData<List<ItemMaster>>>>(content, _serializerOptions);
            return resultSet?.data?.resultSet ?? new List<ItemMaster>();
        }
        catch (HttpRequestException httpEx)
        {
            _logger.LogError(httpEx, OptMedErrorMessage.NetworkError);
            return new List<ItemMaster>();
        }
        catch (JsonException jsonEx)
        {
            _logger.LogError(jsonEx, OptMedErrorMessage.JsonDeserializationError);
            return new List<ItemMaster>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, OptMedErrorMessage.UnexpectedError);
            return new List<ItemMaster>();
        }
    }

    public async Task<List<ItemMaster>> GetByFeatureAsync(string name)
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            _logger.LogWarning("No internet access.");
            return new List<ItemMaster>();
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

            var response = await client.GetAsync($"/{ItemEndpoints.GetByCurated}/{name}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var resultSet = JsonSerializer
                      .Deserialize<ResponseFormatter<ResultSetData<List<ItemMaster>>>>(content, _serializerOptions);
            return resultSet?.data?.resultSet ?? new List<ItemMaster>();
        }
        catch (HttpRequestException httpEx)
        {
            _logger.LogError(httpEx, OptMedErrorMessage.NetworkError);
            return new List<ItemMaster>();
        }
        catch (JsonException jsonEx)
        {
            _logger.LogError(jsonEx, OptMedErrorMessage.JsonDeserializationError);
            return new List<ItemMaster>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, OptMedErrorMessage.UnexpectedError);
            return new List<ItemMaster>();
        }
    }

    public async Task<List<ItemMaster>> GetByDrugTypeIDAsync(int id)
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            _logger.LogWarning("No internet access.");
            return new List<ItemMaster>();
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

            var response = await client.GetAsync($"/{ItemEndpoints.GetByDrugTypeID}/{id}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var resultSet = JsonSerializer
                      .Deserialize<ResponseFormatter<ResultSetData<List<ItemMaster>>>>(content, _serializerOptions);
            return resultSet?.data?.resultSet ?? new List<ItemMaster>();
        }
        catch (HttpRequestException httpEx)
        {
            _logger.LogError(httpEx, OptMedErrorMessage.NetworkError);
            return new List<ItemMaster>();
        }
        catch (JsonException jsonEx)
        {
            _logger.LogError(jsonEx, OptMedErrorMessage.JsonDeserializationError);
            return new List<ItemMaster>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, OptMedErrorMessage.UnexpectedError);
            return new List<ItemMaster>();
        }
    }

    public async Task<List<DrugTypeMaster>> GetDrugTypeAsync()
    {
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            _logger.LogWarning("No internet access.");
            return new List<DrugTypeMaster>();
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

            var response = await client.GetAsync($"/{ItemEndpoints.GetDrugTypeAll}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var resultSet = JsonSerializer
                      .Deserialize<ResponseFormatter<ResultSetData<List<DrugTypeMaster>>>>(content, _serializerOptions);
            return resultSet?.data?.resultSet ?? new List<DrugTypeMaster>();
        }
        catch (HttpRequestException httpEx)
        {
            _logger.LogError(httpEx, OptMedErrorMessage.NetworkError);
            return new List<DrugTypeMaster>();
        }
        catch (JsonException jsonEx)
        {
            _logger.LogError(jsonEx, OptMedErrorMessage.JsonDeserializationError);
            return new List<DrugTypeMaster>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, OptMedErrorMessage.UnexpectedError);
            return new List<DrugTypeMaster>();
        }
    }
}
