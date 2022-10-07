using SocialMediaApp.MVVM.Models;
using SocialMediaApp.MVVM.ViewModels;
using SocialMediaApp.Services;

namespace SocialMediaApp.MVVM.Views;

public partial class CommentsPage : ContentPage
{
	private readonly CommentsViewModel _viewModel;

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