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
            CategoryBox.ItemsSource = Enum.GetValues(typeof(ProductCategory));
        }

        public Product product {  get; private set; }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = NameBox.Text;
                string id = IDBox.Text;

                if (string.IsNullOrWhiteSpace(name))
                    throw new InvalidProductException("Please enter a product name.");

                if (string.IsNullOrWhiteSpace(id))
                    throw new InvalidProductException("Please enter a product ID.");

                if (!int.TryParse(QuantityBox.Text, out int quantity))
                    throw new InvalidProductException("Quantity must be a valid number.");

                if (!decimal.TryParse(PriceBox.Text, out decimal price))
                    throw new InvalidProductException("Price must be a valid number.");

                if (Inventory.Products.Any(p => p.ID == id))
                    throw new Exception("A product with this ID already exists.");

                if (quantity <= 0)
                    throw new InvalidProductException("Quantity must be greater than zero.");

                if (price <= 0)
                    throw new InvalidProductException("Price must be greater than zero.");

                if (CategoryBox.SelectedItem == null)
                    throw new InvalidProductException("Please select a product category.");

                ProductCategory category = (ProductCategory)CategoryBox.SelectedItem;

                product = new Product(name, id, quantity, price, category);
                Inventory.AddProduct(product);

                this.DialogResult = true;
                this.Close();
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

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit without saving?", "Confirm Exit", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void EscapeButton_Click(object sender, RoutedEventArgs e)
        {
            
                this.Close();
            
        }


    }
}
