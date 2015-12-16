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
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


