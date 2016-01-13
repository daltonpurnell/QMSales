using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using QMSales;
using Dropbox.CoreApi.Android.Session;
using Dropbox.CoreApi.Android;
using Java.Lang;


namespace QMSales
{
	[Activity (Label = "QMSales.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{


		string AppKey = "h88oe108wiudpge";
		string AppSecret = "h88oe108wiudpge";
		DropboxAPI dropboxApi;


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);


//			App.userManager = new UserManager (ParseStorage.Default);

			LoadApplication (new App ());
		}

		protected async override void OnStart () {

			base.OnStart ();
			AppKeyPair appKeys = new AppKeyPair(AppKey, AppSecret);
			AndroidAuthSession session = new AndroidAuthSession(appKeys);
			dropboxApi = new DropboxAPI (session);
			(DropboxApi.Session as AndroidAuthSession).StartOAuth2Authentication (this);

		}


		protected async override void OnResume ()
		{
			base.OnResume ();

			// After you allowed to link the app with Dropbox,
			// you need to finish the Authentication process
			var session = DropboxApi.Session as AndroidAuthSession;
			if (!session.AuthenticationSuccessful ())
				return;

			try {
				// Call this method to finish the authentication process
				// Will bind the user's access token to the session.
				session.FinishAuthentication ();

				// Save the Access Token somewhere
				var accessToken = session.OAuth2AccessToken;
			} catch (IllegalStateException ex) {
				Toast.MakeText (this, ex.LocalizedMessage, ToastLength.Short).Show ();
			}
		}
	}
}

