using System;

using Xamarin.Forms;

namespace QMSales
{
	public class Loadingpage : ContentPage
	{
		public Loadingpage ()
		{


			Content = new StackLayout { 
				Children = {
					new Label { Text = "Loading...", TextColor = Color.FromRgb (136, 195, 55)}

				}
			};
		}


		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			this.BackgroundColor = Color.FromRgb (136, 195, 55);


			if (DependencyService.Get<IParseStorage>().IsUserLoggedIn())
			{


				Navigation.PushModalAsync(new FirstPage());

			}
			else
			{

				Navigation.PushModalAsync (new ParseLogin ());
			}

		}


	}
}


