using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Makapointment.Models;
using SQLite;
using Makapointment.Persistence;

namespace Makapointment
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateShopPage : ContentPage
	{
        private SQLiteAsyncConnection _conn;
        public CreateShopPage ()
		{
			InitializeComponent ();
            _conn = DependencyService.Get<ISQLiteDb>().GetConnection();

        }

        private async void ToolbarItem_Activated(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Name.Text) || String.IsNullOrWhiteSpace(Location.Text) || String.IsNullOrWhiteSpace(Phone.Text))
            {
                await DisplayAlert("Creat Shop", "Do not leave any field blank", "Ok");

            }
            else
            {
                var name = Name.Text;
                var location = Location.Text;
                var phone = Phone.Text;
                Shop newShop = new Shop { Name = name, Location = location, PhoneNumber = phone };
                await _conn.InsertAsync(newShop);
                await Navigation.PopAsync();

            }
           

        }
    }
}