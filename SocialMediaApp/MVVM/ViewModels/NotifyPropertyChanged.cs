using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SocialMediaApp.MVVM.ViewModels;
public class NotifyPropertyChanged : INotifyPropertyChanged
{
    public void SetValue<T>(ref T property, T value, [CallerMemberName]string propertyName = null)
    {
        if(property.Equals(value))
        {
            return;
        }

        property = value;

        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event PropertyChangedEventHandler PropertyChanged;
}
