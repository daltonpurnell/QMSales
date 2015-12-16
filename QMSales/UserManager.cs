using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace QMSales
{
	public class UserManager
	{

		IParseStorage storage;

		public UserManager (IParseStorage parseStorage)
		{
			storage = parseStorage;
		}

		public Task<bool> SignUpUserAsync (User user)
		{
			return storage.SignUpUserAsync (user);
		}

		public Task<bool> LoginUserAsync (User user)
		{
			return storage.LoginUserAsync (user);
		}

		public bool IsUserLoggedIn ()
		{
			return storage.IsUserLoggedIn ();
		}

		public Task LogoutAsync ()
		{
			return storage.LogoutAsync ();
		}

	}
}

