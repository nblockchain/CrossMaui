namespace FlyoutProject;
using System;
using FlyoutProject.Models;
using Microsoft.Maui.Controls;
public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new MainPage());// new AppShell();
	}
}
