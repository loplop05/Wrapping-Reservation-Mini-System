# Library Book Wrapping Reservation System

A simple desktop application for managing book wrapping reservations in a small library during the back-to-school season.

## Technology Stack

- **C# WinForms** - Desktop application framework
- **SQL Server** - Database management
- **ADO.NET** - Data access technology
- **3-Tier Architecture** - DAL, BLL, PL separation

## Project Structure

```
Wrapping Reservation Mini System
│
├── DAL/                          # Data Access Layer
│   ├── DataAccess.cs            # Database connection management
│   ├── CustomerDAL.cs           # Customer data operations
│   └── OrderDAL.cs              # Order data operations
│
├── BLL/                          # Business Logic Layer
│   ├── CustomerBLL.cs           # Customer business logic
│   └── OrderBLL.cs              # Order business logic
│
├── PL/                           # Presentation Layer
│   ├── frmMain.cs               # Main menu form
│   ├── frmReservation.cs        # Add reservation form
│   ├── frmOrders.cs             # Orders management form
│   ├── frmEditOrder.cs          # Edit order form
│   └── frmChangeStatus.cs       # Change order status form
│
├── Database.sql                  # Database schema script
├── Program.cs                    # Application entry point
└── README.md                     # This file
```

## Database Setup

1. Open SQL Server Management Studio (SSMS)
2. Connect to your SQL Server instance
3. Open and execute the `Database.sql` script
4. This will create:
   - Database: `LibraryBookWrapping`
   - Table: `Customers` (CustomerID, Phone, Name)
   - Table: `Orders` (OrderID, CustomerID, BooksQty, OtherPurchasesAmount, TotalBill, OrderDate, Status)

## Connection String

Update the connection string in `DAL/DataAccess.cs` if needed:

```csharp
private string connectionString = "Server=localhost;Database=LibraryBookWrapping;Trusted_Connection=True;";
```

**For SQL Server Authentication:**
```csharp
private string connectionString = "Server=YOUR_SERVER;Database=LibraryBookWrapping;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;";
```

## Application Features

### Main Menu (frmMain)
- **Add Reservation** - Opens form to create new book wrapping reservations
- **Check Status** - Opens form to view and manage all orders
- **Exit** - Closes the application

### Add Reservation (frmReservation)
- Enter customer phone number
- Search for existing customer or create new one
- Enter number of books
- Enter other purchases amount
- Automatic total bill calculation (1 JD per book + other purchases)
- Save reservation

### Orders Management (frmOrders)
- View all reservations in a DataGridView
- Search by phone number, customer name, or order ID
- Add new reservation
- Edit existing reservation
- Delete reservation
- Change order status (Pending, Ready, Completed, Cancelled)
- Refresh data

### Order Status Workflow
1. **Pending** - Initial status when reservation is created
2. **Ready** - When books are wrapped and ready for pickup
3. **Completed** - When customer has picked up the order
4. **Cancelled** - If the order is cancelled

## Business Logic

### OrderBLL
- **Wrapping Price**: Configurable (default: 1 JD per book)
- **Total Calculation**: `Total = (BooksQty × WrappingPrice) + OtherPurchases`
- **Validation**: Phone number, name, book quantity, other purchases, status

### CustomerBLL
- **Validation**: Phone number (10-20 characters), name (max 100 characters)
- **Duplicate Prevention**: Prevents creating customers with duplicate phone numbers

## How to Build and Run

### Using Visual Studio
1. Open `Wrapping Reservation Mini System.slnx` in Visual Studio
2. Update connection string in `DAL/DataAccess.cs` if needed
3. Press F5 or click "Start" to run the application

### Using Command Line
```bash
cd "C:\Users\ammar\source\repos\Wrapping Reservation Mini System"
dotnet build
dotnet run
```

## Usage Example

1. **Add a Reservation**
   - Click "Add Reservation" on main menu
   - Enter phone number: "0791234567"
   - Click "Search" - if not found, enter customer name: "Ahmad"
   - Enter number of books: 5
   - Enter other purchases: 3.50
   - Total will auto-calculate: 8.50 JD
   - Click "Save Reservation"

2. **Check Status**
   - Click "Check Status" on main menu
   - View all orders in the grid
   - Search by phone, name, or order ID
   - Select an order and click "Change Status"
   - Update status from "Pending" to "Ready"

## Configuration

### Change Wrapping Price
Edit the wrapping price in `BLL/OrderBLL.cs`:

```csharp
private decimal wrappingPricePerBook = 1.0m; // Change this value
```

## Database Schema

### Customers Table
```sql
CREATE TABLE Customers
(
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    Phone NVARCHAR(20) NOT NULL UNIQUE,
    Name NVARCHAR(100) NOT NULL
);
```

### Orders Table
```sql
CREATE TABLE Orders
(
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT NOT NULL,
    BooksQty INT NOT NULL,
    OtherPurchasesAmount DECIMAL(10,2) NOT NULL DEFAULT 0,
    TotalBill DECIMAL(10,2) NOT NULL,
    OrderDate DATETIME NOT NULL DEFAULT GETDATE(),
    Status NVARCHAR(20) NOT NULL DEFAULT 'Pending',
    
    CONSTRAINT FK_Orders_Customers FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    CONSTRAINT CK_Orders_BooksQty CHECK (BooksQty > 0),
    CONSTRAINT CK_Orders_OtherPurchases CHECK (OtherPurchasesAmount >= 0),
    CONSTRAINT CK_Orders_TotalBill CHECK (TotalBill >= 0)
);
```

## Troubleshooting

### Connection Issues
- Ensure SQL Server is running
- Verify connection string in `DAL/DataAccess.cs`
- Check that the database `LibraryBookWrapping` exists

### Build Errors
- Ensure .NET Framework 4.7.2 is installed
- Verify all referenced assemblies are available

## Notes

- This is a simple, beginner-friendly application
- No authentication or user roles
- No online payments or APIs
- Designed for small library back-to-school season use
- Clean, professional UI suitable for non-technical employees
