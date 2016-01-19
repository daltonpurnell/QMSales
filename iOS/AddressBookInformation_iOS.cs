using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using Xamarin.Forms;
using QMSales.iOS;
using AddressBookUI;
using UIKit;
using AddressBook;
using Parse;
using Contacts;
using ContactsUI;
using Foundation;


[assembly: Dependency(typeof(AddressBookInformation_iOS))]
namespace QMSales.iOS
{
    using System.Linq;
    using System.Threading.Tasks;
    using Xamarin.Contacts;





    public class AddressBookInformation_iOS : IAddressBookInformation
    {
        /// <summary>
        /// The book.
        /// </summary>
        private AddressBook book = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressBookInformation_iOS"/> class.
        /// </summary>
        public AddressBookInformation_iOS()
        {
            this.book = new AddressBook();
        }

        public async Task<List<QMSalesContact>> GetContacts()
        {
            var contacts = new List<QMSalesContact>();
            
            // Observation:
            // On device this returns false sometimes so you can use like this.book.RequestPermission().Result (remove await)
            var permissionResult = await this.book.RequestPermission();
            if (permissionResult)
            {
                if (!this.book.Any())
                {
                    Console.WriteLine("No contacts found");
                }

                foreach (Contact contact in book.OrderBy(c => c.LastName))
                {
					contacts.Add(new QMSalesContact() { FirstName = contact.FirstName, LastName = contact.LastName });
                }
            }

            return contacts;
        }


		public void DisplayContactScreen()
		{
			//... do iOS Magic
			CNContactPickerViewController picker = new CNContactPickerViewController ();

			ContactPickerDelegate pickerDelegate = new ContactPickerDelegate ();

			picker.Delegate = pickerDelegate;

//			// Define fields to be searched
//			var fetchKeys = new NSObject[] {CNContactKey.EmailAddresses};
//			// Grab matching contacts
//			var store = new CNContactStore();
//			NSError error;
//			var contacts = store.GetUnifiedContacts(null, fetchKeys, out error);

			// present contact picker
			UIApplication.SharedApplication.Windows[0].RootViewController.PresentModalViewController (picker, true);


		}




		public class ContactPickerDelegate : CNContactPickerDelegate {


			#region Constructors
			public ContactPickerDelegate ()
			{
			}

			public ContactPickerDelegate (IntPtr handle) : base (handle)
			{
			}
			#endregion



			#region Override Methods
			public override void ContactPickerDidCancel (CNContactPickerViewController picker)
			{

				UIApplication.SharedApplication.Windows [0].RootViewController.DismissViewController (true, null);
				Console.WriteLine ("User canceled picker");

			}

			public override void DidSelectContact (CNContactPickerViewController picker, CNContact contact)
			{

				// create a new qmsalesContact object
				QMSalesContact qmsalesContact = new QMSalesContact ();


				if (contact.GivenName == null) {

					qmsalesContact.FirstName = "No first name";


				} else {

					qmsalesContact.FirstName = contact.GivenName;
				}


				if (contact.FamilyName == null) {

					qmsalesContact.LastName = "No last name";
				} else {

					qmsalesContact.LastName = contact.FamilyName;
				}


				if (contact.PostalAddresses.FirstOrDefault().ToString()== null) {

					qmsalesContact.Address = "No address";
				} else {

					qmsalesContact.Address = contact.PostalAddresses.FirstOrDefault ().ToString ();
				}


				if (contact.EmailAddresses.FirstOrDefault().ToString() == null) {

					qmsalesContact.Email = "No email";
				} else {

					qmsalesContact.Email = contact.EmailAddresses.FirstOrDefault ().ToString ();
				}


				if (contact.PhoneNumbers.FirstOrDefault().ToString() == null) {

					qmsalesContact.PhoneNumber = "No phone number";
				} else {

					qmsalesContact.PhoneNumber = contact.PhoneNumbers.FirstOrDefault ().ToString ();
				}


				// there is no login or signup yet, so the user can't be set yet.
				qmsalesContact.User = ParseUser.CurrentUser.ToString ();

//					qmsalesContact.ObjectACL = new ParseACL(ParseUser.CurrentUser.ToString());
//					ParseACL objectACL = new ParseACL (ParseUser.CurrentUser);


//				//Create Alert
//				var okAlertController = UIAlertController.Create ("Add this contact to your list", null, UIAlertControllerStyle.Alert);
//
//				//Add Action
//				okAlertController.AddAction (UIAlertAction.Create ("Ok", UIAlertActionStyle.Default, null));
//				//Add Action
//				okAlertController.AddAction (UIAlertAction.Create ("No thanks", UIAlertActionStyle.Cancel, null));
//
//				// Present Alert
//				UIApplication.SharedApplication.Windows [0].RootViewController.PresentViewController (okAlertController, true, null);



//					// save this contact to parse
				DependencyService.Get<IParseStorage> ().SaveContactAsync (qmsalesContact);
				// dismiss people picker
				UIApplication.SharedApplication.Windows [0].RootViewController.DismissViewControllerAsync (true);

				Console.WriteLine ("Selected: {0}", contact);
			}

			public override void DidSelectContactProperty (CNContactPickerViewController picker, CNContactProperty contactProperty)
			{

				Console.WriteLine ("Selected Property: {0}", contactProperty);

			}
			#endregion
		}
	}
		
}
