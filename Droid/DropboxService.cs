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
			

		public Task DownloadFile() {

			using (var output = File.OpenWrite (localPath)) {
				// Gets the file from Dropbox and saves it to the local folder
				DropboxApi.GetFile ("https://www.dropbox.com/home/Public", null, output, null);
			}

		}



	}
}

