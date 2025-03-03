
using System.Globalization;

namespace OptMobile.Retailer.Converters;

public class DateFormatConverter : IValueConverter
{
    public string DateFormat { get; set; } = "dd-MM-yyyy";  // Default format

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        try
        {
            if (value is DateTime dateTime)
            {
                return dateTime.ToString(DateFormat);
            }
            return string.Empty;
        }
        catch (Exception ex)
        {
            // Log the exception for further investigation (using AppCenter or any logging mechanism)
            System.Diagnostics.Debug.WriteLine($"Error in BalanceAmountColorConverter: {ex.Message}");
            return string.Empty;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value; // Not needed in this case
    }
}

public class DateTimeFormatConverter : IValueConverter
{
    public string DateFormat { get; set; } = "dd-MM-yyyy HH:mm:ss";  // Default format

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        try
        {
            if (value is DateTime dateTime)
            {
                return dateTime.ToString(DateFormat);
            }
            return string.Empty;
        }
        catch (Exception ex)
        {
            // Log the exception for further investigation (using AppCenter or any logging mechanism)
            System.Diagnostics.Debug.WriteLine($"Error in BalanceAmountColorConverter: {ex.Message}");
            return string.Empty;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value; // Not needed in this case
    }
}
