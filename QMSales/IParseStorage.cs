using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace QMSales
{
	public interface IParseStorage
	{

		Task<List<QMSalesContact>> GetAll ();

		Task<List<QMSalesContact>> RefreshDataAsync();

		Task SaveContactAsync (QMSalesContact contact);

		Task DeleteContactAsync (QMSalesContact id);

		Task<bool> SignUpUserAsync (User user);

		Task<bool> LoginUserAsync (User user);

		bool IsUserLoggedIn ();

		Task LogoutAsync ();


	}
}

