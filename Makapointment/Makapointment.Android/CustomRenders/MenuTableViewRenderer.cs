//using System;
//using Xamarin.Forms;
//using Xamarin.Forms.Platform.Android;
//using Android.Widget;


//[assembly: ExportRenderer(typeof(Makapointment.CreateShopPage), typeof(Makapointment.MenuTableViewRenderer))]
//namespace Makapointment
//{
//    public class MenuTableViewRenderer : TableViewRenderer
//    {
//        protected override void OnElementChanged(ElementChangedEventArgs<TableView> e)
//        {
//            base.OnElementChanged(e);
//            if (Control == null)
//                return;
//            var listView = Control as Android.Widget.ListView;
//            listView.Divider.SetVisible(false, true);
//        }
//    }
//}