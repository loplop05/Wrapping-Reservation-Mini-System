using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class OrderDAL
    {
        private DataAccess dataAccess;

        public OrderDAL()
        {
            dataAccess = new DataAccess();
        }

        public int InsertOrder(int customerId, int booksQty, decimal otherPurchasesAmount, decimal totalBill, string status, string paymentMethod)
        {
            string query = @"INSERT INTO Orders (CustomerID, BooksQty, OtherPurchasesAmount, TotalBill, Status, PaymentMethod) 
                            VALUES (@CustomerID, @BooksQty, @OtherPurchasesAmount, @TotalBill, @Status, @PaymentMethod)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CustomerID", customerId),
                new SqlParameter("@BooksQty", booksQty),
                new SqlParameter("@OtherPurchasesAmount", otherPurchasesAmount),
                new SqlParameter("@TotalBill", totalBill),
                new SqlParameter("@Status", status),
                new SqlParameter("@PaymentMethod", paymentMethod)
            };
            return dataAccess.ExecuteNonQuery(query, parameters);
        }

        public DataTable GetAllOrders()
        {
            string query = @"SELECT o.OrderID, c.Name AS CustomerName, c.Phone, o.BooksQty, 
                            o.OtherPurchasesAmount, o.TotalBill, o.OrderDate, o.Status, o.PaymentMethod
                            FROM Orders o 
                            INNER JOIN Customers c ON o.CustomerID = c.CustomerID 
                            ORDER BY o.OrderDate DESC";
            return dataAccess.ExecuteQuery(query);
        }

        public DataTable GetOrderById(int orderId)
        {
            string query = @"SELECT o.OrderID, c.Name AS CustomerName, c.Phone, o.BooksQty, 
                            o.OtherPurchasesAmount, o.TotalBill, o.OrderDate, o.Status, o.PaymentMethod, o.CustomerID
                            FROM Orders o 
                            INNER JOIN Customers c ON o.CustomerID = c.CustomerID 
                            WHERE o.OrderID = @OrderID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderID", orderId)
            };
            return dataAccess.ExecuteQuery(query, parameters);
        }

        public int UpdateOrder(int orderId, int booksQty, decimal otherPurchasesAmount, decimal totalBill, string status, string paymentMethod)
        {
            string query = @"UPDATE Orders 
                            SET BooksQty = @BooksQty, 
                                OtherPurchasesAmount = @OtherPurchasesAmount, 
                                TotalBill = @TotalBill, 
                                Status = @Status,
                                PaymentMethod = @PaymentMethod
                            WHERE OrderID = @OrderID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderID", orderId),
                new SqlParameter("@BooksQty", booksQty),
                new SqlParameter("@OtherPurchasesAmount", otherPurchasesAmount),
                new SqlParameter("@TotalBill", totalBill),
                new SqlParameter("@Status", status),
                new SqlParameter("@PaymentMethod", paymentMethod)
            };
            return dataAccess.ExecuteNonQuery(query, parameters);
        }

        public int UpdateOrderStatus(int orderId, string status)
        {
            string query = "UPDATE Orders SET Status = @Status WHERE OrderID = @OrderID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderID", orderId),
                new SqlParameter("@Status", status)
            };
            return dataAccess.ExecuteNonQuery(query, parameters);
        }

        public int DeleteOrder(int orderId)
        {
            string query = "DELETE FROM Orders WHERE OrderID = @OrderID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderID", orderId)
            };
            return dataAccess.ExecuteNonQuery(query, parameters);
        }

        public DataTable SearchOrders(string searchTerm)
        {
            string query = @"SELECT o.OrderID, c.Name AS CustomerName, c.Phone, o.BooksQty, 
                            o.OtherPurchasesAmount, o.TotalBill, o.OrderDate, o.Status, o.PaymentMethod
                            FROM Orders o 
                            INNER JOIN Customers c ON o.CustomerID = c.CustomerID 
                            WHERE c.Phone LIKE @SearchTerm 
                            OR c.Name LIKE @SearchTerm 
                            OR CAST(o.OrderID AS NVARCHAR) LIKE @SearchTerm 
                            ORDER BY o.OrderDate DESC";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@SearchTerm", "%" + searchTerm + "%")
            };
            return dataAccess.ExecuteQuery(query, parameters);
        }

        public DataTable GetOrdersByStatus(string status)
        {
            string query = @"SELECT o.OrderID, c.Name AS CustomerName, c.Phone, o.BooksQty, 
                            o.OtherPurchasesAmount, o.TotalBill, o.OrderDate, o.Status, o.PaymentMethod
                            FROM Orders o 
                            INNER JOIN Customers c ON o.CustomerID = c.CustomerID 
                            WHERE o.Status = @Status
                            ORDER BY o.OrderDate DESC";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Status", status)
            };
            return dataAccess.ExecuteQuery(query);
        }

        public DataTable GetEndOfDayStatistics()
        {
            string query = @"SELECT 
                            COUNT(DISTINCT o.CustomerID) AS TotalCustomers,
                            SUM(o.BooksQty) AS TotalBooks,
                            SUM(o.TotalBill) AS TotalMoney,
                            SUM(CASE WHEN o.PaymentMethod = 'Cash' THEN o.TotalBill ELSE 0 END) AS TotalCash,
                            SUM(CASE WHEN o.PaymentMethod = 'Visa' THEN o.TotalBill ELSE 0 END) AS TotalVisa,
                            COUNT(*) AS TotalOrders
                            FROM Orders o 
                            WHERE CAST(o.OrderDate AS DATE) = CAST(GETDATE() AS DATE)";
            return dataAccess.ExecuteQuery(query);
        }
    }
}
