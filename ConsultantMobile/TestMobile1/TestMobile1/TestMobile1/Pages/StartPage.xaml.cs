using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestMobile1.Class;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Command = MvvmHelpers.Commands.Command;


namespace TestMobile1.Pages
{
    public partial class StartPage : ContentPage
    {

        

        public StartPage()
        {
            InitializeComponent();
            var client = new WebClient();
            var response = client.DownloadString("http://192.168.1.66:45455/api/Products");
            LViewProducts.ItemsSource = JsonConvert.DeserializeObject<List<Product>>(response);
           
            LViewProducts.RefreshCommand = new Command(() => {
                //Do your stuff.    
                RefreshData();
                LViewProducts.IsRefreshing = false;
            });




        }
        public void RefreshData()
        {
            var client = new WebClient();
            var response = client.DownloadString("http://192.168.1.66:45455/api/Products");
            LViewProducts.ItemsSource = JsonConvert.DeserializeObject<List<Product>>(response);


        }




            private void LViewProducts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new DetalisPage(LViewProducts.SelectedItem as Product));
        }

        private void AddItem(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DetalisPage(null));
        }

      

        private void LViewProducts_ItemTapped(object sender, ItemTappedEventArgs e)
        {
           /* ((ListView)sender).SelectedItem = null;*/
        }


    }
}