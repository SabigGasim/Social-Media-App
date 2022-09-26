using SocialMediaApp.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.MVVM.ViewModels;
public class PostsViewModel : NotifyPropertyChanged
{
    private ObservableCollection<PostModel> _posts = new();

    public ObservableCollection<PostModel> Posts 
    {
        get => _posts;
        set => SetValue(ref _posts, value);
    }
}
