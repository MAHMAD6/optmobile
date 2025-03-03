using System.Globalization;

namespace OptMobile.Retailer.Converters;

public class IndexToContentVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is int selectedIndex && parameter is string param)
        {
            int tabIndex = int.Parse(param);
            return selectedIndex == tabIndex; // Returns true (visible) if tab index matches
        }

        return false; // Not visible
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
