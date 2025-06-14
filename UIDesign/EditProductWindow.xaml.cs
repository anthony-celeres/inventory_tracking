using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ClassDesign;

namespace UIDesign
{
    /// <summary>
    /// Interaction logic for EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {

        private Product product;

        public EditProductWindow(Product selectedProduct)
        {
            InitializeComponent();
            product = selectedProduct;

            // Populate UI with current product values
            NameBox.Text = product.Name;
            IDBox.Text = product.ID;
            QuantityBox.Text = product.Quantity.ToString();
            PriceBox.Text = product.Price.ToString("F2");

            // Populate category combo box with enum values and select current
            CategoryBox.ItemsSource = Enum.GetValues(typeof(ProductCategory));
            CategoryBox.SelectedItem = product.Category;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
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

                if (CategoryBox.SelectedItem == null)
                    throw new InvalidProductException("Please select a product category.");

                if (Inventory.Products.Any(p => p != product && p.ID == id))
                    throw new Exception("A product with this ID already exists.");

                if (quantity <= 0)
                    throw new InvalidProductException("Quantity must be greater than zero.");

                if (price <= 0)
                    throw new InvalidProductException("Price must be greater than zero.");

                // Update product properties
                product.Name = name;
                product.ID = id;
                product.Quantity = quantity;
                product.Price = price;
                product.Category = (ProductCategory)CategoryBox.SelectedItem;
                product.UpdateProductStockStatus(quantity);

                this.DialogResult = true;
                this.Close(); // Closes only if successful
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

