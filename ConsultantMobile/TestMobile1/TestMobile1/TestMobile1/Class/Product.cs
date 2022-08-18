using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace TestMobile1.Class
{
    public class Product
    {

            public int ID { get; set; }
            public string Name { get; set; }
            public string Model { get; set; }
            public decimal Cost { get; set; }
            public string Description { get; set; }
            public Nullable<int> ManufacturerID { get; set; }
            public System.DateTime ReceiptDate { get; set; }
            public Nullable<int> Number { get; set; }
            public string ProductImage { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public ImageSource Photo
        {
            get
            {
                return ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(ProductImage)));
            }
        }


    }
}
