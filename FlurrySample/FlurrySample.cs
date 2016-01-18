using System;

using Xamarin.Forms;

namespace FlurrySample
{
	public class App : Application
	{
		public App ()
		{
			
		}

		static void RegisterTypes ()
		{

			ViewFactory.Register<MainPage, MainViewModel> ();


		}

		public static Page GetMainPage ()
		{
			RegisterTypes ();

			return ViewFactory.CreatePage<MainViewModel> ();
		}
	}
}

