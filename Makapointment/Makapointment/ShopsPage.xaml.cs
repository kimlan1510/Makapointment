using Makapointment.Models;
using Makapointment.Persistence;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Makapointment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShopsPage : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        private List<Shop> shops;
        public ShopsPage()
        {
            InitializeComponent();

            _conn = DependencyService.Get<ISQLiteDb>().GetConnection();
            
        }

        protected override async void OnAppearing()
        {
            await _conn.CreateTableAsync<Shop>();
            shops = await _conn.Table<Shop>().ToListAsync();

            listView.ItemsSource = shops;
        }

        IEnumerable<Shop> GetShops(string searchText = null)
        {
            if (String.IsNullOrWhiteSpace(searchText))
                return shops;
            return shops.Where(s => s.Name.ToLower().Contains(searchText.ToLower()));

        }
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = GetShops(e.NewTextValue);
        }




    }
}