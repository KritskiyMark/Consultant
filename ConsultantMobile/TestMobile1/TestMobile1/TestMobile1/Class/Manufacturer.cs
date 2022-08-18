using System;
using System.Collections.Generic;
using System.Text;

namespace TestMobile1.Class
{
    public class Manufacturer
    {
            public int ID { get; set; }
            public string Name { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
