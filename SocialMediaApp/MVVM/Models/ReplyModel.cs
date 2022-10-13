namespace SocialMediaApp.MVVM.Models;

public sealed class ReplyModel
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string Text { get; set; }
    public long Likes { get; set; }
    public UserModel User { get; set; }
    public CommentModel Comment { get; set; }
}