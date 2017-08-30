using Makapointment.Models;
using Makapointment.Persistence;
using SQLite;
using SQLite.Net.Async;
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
	public partial class StylistsPage : ContentPage
	{
        private SQLiteAsyncConnection _conn;
        private ObservableCollection<Stylist> _stylists;
        public StylistsPage ()
		{
			InitializeComponent ();
            _conn = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected override async void OnAppearing()
        {
            await _conn.CreateTableAsync <Stylist>();
            var listStylist = await _conn.Table<Stylist>().ToListAsync();
            _stylists = new ObservableCollection<Stylist>(listStylist);
            listView.ItemsSource = _stylists;

            base.OnAppearing();
        }

        IEnumerable<Stylist> GetStylists(string searchText = null)
        {
            if (String.IsNullOrWhiteSpace(searchText))
                return _stylists;
            return _stylists.Where(s => s.Name.ToLower().Contains(searchText.ToLower()));

        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = GetStylists(e.NewTextValue);
        }

        private void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
        //    var stylist = e.Item as Stylist;
        //    await Navigation.PushAsync(new StylistDetailPage(stylist));

        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            listView.SelectedItem = null;

        }

        private async void MenuItem_Delete(object sender, EventArgs e)
        {
            var menuItem = ((MenuItem)sender);
            var stylist = menuItem.CommandParameter as Stylist;
            _stylists.Remove(stylist);
            await _conn.DeleteAsync(stylist);
        }

        private void MenuItem_Edit(object sender, EventArgs e)
        {
            var menuItem = ((MenuItem)sender);
            var stylist = menuItem.CommandParameter as Stylist;

            Navigation.PushAsync(new EditStylistPage(stylist));
        }

        
    }
}