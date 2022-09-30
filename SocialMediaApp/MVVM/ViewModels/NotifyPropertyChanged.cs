using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SocialMediaApp.MVVM.ViewModels;
public class NotifyPropertyChanged : INotifyPropertyChanged
{
    public bool TrySetValue<T>(ref T property, T value, [CallerMemberName]string propertyName = null)
    {
        if(property.Equals(value))
        {
            return false;
        }

        property = value;

        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        
        return true;
    }

    public event PropertyChangedEventHandler PropertyChanged;
}
