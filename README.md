# 🛒 Celeres Store Inventory Tracker

A simple WPF desktop application for managing store inventory, built with **C#**, **XAML**, and the **MVVM pattern**. This application visually highlights low-stock items using a color-coded system.

---

## ✨ Features

- 📦 Add, update, and delete products from inventory
- 🎨 Color-coded stock warnings (e.g., red for ≤ 5 units)
- 📊 Real-time updates using `ObservableCollection`
- 🧠 Data validation (no negative stock)
- 🖼️ Clean UI with styled headers and layout
- 🔧 MVVM-friendly design

---

## 📁 Project Structure

```plaintext
Solution: InventoryTracker
├── ClassDesign/
│   ├── Inventory.cs
│   └── Product.cs
├── UIDesign/
│   ├── MainWindow.xaml
│   ├── MainWindow.xaml.cs
│   ├── Style.xaml
│   └── QuantityToBrushConverter.cs
└── InventoryTracker.sln
