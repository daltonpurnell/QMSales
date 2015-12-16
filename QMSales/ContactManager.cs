using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace QMSales
{
	public class ContactManager
	{
		IParseStorage storage;

		public ContactManager (IParseStorage storage)
		{
			this.storage = storage;
		}

//		public Task<ParseContact> GetPersonAsync(string id)
//		{
//			return storage.GetContactAsync(id);
//		}

		public Task<List<QMSalesContact>> GetPersonAsync ()
		{
			return storage.RefreshDataAsync();
		}

//		public Task SavePersonAsync (ParseContact contact)
//		{
//			return storage.SaveContactAsync(contact);
//		}

		public Task DeletePersonAsync (QMSalesContact contact)
		{
			return storage.DeleteContactAsync(contact);
		}
	}
}

