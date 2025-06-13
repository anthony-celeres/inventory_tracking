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

            Products.Add(product);
        }

        public static void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }
    }

}
