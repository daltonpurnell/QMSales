using System;

using Xamarin.Forms;

namespace QMSales
{
	public class Loadingpage : ContentPage
	{
		public Loadingpage ()
		{
			this.BackgroundColor = Color.FromRgb (136, 195, 55);

			Content = new StackLayout { 
				Children = {
					new Label { Text = "Loading...", TextColor = Color.FromRgb (136, 195, 55)}

				}
			};
		}


		protected override void OnAppearing ()
		{
			base.OnAppearing ();


			if (DependencyService.Get<IParseStorage>().IsUserLoggedIn())
			{
				Navigation.PushAsync( new FirstPage());
			}
			else
			{
				Navigation.PushAsync (new ParseLogin ());
			}

		}


	}
}


