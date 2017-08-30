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
	public partial class EditStylistPage : ContentPage
	{
        private SQLiteAsyncConnection _conn;
        private static Stylist _stylist;

        public EditStylistPage(Stylist stylist)
		{
            _stylist = stylist ?? throw new ArgumentNullException();
            BindingContext = _stylist;
            _conn = DependencyService.Get<ISQLiteDb>().GetConnection();

            InitializeComponent ();
		}

        private async void ToolbarItem_Activated(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Name.Text) || String.IsNullOrWhiteSpace(Description.Text))
            {
                await DisplayAlert("Edit Stylist", "Do not leave any field blank", "Ok");

            }
            else
            {
                _stylist.Name = Name.Text;
                _stylist.Description = Description.Text;
                

                await _conn.UpdateAsync(_stylist);
                await Navigation.PopAsync();

            }
        }
    }
}