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
using UIDesign;

namespace UIDesign
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> Products => Inventory.Products;

        public static readonly DependencyProperty IsUpdatePanelOpenProperty =
        DependencyProperty.Register("IsUpdatePanelOpen", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));

        public bool IsUpdatePanelOpen
        {
            get { return (bool)GetValue(IsUpdatePanelOpenProperty); }
            set { SetValue(IsUpdatePanelOpenProperty, value); }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            this.DataContext = this; // Now {Binding Products} will work
            Product p = new Product("Banana", "123", 20, 15);
            Product q = new Product("Apple", "124", 4,20);
            Product r = new Product("Orange", "125", 6, 50);
            Product s = new Product("Pineapple", "126", 10, 60);
            Product t = new Product("Mango", "127", 11, 10);
            Products.Add(p);
            Products.Add(q);
            Products.Add(r);
            Products.Add(s);
            Products.Add(t);

        }

        private void OpenAddProductWindow_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = ProductGrid.SelectedItem;
            AddProductWindow popup = new AddProductWindow();
            popup.Owner = this;

            if (popup.ShowDialog() == true)
            {
                // Access values if needed via properties or shared data
                MessageBox.Show($"{popup.product.Name} added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
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
            ViewProductGrid.Visibility = Visibility.Collapsed; 
        }

        private object previouslySelectedItem = null;

        private void ProductGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var currentSelectedItem = ProductGrid.SelectedItem;

            if (currentSelectedItem == previouslySelectedItem && currentSelectedItem != null)
            {
                // Same item clicked again: collapse the panel and deselect
                
                ViewProductGrid.Visibility = Visibility.Collapsed;
                ProductGrid.SelectedItem = null;
                previouslySelectedItem = null;
            }
            else if (currentSelectedItem is Product)
            {
                // New item selected: show the panel
                ViewProductGrid.Visibility = Visibility.Visible;
                previouslySelectedItem = currentSelectedItem;
                Product p = currentSelectedItem as Product;
                ViewProductDescription(p);
                ViewProductStatistics(p);
            }
        }

        private void ViewProductDescription(Product p)
        {
            ProductDescription.Text = $"Product Description\n\tName:\t {p.Name}\n\tID: \t{p.ID}\n\tStock: \t{p.Quantity}\n\tPrice:";
        }

        private void ViewProductStatistics(Product p)
        {
            ProductStatistics.Text = $"Product Description\n\tName:\t {p.Name}\n\tID: \t{p.ID}\n\tStock: \t{p.Quantity}\n\tPrice:";
        }

        private void UpdateStockButton_Click(object sender, RoutedEventArgs e)
        {
            // Toggle panel and state
            UpdateStockPanel.Visibility = IsUpdatePanelOpen ? Visibility.Collapsed : Visibility.Visible;
            IsUpdatePanelOpen = !IsUpdatePanelOpen;
        }

        private void AddStockButton_Click(object sender, RoutedEventArgs e)
        {
            var currentSelectedItem = ProductGrid.SelectedItem;
            Product p = currentSelectedItem as Product;
            try
            {
                if (!int.TryParse(AddStockBox.Text, out int stock))
                {
                    throw new InvalidProductException("Stock must be a valid number.");
                }

                if (stock <= 0)
                {
                    AddStockBox.Text = "0";
                    throw new InvalidProductException("Stock must be greater than zero.");
                }
                else
                {
                    p.Quantity += stock;
                    p.UpdateProductStockStatus(p.Quantity);
                    Inventory.UpdateProduct(p, p.Name, p.ID, p.Quantity, p.Price);
                    ViewProductDescription(p);
                }
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

        private void SubStockButton_Click(object sender, RoutedEventArgs e)
        {
            var currentSelectedItem = ProductGrid.SelectedItem;
            Product p = currentSelectedItem as Product;
            try
            {
                if (!int.TryParse(SubStockBox.Text, out int stock))
                {
                    throw new InvalidProductException("Stock must be a valid number.");
                }

                if (stock <= 0)
                {
                    SubStockBox.Text = "0";
                    throw new InvalidProductException("Stock must be greater than zero.");
                }
                else if(p.Quantity - stock < 0)
                {
                    throw new InvalidProductException("Stock cannot be negative after subtraction.");
                }
                else
                {
                    p.Quantity -= stock;
                    p.UpdateProductStockStatus(p.Quantity);
                    Inventory.UpdateProduct(p,p.Name, p.ID, p.Quantity, p.Price);
                    ViewProductDescription(p);
                }
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

        private void EditStockButton_Click(object sender, RoutedEventArgs e)
        {
            var currentSelectedItem = ProductGrid.SelectedItem;
            Product p = currentSelectedItem as Product;
            try
            {
                if (!int.TryParse(EditStockBox.Text, out int stock))
                {
                    throw new InvalidProductException("Stock must be a valid number.");
                }

                if (stock <= 0)
                {
                    EditStockBox.Text = "0";
                    throw new InvalidProductException("Stock must be greater than zero.");
                }
                else
                {
                    p.Quantity = stock;
                    p.UpdateProductStockStatus(p.Quantity);
                    Inventory.UpdateProduct(p, p.Name, p.ID, p.Quantity, p.Price);
                    ViewProductDescription(p);
                }
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
