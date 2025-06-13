using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Odbc;
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
        public int Price {  get; set; }
        public string Status {  get; set; }

        public Product(string name, string id, int quantity, int price) 
        {
            
            this.Name = name;
            this.ID = id;
            this.Quantity = quantity;
            this.Price = price;

            UpdateProductStockStatus(this.Quantity);
            
        }

        public void UpdateProductStockStatus(int quantity)
        {
            if (quantity < 0)
                throw new InvalidProductException("Quantity cannot be negative.");
            else if (quantity == 0)
                Status = "Empty Stock";
            else if (quantity <= 5 && quantity > 0)
                Status = "Low Stock";
            else if (quantity <= 15 && quantity > 5)
                Status = "Moderate Stock";
            else if (quantity > 15)
                Status = "High Stock";
        }
    }
}
