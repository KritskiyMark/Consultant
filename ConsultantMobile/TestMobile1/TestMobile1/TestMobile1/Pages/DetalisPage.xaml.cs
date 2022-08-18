using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestMobile1.Class;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestMobile1.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalisPage : ContentPage
    {
        Product a { get; set; } = new Product();
        public DetalisPage( Product product)
        {
            InitializeComponent();
           
            if (product != null)
            {
                a = product;
                    }
            BindingContext = a;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var client = new WebClient();
            client.Headers.Clear();

            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            
            if (a.ID != 0)
            {

                
               
                   
                    client.UploadString("http://192.168.1.66:45455/api/Update" , JsonConvert.SerializeObject(a));
                   
                return;
            }
            
            var d = client.UploadString("http://192.168.1.66:45455/api/Products",
                  JsonConvert.SerializeObject(a));

            DisplayAlert("", $"{a.ID}\n{a.Name}\n{a.Model}\n{a.ManufacturerID}\n{a.Description}\n{a.Cost}\n{a.Number}\n{a.ProductImage}\n{a.ReceiptDate}", "Сохраненно");
        }
        

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}