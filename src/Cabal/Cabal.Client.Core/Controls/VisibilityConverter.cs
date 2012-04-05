using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Cabal.Client.Core.Controls
{
    /// <summary>
    /// A type converter for visibility and boolean values.
    /// </summary>
    /// <remarks>
    /// http://www.jeff.wilcox.name/2008/07/visibility-type-converter/
    /// </remarks>
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            return (Visibility)value == Visibility.Visible;
        }
    }
}