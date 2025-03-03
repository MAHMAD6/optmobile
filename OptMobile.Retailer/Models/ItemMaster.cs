using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptMobile.Retailer.Models;

public partial class ItemMaster : ObservableObject
{
    public int item_id { get; set; }
    public string item_code { get; set; }
    public string item_name { get; set; }
    public string packing { get; set; }
    public string bar_code { get; set; }
    public string hsn_code { get; set; }
    public decimal? qty_in_box { get; set; }
    public decimal? qty_in_case { get; set; }
    public decimal? mrp { get; set; }
    public decimal? pts { get; set; }
    [ObservableProperty]
    private decimal? ptr;
    public decimal? rate { get; set; }
    public string image_url { get; set; }
    public bool? isitem { get; set; }
    public bool? issample { get; set; }
    public bool? isactive { get; set; }
    public int? branch_id { get; set; }
    public bool? issync { get; set; }
    public string unq_code { get; set; }

    [ObservableProperty]
    [NotMapped]
    private int qty;
    [ObservableProperty]
    [NotMapped]
    private bool isMinusButtonVisible;


    //public List<string> Images { get; set; }
}
