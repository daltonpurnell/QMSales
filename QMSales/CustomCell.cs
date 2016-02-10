using System;
using Xamarin.Forms;

namespace QMSales
{
	public class CustomCell : ViewCell
	{
		public CustomCell ()
		{
			var first = new Label {

				HorizontalTextAlignment = TextAlignment.Center
			};
			var second = new Label {

				HorizontalTextAlignment = TextAlignment.Center
					
			};
			var third = new Label {

				HorizontalTextAlignment = TextAlignment.Center
					

			};
			var fourth = new Label {

				HorizontalTextAlignment = TextAlignment.Center
					
			};
			var fifth = new Label {

				HorizontalTextAlignment = TextAlignment.Center
					
			};


			first.SetBinding(Label.TextProperty, "FirstName");
			second.SetBinding (Label.TextProperty, "LastName");
			third.SetBinding (Label.TextProperty, "PhoneNumber");
			fourth.SetBinding (Label.TextProperty, "Email");
			fifth.SetBinding (Label.TextProperty, "Address");



			var layout = new StackLayout
			{
				Padding = new Thickness(20, 0, 0, 0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = 
				{ 
					first,
					second,
					third,
					fourth,
					fifth
				}
			};

			View = layout;
		}


		protected override void OnBindingContextChanged()
		{
			View.BindingContext = BindingContext;
			base.OnBindingContextChanged();
		}
			
	}
}
