using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace QMSales
{

	public interface IDropboxService
	{

		// declare some methods to be implemented in Dropbox service classes in .ios and .android

		Task LinkDropBox();

		Task DownloadFile();



	}
}

