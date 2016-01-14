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
			ABPeoplePickerNavigationController picker = new ABPeoplePickerNavigationController ();

			PeoplePickerDelegate pickerDelegate = new PeoplePickerDelegate ();

			picker.Delegate = pickerDelegate;

			// show the event controller

			FirstPage firstPage = new FirstPage ();

			UIApplication.SharedApplication.Windows[0].RootViewController.PresentModalViewController (picker, true);


		}


	


		public class PeoplePickerDelegate : ABPeoplePickerNavigationControllerDelegate

		{



			public override void Cancelled (ABPeoplePickerNavigationController peoplePicker)
			{
				UIApplication.SharedApplication.Windows [0].RootViewController.DismissViewController (true, null);

			}
	

		
			public override void DidSelectPerson (ABPeoplePickerNavigationController peoplePicker, ABPerson selectedPerson)
			{
				if (ParseUser.CurrentUser != null) {
					// create a new qmsalesContact object
					QMSalesContact qmsalesContact = new QMSalesContact ();


					if (selectedPerson.FirstName == null) {

						qmsalesContact.FirstName = "No first name";


					} else {

						qmsalesContact.FirstName = selectedPerson.FirstName;
					}


					if (selectedPerson.LastName == null) {

						qmsalesContact.LastName = "No last name";
					} else {

						qmsalesContact.LastName = selectedPerson.LastName;
					}


					if (selectedPerson.GetAllAddresses ().FirstOrDefault ().ToString () == null) {

						qmsalesContact.Address = "No address";
					} else {

						qmsalesContact.Address = selectedPerson.GetAllAddresses ().FirstOrDefault ().ToString ();
					}


					if (selectedPerson.GetEmails ().FirstOrDefault ().ToString () == null) {

						qmsalesContact.Email = "No email";
					} else {

						qmsalesContact.Email = selectedPerson.GetEmails ().FirstOrDefault ().ToString ();
					}


					if (selectedPerson.GetPhones ().FirstOrDefault ().ToString () == null) {

						qmsalesContact.PhoneNumber = "No phone number";
					} else {

						qmsalesContact.PhoneNumber = selectedPerson.GetPhones ().FirstOrDefault ().ToString ();
					}


					// there is no login or signup yet, so the user can't be set yet.
					qmsalesContact.User = ParseUser.CurrentUser.ToString ();
//					qmsalesContact.ObjectACL = new ParseACL(ParseUser.CurrentUser.ToString());

//					ParseACL objectACL = new ParseACL (ParseUser.CurrentUser);

//					// save this contact to parse
					DependencyService.Get<IParseStorage> ().SaveContactAsync (qmsalesContact);
					// dismiss people picker
					UIApplication.SharedApplication.Windows [0].RootViewController.DismissViewControllerAsync (true);

				} else {

					// show login page


				}



			}
		}





    }
}
