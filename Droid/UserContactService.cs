using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using QMSales.Droid;

[assembly: Dependency(typeof(UserContactService))]
namespace QMSales.Droid
{

	using System.Threading.Tasks;
	using Xamarin.Contacts;
	using Xamarin.Forms;


	public class UserContactService : IUserContactService
	{

		private readonly Xamarin.Contacts.AddressBook _book;

		private static IEnumerable<Contact> _contacts;

		public UserContactService ()
		{

			_book = new Xamarin.Contacts.AddressBook(Forms.Context.ApplicationContext);

		}


		public async Task<IEnumerable<Contact>> GetAllContacts()
		{
			if (_contacts != null) return _contacts;

			var contacts = new List<Contact>();
			await _book.RequestPermission().ContinueWith(t =>
				{
					if (!t.Result)
					{
						Console.WriteLine("Sorry! Permission was denied by user or manifest!");
						return;
					}
					foreach (var contact in _book.Where(c => c.Emails.Any())) // Filtering the Contact's that has E-Mail addresses
					{
						var firstOrDefault = contact.Emails.FirstOrDefault();
						if (firstOrDefault != null)
						{
							contacts.Add(new Contact()
								{ 
									FirstName = contact.FirstName, 
									LastName = contact.LastName,
//									PhoneNumber = contact.Phones, 
									Email = firstOrDefault.Address,
//									Address = contact.Addresses,
								});
						}
					}
				});

			_contacts = (from c in contacts orderby c.LastName select c).ToList();
			return _contacts;
		}

		public List<Contact> FindContacts(string searchString)
		{
			var ResultContacts = new List<Contact>();

			foreach (var currentContact in _contacts)
			{
				// Running a basic String Contains() search through all the 
				// fields in each Contact in the list for the given search string
				if ((currentContact.FirstName != null && currentContact.FirstName.ToLower().Contains(searchString.ToLower())) ||
					(currentContact.LastName != null && currentContact.LastName.ToLower().Contains(searchString.ToLower())) ||
					(currentContact.PhoneNumber != null && currentContact.PhoneNumber.ToLower().Contains(searchString.ToLower())) ||
					(currentContact.Email != null && currentContact.Email.ToLower().Contains(searchString.ToLower())) ||
					(currentContact.Address != null && currentContact.Address.ToLower().Contains(searchString.ToLower())))
				{
					ResultContacts.Add(currentContact);
				}
			}

			return ResultContacts;
		}

	}
}
