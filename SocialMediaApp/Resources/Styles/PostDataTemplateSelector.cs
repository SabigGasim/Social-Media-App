using SocialMediaApp.MVVM.Models;
using SocialMediaApp.MVVM.ViewModels;
using System.Linq.Expressions;

namespace SocialMediaApp.Resources.Styles;
public class PostDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate HasMediaDataTemplate { get; set; }
    public DataTemplate DoesntHaveMediaDataTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var context = item is PostModel post
            ? post
            : item is CommentsViewModel vm
            ? vm.Post
            : null;

        return context?.Media is null || context?.Media.Count < 1
            ? DoesntHaveMediaDataTemplate
            : HasMediaDataTemplate;
    }
}