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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassDesign;

namespace UIDesign
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> Products { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Products = new ObservableCollection<Product>();
            this.DataContext = this; // Now {Binding Products} will work
            Product p = new Product("Banana", "123", 20);
            Product q = new Product("Apple", "124", 4);
            Product r = new Product("Orange", "125", 6);
            Product s = new Product("Pineapple", "126", 10);
            Product t = new Product("Mango", "127", 11);
            Products.Add(p);
            Products.Add(q);
            Products.Add(r);
            Products.Add(s);
            Products.Add(t);

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string productName = NameBox.Text?.Trim();
                string productID = IDBox.Text?.Trim();
                
                if (string.IsNullOrWhiteSpace(productName))
                {
                    throw new Exception("Please enter a product name.");
                }

                if (string.IsNullOrWhiteSpace(productID))
                {
                    throw new Exception("Please enter a product ID.");
                }

                if (!int.TryParse(QuantityBox.Text, out int quantity) || quantity < 0)
                {
                    throw new Exception("Please enter a valid and positive product quantity.");
                }

                // Check if product ID already exists
                if (Products.Any(p => p.ID == productID))
                {
                    throw new Exception("A product with this ID already exists.");
                }

                // Create and add new product
                var product = new Product(productName, productID, quantity);
                Products.Add(product);
                

                // Clear input fields
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ClearInputFields()
        {
            NameBox.Clear();
            IDBox.Clear();
            QuantityBox.Clear();
        }

        private void RemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductGrid.SelectedItem is Product selectedProduct)
            {
                var result = MessageBox.Show(
                    $"Are you sure you want to remove '{selectedProduct.Name}'?",
                    "Confirm Remove",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    Products.Remove(selectedProduct);     
                }
            }
            else
            {
                MessageBox.Show("Please select a product to remove.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ProductGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Show the stock panel only if a product is selected
            StockPanel.Visibility = ProductGrid.SelectedItem is Product ? Visibility.Visible : Visibility.Collapsed;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = ProductGrid.SelectedItem as Product;
            try
            {
                // Add stock
                if (int.TryParse(AddStockBox.Text, out int addValue) && addValue > 0)
                {
                    if (selectedProduct.Quantity + addValue < 6 && selectedProduct.Quantity + addValue > 0)
                    {
                        MessageBox.Show("Low stock alert", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        selectedProduct.Quantity += addValue;
                    }
                    else
                        selectedProduct.Quantity += addValue;
                }

                // Remove stock
                if (int.TryParse(RemoveStockBox.Text, out int removeValue) && removeValue > 0)
                {
                    if (selectedProduct.Quantity - removeValue < 0)
                    {
                        MessageBox.Show("Stock will be negative.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        selectedProduct.Quantity = 0;
                    }
                    else if (selectedProduct.Quantity - removeValue < 6 && selectedProduct.Quantity - removeValue > 0)
                    {
                        MessageBox.Show("Low stock alert", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        selectedProduct.Quantity -= removeValue;
                    }
                    else    
                    selectedProduct.Quantity -= removeValue;
                }

                // Edit stock
                if (int.TryParse(EditStockBox.Text, out int newStockValue))
                {
                    if (newStockValue < 0)
                    {
                        MessageBox.Show("Stock will be negative.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        selectedProduct.Quantity = 0;
                    }
                    else if (newStockValue < 6 && newStockValue > 0)
                    {
                        MessageBox.Show("Low stock alert", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        selectedProduct.Quantity = newStockValue;
                    }
                    else
                        selectedProduct.Quantity = newStockValue;
                }

                // Refresh the DataGrid to reflect the update
                ProductGrid.Items.Refresh();

                // Clear the textboxes
                AddStockBox.Clear();
                RemoveStockBox.Clear();
                EditStockBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
