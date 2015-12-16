using System;
using Xamarin.Forms;

namespace QMSales
{
	public class App : Application
	{

		public static UserManager userManager { get; set; }
		public App ()
		{
//			if (userManager.IsUserLoggedIn())
//			{
//				MainPage = new FirstPage ();
//			}
//			else
//			{
				MainPage = new NavigationPage(new ParseLogin());
//			}
				
			NavigationPage.SetHasNavigationBar (MainPage, true);

		}

		protected override void OnStart ()
		{
			// Handle when your app starts


		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

