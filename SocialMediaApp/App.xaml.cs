using SocialMediaApp.MVVM.Views;
using SocialMediaApp.MVVM.ViewModels;
using SocialMediaApp.Services;

namespace SocialMediaApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        MainPage = new AppShell();
	}
}
