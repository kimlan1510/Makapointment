using Makapointment.Models;
using Makapointment.Persistence;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Makapointment
{
    public partial class MainPage : TabbedPage
    {
        private SQLiteAsyncConnection _conn;
        public MainPage()
        {
            _conn = DependencyService.Get<ISQLiteDb>().GetConnection();
            InitializeComponent();
            
        }

        protected override async void OnAppearing()
        {
            await _conn.CreateTableAsync<Shop>();
            await _conn.CreateTableAsync<Stylist>();
            await _conn.CreateTableAsync<Shop_Stylist>();

            base.OnAppearing();
        }

        private async void AddShop(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateShopPage());
            
        }

        private async void AddStylist(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateStylistPage());

        }
    }
}
