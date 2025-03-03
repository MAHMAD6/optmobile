
namespace OptMobile.Retailer.Models;

public class BrandMaster
{
    public string DefaultImage { get; set; }
    public string BrandName { get; set; }
    public decimal Price { get; set; }
    public List<string> Images { get; set; }
}
