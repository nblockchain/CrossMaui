using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace Maui.Controls.Sample
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			System.Diagnostics.Debug.WriteLine($"OnAppearing");
		}

		protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
		{
			base.OnNavigatingFrom(args);
			System.Diagnostics.Debug.WriteLine($"NavigatingFromEventArgs {args}");
		}

		protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
		{
			base.OnNavigatedFrom(args);
			System.Diagnostics.Debug.WriteLine($"OnNavigatedFrom {args}");
		}

		protected override void OnNavigatedTo(NavigatedToEventArgs args)
		{
			base.OnNavigatedTo(args);
			System.Diagnostics.Debug.WriteLine($"OnNavigatedTo {args}");
		}
	}
}