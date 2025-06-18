using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        public ObservableCollection<Product> FilteredProducts { get; set; } = new ObservableCollection<Product>();
        public ObservableCollection<Product> SearchResults { get; set; } = new ObservableCollection<Product>();


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
            this.DataContext = this;

            // Initial Product List
            Products.Add(new Product("Potato Chips", "P001", 10, 15, ProductCategory.Snacks));
            Products.Add(new Product("Chocolate Bar", "P002", 8, 12.50m, ProductCategory.Snacks));
            Products.Add(new Product("Crackers", "P003", 12, 10.00m, ProductCategory.Snacks));
            Products.Add(new Product("Gummy Bears", "P004", 5, 18.00m, ProductCategory.Snacks));
            Products.Add(new Product("Mixed Nuts", "P005", 7, 20.00m, ProductCategory.Snacks));

            Products.Add(new Product("Bottled Water", "B001", 20, 10.00m, ProductCategory.Beverages));
            Products.Add(new Product("Soda (Cola)", "B002", 15, 17.00m, ProductCategory.Beverages));
            Products.Add(new Product("Iced Tea", "B003", 10, 18.50m, ProductCategory.Beverages));
            Products.Add(new Product("Energy Drink", "B004", 8, 25.00m, ProductCategory.Beverages));
            Products.Add(new Product("Canned Coffee", "B005", 12, 22.00m, ProductCategory.Beverages));

            Products.Add(new Product("Toothpaste", "PC001", 10, 30.00m, ProductCategory.PersonalCare));
            Products.Add(new Product("Shampoo (Sachet)", "PC002", 25, 7.00m, ProductCategory.PersonalCare));
            Products.Add(new Product("Soap Bar", "PC003", 18, 15.00m, ProductCategory.PersonalCare));
            Products.Add(new Product("Deodorant Stick", "PC004", 6, 50.00m, ProductCategory.PersonalCare));
            Products.Add(new Product("Sanitary Napkins", "PC005", 10, 40.00m, ProductCategory.PersonalCare));

            Products.Add(new Product("Canned Tuna", "PG001", 15, 25.00m, ProductCategory.PackagedGoods));
            Products.Add(new Product("Instant Noodles", "PG002", 30, 10.00m, ProductCategory.PackagedGoods));
            Products.Add(new Product("Sardines", "PG003", 20, 15.00m, ProductCategory.PackagedGoods));
            Products.Add(new Product("Pack of Rice", "PG004", 5, 50.00m, ProductCategory.PackagedGoods));
            Products.Add(new Product("Boxed Cereal (mini)", "PG005", 8, 35.00m, ProductCategory.PackagedGoods));

            Products.Add(new Product("Dishwashing Liquid", "HH001", 10, 25.00m, ProductCategory.HouseholdItems));
            Products.Add(new Product("Laundry Powder (Small)", "HH002", 12, 20.00m, ProductCategory.HouseholdItems));
            Products.Add(new Product("Trash Bags", "HH003", 15, 18.00m, ProductCategory.HouseholdItems));
            Products.Add(new Product("Tissue Roll", "HH004", 20, 10.00m, ProductCategory.HouseholdItems));
            Products.Add(new Product("Air Freshener", "HH005", 7, 45.00m, ProductCategory.HouseholdItems));

            Products.Add(new Product("Cup Noodles", "IM001", 20, 15.00m, ProductCategory.InstantMeals));
            Products.Add(new Product("Microwaveable Rice Meal", "IM002", 5, 55.00m, ProductCategory.InstantMeals));
            Products.Add(new Product("Canned Spaghetti", "IM003", 8, 30.00m, ProductCategory.InstantMeals));
            Products.Add(new Product("Ready-to-Eat Adobo", "IM004", 4, 60.00m, ProductCategory.InstantMeals));
            Products.Add(new Product("Mac & Cheese Bowl", "IM005", 6, 35.00m, ProductCategory.InstantMeals));

            Products.Add(new Product("Paracetamol", "M001", 25, 5.00m, ProductCategory.OverTheCounterMedicine));
            Products.Add(new Product("Cough Syrup", "M002", 10, 30.00m, ProductCategory.OverTheCounterMedicine));
            Products.Add(new Product("Antacid Tablets", "M003", 12, 8.00m, ProductCategory.OverTheCounterMedicine));
            Products.Add(new Product("Pain Relief Balm", "M004", 10, 20.00m, ProductCategory.OverTheCounterMedicine));
            Products.Add(new Product("Anti-allergy Capsule", "M005", 15, 10.00m, ProductCategory.OverTheCounterMedicine));

            Products.Add(new Product("Cigarettes", "T001", 50, 8.00m, ProductCategory.Tobacco));
            Products.Add(new Product("Lighter", "T002", 25, 10.00m, ProductCategory.Tobacco));
            Products.Add(new Product("Chewing Tobacco", "T003", 10, 15.00m, ProductCategory.Tobacco));
            Products.Add(new Product("Rolling Paper", "T004", 20, 5.00m, ProductCategory.Tobacco));
            Products.Add(new Product("Vape Pod", "T005", 7, 60.00m, ProductCategory.Tobacco));

            Products.Add(new Product("Fresh Milk (small)", "D001", 10, 20.00m, ProductCategory.Dairy));
            Products.Add(new Product("Cheese Slice Pack", "D002", 8, 25.00m, ProductCategory.Dairy));
            Products.Add(new Product("Yogurt Cup", "D003", 12, 18.00m, ProductCategory.Dairy));
            Products.Add(new Product("Butter Stick", "D004", 5, 30.00m, ProductCategory.Dairy));
            Products.Add(new Product("Creamer Sachet", "D005", 15, 5.00m, ProductCategory.Dairy));

            Products.Add(new Product("Ballpen", "S001", 30, 8.00m, ProductCategory.Stationery));
            Products.Add(new Product("Notebook (small)", "S002", 20, 15.00m, ProductCategory.Stationery));
            Products.Add(new Product("Correction Tape", "S003", 10, 25.00m, ProductCategory.Stationery));
            Products.Add(new Product("Envelopes", "S004", 40, 5.00m, ProductCategory.Stationery));
            Products.Add(new Product("Pencil", "S005", 35, 6.00m, ProductCategory.Stationery));

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
            DataGrid clickedGrid = sender as DataGrid;
            Product selectedProduct = clickedGrid.SelectedItem as Product;

            if (selectedProduct == previouslySelectedItem && selectedProduct != null)
            {
                ViewProductGrid.Visibility = Visibility.Collapsed;

                ProductGrid.SelectedItem = null;
                SearchResultGrid.SelectedItem = null;
                previouslySelectedItem = null;
            }
            else if (selectedProduct != null)
            {
                ViewProductGrid.Visibility = Visibility.Visible;
                previouslySelectedItem = selectedProduct;

                // Deselect in the opposite grid
                if (clickedGrid == ProductGrid)
                    SearchResultGrid.SelectedItem = null;
                else
                    ProductGrid.SelectedItem = null;

                // Scroll in the correct grid
                clickedGrid.ScrollIntoView(selectedProduct);

                ViewProductDescription(selectedProduct);
                ViewProductStatistics(selectedProduct);
            }
        }

        private void ViewProductDescription(Product p)
        {
            ProductDescription.Text = $"Product Description\n" +
                                      $"   Name:\t {p.Name}\n" +
                                      $"   ID:\t {p.ID}\n" +
                                      $"   Stock:\t {p.Quantity}\n" +
                                      $"   Price:\t ₱{p.Price.ToString("F2")}";
        }


        private void ViewProductStatistics(Product p)
        {
            ProductStatistics.Text = $"Product Description\n   Name:\t {p.Name}\n   ID: \t{p.ID}\n   Stock: \t{p.Quantity}\n   Price:\t{p.Price}";
        }

        private void UpdateStockButton_Click(object sender, RoutedEventArgs e)
        {
            // Toggle panel and state
            UpdateStockPanel.Visibility = IsUpdatePanelOpen ? Visibility.Collapsed : Visibility.Visible;
            IsUpdatePanelOpen = !IsUpdatePanelOpen;
        }

        private Product GetSelectedProduct()
        {
            // Prefer the one that is selected (non-null), regardless of visibility
            if (SearchResultGrid.SelectedItem is Product searchSelected)
                return searchSelected;

            if (ProductGrid.SelectedItem is Product productSelected)
                return productSelected;

            return null; // If neither has a selection
        }



        private void AddStockButton_Click(object sender, RoutedEventArgs e)
        {
            Product p = GetSelectedProduct();

            try
            {
                if (p == null)
                    throw new InvalidProductException("Please select a product to add stock.");

                if (!int.TryParse(AddStockBox.Text, out int stock))
                    throw new InvalidProductException("Stock must be a valid number.");

                if (stock <= 0)
                {
                    AddStockBox.Text = "0";
                    throw new InvalidProductException("Stock must be greater than zero.");
                }

                // Update
                p.Quantity += stock;
                p.UpdateProductStockStatus(p.Quantity);
                Inventory.UpdateProduct(p, p.Name, p.ID, p.Quantity, p.Price, p.Category);

                // Refresh both grids
                ProductGrid.Items.Refresh();
                SearchResultGrid.Items.Refresh();
                AddStockBox.Text = string.Empty;

                // Show changes
                ViewProductDescription(p);
                MessageBox.Show("Stock added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                ProductGrid.ScrollIntoView(p);
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
            Product p = GetSelectedProduct();

            try
            {
                if (p == null)
                    throw new InvalidProductException("Please select a product to subtract stock.");

                if (!int.TryParse(SubStockBox.Text, out int stock))
                    throw new InvalidProductException("Stock must be a valid number.");

                if (stock <= 0)
                {
                    SubStockBox.Text = "0";
                    throw new InvalidProductException("Stock must be greater than zero.");
                }

                if (p.Quantity - stock < 0)
                    throw new InvalidProductException("Stock cannot be negative after subtraction.");

                // Update
                p.Quantity -= stock;
                p.UpdateProductStockStatus(p.Quantity);
                Inventory.UpdateProduct(p, p.Name, p.ID, p.Quantity, p.Price, p.Category);

                // Refresh both grids
                ProductGrid.Items.Refresh();
                SearchResultGrid.Items.Refresh();
                SubStockBox.Text = string.Empty;

                // Show changes
                ViewProductDescription(p);
                MessageBox.Show("Stock subtracted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                ProductGrid.ScrollIntoView(p);
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
            Product p = GetSelectedProduct();

            try
            {
                if (p == null)
                    throw new InvalidProductException("Please select a product to edit stock.");

                if (!int.TryParse(EditStockBox.Text, out int stock))
                    throw new InvalidProductException("Stock must be a valid number.");

                if (stock <= 0)
                {
                    EditStockBox.Text = "0";
                    throw new InvalidProductException("Stock must be greater than zero.");
                }

                // Update
                p.Quantity = stock;
                p.UpdateProductStockStatus(p.Quantity);
                Inventory.UpdateProduct(p, p.Name, p.ID, p.Quantity, p.Price, p.Category);

                // Refresh both grids
                ProductGrid.Items.Refresh();
                SearchResultGrid.Items.Refresh();
                EditStockBox.Text = string.Empty;

                // Show changes
                ViewProductDescription(p);
                MessageBox.Show("Stock updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                ProductGrid.ScrollIntoView(p);
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

        private void EditProductButton_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = GetSelectedProduct();

            if (selectedProduct != null)
            {
                EditProductWindow editWindow = new EditProductWindow(selectedProduct);
                editWindow.Owner = this;

                if (editWindow.ShowDialog() == true)
                {
                    // Refresh both grids to reflect changes
                    ProductGrid.Items.Refresh();
                    SearchResultGrid.Items.Refresh();

                    // Re-display updated info
                    ViewProductDescription(selectedProduct);
                    ViewProductStatistics(selectedProduct);

                    MessageBox.Show("Product updated successfully!", "Edit Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                    ProductGrid.ScrollIntoView(selectedProduct);
                }
            }
            else
            {
                MessageBox.Show("Please select a product to edit.", "No Product Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedCriteria = (SearchByComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();
            string searchTerm = SearchBox.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(searchTerm) || selectedCriteria == "Search by")
            {
                MessageBox.Show("Please select a search criterion and enter a value.", "Invalid Search", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            SearchResults.Clear(); // Clear previous search results

            IEnumerable<Product> result = Inventory.Products;

            switch (selectedCriteria)
            {
                case "ID":
                    result = result.Where(p => p.ID.ToLower().Contains(searchTerm));
                    break;
                case "Name":
                    result = result.Where(p => p.Name.ToLower().Contains(searchTerm));
                    break;
                case "Stock":
                    if (int.TryParse(searchTerm, out int qty))
                        result = result.Where(p => p.Quantity == qty);
                    else
                    {
                        MessageBox.Show("Enter a valid number for Stock.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    break;
                case "Price":
                    if (decimal.TryParse(searchTerm, out decimal price))
                        result = result.Where(p => p.Price == price);
                    else
                    {
                        MessageBox.Show("Enter a valid number for Price.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    break;
            }

            foreach (var item in result)
            {
                SearchResults.Add(item);
            }

            bool found = SearchResults.Any();

            SearchResultGrid.Visibility = found ? Visibility.Visible : Visibility.Collapsed;
            SearchResultsHeader.Visibility = found ? Visibility.Visible : Visibility.Collapsed;
            EscapeButton.Visibility = Visibility.Visible;
            NoResultsText.Visibility = found ? Visibility.Collapsed : Visibility.Visible;
        }

        private void EscapeButton_Click(object sender, RoutedEventArgs e)
        {
            SearchResults.Clear();
            SearchResultGrid.Visibility = Visibility.Collapsed;
            SearchResultsHeader.Visibility = Visibility.Collapsed;
            NoResultsText.Visibility = Visibility.Collapsed;
            EscapeButton.Visibility = Visibility.Collapsed;
            SearchBox.Text = string.Empty;
        }

        private string lastSelectedFilter = string.Empty;

        private void FilterByComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FilterByComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                lastSelectedFilter = selectedItem.Content.ToString();
                ApplyFilter(lastSelectedFilter);
            }
        }

        private void FilterByComboBox_DropDownClosed(object sender, EventArgs e)
        {
            // Reselecting same item won't trigger SelectionChanged, so handle here
            if (FilterByComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string currentFilter = selectedItem.Content.ToString();

                if (currentFilter == lastSelectedFilter)
                {
                    ApplyFilter(currentFilter);
                }
            }
        }

        private void ApplyFilter(string selectedFilter)
        {
           

            switch (selectedFilter)
            {
                case "All":
                    ShowAllProducts();
                    break;

                case "Status":
                    FilterByStatusPanel.IsOpen = true;
                    FilterByCategoryPanel.IsOpen = false;
                    break;

                case "Category":
                    FilterByCategoryPanel.IsOpen = true;
                    FilterByStatusPanel.IsOpen = false;
                    break;
            }
        }


        private void FilterStatusButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                string selectedStatus = btn.Content.ToString();
                ApplyStatusFilter(selectedStatus);
                FilterByStatusPanel.IsOpen = false;
            }
        }

        private void FilterCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                string selectedCategory = btn.Content.ToString();
                ApplyCategoryFilter(selectedCategory);
                FilterByCategoryPanel.IsOpen = false;
            }
        }

        private void ShowAllProducts_Click(object sender, RoutedEventArgs e)
        {
            FilterByComboBox.SelectedIndex = 1;
            ShowAllProducts();
            FilterByStatusPanel.IsOpen = false;
            FilterByCategoryPanel.IsOpen = false;
        }


        private void ApplyStatusFilter(string status)
        {
            FilteredProducts.Clear();
            FilteredProductGrid.Visibility = Visibility.Visible;
            ProductGrid.Visibility = Visibility.Collapsed;
            foreach (var p in Inventory.Products)
            {
                if (p.Status == status)
                    FilteredProducts.Add(p);
            }
        }

        private void ApplyCategoryFilter(string category)
        {
            FilteredProducts.Clear();
            FilteredProductGrid.Visibility = Visibility.Visible;
            ProductGrid.Visibility = Visibility.Collapsed;
            foreach (var p in Inventory.Products)
            {
                if (p.Category.ToString() == category)
                    FilteredProducts.Add(p);
            }
        }

        private void ShowAllProducts()
        {
            FilteredProducts.Clear();
            ProductGrid.Visibility = Visibility.Visible;
            FilteredProductGrid.Visibility = Visibility.Collapsed;
        }

        
    }
}
