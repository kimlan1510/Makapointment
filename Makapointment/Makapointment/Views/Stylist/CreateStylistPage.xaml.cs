using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Makapointment.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Makapointment.Persistence;
using SQLite.Net.Async;

namespace Makapointment
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateStylistPage : ContentPage
	{
        private SQLiteAsyncConnection _conn;
        public CreateStylistPage ()
		{
			InitializeComponent ();
            _conn = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        private async void ToolbarItem_Activated(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Name.Text) || String.IsNullOrWhiteSpace(Description.Text))
            {
                await DisplayAlert("Add Stylist", "Do not leave any field blank", "Ok");

            }
            else
            {
                var name = Name.Text;
                var description = Description.Text;
                
                Stylist newStylist = new Stylist { Name = name, Description = description};
                await _conn.InsertAsync(newStylist);
                await Navigation.PopAsync();

            }


        }
    }
}