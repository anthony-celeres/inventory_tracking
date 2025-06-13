using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;
using ClassDesign;

namespace UIDesign
{
    /// <summary>
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            InitializeComponent();
        }

        public Product product {  get; private set; }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = NameBox.Text;
                string id = IDBox.Text;

                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new InvalidProductException("Please enter a product name.");
                }

                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new InvalidProductException("Please enter a product ID.");
                }

                if (!int.TryParse(QuantityBox.Text, out int quantity))
                {
                    throw new InvalidProductException("Quantity must be a valid number.");
                }

                if (!int.TryParse(PriceBox.Text, out int price))
                {
                    throw new InvalidProductException("Price must be a valid number.");
                }

                if (Inventory.Products.Any(p => p.ID == id))
                {
                    throw new Exception("A product with this ID already exists.");
                }

                if (quantity <= 0)
                {
                    throw new InvalidProductException("Quantity must be greater than zero.");
                }

                if (price <= 0)
                {
                    throw new InvalidProductException("Price must be greater than zero.");
                }

                product = new Product(name, id, quantity, price);
                Inventory.AddProduct(product);

                this.DialogResult = true;
                this.Close(); // only closes if no exceptions occur
            }
            catch (InvalidProductException ex)
            {
                MessageBox.Show(ex.Message, "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
