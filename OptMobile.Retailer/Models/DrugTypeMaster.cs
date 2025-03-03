namespace OptMobile.Retailer.Models;

public class DrugTypeMaster
{
    public int drug_type_id { get; set; }
    public string drug_type { get; set; }
    public string image_url { get; set; }
    public bool isactive { get; set; }
    public int branch_id { get; set; }
}
