using System.Collections.ObjectModel;

namespace SocialMediaApp.MVVM.Models;

public class PostModel
{
    private string _nickname;
    public string Nickname 
    { 
        get => _nickname;
        set
        {
            _nickname = value;
            Username = value.Split(' ')[0];
        }
    }
    public string Username { get; private set; }
    public ImageSource ProfilePic { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; }
    public long Likes { get; set; }
    public ObservableCollection<ImageSource> Media { get; set; }
    public ObservableCollection<Comment> Comments { get; set; }
}
