using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApi1.Entities;
using Xamarin.Forms;

namespace TestApi1.Models
{
    public class ResponseProduct
    {
        public ResponseProduct(Product product)
        {
            ID = product.ID;
            Name = product.Name;
            Model = product.Model;
            Cost = (decimal)product.Cost;
            Description = product.Description;
            ManufacturerID = product.ManufacturerID;
            ReceiptDate = product.ReceiptDate;
            Number = product.Number;
            ProductImage = product.ProductImage;

        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public Nullable<int> ManufacturerID { get; set; }
        public System.DateTime ReceiptDate { get; set; }
        public Nullable<int> Number { get; set; }
        public byte[] ProductImage { get; set; }
    }
}