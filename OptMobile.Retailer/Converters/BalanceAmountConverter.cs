using System.Globalization;

namespace OptMobile.Retailer.Converters;

public class BalanceAmountConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        try
        {
            if (value is decimal balanceAmount)
            {
                return balanceAmount == 0 ? "Paid" : $"Remaining {balanceAmount}";
            }
            return "Remaining 0"; // Default case
        }
        catch (Exception ex)
        {
            // Log the exception for further investigation (using AppCenter or any logging mechanism)
            System.Diagnostics.Debug.WriteLine($"Error in BalanceAmountColorConverter: {ex.Message}");
            return "Remaining 0";
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

//public class BalanceAmountColorConverter : IValueConverter
//{
//    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
//    {
//        if (value is int balanceAmount)
//        {
//            return balanceAmount == 0 ? Color.Green : Color.Red;
//        }
//        return Color.Red; // Default case
//    }

//    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
//    {
//        return value; // Not needed for this example
//    }
//}


#region(Parameterized converter)
/*
public class BalanceAmountConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is int balanceAmount)
        {
            if (balanceAmount == 0)
            {
                return new Tuple<string, Color>("Paid", Color.Green);
            }
            else
            {
                return new Tuple<string, Color>($"Remaining {balanceAmount}", Color.Red);
            }
        }
        return new Tuple<string, Color>("Remaining 0", Color.Red); // Default case
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value; // Not needed for this example
    }
}
*/
#endregion