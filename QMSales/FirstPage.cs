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
							Label label = new Label() { TextColor = Color.FromRgb (100, 100, 100)};
							label.SetBinding(Label.TextProperty, "Title");

							// Return an assembled ViewCell.
							return new ViewCell
							{


								View = new StackLayout
								{
									Padding = new Thickness(15, 10),
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


				// create logout toolbar item
				var tbi2 = new ToolbarItem ("Log Out", null, () => {

				}, 0, 0);


				if (Device.OS == TargetPlatform.Android) { // BUG: Android doesn't support the icon being null
					tbi2 = new ToolbarItem ("Log Out", "Log Out", () => {

					}, 0, 0);
				}

				ToolbarItems.Add(tbi2);
				tbi2.Clicked+= HandleLogOutEvent;


			}


			public void HandleLogOutEvent (object sender, EventArgs ea) {

				DependencyService.Get<IParseStorage> ().LogoutAsync ();
				Navigation.PushModalAsync (new ParseLogin ());

			}



			public void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
			{


				if (e.SelectedItem == null) {
					return; //ItemSelected is called on deselection, which results in SelectedItem being set to null

					// open url based on which cell was selected
				} else {
					
					SalesToolItem item = (SalesToolItem)e.SelectedItem;
					int index = -1;

					for(int i = 0; i < salesToolsItems.Count; i++)
					{
						if(salesToolsItems[i] == item)
						{
							index = i;
							break;
						}
					}
//					DisplayAlert("Tapped", index.ToString(), "OK");

					if (index.ToString () == "0") {

						Device.OpenUri(new Uri("http://quickmar.com"));
						((ListView)sender).SelectedItem = null; // de-select the row

					}

					if (index.ToString () == "1") {

						Device.OpenUri(new Uri("http://quickmar.com"));
						((ListView)sender).SelectedItem = null; // de-select the row

					}

					if (index.ToString () == "2") {

						Device.OpenUri(new Uri("http://quickmar.com"));
						((ListView)sender).SelectedItem = null; // de-select the row

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
							Label label = new Label() { TextColor = Color.FromRgb (100, 100, 100)};
							label.SetBinding(Label.TextProperty, "Name");

							// Return an assembled ViewCell.
							return new ViewCell
							{
								View = new StackLayout
								{
									Padding = new Thickness(15, 10),
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

				// create logout toolbar item
				var tbi2 = new ToolbarItem ("Log Out", null, () => {

				}, 0, 0);


				if (Device.OS == TargetPlatform.Android) { // BUG: Android doesn't support the icon being null
					tbi2 = new ToolbarItem ("Log Out", "Log Out", () => {

					}, 0, 0);
				}

				ToolbarItems.Add(tbi2);
				tbi2.Clicked+= HandleLogOutEvent;



			}





			public void HandleLogOutEvent (object sender, EventArgs ea) {

				DependencyService.Get<IParseStorage> ().LogoutAsync ();
				Navigation.PushModalAsync (new ParseLogin ());

			}



			public void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
			{

				var item = (HandyRefItem)BindingContext;


				if (e.SelectedItem == null) {
					return; //ItemSelected is called on deselection, which results in SelectedItem being set to null

					// open url based on which cell was selected
				} else {

					HandyRefItem handyRefItem = (HandyRefItem)e.SelectedItem;
					int index = -1;

					for(int i = 0; i < handyRefItems.Count; i++)
					{
						if(handyRefItems[i] == handyRefItem)
						{
							index = i;
							break;
						}
					}
					//					DisplayAlert("Tapped", index.ToString(), "OK");

					if (index.ToString () == "0") {

						Device.OpenUri(new Uri("http://quickmar.com"));
						((ListView)sender).SelectedItem = null; // de-select the row

					}

					if (index.ToString () == "1") {

						Device.OpenUri(new Uri("http://quickmar.com"));
						((ListView)sender).SelectedItem = null; // de-select the row

					}

					if (index.ToString () == "2") {

						Device.OpenUri(new Uri("http://quickmar.com"));
						((ListView)sender).SelectedItem = null; // de-select the row

					}

					if (index.ToString () == "3") {

						Device.OpenUri(new Uri("http://quickmar.com"));
						((ListView)sender).SelectedItem = null; // de-select the row

					}

					if (index.ToString () == "4") {

						Device.OpenUri(new Uri("http://quickmar.com"));
						((ListView)sender).SelectedItem = null; // de-select the row

					}

					if (index.ToString () == "5") {

						Device.OpenUri(new Uri("http://quickmar.com"));
						((ListView)sender).SelectedItem = null; // de-select the row

					}

					if (index.ToString () == "6") {

						Device.OpenUri(new Uri("http://quickmar.com"));
						((ListView)sender).SelectedItem = null; // de-select the row

					}

					if (index.ToString () == "7") {

						Device.OpenUri(new Uri("http://quickmar.com"));
						((ListView)sender).SelectedItem = null; // de-select the row

					}

					if (index.ToString () == "8") {

						Device.OpenUri(new Uri("http://quickmar.com"));
						((ListView)sender).SelectedItem = null; // de-select the row

					}

					if (index.ToString () == "9") {

						Device.OpenUri(new Uri("http://quickmar.com"));
						((ListView)sender).SelectedItem = null; // de-select the row

					}

					if (index.ToString () == "10") {

						Device.OpenUri(new Uri("http://quickmar.com"));
						((ListView)sender).SelectedItem = null; // de-select the row

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
									Padding = new Thickness(15, 10),
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


				// create plus toolbar item
				var tbi = new ToolbarItem ("+", null, () => {

				}, 0, 0);


				if (Device.OS == TargetPlatform.Android) { // BUG: Android doesn't support the icon being null
					tbi = new ToolbarItem ("+", "plus", () => {

					}, 0, 0);
				}


				ToolbarItems.Add (tbi);
				tbi.Clicked+= HandleEvent;



				// create logout toolbar item
				var tbi2 = new ToolbarItem ("Log Out", null, () => {

				}, 0, 0);


				if (Device.OS == TargetPlatform.Android) { // BUG: Android doesn't support the icon being null
					tbi2 = new ToolbarItem ("Log Out", "Log Out", () => {

					}, 0, 0);
				}

				ToolbarItems.Add(tbi2);
				tbi2.Clicked+= HandleLogOutEvent;


			}

			public void HandleEvent (object sender, EventArgs ea) {

//				DisplayAlert ("Alert", "You tapped the plus", "OK");

				// open address book
				DependencyService.Get<IAddressBookInformation>().GetContacts();
				DependencyService.Get<IAddressBookInformation> ().DisplayContactScreen ();

			}


			public void HandleLogOutEvent (object sender, EventArgs ea) {

				DependencyService.Get<IParseStorage> ().LogoutAsync ();
				Navigation.PushModalAsync (new ParseLogin ());

			}
				
		}


			
		public FirstPage ()
		{

			this.Children.Add (new HandyRefPage ());
			this.Children.Add (new SalesToolsPage ());
			this.Children.Add (new ContactsPage ());


//			this.Children.Add (new NavigationPage(new ContactsPage ()) { Title = "Contacts", BarBackgroundColor = Color.FromRgb (136, 195, 55), BarTextColor = Color.White});

		}
			

	
		protected override void OnAppearing ()
		{
			base.OnAppearing ();

//			DependencyService.Get<IDropboxService> ().LinkDropBox (this);


		}



	}
}


