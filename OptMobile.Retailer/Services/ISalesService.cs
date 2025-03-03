using OptMobile.Retailer.Models;

namespace OptMobile.Retailer.Services;

public interface ISalesService
{
    Task<SalesInvoiceMaster> GetByIDAsync(int id);
    Task<SalesInvoiceMaster> GetByCodeAsync(string code);
    Task<List<SalesInvoiceMaster>> GetByPartyIDAsync(int id);
}
