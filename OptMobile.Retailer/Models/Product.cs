using CommunityToolkit.Mvvm.ComponentModel;

namespace OptMobile.Retailer.Models;

public partial class Product : ObservableObject
{
    public int ID { get; set; }
    public List<int> RelatedProductIds { get; set; }
    public string Title { get; set; }
    public string Brand { get; set; }
    public List<string> ImageSource { get; set; }
    public string Rating { get; set; }
    public string Time { get; set; }
    public string Price { get; set; }
    public string DiscountPrice { get; set; }
    public int Quantity { get; set; }

    [ObservableProperty]
    private int purchaseQuantity;

    [ObservableProperty]
    private bool isMinusButtonVisible;

    public string Description { get; set; }
    public string Location { get; set; }
    public string Calories { get; set; }
}