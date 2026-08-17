using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class CustomerDAL
    {
        private DataAccess dataAccess;

        public CustomerDAL()
        {
            dataAccess = new DataAccess();
        }

        public DataTable GetCustomerByPhone(string phone)
        {
            string query = "SELECT * FROM Customers WHERE Phone = @Phone";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Phone", phone)
            };
            return dataAccess.ExecuteQuery(query, parameters);
        }

        public DataTable GetCustomerById(int customerId)
        {
            string query = "SELECT * FROM Customers WHERE CustomerID = @CustomerID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CustomerID", customerId)
            };
            return dataAccess.ExecuteQuery(query, parameters);
        }

        public int InsertCustomer(string phone, string name)
        {
            string query = "INSERT INTO Customers (Phone, Name) VALUES (@Phone, @Name)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Phone", phone),
                new SqlParameter("@Name", name)
            };
            return dataAccess.ExecuteNonQuery(query, parameters);
        }

        public DataTable GetAllCustomers()
        {
            string query = "SELECT * FROM Customers ORDER BY Name";
            return dataAccess.ExecuteQuery(query);
        }
    }
}
