using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Parse;
using QMSales.iOS;


[assembly: Xamarin.Forms.Dependency (typeof (ParseStorage))]
namespace QMSales.iOS
{
	public class ParseStorage : IParseStorage
	{
		static ParseStorage contactServiceInstance = new ParseStorage();
		public static ParseStorage Default { get { return contactServiceInstance; } }
		public List<QMSalesContact> Contacts { get; private set;}

		public ParseStorage ()
		{
			Contacts = new List<QMSalesContact>();

			ParseClient.Initialize("udkZYoVnyKNzB3vA6uoF352RkD2yS46I8pPD27l1",
				"mLbwWOy4hR4VU4wa5H2L8SjKRHbi8XtxX8Q8eI5b");
		}


		ParseObject ToParseObject (QMSalesContact contact)
		{
			var po = new ParseObject("Contact");
			if (contact.ID != string.Empty)

				po.ObjectId = contact.ID;
			po["FirstName"] =contact.FirstName;
			po["LastName"] = contact.LastName;
			po["PhoneNumber"] = contact.PhoneNumber;
			po["Email"] = contact.Email;
			po["Address"] = contact.Address;
			po ["User"] = ParseUser.CurrentUser;
//			po ["ObjectACL"] = ParseUser.CurrentUser.ACL;


			return po;
		}

		static QMSalesContact FromParseObject (ParseObject po)
		{
			var c = new QMSalesContact();
			c.ID = po.ObjectId;
			c.FirstName = Convert.ToString(po["FirstName"]);
			c.LastName = Convert.ToString (po["LastName"]);
			c.PhoneNumber = Convert.ToString (po["PhoneNumber"]);
			c.Email = Convert.ToString (po["Email"]);
			c.Address = Convert.ToString (po["Address"]);
			c.User = Convert.ToString (po["User"]);
//			c.ObjectACL = Convert.ToString (po ["ObjectACL"]);


			return c;
		}

		public async Task<List<QMSalesContact>> GetAll () 
		{
			var query = ParseObject.GetQuery ("Contact").OrderBy ("LastName");
			var ie = await query.FindAsync ();

			var cl = new List<QMSalesContact> ();
			foreach (var c in ie) {
				cl.Add (FromParseObject (c));
			}

			return cl;
		}
			

		async public Task<List<QMSalesContact>> RefreshDataAsync()
		{
			var query = ParseObject.GetQuery ("Contact").OrderBy ("LastName");
			var ie = await query.FindAsync ();

			var Contacts = new List<QMSalesContact> ();
			foreach (var c in ie) {
				Contacts.Add (FromParseObject (c));
			}

			return Contacts;
		}

		public async Task SaveContactAsync(QMSalesContact contact)
		{
			await ToParseObject(contact).SaveAsync();
		}
//
//		public async Task<QMSalesContact> GetContactAsync(string id)
//		{
//			var query = ParseObject.GetQuery("Contact").WhereEqualTo("objectId", id);
//			var t = await query.FirstAsync();
//			return FromParseObject(c);
//		}





		public async Task DeleteContactAsync(QMSalesContact contact)
		{
			try 
			{
				await ToParseObject(contact).DeleteAsync();
			}  
			catch (Exception e) 
			{
				Console.Error.WriteLine(@"ERROR { 0}", e.Message);
			}
		}
			




		public async Task<bool> SignUpUserAsync (User user)
		{
			try {


				var parseUser = new ParseUser () {
					Username = user.Username,
					Password = user.Password,
					Email = user.Email
				} ;

				await parseUser.SignUpAsync ();
				// Sign up succeeded
				return true;
			}  catch (Exception e) {
				Console.Error.WriteLine (@"ERROR { 0}", e.Message);
				return false;
			}
		}




		public async Task<bool> LoginUserAsync (User user)
		{
			try {
				await ParseUser.LogInAsync (user.Username, user.Password);
				// Login was successful
				return true;
			}  catch (Exception e) {
				Console.Error.WriteLine (@"ERROR { 0}", e.Message);
				return false;
			}
		}




		public bool IsUserLoggedIn()
		{
			if (ParseUser.CurrentUser != null)
			{
				return true;
			}
			else
			{
				return false;
			}

		}




		public async Task LogoutAsync ()
		{
			try {
				await ParseUser.LogOutAsync ();
			}  catch (Exception e) {
				Console.Error.WriteLine (@"ERROR { 0}", e.Message);
			}
		}




	}
}

