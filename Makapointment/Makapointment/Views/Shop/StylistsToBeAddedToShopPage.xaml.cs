using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Makapointment;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Makapointment.Models;
using SQLite;
using System.Collections.ObjectModel;
using Makapointment.Persistence;
using SQLiteNetExtensions.Attributes;
using SQLite.Net.Async;
using SQLiteNetExtensionsAsync.Extensions;

namespace Makapointment
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StylistsToBeAddedToShopPage : ContentPage
	{
        private SQLiteAsyncConnection _conn;
        private ObservableCollection<Stylist> _stylists;
        private static Shop _shop;

        public StylistsToBeAddedToShopPage (Shop shop)
		{
            _shop = shop ?? throw new ArgumentNullException();
            _conn = DependencyService.Get<ISQLiteDb>().GetConnection();

            InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            await _conn.CreateTableAsync<Shop_Stylist>();
            //var AddedStylists = await _conn.GetWithChildrenAsync<Shop>(_shop.Id);

            var listStylist = await _conn.Table<Stylist>().ToListAsync();
            _stylists = new ObservableCollection<Stylist>(listStylist);
            listView.ItemsSource = _stylists;
           
            base.OnAppearing();
        }

        private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var shop = _shop;
            var selectedStylist = e.Item as Stylist;
            _shop.Stylists = new List<Stylist> { selectedStylist };
            await _conn.InsertOrReplaceWithChildrenAsync(_shop);

            //selectedStylist.Shops = new List<Shop> { _shop };
            //await _conn.UpdateWithChildrenAsync(selectedStylist);
            await Navigation.PopAsync();

        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            listView.SelectedItem = null;

        }
    }
}