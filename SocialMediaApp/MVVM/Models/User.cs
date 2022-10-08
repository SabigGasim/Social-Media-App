using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.MVVM.Models;
public sealed class UserModel
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
    public ProfileModel Profile { get; set; } = new();
}
