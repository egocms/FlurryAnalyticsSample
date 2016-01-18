using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin.Forms;

namespace FlurrySample.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		UIWindow window;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			window = new UIWindow (UIScreen.MainScreen.Bounds);
			window.RootViewController = App.GetMainPage ().CreateViewController ();
			window.MakeKeyAndVisible ();

			return true;
		}

		void InitFlurry ()
		{
			// Start Flurry Session
			Flurry.Analytics.Portable.AnalyticsApi.StartSession ("SET YOUR <API_KEY>");

			// Configurate Flurry
			Flurry.Analytics.FlurryAgent.SetSessionReportsOnCloseEnabled (true);
			
			// default parameter is true
			// I inserted this method as sample
			Flurry.Analytics.FlurryAgent.SetSessionReportsOnPauseEnabled (true);

			// Configurate Parameters
			Flurry.Analytics.Portable.AnalyticsApi.SetUserId ("sampleId");
			Flurry.Analytics.Portable.AnalyticsApi.SetAge (37);
			Flurry.Analytics.Portable.AnalyticsApi.SetGender (Flurry.Analytics.Portable.Gender.Female);
			Flurry.Analytics.Portable.AnalyticsApi.SetAppVersion ("0.12");

			// Configurate debug info
			Flurry.Analytics.FlurryAgent.SetCrashReportingEnabled (true);
			Flurry.Analytics.FlurryAgent.SetDebugLogEnabled (true);
			Flurry.Analytics.FlurryAgent.SetEventLoggingEnabled (true);
			Flurry.Analytics.FlurryAgent.SetShowErrorInLogEnabled (true);
			Flurry.Analytics.FlurryAgent.SetPulseEnabled (true);
		}
	}
}

