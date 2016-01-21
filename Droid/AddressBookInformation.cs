using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using QMSales.Droid;
using Android.Content;
using Android.App;
using Android.Widget;
using Parse;


[assembly: Dependency(typeof(AddressBookInformation))]
namespace QMSales.Droid
{
    using System.Threading.Tasks;
    using Xamarin.Contacts;
    using Xamarin.Forms;

    public class AddressBookInformation : IAddressBookInformation
    {
        /// <summary>
        /// The book.
        /// </summary>
        private AddressBook book = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressBookInformation"/> class.
        /// </summary>
        public AddressBookInformation()
        {
            this.book = new AddressBook(Forms.Context.ApplicationContext);
        }

        public async Task<List<QMSalesContact>> GetContacts()
        {
            var contacts = new List<QMSalesContact>();
            
            // Observation:
            // On device RequestPermission() returns false sometimes so you can use  this.book.RequestPermission().Result (remove await)
            var permissionResult = await this.book.RequestPermission();
            if (permissionResult)
            {
                if (!this.book.Any())
                {
                    Console.WriteLine("No contacts found");
                }

                foreach (Contact contact in book.OrderBy(c => c.LastName))
                {
                    // Note: on certain android device(Htc for example) it show name in DisplayName Field
					contacts.Add(new QMSalesContact() { FirstName = contact.FirstName, LastName = contact.LastName });
                }
            }

            return contacts;
        }

		public void DisplayContactScreen()
		{
			//Create a new intent for choosing a contact
			var contactPickerIntent = new Intent(Intent.ActionPick,
				Android.Provider.ContactsContract.Contacts.ContentUri);
			
			//Start the contact picker expecting a result with the resultCode '101'
			((Activity)Forms.Context).StartActivityForResult(contactPickerIntent, 101);



		}

	


		public void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			//See if we are handling the contact picker request code
			//  and that the result code is ok!
			if (requestCode == 101 && resultCode == Result.Ok)
			{
				//Ensure we have data returned
				if (data == null || data.Data == null)
					return;

				var addressBook = new Xamarin.Contacts.AddressBook (Xamarin.Forms.Forms.Context);
				//Note: This is important 
				addressBook.PreferContactAggregation = true;

				//Load the contact via the android contact id in the last segment of the Uri returned by the android contact picker
				var contact = addressBook.Load(data.Data.LastPathSegment);

					// create a new qmsalesContact object
					var qmsalesContact = new QMSalesContact ();

					if (contact.FirstName == null) {
						qmsalesContact.FirstName = "No first name";
					} else {
						qmsalesContact.FirstName = contact.FirstName;
					}

					if (contact.LastName == null) {
						qmsalesContact.LastName = "No last name";
					} else {
						qmsalesContact.LastName = contact.LastName;
					}

					if (contact.Addresses.FirstOrDefault () == null) {
						qmsalesContact.Address = "No address";
					} else {
						qmsalesContact.Address = contact.Addresses.FirstOrDefault ().ToString ();
					}

					if (contact.Emails.FirstOrDefault () == null) {
						qmsalesContact.Email = "No email";
					} else {
						qmsalesContact.Email = contact.Emails.FirstOrDefault ().ToString ();
					}

					if (contact.Phones.FirstOrDefault () == null) {
						qmsalesContact.PhoneNumber = "No phone number";
					} else {
						qmsalesContact.PhoneNumber = contact.Phones.FirstOrDefault ().ToString ();
					}

//					qmsalesContact.User = ParseUser.CurrentUser.ToString ();
//					qmsalesContact.ObjectACL = new ParseACL(ParseUser.CurrentUser.ToString());

//					ParseACL objectACL = new ParseACL (ParseUser.CurrentUser);

					// save this contact to parse
					DependencyService.Get<IParseStorage> ().SaveContactAsync (qmsalesContact);
					// dismiss contact picker


				} 
		}





    }
}