using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApi1.Entities;
using Xamarin.Forms;

namespace TestApi1.Models
{
    public class ResponseManufacturer
    {
        public ResponseManufacturer(Manufacturer manufacturer)
        {
            ID = manufacturer.ID;
            Name = manufacturer.Name;

        }

        public int ID { get; set; }
        public string Name { get; set; }
    }
}