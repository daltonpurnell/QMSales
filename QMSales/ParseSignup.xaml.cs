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
			this.BackgroundColor = Color.White;
			SignUpButton.TextColor = Color.White;
//			SignUpButton.BackgroundColor = Color.FromRgba(136, 195, 55, 255);
			SignUpButton.BackgroundColor = Color.Gray;
			passwordEntry.BackgroundColor = Color.Transparent;
			usernameEntry.BackgroundColor = Color.Transparent;
			emailEntry.BackgroundColor = Color.Transparent;

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

