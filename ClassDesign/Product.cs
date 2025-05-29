using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDesign
{
    public class Product
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Quantity {  get; set; }

        public Product(string name, string id, int quantity) 
        { 
            this.Name = name;
            this.ID = id;  
            this.Quantity = quantity;
        }
    }
}
