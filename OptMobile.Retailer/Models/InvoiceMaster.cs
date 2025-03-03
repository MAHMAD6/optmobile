namespace OptMobile.Retailer.Models
{
    public class InvoiceMaster
    {
        public int InvoiceID { get; set; }
        public int PartyID { get; set; }
        public string InvoiceCode { get; set; }
        public DateOnly InvoiceDate { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public bool IsMrNameVisible { get; set; }
    }
}
