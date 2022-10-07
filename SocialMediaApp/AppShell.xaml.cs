using SocialMediaApp.MVVM.Views;
using SocialMediaApp.Services;

namespace SocialMediaApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute("comments", typeof(CommentsPage));
	}
}
