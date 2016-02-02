using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace QMSales
{
	public class SelectMaterialsPage : ContentPage
	{

		class HandyRefItem {

			public HandyRefItem(string name) {
				this.Name = name;
			}
			public string Name { private set; get; }
		};


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


		public SelectMaterialsPage ()
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



		}





		public void OnItemSelected (object sender, SelectedItemChangedEventArgs e)
		{


				

			if (e.SelectedItem == null) {
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null

				// open url based on which cell was selected
			} else {

				HandyRefItem handyRefItem = (HandyRefItem)e.SelectedItem;
				int index = -1;

				List<string> selectedItemsList = new List<string> { };

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


					selectedItemsList.Add(index.ToString());
	
				}

				if (index.ToString () == "1") {


					selectedItemsList.Add(index.ToString());


				}

				if (index.ToString () == "2") {


					selectedItemsList.Add(index.ToString());

				}

				if (index.ToString () == "3") {


					selectedItemsList.Add(index.ToString());


				}

				if (index.ToString () == "4") {


					selectedItemsList.Add(index.ToString());


				}

				if (index.ToString () == "5") {


					selectedItemsList.Add(index.ToString());


				}

				if (index.ToString () == "6") {


					selectedItemsList.Add(index.ToString());


				}

				if (index.ToString () == "7") {


					selectedItemsList.Add(index.ToString());


				}

				if (index.ToString () == "8") {


					selectedItemsList.Add(index.ToString());


				}

				if (index.ToString () == "9") {

					selectedItemsList.Add(index.ToString());


				}

				if (index.ToString () == "10") {

					selectedItemsList.Add(index.ToString());


				}
			}
		}









	}
}


