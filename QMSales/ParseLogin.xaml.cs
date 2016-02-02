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
			this.BackgroundColor = Color.White;
			SignUpButton.TextColor = Color.White;
			SignUpButton.BackgroundColor = Color.Gray;
			LoginButton.TextColor = Color.White;
			LoginButton.BackgroundColor = Color.Gray;

			if (Device.OS == TargetPlatform.iOS) { 
				passwordEntry.BackgroundColor = Color.Transparent;
				usernameEntry.BackgroundColor = Color.Transparent;
			} else if (Device.OS == TargetPlatform.Android) { 

				passwordEntry.BackgroundColor = Color.Gray;
				usernameEntry.BackgroundColor = Color.Gray;
				LoginButton.IsEnabled = true;
				SignUpButton.IsEnabled = true;

			}

		}



		public async void Login_Click(object sender, EventArgs e)  

		{   

			var user = new User () {
				Username = usernameEntry.Text,
				Password = passwordEntry.Text
			} ;

			var result = await DependencyService.Get<IParseStorage>().LoginUserAsync(user);

			if (result) {
//				await Navigation.PushModalAsync(new FirstPage());
				await Navigation.PopModalAsync ();
			} else {
				
				messageLabel.Text = "Login failed";
				await DisplayAlert ("There was an error signing you in", "Please try again", "Ok");
			}

		}   

		public void SignUp_Click(object sender, EventArgs e)   

		{   
			Navigation.PushModalAsync(new ParseSignup());

		} 




		protected override void OnAppearing ()
		{
			base.OnAppearing ();



		}


	}
}

