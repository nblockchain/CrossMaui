using System;
using System.Collections.Generic;
using FlyoutProject.Models;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace FlyoutProject;

public partial class MainPage : FlyoutPage, IFlyoutPageController, IFlyoutView
{
	public MainPage()
	{
		InitializeComponent();

		flyoutPage.listView.ItemSelected += ListView_ItemSelected;
	}

	Dictionary<Type, Page> _keyValuePairs = new Dictionary<Type, Page>();

	private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		var item = e.SelectedItem as FlyoutPageItem;
		if (item != null)
		{
			if (_keyValuePairs.TryGetValue(item.TargetType, out var value))
			{
				Detail = value;
				return;
			}

			Page page = (Page)Activator.CreateInstance(item.TargetType);
			Detail = new NavigationPage(page);
			_keyValuePairs.Add(item.TargetType, Detail);
			//flyoutPage.listView.SelectedItem = null;
			//IsPresented = false;
		}
	}

	bool IFlyoutPageController.ShouldShowSplitMode
	{
		get => true;
	}

	double IFlyoutView.FlyoutWidth
	{
		get => 50;
	}
}

