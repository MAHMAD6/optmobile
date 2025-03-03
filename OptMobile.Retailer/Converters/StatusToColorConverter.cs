using System.Globalization;

namespace OptMobile.Retailer.Converters;

public class StatusToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value.ToString() switch
        {
            "Paid" => Colors.Green,
            "Overdue" => Colors.Red,
            "Unpaid" => Colors.Orange,
            "Draft" => Colors.Gray,
            _ => Colors.Black,
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
