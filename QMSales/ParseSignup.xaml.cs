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

		}


		public async void SignUp_Click(object sender, EventArgs e)   

		{   

			var user = new User () {
				
				Username = usernameEntry.Text,
				Password = passwordEntry.Text,
				Email = emailEntry.Text

			} ;
					
			var result = await App.userManager.SignUpUserAsync (user);

			if (result) {
				await Navigation.PopModalAsync();
			} else {

				messageLabel.Text = "Sign up failed";
			}
		} 





	}
}

