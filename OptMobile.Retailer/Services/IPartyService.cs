using OptMobile.Retailer.Models;

namespace OptMobile.Retailer.Services;

public interface IPartyService
{
    Task<PartyMaster> GetPartyByIDAsync(int id);
    Task<List<PartyMaster>> GetAllPartyAsync();
}
