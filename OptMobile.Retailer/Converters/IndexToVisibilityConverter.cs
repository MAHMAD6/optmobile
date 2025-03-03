using System.Globalization;

namespace OptMobile.Retailer.Converters;

public class IndexToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is int selectedIndex && parameter is string param)
        {
            int tabIndex = int.Parse(param);

            // Return colors for active/inactive tab background
            return selectedIndex == tabIndex
                ? Color.FromArgb("#FF9E62") // Active tab color
                : Color.FromArgb("#ffffff"); // Inactive tab color
        }

        return Color.FromArgb("#ffffff"); // Default inactive color
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
