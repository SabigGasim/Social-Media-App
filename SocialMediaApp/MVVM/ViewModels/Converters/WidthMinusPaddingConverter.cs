using System.Globalization;

namespace SocialMediaApp.MVVM.ViewModels.Converters;
public class WidthMinusPaddingConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(parameter is not Layout view)
        {
            return null;
        }

        return view.Width - view.Padding.HorizontalThickness;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }
}
