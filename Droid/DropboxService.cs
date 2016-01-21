using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using QMSales.Droid;
using Dropbox.CoreApi.Android;
using System.IO;

[assembly: Xamarin.Forms.Dependency (typeof (DropboxService))]
namespace QMSales.Droid
{
	public class DropboxService : IDropboxService2
	{


		static DropboxService dropboxServiceInstance = new DropboxService();
		public static DropboxService Default { get { return dropboxServiceInstance; } }


		public DropboxService ()
		{

		}
			
//
//		public Task DownloadFile() {
//
//			using (var output = File.OpenWrite (Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments))) {
//				// Gets the file from Dropbox and saves it to the local folder
//				DropboxApi dropboxApi;
//				dropboxApi.GetFile ("https://www.dropbox.com/home/QMSales?preview=2016+CareSuite+by+QuickMAR+Brief.pptx", null, output, null);
//			}
//
//		}



	}
}

