using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace UIDesign
{
    public class QuantityToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int quantity)
            {
                if (quantity == 0)
                    return Brushes.Tomato;
                else if (quantity <= 5)
                    return Brushes.Orange;
                else if (quantity <= 15)
                    return Brushes.LimeGreen;
                else
                    return Brushes.DodgerBlue;
            }

            return Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
