﻿using SocialMediaApp.MVVM.Views;

namespace SocialMediaApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
