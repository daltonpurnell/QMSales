using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;


namespace QMSales
{
	public class FirstPage : TabbedPage
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
				ListView SalesToolsListView = new ListView {

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

				Content = SalesToolsListView;
				SalesToolsListView.ItemSelected += OnItemSelected;

			}

		

			public void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
			{

				var item = (HandyRefItem)BindingContext;


				if (e.SelectedItem == null) {
					return; //ItemSelected is called on deselection, which results in SelectedItem being set to null

					// open url based on which cell was selected
				} else {

					DisplayAlert ("Alert", e.SelectedItem.ToString(), "OK");


					switch (e.SelectedItem.GetHashCode()) 

					{

					case 0:
						// open url
						Device.OpenUri(new Uri("http://quickmar.com"));
						break;
					case 1:
						// show alert view
						DisplayAlert ("Elevator Pitch", "Blah blah blah blah blah blah blah blah blah blah blah blah", "Ok");
						break;
					case 2:
						// open url
						Device.OpenUri(new Uri("http://quickmar.com"));
						break;
					default:
						// stuff
						break;
					}
				}
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
				ListView HandyRefListView = new ListView {



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

				Content = HandyRefListView;
				HandyRefListView.ItemSelected += OnItemSelected;

			}



			public void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
			{

				var item = (HandyRefItem)BindingContext;


				if (e.SelectedItem == null) {
					return; //ItemSelected is called on deselection, which results in SelectedItem being set to null

					// open url based on which cell was selected
				} else {

									DisplayAlert ("Alert", "Row has been selected", "OK");

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




		public class ContactsPage : ContentPage {


			public ContactsPage ()  
			{

				Title = "Contacts";
				ListView ContactsListView = new ListView {



// 					Need logic to only call this method if there are objects to get so it doesn't return null
//					ItemsSource = DependencyService.Get<IParseStorage>().GetAll (),

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
									Padding = new Thickness(10, 5),
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

				Content = ContactsListView;

				var tbi = new ToolbarItem ("+", null, () => {

				}, 0, 0);


				if (Device.OS == TargetPlatform.Android) { // BUG: Android doesn't support the icon being null
					tbi = new ToolbarItem ("+", "plus", () => {

					}, 0, 0);
				}


				ToolbarItems.Add (tbi);
				tbi.Clicked+= HandleEvent;
			}

			public void HandleEvent (object sender, EventArgs ea) {

//				DisplayAlert ("Alert", "You tapped the plus", "OK");

				// open address book
				DependencyService.Get<IAddressBookInformation>().GetContacts();
				DependencyService.Get<IAddressBookInformation> ().DisplayContactScreen ();



			}
				

		}


			
		public FirstPage ()
		{

			this.Children.Add (new NavigationPage(new HandyRefPage ()) { Title = "Handy Ref", BarBackgroundColor = Color.White });
			this.Children.Add (new NavigationPage(new SalesToolsPage ()) { Title = "Sales Tools", BarBackgroundColor = Color.White});
			this.Children.Add (new NavigationPage(new ContactsPage ()) { Title = "Contacts", BarBackgroundColor = Color.White});

		}
			

	
		protected override void OnAppearing ()
		{
			base.OnAppearing ();


		}



	}
}


