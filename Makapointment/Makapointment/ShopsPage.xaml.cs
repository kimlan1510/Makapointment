using Makapointment.Models;
using Makapointment.Persistence;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<Shop> _shops;
        public ShopsPage()
        {
            InitializeComponent();

            _conn = DependencyService.Get<ISQLiteDb>().GetConnection();
                        

        }

        protected override async void OnAppearing()
        {
            await _conn.CreateTableAsync<Shop>();
            var listShop = await _conn.Table<Shop>().ToListAsync();
            _shops = new ObservableCollection<Shop>(listShop);
            listView.ItemsSource = _shops;

            base.OnAppearing();
        }

        IEnumerable<Shop> GetShops(string searchText = null)
        {
            if (String.IsNullOrWhiteSpace(searchText))
                return _shops;
            return _shops.Where(s => s.Name.ToLower().Contains(searchText.ToLower()));

        }
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = GetShops(e.NewTextValue);
        }

        private void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            DisplayAlert("ItemTappeds", "Tapped", "ok");
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            listView.SelectedItem = null;
           
        }

        private async void MenuItem_Delete(object sender, EventArgs e)
        {
            var menuItem = ((MenuItem)sender);
            var shop = menuItem.CommandParameter as Shop;
            _shops.Remove(shop);
            await _conn.DeleteAsync(shop);
        }

        private void MenuItem_Edit(object sender, EventArgs e)
        {

        }
    }
}