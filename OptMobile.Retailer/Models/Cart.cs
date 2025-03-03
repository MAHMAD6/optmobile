using CommunityToolkit.Mvvm.ComponentModel;

namespace OptMobile.Retailer.Models;

public class Cart
{
    public int ID { get; set; }
    public User user { get; set; }
    public ItemMaster product { get; set; }
}

public class User : ObservableObject
{
    public int ID { get; set; }
    public string name { get; set; }
    public User()
    {
        ID = 1;
        name = "User";
    }
}
