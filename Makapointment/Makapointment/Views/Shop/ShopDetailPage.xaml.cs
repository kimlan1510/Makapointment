using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Makapointment.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using SQLite.Net.Async;
using Makapointment.Persistence;
using SQLiteNetExtensionsAsync.Extensions;

namespace Makapointment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShopDetailPage : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        private static Shop _shop;

        public ShopDetailPage(Shop shop)
        {
            _shop = shop ?? throw new ArgumentNullException();
            BindingContext = _shop;
            _conn = DependencyService.Get<ISQLiteDb>().GetConnection();

            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            var listStylists = _conn.GetWithChildrenAsync<Shop>(_shop.Id, recursive: true);
            var result = listStylists.Result.Stylists.ToList();

            listView.ItemsSource = new ObservableCollection<Stylist>(result);
            
            base.OnAppearing();
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StylistsToBeAddedToShopPage(_shop));
        }

        private void MenuItem_Delete(object sender, EventArgs e)
        {

        }


        private void MenuItem_Edit(object sender, EventArgs e)
        {

        }
    }
}