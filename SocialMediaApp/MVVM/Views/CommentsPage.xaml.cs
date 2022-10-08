using SocialMediaApp.MVVM.ViewModels;

namespace SocialMediaApp.MVVM.Views;

public partial class CommentsPage : ContentPage
{
	public CommentsPage(CommentsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
    }
}