﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptMobile.Retailer.Converters
{
    public class BoolToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isVisible)
            {
                return isVisible ? "uparrowicon.svg" : "downarrowicon.svg";
            }
            return "downarrowicon.svg"; // Default fallback
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
