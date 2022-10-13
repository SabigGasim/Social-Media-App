using SocialMediaApp.MVVM.Models;
using SocialMediaApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.MVVM.ViewModels;

[QueryProperty(nameof(Comment), nameof(Comment))]
public class RepliesViewModel : ViewModelBase
{
    private CommentModel _comment = new();

    public RepliesViewModel(INavigationService navigationService) : base(navigationService)
    {
    }

    public CommentModel Comment
    {
        get => _comment;
        set => TrySetValue(ref _comment, value);
    }
}
