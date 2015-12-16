using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;


namespace QMSales
{
	public partial class MainPage : TabbedPage
	{
		

		class SalesToolItem {

			public SalesToolItem(string title) {
				this.Title = title;
			}
			public string Title { private set; get; }
		};



		class HandyRefItem {
			
			public HandyRefItem(string name) {
				this.Name = name;
			}
			public string Name { private set; get; }
		};




		public class SalesToolsPage : ContentPage 
		{

			// Define salestoolsitems list
			List<SalesToolItem> salesToolsItems = new List<SalesToolItem> 
			{
				new SalesToolItem("Elevator Pitch"),
				new SalesToolItem("Show Video"),
				new SalesToolItem("PowerPoint Slides")
			};



			public SalesToolsPage() {


				Title = "Sales Tools";
				Content = new ListView {

					ItemsSource = salesToolsItems,

					// Define template for displaying each item.
					// (Argument of DataTemplate constructor is called for 
					//      each item; it must return a Cell derivative.)
					ItemTemplate = new DataTemplate(() =>
						{
							// Create views with bindings for displaying each property.
							Label label = new Label();
							label.SetBinding(Label.TextProperty, "Title");

							// Return an assembled ViewCell.
							return new ViewCell
							{
								View = new StackLayout
								{
									Padding = new Thickness(10, 5),
									Orientation = StackOrientation.Horizontal,
									Children = 
									{
										label
									}
									}
							};
						})

				};
			}
		}




		public class HandyRefPage : ContentPage
		{

			List<HandyRefItem> handyRefItems = new List<HandyRefItem>
			{
				new HandyRefItem("Request A Demo"),
				new HandyRefItem("Request A Training"),
				new HandyRefItem("Hardware Requirements"),
				new HandyRefItem("Order Materials"),
				new HandyRefItem("View Training Materials"),
				new HandyRefItem("Sample Project Plan"),
				new HandyRefItem("QuickMAR University"),
				new HandyRefItem("News"),
				new HandyRefItem("Brochure"),
				new HandyRefItem("Fact Sheet"),
				new HandyRefItem("I bought QuickMAR. Now what?")
			};


			public HandyRefPage()
			{

				Title = "Handy Ref";
				Content = new ListView {

						ItemsSource = handyRefItems,

						// Define template for displaying each item.
						// (Argument of DataTemplate constructor is called for 
						//      each item; it must return a Cell derivative.)
						ItemTemplate = new DataTemplate(() =>
							{
								// Create views with bindings for displaying each property.
								Label label = new Label();
								label.SetBinding(Label.TextProperty, "Name");

								// Return an assembled ViewCell.
								return new ViewCell
								{
									View = new StackLayout
									{
										Padding = new Thickness(10, 5),
										Orientation = StackOrientation.Horizontal,
										Children = 
										{
											label
										}
									}
								};
							})

					};
			}
		}




		public class ContactsPage : ContentPage {


			public ContactsPage ()  
			{

				var tbi = new ToolbarItem ("+", null, () => {

					// open address book
					DependencyService.Get<IAddressBookInformation>().GetContacts();


				}, 0, 0);


				if (Device.OS == TargetPlatform.Android) { // BUG: Android doesn't support the icon being null
					tbi = new ToolbarItem ("+", "plus", () => {

						// open address book
						DependencyService.Get<IAddressBookInformation>().GetContacts();


					}, 0, 0);
				}

				ToolbarItems.Add (tbi);


				Title = "Contacts";
				Content = new ListView {

					//ItemsSource = await App.ContactManager.GetContactsAsync (),

					ItemTemplate = new DataTemplate(() =>
						{
							// Create views with bindings for displaying each property.
							Label label = new Label();
							label.SetBinding(Label.TextProperty, "First Name");

							Label lastName = new Label();
							lastName.SetBinding(Label.TextProperty, "Last Name");

							Label phoneNumber = new Label();
							phoneNumber.SetBinding(Label.TextProperty, "Phone Number");

							Label email = new Label();
							email.SetBinding(Label.TextProperty, "Email");

							Label address = new Label();
							address.SetBinding(Label.TextProperty, "Address");



							// Return an assembled ViewCell.
							return new ViewCell
							{
								View = new StackLayout
								{
									Padding = new Thickness(0, 5),
									Orientation = StackOrientation.Horizontal,
									Children = 
									{
										label,
										lastName,
										phoneNumber,
										email,
										address
									}
									}
							};
						})
				};
			}
		}




		public MainPage ()
		{
			InitializeComponent ();

			// load all contacts from parse
//			Task<Contact> AllSavedContactsList = DependencyService.Get<IParseStorage>().GetContactAsync();


			this.Children.Add (new NavigationPage(new HandyRefPage ()) { Title = "Handy Ref", BarBackgroundColor = Color.White });
			this.Children.Add (new NavigationPage(new SalesToolsPage ()) { Title = "Sales Tools", BarBackgroundColor = Color.White});
			this.Children.Add (new NavigationPage(new ContactsPage ()) { Title = "Contacts", BarBackgroundColor = Color.White});
		}
		// Icon = "Today.png"
	









		public void OnItemSelected (object sender, SelectedItemChangedEventArgs e) 		{

//			var item = (HandyRefItem)BindingContext;


			if (e.SelectedItem == null) {
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null

				// open url based on which cell was selected
			} else {
				
//				DisplayAlert ("Alert", "Row has been selected", "OK");

				switch (e.SelectedItem.ToString ()) 

				{

				case "Request A Demo":
					// open url
					Device.OpenUri(new Uri("http://quickmar.com"));
					break;
				case "Request A Training":
					// open url
					Device.OpenUri(new Uri("http://quickmar.com"));
					break;
				case "Hardware Requirements":
					// open url
					Device.OpenUri(new Uri("http://quickmar.com"));
					break;
				case "Order Materials":
					// open url
					Device.OpenUri(new Uri("http://quickmar.com"));
					break;
				case "View Training Materials":
					// open url
					Device.OpenUri(new Uri("http://quickmar.com"));
					break;
				case "Sample Project Plan":
					// open url
					Device.OpenUri(new Uri("http://quickmar.com"));
					break;
				case "QuickMAR University":
					// open url
					Device.OpenUri(new Uri("http://quickmar.com"));
					break;
				case "News":
					// open url
					Device.OpenUri(new Uri("http://quickmar.com"));
					break;
				case "Brochure":
					// open url
					Device.OpenUri(new Uri("http://quickmar.com"));
					break;
				case "Fact Sheet":
					// open url
					Device.OpenUri(new Uri("http://quickmar.com"));
					break;
				case "Show Video":
					// open url
					Device.OpenUri(new Uri("http://quickmar.com"));
					break;
				case "Elevator Pitch":
					// show alert view
					DisplayAlert ("Elevator Pitch", "Blah blah blah blah blah blah blah blah blah blah blah blah", "Ok");
					break;
				case "PowerPoint Slides":
					// open url
					Device.OpenUri(new Uri("http://quickmar.com"));
					break;
				case "I bought QuickMAR. Now what?":
					// show new page
					DisplayAlert ("What's next", "Blah blah blah blah blah blah blah blah blah blah blah blah", "Ok");
					break;
				default:
					// stuff
					break;
				}
			}
		}




	
	}
}


