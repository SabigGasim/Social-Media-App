using SocialMediaApp.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.MVVM.ViewModels.Converters;
public class HumanizeIntToStringConverter : IValueConverter
{
    private readonly IHumanizerService _humanizerService;

    public HumanizeIntToStringConverter()
    {
        _humanizerService = DependencyService.Get<IHumanizerService>();
    }

    public HumanizeIntToStringConverter(IHumanizerService humanizerService)
    {
        _humanizerService = humanizerService;
    }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(value is int i)
        {
            return _humanizerService.Humanize(i);
        }

        if(value is long l)
        {
            return _humanizerService.Humanize(l);
        }

        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
