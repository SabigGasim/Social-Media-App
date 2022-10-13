using SocialMediaApp.MVVM.Models;
using SocialMediaApp.Services;
using System.Windows.Input;

namespace SocialMediaApp.MVVM.ViewModels;

[QueryProperty(nameof(Post), nameof(Post))]
public class CommentsViewModel : ViewModelBase
{
    private ICommand _replyButtonClickedCommand;
    private PostModel _post = new();

    public CommentsViewModel(INavigationService navigationService) : base(navigationService)
    {
        _replyButtonClickedCommand = new Command
        (
            execute: async (param) =>
            {
                var navParam = new Dictionary<string, object>()
                {
                    ["Comment"] = param as CommentModel
                };

                await _navigationService.NavigateToAsync("replies", navParam);
            }
        );
    }

    public PostModel Post
    {
        get => _post;
        set => TrySetValue(ref _post, value);
    }

    public ICommand ReplyButtonClickedCommand
    {
        get => _replyButtonClickedCommand;
        set => TrySetValue(ref _replyButtonClickedCommand, value);
    }
}
