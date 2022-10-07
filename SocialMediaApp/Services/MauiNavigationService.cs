using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Services;

public interface INavigationService
{
    Task InitializeAsync();

    Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null);

    Task PopAsync(string route = null);
}

public class MauiNavigationService : INavigationService
{
    public Task InitializeAsync()
    {
        throw new NotImplementedException();
    }

    public Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null) =>
        routeParameters is not null
            ? Shell.Current.GoToAsync(route, routeParameters)
            : Shell.Current.GoToAsync(route);

    public Task PopAsync(string route = "..") => Shell.Current.GoToAsync(route);
}
