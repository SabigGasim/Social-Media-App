using SocialMediaApp.Services;

namespace SocialMediaApp.MVVM.ViewModels;
public abstract class ViewModelBase : PropertyChangedNotifier
{
	protected readonly INavigationService _navigationService;

	public ViewModelBase(INavigationService navigationService)
	{
		_navigationService = navigationService;
    }
}
