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

        var postFaker = new Faker<PostModel>()
			.RuleFor(post => post.Nickname, f => f.Name.FullName())
			.RuleFor(post => post.Text, f => f.Lorem.Text())
			.RuleFor(post => post.Date, f => f.Date.Between(DateTime.Now.AddYears(-5), DateTime.Now))
			.RuleFor(post => post.ProfilePic, f => 
			{
				var imageUrl = f.Image.LoremFlickrUrl(200, 200);
                return new Uri(imageUrl);
            })
            .RuleFor(post => post.Likes, () => randomizer.Next(1_000_000_000));

        var posts = postFaker.GenerateBetween(30, 100);

		posts.ForEach(post =>
		{
			var fakeProfilePic = new Faker<ProfileModel>()
				.RuleFor(profile => profile.Icon, f => f.Image.LoremFlickrUrl(1920, 1080));

			var fakeUser = new Faker<UserModel>()
				.RuleFor(comment => comment.Nickname, f => f.Name.FullName())
				.RuleFor(comment => comment.Profile, () => fakeProfilePic);

			var fakeReply = new Faker<ReplyModel>()
				.RuleFor(reply => reply.User, () => fakeUser)
				.RuleFor(reply => reply.Text, f => f.Lorem.Text())
				.RuleFor(reply => reply.Likes, () => randomizer.Next(10_000))
                .RuleFor(reply => reply.Id, Guid.NewGuid())
				.RuleFor(reply => reply.Date, f => f.Date.Past(3));

			post.Comments = new(new Faker<CommentModel>()
				.RuleFor(comment => comment.Text, f => f.Lorem.Text())
				.RuleFor(comment => comment.User, () => fakeUser)
				.RuleFor(comment => comment.Date, f => f.Date.Between(DateTime.Now.AddYears(-5), DateTime.Now))
                .RuleFor(comment => comment.Likes, () => randomizer.Next(1_000_000_000))
				.RuleFor(comment => comment.Replies, () => new(fakeReply.Generate(randomizer.Next(0, 10))))
                .Generate(randomizer.Next(3, 20)));
		});

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

			foreach(var comment in post.Comments)
			{
				foreach(var reply in comment.Replies)
				{
					reply.Comment = comment;
				}
			}
		});

		return posts;
	}
}