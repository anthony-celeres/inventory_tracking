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
        public static ObservableCollection<Product> products { get; } = new ObservableCollection<Product>();

        public void AddProduct(Product product)
        {
            products.Add (product);
        }

        public void RemoveProduct(Product product)
        {
            products.Remove(product);
        }
    }

}
