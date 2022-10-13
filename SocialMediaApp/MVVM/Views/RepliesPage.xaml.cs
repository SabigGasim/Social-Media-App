using SocialMediaApp.MVVM.ViewModels;

namespace SocialMediaApp.MVVM.Views;

public partial class RepliesPage : ContentPage
{
	public RepliesPage(RepliesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}