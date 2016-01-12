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


		async void OnSignUpActivated(object sender, EventArgs e) 

		{   

			var user = new User () {
				
				Username = usernameEntry.Text,
				Password = passwordEntry.Text,
				Email = emailEntry.Text

			} ;
					
			var result = await DependencyService.Get<IParseStorage>().SignUpUserAsync(user);

			if (result) {
				await Navigation.PushAsync (new FirstPage ());
			} else {

				messageLabel.Text = "Sign up failed";
			}
		} 





	}
}

