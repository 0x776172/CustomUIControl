using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace CustomControl.Converters
{
    internal class DiameterAndThicknessToStrokeDashArrayConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2 ||
                !double.TryParse(values[0].ToString(), out double diameter) ||
                !double.TryParse(values[1].ToString(), out double thickness))
            {
                return new DoubleCollection(new[] { 0.0 });
            }

            double circumference = Math.PI * diameter;

            double lineLength = circumference * 0.95;
            double gapLength = circumference - lineLength;

            try
            {
                double strokeDashArray1 = lineLength / thickness;
                double strokeDashArray2 = gapLength / thickness;

                return new DoubleCollection(new[] { strokeDashArray1, strokeDashArray2 });
            }

            catch { throw; }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
