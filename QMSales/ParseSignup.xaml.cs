using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace QMSales
{
	public partial class ParseSignup : ContentPage
	{

		public ParseSignup ()
		{
			InitializeComponent ();
			this.BackgroundColor = Color.FromRgb (136, 195, 55);
			SignUpButton.TextColor = Color.White;
			SignUpButton.BackgroundColor = Color.Gray;
			usernameLabel.TextColor = Color.White;
			passwordLabel.TextColor = Color.White;
			emailLabel.TextColor = Color.White;
			passwordEntry.BackgroundColor = Color.FromRgb (136, 195, 55);
			usernameEntry.BackgroundColor = Color.FromRgb (136, 195, 55);
			emailEntry.BackgroundColor = Color.FromRgb (136, 195, 55);

		}


		async void OnSignUpActivated(object sender, EventArgs e) 

		{   

			var user = new User () {
				
				Username = usernameEntry.Text,
				Password = passwordEntry.Text,
				Email = emailEntry.Text

			} ;
					
			var result = await DependencyService.Get<IParseStorage>().SignUpUserAsync(user);

			if (result) {
				await Navigation.PushModalAsync (new FirstPage ());
			} else {

				messageLabel.Text = "Sign up failed";
			}
		} 



		protected override void OnAppearing ()
		{
			base.OnAppearing ();


		}


	}


}

