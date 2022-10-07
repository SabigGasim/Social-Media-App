using SocialMediaApp.MVVM.Models;
using SocialMediaApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.MVVM.ViewModels;

[QueryProperty(nameof(Post), nameof(Post))]
public class CommentsViewModel : ViewModelBase
{
    public CommentsViewModel(INavigationService navigationService) : base(navigationService)
    {

    }

    private PostModel _post = new();

    public PostModel Post
    {
        get => _post;
        set => TrySetValue(ref _post, value);
    }
}
