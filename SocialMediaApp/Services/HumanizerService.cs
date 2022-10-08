using Humanizer;
using Humanizer.Localisation;

namespace SocialMediaApp.Services;

public interface IHumanizerService
{
    public string Humanize(DateTime dateTime);
    public string Humanize(DateTimeOffset dateTime);
    public string Humanize(int number);
    public string Humanize(long number);
}


public class HumanizerService : IHumanizerService
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

    public string Humanize(int number)
    {
        switch (number)
        {
            case < 1000:
                return number.ToString();
            case < 10000:
                return string.Format("{0:#,.##}K", number - 5);
            case < 100000:
                return string.Format("{0:#,.#}K", number - 50);
            case < 1000000:
                return string.Format("{0:#,.}K", number - 500);
            case < 10000000:
                return string.Format("{0:#,,.##}M", number - 5000);
            case < 100000000:
                return string.Format("{0:#,,.#}M", number - 50000);
            case < 1000000000:
                return string.Format("{0:#,,.}M", number - 500000);
            default:
                return string.Format("{0:#,,,.##}B", number - 5000000);
        }
    }

    public string Humanize(long number)
    {
        switch (number)
        {
            case < 1000:
                return number.ToString();
            case < 10000:
                return string.Format("{0:#,.##}K", number - 5);
            case < 100000:
                return string.Format("{0:#,.#}K", number - 50);
            case < 1000000:
                return string.Format("{0:#,.}K", number - 500);
            case < 10000000:
                return string.Format("{0:#,,.##}M", number - 5000);
            case < 100000000:
                return string.Format("{0:#,,.#}M", number - 50000);
            case < 1000000000:
                return string.Format("{0:#,,.}M", number - 500000);
            default:
                return string.Format("{0:#,,,.##}B", number - 5000000);
        }
    }
}
