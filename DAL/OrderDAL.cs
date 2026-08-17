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

        public int InsertOrder(int customerId, int booksQty, decimal otherPurchasesAmount, decimal totalBill, string status)
        {
            string query = @"INSERT INTO Orders (CustomerID, BooksQty, OtherPurchasesAmount, TotalBill, Status) 
                            VALUES (@CustomerID, @BooksQty, @OtherPurchasesAmount, @TotalBill, @Status)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CustomerID", customerId),
                new SqlParameter("@BooksQty", booksQty),
                new SqlParameter("@OtherPurchasesAmount", otherPurchasesAmount),
                new SqlParameter("@TotalBill", totalBill),
                new SqlParameter("@Status", status)
            };
            return dataAccess.ExecuteNonQuery(query, parameters);
        }

        public DataTable GetAllOrders()
        {
            string query = @"SELECT o.OrderID, c.Name AS CustomerName, c.Phone, o.BooksQty, 
                            o.OtherPurchasesAmount, o.TotalBill, o.OrderDate, o.Status 
                            FROM Orders o 
                            INNER JOIN Customers c ON o.CustomerID = c.CustomerID 
                            ORDER BY o.OrderDate DESC";
            return dataAccess.ExecuteQuery(query);
        }

        public DataTable GetOrderById(int orderId)
        {
            string query = @"SELECT o.OrderID, c.Name AS CustomerName, c.Phone, o.BooksQty, 
                            o.OtherPurchasesAmount, o.TotalBill, o.OrderDate, o.Status, o.CustomerID
                            FROM Orders o 
                            INNER JOIN Customers c ON o.CustomerID = c.CustomerID 
                            WHERE o.OrderID = @OrderID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderID", orderId)
            };
            return dataAccess.ExecuteQuery(query, parameters);
        }

        public int UpdateOrder(int orderId, int booksQty, decimal otherPurchasesAmount, decimal totalBill, string status)
        {
            string query = @"UPDATE Orders 
                            SET BooksQty = @BooksQty, 
                                OtherPurchasesAmount = @OtherPurchasesAmount, 
                                TotalBill = @TotalBill, 
                                Status = @Status 
                            WHERE OrderID = @OrderID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@OrderID", orderId),
                new SqlParameter("@BooksQty", booksQty),
                new SqlParameter("@OtherPurchasesAmount", otherPurchasesAmount),
                new SqlParameter("@TotalBill", totalBill),
                new SqlParameter("@Status", status)
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
                            o.OtherPurchasesAmount, o.TotalBill, o.OrderDate, o.Status 
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
    }
}
