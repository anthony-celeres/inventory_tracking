# 🛒 Store Inventory Tracker

A simple WPF desktop application for managing store inventory, built with **C#**, **XAML**, and the **MVVM pattern**. This application visually highlights low-stock items using a color-coded system.

---

## ✨ Features

- 📦 Add, update, and delete products from inventory
- 🎨 Color-coded stock warnings (e.g., red for ≤ 5 units)
- 📊 Real-time updates using `ObservableCollection`
- 🧠 Data validation (no negative stock)
- 🖼️ Clean UI with styled headers and layout
- 🔧 MVVM-friendly design with separation of concerns

---

## 📁 Project Structure

Solution: InventoryTracker
├── ClassDesign/
│   ├── Inventory.cs                  # Handles product logic (add, update, delete)
│   └── Product.cs                    # Product model with Name and Stock properties
├── UIDesign/
│   ├── MainWindow\.xaml               # Main UI layout (DataGrid with bindings)
│   ├── MainWindow\.xaml.cs            # Code-behind to connect data to the view
│   ├── Style.xaml                    # ResourceDictionary for UI styles and row colors
│   └── QuantityToBrushConverter.cs   # Converts stock level to background brush
└── InventoryTracker.sln              # Visual Studio solution file

---

## 🖥️ How to Run

1. Clone the repository:
    git clone https://github.com/your-username/CeleresInventory.git
    
2. Open the solution file in Visual Studio:
    InventoryTracker.sln

3. In Solution Explorer:
    - Right-click `UIDesign` and choose **Set as Startup Project**

4. Press `F5` or click **Start** to run the application

---

## 💡 How It Works

- The UI is built using XAML and styled with a `Style.xaml` file.
- A `QuantityToBrushConverter` applies a red background to rows where stock is 5 or less.
- The logic for managing products (adding, updating, deleting) is isolated in the `ClassDesign` project.
- The product list is observable, so changes are reflected instantly in the UI.

---

## 📌 Future Improvements

- [ ] Implement file or database persistence
- [ ] Add a dedicated product editor dialog
- [ ] Filter/search inventory
- [ ] Add unit tests for the `Inventory` logic in `ClassDesign`
- [ ] Enhance styling with custom themes or animations

---

## 📃 License

This project is licensed under the **MIT License**.

MIT License

Copyright (c) \[2025]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

---

## 🙌 Acknowledgments

Developed as a practical project to learn and demonstrate WPF, XAML, and object-oriented design patterns in C#.

This project is ideal for students, beginners, or anyone learning how to:

- Build a simple MVVM-capable desktop app
- Apply styles and value converters in XAML
- Separate logic into multiple projects (UI vs. business logic)
