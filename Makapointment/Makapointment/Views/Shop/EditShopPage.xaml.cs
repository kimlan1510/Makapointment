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
    public partial class EditShopPage : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        private static Shop _shop;

        public EditShopPage(Shop shop)
        {
            _shop = shop ?? throw new ArgumentNullException();
            BindingContext = _shop;

            InitializeComponent();
            _conn = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        private async void ToolbarItem_Activated(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Name.Text) || String.IsNullOrWhiteSpace(Location.Text) || String.IsNullOrWhiteSpace(Phone.Text))
            {
                await DisplayAlert("Edit Shop", "Do not leave any field blank", "Ok");

            }
            else
            {
                _shop.Name = Name.Text;
                _shop.Location = Location.Text;
               _shop.PhoneNumber = Phone.Text;

                await _conn.UpdateAsync(_shop);
                await Navigation.PopAsync();

            }
        }
    }
}