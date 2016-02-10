using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Dropbox.CoreApi.iOS;
using UIKit;
using QMSales.iOS;
using Xamarin.Forms;
using System.Reflection;

[assembly: Xamarin.Forms.Dependency (typeof (DropboxService))]
namespace QMSales.iOS
{
	public class DropboxService : IDropboxService
	{

		static DropboxService dropboxServiceInstance = new DropboxService();
		public static DropboxService Default { get { return dropboxServiceInstance; } }


		public DropboxService ()
		{

		}


		// implement the methods declared in the idropboxservice interface

		public async Task LinkDropBox(FirstPage firstPage) {


			// create a view controller from a page // 
			Type _platformType = Type.GetType("Xamarin.Forms.Platform.iOS.Platform, Xamarin.Forms.Platform.iOS", true);  

			UIViewController vc = null;

			//Set the parent page to the current application
//			firstPage.Parent = Application.Current;

			//Create a platform object
			IPlatform Platform = Activator.CreateInstance(_platformType, true) as IPlatform;

			//Set the page to the new platform object
			if (Platform != null) {
				Platform.SetPage (firstPage);

				//Get the renderer of the platform object and get the UIViewController Object
				var a = Platform.GetType ().GetField ("renderer", BindingFlags.NonPublic | BindingFlags.Instance).GetValue (Platform);
				vc = a as UIViewController;

				Console.Write ("Linking to dropbox");
			 	Session.SharedSession.LinkFromController (vc);

			}
		}


//		public Task DownloadFile() {
//			var restClient = new RestClient (Session.SharedSession);
//
//			// download the file
//			restClient.LoadFile ("https://www.dropbox.com/home/QMSales?preview=2016+CareSuite+by+QuickMAR+Brief.pptx", Environment.SpecialFolder.MyDocuments.ToString());
//
//		}




		//			restClient.FileLoaded += (object sender, RestClientFileLoadedEventArgs e) => {
		//				// Do something when the file is loaded
		//			};
		//
		//			restClient.LoadFileFailed += (object sender, RestClientErrorEventArgs e) => {
		//				// Do something if the request failed
		//			};

	}
}

