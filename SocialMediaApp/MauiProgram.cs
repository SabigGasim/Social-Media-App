using SocialMediaApp.MVVM.ViewModels;
using SocialMediaApp.MVVM.Views;
using SocialMediaApp.Services;

namespace SocialMediaApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddTransient<CommentsViewModel>();
		builder.Services.AddTransient<CommentsPage>();

        DependencyService.RegisterSingleton<IDateTimeHumanizerService>(new DateTimeHumanizerService());
        DependencyService.RegisterSingleton<INavigationService>(new MauiNavigationService());

        return builder.Build();
	}
}
