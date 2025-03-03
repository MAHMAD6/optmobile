using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptMobile.Retailer.Models;

public class SalesOrderMaster
{
    public long order_id { get; set; }
    public string order_number { get; set; }
    public string supplier_code { get; set; }
    public long division_id { get; set; }
    public int series_id { get; set; }
    public string order_code { get; set; }
    public DateTime order_date { get; set; }
    public DateTime receipt_date { get; set; }
    public long party_id { get; set; }
    public decimal discount { get; set; }
    public decimal discount_amount { get; set; }
    public decimal tax { get; set; }
    public decimal tax_amount { get; set; }
    public decimal amount { get; set; }
    public decimal total_amount { get; set; }
    public decimal grand_total { get; set; }
    public string shipment { get; set; }
    public int tax_type { get; set; }
    public int warehouse_id { get; set; }
    public int carrier_id { get; set; }
    public int freight_id { get; set; }
    public int? order_status { get; set; }
    public string order_by { get; set; }
    public string remarks { get; set; }
    public string emp_code { get; set; }
    public int financial_year { get; set; }
    public bool isapp { get; set; }
    public bool isaccept { get; set; }
    public bool iscancel { get; set; }
    public bool iscomplete { get; set; }
    public bool ispick { get; set; }
    public bool isposted { get; set; }
    public bool isedit { get; set; }
    public bool isactive { get; set; }
    public DateTime create_date { get; set; }
    public long create_by { get; set; }
    public string ip_address { get; set; }
    public int branch_id { get; set; }
    public bool issync { get; set; }
    public string unq_code { get; set; }
    public virtual List<SalesOrderItems> OrderItems { get; set; }
}

public class SalesOrderItems
{
    public long tran_id { get; set; }
    public long order_id { get; set; }
    public int item_id { get; set; }
    public string item_name { get; set; }
    public string batch { get; set; }
    public DateTime mfg_date { get; set; }
    public DateTime exp_date { get; set; }
    public decimal rate { get; set; }
    public decimal qty { get; set; }
    public decimal free_qty { get; set; }
    public decimal discount { get; set; }
    public decimal discount_amount { get; set; }
    public decimal tax { get; set; }
    public decimal tax_amount { get; set; }
    public decimal amount { get; set; }
    public decimal total_amount { get; set; }
    public decimal grand_total { get; set; }
}
