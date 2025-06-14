using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDesign
{
    public class Product : INotifyPropertyChanged
    {
        private string name;
        private string id;
        private int quantity;
        private decimal price;
        private string status;
        private ProductCategory category;

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string ID
        {
            get => id;
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(ID));
                }
            }
        }

        public int Quantity
        {
            get => quantity;
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }

        public decimal Price
        {
            get => price;
            set
            {
                if (price != value)
                {
                    price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }

        public string Status
        {
            get => status;
            set
            {
                if (status != value)
                {
                    status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        public ProductCategory Category
        {
            get => category;
            set
            {
                if (category != value)
                {
                    category = value;
                    OnPropertyChanged(nameof(Category));
                }
            }
        }

        public Product(string name, string id, int quantity, decimal price, ProductCategory category)
        {
            Name = name;
            ID = id;
            Quantity = quantity;
            Price = price;
            Category = category;
            UpdateProductStockStatus(quantity);
        }

        public void UpdateProductStockStatus(int quantity)
        {
            if (quantity < 0)
                throw new InvalidProductException("Quantity cannot be negative.");
            else if (quantity == 0)
                Status = "Empty Stock";
            else if (quantity <= 5)
                Status = "Low Stock";
            else if (quantity <= 15)
                Status = "Moderate Stock";
            else
                Status = "High Stock";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
