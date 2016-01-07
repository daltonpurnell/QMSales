using System;
using System.Collections.Generic;
using System.Linq;
using Dropbox.CoreApi.iOS;
using Foundation;
using UIKit;
using Parse;

namespace QMSales.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{

		string appKey = "h88oe108wiudpge";
		string appSecret = "h88oe108wiudpge";

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{


			ParseClient.Initialize("udkZYoVnyKNzB3vA6uoF352RkD2yS46I8pPD27l1",
				"mLbwWOy4hR4VU4wa5H2L8SjKRHbi8XtxX8Q8eI5b");
			global::Xamarin.Forms.Forms.Init ();


// 			this parse object will only save if i comment out these properties

			ParseObject thing = new ParseObject("Thing");
//			thing["First Name"] = "Dalton";
//			thing["Last Name"] = "Purnell";
//			thing["Email"] = "daltonpurnell@live.com";
//			thing["Address"] = "420E 700N #3";
			thing.SaveAsync ();



			// Create a new Dropbox Session, choose the type of access that your app has to your folders.
			//Session.RootAppFolder = The app will only have access to its own folder located in /Applications/AppName/
			// Session.RootDropbox = The app will have access to all the files that you have granted permission
			var session = new Session (appKey, appSecret, Session.RootDropbox);

			// The session that you have just created, will live through all the app
			Session.SharedSession = session;



			// Code for starting up the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
			#endif

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
//
//		public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
//		{
//			if (Session.SharedSession.HandleOpenUrl (url) && Session.SharedSession.IsLinked) {
//				// Do your magic after the app gets linked
//			}
//		}
	}
}

