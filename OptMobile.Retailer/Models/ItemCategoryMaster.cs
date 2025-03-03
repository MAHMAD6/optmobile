namespace OptMobile.Retailer.Models;

public class ItemCategoryMaster
{
    public int item_category_id { get; set; }
    public string category { get; set; }
    public bool isactive { get; set; }
    public int branch_id { get; set; }
    public string image_url { get; set; }
}
