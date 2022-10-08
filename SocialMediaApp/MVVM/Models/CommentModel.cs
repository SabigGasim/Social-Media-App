using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.MVVM.Models;
public sealed class CommentModel
{
    public int Id { get; set; }
    public string Text { get; set; }
    public long Likes { get; set; }
    public DateTime Date { get; init; }
    public UserModel User { get; set; }
    public ObservableCollection<ReplyModel> Replies { get; set; }
}
