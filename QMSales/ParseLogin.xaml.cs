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
			this.BackgroundColor = Color.FromRgb (136, 195, 55);
			SignUpButton.TextColor = Color.White;
			SignUpButton.BackgroundColor = Color.Gray;
			LoginButton.TextColor = Color.White;
			LoginButton.BackgroundColor = Color.Gray;
			usernameLabel.TextColor = Color.White;
			passwordLabel.TextColor = Color.White;
			passwordEntry.BackgroundColor = Color.FromRgb (136, 195, 55);
			usernameEntry.BackgroundColor = Color.FromRgb (136, 195, 55);

		}



		public async void Login_Click(object sender, EventArgs e)  

		{   

			var user = new User () {
				Username = usernameEntry.Text,
				Password = passwordEntry.Text
			} ;

			var result = await DependencyService.Get<IParseStorage>().LoginUserAsync(user);

			if (result) {
				await Navigation.PushModalAsync(new FirstPage());
			} else {
				
				messageLabel.Text = "Login failed";
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

