using System;
using System.Data;
using DAL;

namespace BLL
{
    public class CustomerBLL
    {
        private CustomerDAL customerDAL;

        public CustomerBLL()
        {
            customerDAL = new CustomerDAL();
        }

        public bool ValidatePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            if (phone.Length < 10 || phone.Length > 20)
                return false;

            return true;
        }

        public bool ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            if (name.Length > 100)
                return false;

            return true;
        }

        public DataTable GetCustomerByPhone(string phone)
        {
            if (!ValidatePhone(phone))
                throw new ArgumentException("Invalid phone number");

            return customerDAL.GetCustomerByPhone(phone);
        }

        public DataTable GetCustomerById(int customerId)
        {
            if (customerId <= 0)
                throw new ArgumentException("Invalid customer ID");

            return customerDAL.GetCustomerById(customerId);
        }

        public bool CreateCustomer(string phone, string name)
        {
            if (!ValidatePhone(phone))
                throw new ArgumentException("Invalid phone number");

            if (!ValidateName(name))
                throw new ArgumentException("Invalid customer name");

            // Check if customer already exists - if so, return success (use existing customer)
            DataTable existingCustomer = customerDAL.GetCustomerByPhone(phone);
            if (existingCustomer.Rows.Count > 0)
                return true; // Customer already exists, use them

            int result = customerDAL.InsertCustomer(phone, name);
            return result > 0;
        }

        public int GetOrCreateCustomer(string phone, string name)
        {
            if (!ValidatePhone(phone))
                throw new ArgumentException("Invalid phone number");

            if (!ValidateName(name))
                throw new ArgumentException("Invalid customer name");

            // Check if customer already exists
            DataTable existingCustomer = customerDAL.GetCustomerByPhone(phone);
            if (existingCustomer.Rows.Count > 0)
            {
                return Convert.ToInt32(existingCustomer.Rows[0]["CustomerID"]);
            }

            // Create new customer
            customerDAL.InsertCustomer(phone, name);
            
            // Get the newly created customer ID
            DataTable newCustomer = customerDAL.GetCustomerByPhone(phone);
            if (newCustomer.Rows.Count > 0)
            {
                return Convert.ToInt32(newCustomer.Rows[0]["CustomerID"]);
            }

            throw new Exception("Failed to create or retrieve customer");
        }

        public DataTable GetAllCustomers()
        {
            return customerDAL.GetAllCustomers();
        }
    }
}
