using OptMobile.Retailer.Models;

namespace OptMobile.Retailer.Services;

public interface IItemService
{
    Task<ItemMaster> GetByIDAsync(int id);
    Task<List<ItemMaster>> GetAllAsync();
    Task<List<ItemMaster>> GetByNameAsync(string name);
    Task<List<ItemMaster>> GetByFeatureAsync(string name);
    Task<List<ItemMaster>> GetByDrugTypeIDAsync(int id);
    Task<List<DrugTypeMaster>> GetDrugTypeAsync();
}
