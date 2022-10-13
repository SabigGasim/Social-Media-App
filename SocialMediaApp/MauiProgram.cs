using SocialMediaApp.MVVM.ViewModels;
using SocialMediaApp.MVVM.ViewModels.Converters;
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

		builder.Services
			// services
			.AddSingleton<INavigationService, MauiNavigationService>()
			.AddSingleton<HumanizeDateTimeToStringConverter>()
			//view models
			.AddTransient<CommentsViewModel>()
			.AddTransient<PostsViewModel>()
			.AddTransient<RepliesViewModel>()
			//views
			.AddSingleton<HomePage>()
			.AddTransient<CommentsPage>()	
			.AddTransient<RepliesPage>();

		DependencyService.RegisterSingleton<IHumanizerService>(new HumanizerService());

        return builder.Build();
	}
}
