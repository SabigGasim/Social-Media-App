using Humanizer;
using Humanizer.Localisation;

namespace SocialMediaApp.Services;
public class DateTimeHumanizerService : IDateTimeHumanizerService
{
    private const string Now = nameof(Now);
    
    public string Humanize(DateTime dateTime)
    {
        var timeSpace = DateTime.Now - dateTime;

        if(timeSpace.Seconds < 1 && timeSpace.Seconds > -1)
        {
            return Now;
        }

        return timeSpace.Humanize(maxUnit: TimeUnit.Year, minUnit: TimeUnit.Second);
    }
}
