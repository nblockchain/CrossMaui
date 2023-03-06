using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace Microsoft.Maui.Handlers
{

	public partial class NavigationViewHandler : ViewHandler<IStackNavigationView, NavigationView>
	{

		protected override NavigationView CreatePlatformView()
		{
			return new NavigationView();
		}

		protected override void ConnectHandler(NavigationView nativeView)
		{
			base.ConnectHandler(nativeView);
			nativeView.Connect(VirtualView);
		}

		protected override void DisconnectHandler(NavigationView nativeView)
		{
			base.DisconnectHandler(nativeView);
			nativeView.Disconnect(VirtualView);
		}

		public static void RequestNavigation(INavigationViewHandler handler, IStackNavigation navigation, object? request)
		{
			if (handler is NavigationViewHandler platformHandler && request is NavigationRequest navRequest)
			{
				platformHandler.PlatformView?.RequestNavigation(navRequest);
				navigation.NavigationFinished(navRequest.NavigationStack);
			}
		}
	}

}