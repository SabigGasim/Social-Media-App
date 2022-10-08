namespace SocialMediaApp.MVVM.Models;

public sealed class ReplyModel
{
    public int Id { get; set; }
    public string Text { get; set; }
    public long Likes { get; set; }
    public UserModel User { get; set; }
}