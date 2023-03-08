﻿using System;
using Gtk;

namespace Microsoft.Maui.Handlers
{

	// https://docs.gtk.org/gtk3/class.SpinButton.html
	public partial class StepperHandler : ViewHandler<IStepper, SpinButton>
	{
		protected override SpinButton CreatePlatformView()
		{
			// var adjustment = new Adjustment(0, 0, 1, 1, 1, 1);
			// return new SpinButton(adjustment, 1, 1);
			return new SpinButton(0, 1, .1) { Numeric = true, ClimbRate = 0.1 };
		}

		protected override void ConnectHandler(SpinButton nativeView)
		{
			base.ConnectHandler(nativeView);

			_ = PlatformView ?? throw new InvalidOperationException($"{nameof(PlatformView)} should have been set by base class.");

			nativeView.ValueChanged += OnNativeViewValueChanged;

		}


		protected override void DisconnectHandler(SpinButton nativeView)
		{
			base.DisconnectHandler(nativeView);

			_ = PlatformView ?? throw new InvalidOperationException($"{nameof(PlatformView)} should have been set by base class.");

			nativeView.ValueChanged += OnNativeViewValueChanged;
		}

		void OnNativeViewValueChanged(object? sender, EventArgs e)
		{
			if (sender is not SpinButton nativeView || VirtualView is not { } virtualView)
				return;

			virtualView.Value = nativeView.Value;
		}

		public static void MapMinimum(StepperHandler handler, IStepper stepper)
		{
			handler.PlatformView?.UpdateRange(stepper);

		}

		public static void MapMaximum(StepperHandler handler, IStepper stepper)
		{
			handler.PlatformView?.UpdateRange(stepper);

		}

		public static void MapIncrement(StepperHandler handler, IStepper stepper)
		{
			handler.PlatformView?.UpdateIncrement(stepper);

		}

		public static void MapValue(StepperHandler handler, IStepper stepper)
		{
			handler.PlatformView?.UpdateValue(stepper);

		}
	}
}