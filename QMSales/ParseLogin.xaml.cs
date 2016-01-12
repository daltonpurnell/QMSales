using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace QMSales
{
	public partial class ParseLogin : ContentPage
	{


		public ParseLogin ()
		{
			InitializeComponent ();


		}



		public async void Login_Click(object sender, EventArgs e)  

		{   

			var user = new User () {
				Username = usernameEntry.Text,
				Password = passwordEntry.Text
			} ;

			var result = await DependencyService.Get<IParseStorage>().LoginUserAsync(user);

			if (result) {
				await Navigation.PopModalAsync();
			} else {
				
				messageLabel.Text = "Login failed";
			}

		}   

		public void SignUp_Click(object sender, EventArgs e)   

		{   
			Navigation.PushModalAsync(new ParseSignup());

		} 


	}
}

