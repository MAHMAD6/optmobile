using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptMobile.Retailer.Models;

public class PaymentMaster
{
    [Key]
    public int payment_id { get; set; }
    public string payment_code { get; set; }
    public int grid_row_number { get; set; }
    public int serial_number { get; set; }
    public int party_id { get; set; }
    public int payment_mode_id { get; set; }
    public int account_id { get; set; }
    public string? reference_number { get; set; }
    public string? reference_bank { get; set; }
    public DateTime payment_date { get; set; }
    public decimal paid_amount { get; set; }
    public int payment_type_id { get; set; }
    public int transaction_type_id { get; set; }
    public string? emp_code { get; set; }
    public string? remarks { get; set; }
    public string? receipt_number { get; set; }
    public int financial_year { get; set; }
    public bool? ispick { get; set; }
    public bool isonline { get; set; }
    public bool isposted { get; set; }
    public bool isactive { get; set; }
    public DateTime? create_date { get; set; }
    public int? create_by { get; set; }
    public string? ip_address { get; set; }
    public int? branch_id { get; set; }
    public bool? issync { get; set; }
    public string? unq_code { get; set; }

    [ForeignKey("payment_id")]
    public virtual List<PaymentTransaction>? PaymentTransactions { get; set; }
}

public class PaymentTransaction
{
    [Key]
    public int tran_id { get; set; }
    public int payment_id { get; set; }
    public int invoice_id { get; set; }
    public decimal invoice_amount { get; set; }
    public decimal paid_amount { get; set; }
    public int sequence_number { get; set; }
    public string remarks { get; set; }
    public string receipt_number { get; set; }
    //public virtual PaymentMaster? PaymentMaster { get; set; }
}
