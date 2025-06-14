using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDesign
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;

    public class Inventory 
    {
        public static ObservableCollection<Product> Products { get; } = new ObservableCollection<Product>();

        public static void AddProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            Products.Add(product);
        }

        public static void RemoveProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            Products.Remove(product);
        }

        public static void UpdateProduct(Product product, string name, string id, int quantity, decimal price, ProductCategory category)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            product.Name = name;
            product.ID = id;
            product.Quantity = quantity;
            product.Price = price;
            product.Category = category;
            product.UpdateProductStockStatus(quantity);
        }
    }

}
