using SocialMediaApp.MVVM.Models;
using System.Linq.Expressions;

namespace SocialMediaApp.Resources.Styles;
public class PostDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate HasMediaDataTemplate { get; set; }
    public DataTemplate DoesntHaveMediaDataTemplate { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var context = item as PostModel;

        return context.Media is null || context.Media.Count < 1
            ? DoesntHaveMediaDataTemplate
            : HasMediaDataTemplate;
    }
}