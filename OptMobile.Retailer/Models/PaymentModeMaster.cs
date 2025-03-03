namespace OptMobile.Retailer.Models;

public class PaymentModeMaster
{
    public int payment_mode_id { get; set; }
    public string payment_mode { get; set; }
    public int transaction_type_id { get; set; }
    public bool isactive { get; set; }
}
