using System.ComponentModel.DataAnnotations.Schema;

namespace OptMobile.Retailer.Models;

public class SalesInvoiceMaster
{
    public int invoice_id { get; set; }
    public int party_id { get; set; }
    public string invoice_code { get; set; }
    public DateTime invoice_date { get; set; }
    public DateTime due_date { get; set; }
    public decimal freight { get; set; }
    public decimal freight_tax { get; set; }
    public decimal freight_tax_amount { get; set; }
    public decimal discount { get; set; }
    public decimal discount_amount { get; set; }
    public decimal tax { get; set; }
    public decimal tax_amount { get; set; }
    public decimal amount { get; set; }
    public decimal total_amount { get; set; }
    public decimal grand_total { get; set; }
    public decimal round_off { get; set; }
    public string remarks { get; set; }
    public int warehouse_id { get; set; }
    public int financial_year { get; set; }
    public bool iscomplete { get; set; }
    public bool isposted { get; set; }
    public bool isactive { get; set; }
    public bool ispick { get; set; }
    public DateTime create_date { get; set; }
    public int create_by { get; set; }

    [ForeignKey("invoice_id")]
    public virtual List<SalesInvoiceTransaction> InvoiceTransactions { get; set; }
    [ForeignKey("invoice_id")]
    public virtual List<PaymentTransaction>? PaymentTransactions { get; set; }

    [ForeignKey("party_id")]
    public virtual PartyMaster? party { get; set; }

    public decimal balance_amount { get; set; }
}

public class SalesInvoiceTransaction
{
    public int tran_id { get; set; }
    public int invoice_id { get; set; }
    public int item_id { get; set; }
    public string item_name { get; set; }
    public string packing { get; set; }
    public string batch { get; set; }
    public decimal qty { get; set; }
    public decimal free_qty { get; set; }
    public decimal mrp { get; set; }
    public decimal pts { get; set; }
    public decimal ptr { get; set; }
    public decimal rate { get; set; }
    public decimal discount { get; set; }
    public decimal discount_amount { get; set; }
    public decimal amount { get; set; }
    public decimal total_amount { get; set; }
    public decimal grand_total { get; set; }
}
