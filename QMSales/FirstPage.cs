using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections;


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



			public class CustomCell : ViewCell
			{
				public CustomCell()
				{
					//instantiate each of our views
					StackLayout cellWrapper = new StackLayout ();
					StackLayout verticalLayout = new StackLayout ();
					Label first = new Label ();
					Label second = new Label ();
					Label third = new Label ();
					Label fourth = new Label();
					Label fifth = new Label ();


					//set bindings
					first.SetBinding (Label.TextProperty, "FirstName");
					second.SetBinding (Label.TextProperty, "FirstName");
					third.SetBinding (Label.TextProperty, "PhoneNumber");
					fourth.SetBinding (Label.TextProperty, "Email");
					fifth.SetBinding (Label.TextProperty, "Address");


					//Set properties for desired design
					cellWrapper.BackgroundColor = Color.White;
					verticalLayout.Orientation = StackOrientation.Vertical;

					first.VerticalOptions = LayoutOptions.FillAndExpand;
					second.VerticalOptions = LayoutOptions.FillAndExpand;
					third.VerticalOptions = LayoutOptions.FillAndExpand;
					fourth.VerticalOptions = LayoutOptions.FillAndExpand;

					first.TextColor = Color.FromRgb(120, 120, 120);
					second.TextColor = Color.FromRgb (120, 120, 120);
					third.TextColor = Color.FromRgb (120, 120, 120);
					fourth.TextColor = Color.FromRgb (120, 120, 120);
					fifth.TextColor = Color.FromRgb (120, 120, 120);


					//add views to the view hierarchy
					verticalLayout.Children.Add (first);
					verticalLayout.Children.Add (second);
					verticalLayout.Children.Add (third);
					verticalLayout.Children.Add (fourth);
					verticalLayout.Children.Add (fifth);
					cellWrapper.Children.Add (verticalLayout);
					View = cellWrapper;


				}



			}




			public ContactsPage ()  
			{
				var qmsalesContacts = DependencyService.Get<IParseStorage>().GetAll();


				Title = "Contacts";
				ListView ContactsListView = new ListView 
				
				{
					ItemsSource = (qmsalesContacts as IEnumerable), 
					ItemTemplate = new DataTemplate(typeof(CustomCell))				
				};



				Content = ContactsListView;
				ContactsListView.ItemSelected += OnItemSelected;


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




			public void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
			{

				if (e.SelectedItem == null) {
					return; //ItemSelected is called on deselection, which results in SelectedItem being set to null

					// send email to email address of whichever cell was selected
				} else {

					Navigation.PushModalAsync (new SelectMaterialsPage ());

				}

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

			if (Device.OS == TargetPlatform.iOS) { 
				this.Children.Add (new NavigationPage (new HandyRefPage ()) {
					Title = "Contacts",
					BarBackgroundColor = Color.FromRgb (136, 195, 55),
					BarTextColor = Color.White

				});
				this.Children.Add (new NavigationPage (new SalesToolsPage ()) {
					Title = "Contacts",
					BarBackgroundColor = Color.FromRgb (136, 195, 55),
					BarTextColor = Color.White
				});
				this.Children.Add (new NavigationPage (new ContactsPage ()) {
					Title = "Contacts",
					BarBackgroundColor = Color.FromRgb (136, 195, 55),
					BarTextColor = Color.White
				});

			} else if (Device.OS == TargetPlatform.Android) {
 
			this.Children.Add (new HandyRefPage ());
			this.Children.Add (new SalesToolsPage ());
			this.Children.Add (new ContactsPage ());

			
			}


		}
			

	
		protected override void OnAppearing ()
		{
			base.OnAppearing ();


			this.BackgroundColor = Color.White;




//			if (DependencyService.Get<IParseStorage>().IsUserLoggedIn())
//			{
////				DisplayAlert ("Welcome!", null, "Ok");
//			}
//			else
//			{
//				Navigation.PushModalAsync (new ParseLogin ());
//			}

//
//			DependencyService.Get<IDropboxService> ().LinkDropBox (this);

		}



	}
}


