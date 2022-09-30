using Humanizer;
using Humanizer.Localisation;

namespace SocialMediaApp.Services;

public interface IDateTimeHumanizerService
{
    public string Humanize(DateTime dateTime);
    public string Humanize(DateTimeOffset dateTime);
}


public class DateTimeHumanizerService : IDateTimeHumanizerService
{
    private const string Now = nameof(Now);
    
    public string Humanize(DateTime dateTime)
    {
        var timeSpace = DateTime.Now - dateTime;

        if (Math.Abs(timeSpace.Ticks) < TimeSpan.TicksPerSecond)
        {
            return Now;
        }

        return timeSpace.Humanize(maxUnit: TimeUnit.Year, minUnit: TimeUnit.Second);
    }

    public string Humanize(DateTimeOffset dateTime)
    {
        var timeSpace = DateTimeOffset.Now - dateTime;

        if (Math.Abs(timeSpace.Ticks) < TimeSpan.TicksPerSecond)
        {
            return Now;
        }

        return timeSpace.Humanize(maxUnit: TimeUnit.Year, minUnit: TimeUnit.Second);
    }
}
