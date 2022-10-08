using System.Collections.ObjectModel;

namespace SocialMediaApp.MVVM.Models;

public sealed class ProfileModel
{
    public int Id { get; set; }
    public ImageSource Icon { get; set; }
    public ObservableCollection<PostModel> Posts { get; set; }
}