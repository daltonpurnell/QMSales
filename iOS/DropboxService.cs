using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Dropbox.CoreApi.iOS;
using UIKit;
using QMSales.iOS;

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

//
//		// implement the methods declared in the idropboxservice interface
//
//		public async Task LinkDropBox(FirstPage firstPage) {
//
//
//			await Session.SharedSession.LinkFromController (firstPage as UIViewController);
//
//
//		}
//
//
//		public Task DownloadFile() {
//			var restClient = new RestClient (Session.SharedSession);
//
//			// download the file
//			restClient.LoadFile ("https://www.dropbox.com/home/QMSales?preview=2016+CareSuite+by+QuickMAR+Brief.pptx", Environment.SpecialFolder.MyDocuments.ToString());
//
//
//			restClient.FileLoaded += (object sender, RestClientFileLoadedEventArgs e) => {
//				// Do something when the file is loaded
//			};
//
//			restClient.LoadFileFailed += (object sender, RestClientErrorEventArgs e) => {
//				// Do something if the request failed
//			};
//
//
//		}



	}
}

