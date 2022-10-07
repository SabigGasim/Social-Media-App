using SocialMediaApp.MVVM.Models;
using SocialMediaApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.MVVM.ViewModels;
public sealed class PostsViewModel : ViewModelBase
{
    private Command _commentsButtonClieckedCommand;
    private ObservableCollection<PostModel> _posts = new();

    public PostsViewModel(INavigationService navigationService) : base(navigationService)
    {
        InitializeCommands();
    }


    public ObservableCollection<PostModel> Posts 
    {
        get => _posts;
        set => TrySetValue(ref _posts, value);
    }

    public Command CommentsButtonClieckedCommand
    {
        get => _commentsButtonClieckedCommand;
        set => TrySetValue(ref _commentsButtonClieckedCommand, value);
    }
    
    private void InitializeCommands()
    {
        _commentsButtonClieckedCommand = new(async (post) =>
        {
            var routeParam = new Dictionary<string, object>
            {
                ["Post"] = post
            };

            await _navigationService.NavigateToAsync("comments", routeParam);
        });
    }
}
