using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace QMSales
{
	public interface IUserContactService
	{
		Task<List<QMSalesContact>> GetAllContacts();
		List<QMSalesContact> FindContacts(string searchInContactsString);
	}
}

