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
	public partial class CreateShopPage : ContentPage
	{
		public CreateShopPage ()
		{
			InitializeComponent ();
            
		}

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            var name = Name.Text;
            var location = Location.Text;
            var phone = Phone.Text;
        }
    }
}