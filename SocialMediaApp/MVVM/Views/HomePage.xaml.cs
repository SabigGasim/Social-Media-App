using Bogus;
using Microsoft.Maui.Animations;
using SocialMediaApp.MVVM.Models;
using SocialMediaApp.MVVM.ViewModels;
using System.Collections.ObjectModel;

namespace SocialMediaApp.MVVM.Views;

public partial class HomePage : ContentPage
{
	public HomePage(PostsViewModel viewModel)
	{
		InitializeComponent();

		var posts = GenerateFakePosts();
        viewModel.Posts = new ObservableCollection<PostModel>(posts);

        BindingContext = viewModel;
	}

	private static IEnumerable<PostModel> GenerateFakePosts()
	{
		var randomizer = new Random();
		var postCommentsLength = randomizer.Next(3, 20);

        var postFaker = new Faker<PostModel>()
			.RuleFor(post => post.Nickname, f => f.Name.FullName())
			.RuleFor(post => post.Text, f => f.Lorem.Text())
			.RuleFor(post => post.Date, f => f.Date.Between(DateTime.Now.AddYears(-5), DateTime.Now))
			.RuleFor(post => post.ProfilePic, f => 
			{
				var imageUrl = f.Image.LoremFlickrUrl(200, 200);
                return new Uri(imageUrl);
            });

		var posts = postFaker.GenerateBetween(30, 100);

		posts.ForEach(post => post.Comments = new(new Faker<Comment>()
            .RuleFor(comment => comment.Text, f => f.Lorem.Text())
            .Generate(postCommentsLength)));

		posts.ForEach(post =>
		{
			post.Media ??= new();

            var postMediaFilesLength = randomizer.Next(-4, 5);

            for (int i = 0; i < postMediaFilesLength; i++)
            {
                var imageUrl = new Faker().Image.LoremFlickrUrl(1920, 1080);
                var imageUri = new Uri(imageUrl);
                var imageSource = ImageSource.FromUri(imageUri);

                post.Media.Add(imageSource);
            }
		});

		return posts;
	}
}