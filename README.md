# 🗃️ Simple Inventory System

This is a **console-based inventory management system** built with C#. It allows users to manage products using a simple command-line menu. Product data is stored in a JSON file, and the system includes logging and input validation.

---

## 📋 Features

- Add a new product
- Update existing product details
- Remove a product by ID
- Display a product by ID
- Display all products
- Show out-of-stock products
- Persist data in a JSON file
- Validate input and log operations

---

## 📦 Menu Options

1- Add New Product
2- Update Product
3- Remove Product
4- Display Product By ID
5- Display All Products
6- Display Out of Stock Products
7- Exit

---

## 📁 Project Structure

```plaintext
├── Enums
│ └── Options.cs # Enum for menu options
│
├── Interfaces
│ ├── IFileService.cs # Interface for file I/O operations
│ ├── IInventoryMenuView.cs # Interface for the main menu view
│ ├── IInventoryOperations.cs # Interface for core product operations
│ └── IInventoryOperationsView.cs # Interface for operations display
│
├── Logs
│ └── log.txt # Log file for recording events
│
├── Models
│ └── Product.cs # Product data model
│
├── Services
│ ├── FileService.cs # Handles reading/writing product JSON
│ └── OpreationService.cs # Implements inventory logic
│
├── Utils
│ ├── Logger.cs # Built-in logger utility
│ └── Validations
│ ├── ProductValidator.cs # Validates product fields
│ ├── ValidationResult.cs # Represents validation result
│ └── Validator.cs # General validation handler
│
├── Views
│ ├── MenuView.cs # Handles main menu UI
│ └── OperationsView.cs # Handles display of operation results
│
└── Program.cs # Application entry point

```


---

## 📂 Data Storage

- All product data is stored in a local JSON file, enabling persistent storage across application runs.
- Logs are written to `Logs/log.txt`.

---

## 🚀 Getting Started

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-username/inventory-system.git
   cd inventory-system
  ```

2. **Build and run**
  Open in Visual Studio or run using CLI:

   ```bash
   dotnet run
  ```
3. **Use the menu to manage inventory**


## 📄 License
MIT License — feel free to use and modify.

## 📂 Contribution
Feel free to fork this repository and contribute by submitting a pull request.