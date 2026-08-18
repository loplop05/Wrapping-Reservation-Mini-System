using System;
using System.Data;
using DAL;

namespace BLL
{
    public class OrderBLL
    {
        private readonly OrderDAL orderDAL;
        private readonly CustomerBLL customerBLL;
        private decimal wrappingPricePerBook = 1.0m;

        public OrderBLL()
        {
            orderDAL = new OrderDAL();
            customerBLL = new CustomerBLL();
        }

        public decimal WrappingPricePerBook
        {
            get { return wrappingPricePerBook; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Wrapping price cannot be negative");

                wrappingPricePerBook = value;
            }
        }

        public bool ValidateBooksQty(int booksQty)
        {
            return booksQty > 0;
        }

        public bool ValidateOtherPurchases(decimal otherPurchases)
        {
            return otherPurchases >= 0;
        }

        public decimal CalculateTotalBill(int booksQty, decimal otherPurchases)
        {
            if (!ValidateBooksQty(booksQty))
                throw new ArgumentException("Invalid books quantity");

            if (!ValidateOtherPurchases(otherPurchases))
                throw new ArgumentException("Invalid other purchases amount");

            decimal wrappingCost = booksQty * wrappingPricePerBook;
            return wrappingCost + otherPurchases;
        }

        public bool ValidateStatus(string status)
        {
            string[] validStatuses = { "Pending", "Ready", "Completed", "Cancelled" };
            return !string.IsNullOrWhiteSpace(status) &&
                   Array.Exists(validStatuses, s => s.Equals(status, StringComparison.OrdinalIgnoreCase));
        }

        public bool ValidatePaymentMethod(string paymentMethod)
        {
            string[] validPaymentMethods = { "Cash", "Visa" };
            return !string.IsNullOrWhiteSpace(paymentMethod) &&
                   Array.Exists(validPaymentMethods, p => p.Equals(paymentMethod, StringComparison.OrdinalIgnoreCase));
        }

        public bool CreateOrder(
            int customerId,
            int booksQty,
            decimal otherPurchases,
            string status = "Pending",
            string paymentMethod = "Cash")
        {
            if (customerId <= 0)
                throw new ArgumentException("Invalid customer ID");

            if (!ValidateBooksQty(booksQty))
                throw new ArgumentException("Books quantity must be greater than 0");

            if (!ValidateOtherPurchases(otherPurchases))
                throw new ArgumentException("Other purchases amount cannot be negative");

            if (!ValidateStatus(status))
                throw new ArgumentException("Invalid status");

            if (!ValidatePaymentMethod(paymentMethod))
                throw new ArgumentException("Invalid payment method");

            decimal totalBill = CalculateTotalBill(booksQty, otherPurchases);
            int result = orderDAL.InsertOrder(customerId, booksQty, otherPurchases, totalBill, status, paymentMethod);
            return result > 0;
        }

        public DataTable GetAllOrders()
        {
            return orderDAL.GetAllOrders();
        }

        public DataTable GetOrderById(int orderId)
        {
            if (orderId <= 0)
                throw new ArgumentException("Invalid order ID");

            return orderDAL.GetOrderById(orderId);
        }

        public bool UpdateOrder(
            int orderId,
            int booksQty,
            decimal otherPurchases,
            string status,
            string paymentMethod = "Cash")
        {
            if (orderId <= 0)
                throw new ArgumentException("Invalid order ID");

            if (!ValidateBooksQty(booksQty))
                throw new ArgumentException("Books quantity must be greater than 0");

            if (!ValidateOtherPurchases(otherPurchases))
                throw new ArgumentException("Other purchases amount cannot be negative");

            if (!ValidateStatus(status))
                throw new ArgumentException("Invalid status");

            if (!ValidatePaymentMethod(paymentMethod))
                throw new ArgumentException("Invalid payment method");

            decimal totalBill = CalculateTotalBill(booksQty, otherPurchases);
            int result = orderDAL.UpdateOrder(orderId, booksQty, otherPurchases, totalBill, status, paymentMethod);
            return result > 0;
        }

        public bool UpdateOrderStatus(int orderId, string status)
        {
            if (orderId <= 0)
                throw new ArgumentException("Invalid order ID");

            if (!ValidateStatus(status))
                throw new ArgumentException("Invalid status");

            int result = orderDAL.UpdateOrderStatus(orderId, status);
            return result > 0;
        }

        public bool DeleteOrder(int orderId)
        {
            if (orderId <= 0)
                throw new ArgumentException("Invalid order ID");

            int result = orderDAL.DeleteOrder(orderId);
            return result > 0;
        }

        public DataTable SearchOrders(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return GetAllOrders();

            return orderDAL.SearchOrders(searchTerm.Trim());
        }

        public DataTable GetOrdersByStatus(string status)
        {
            if (!ValidateStatus(status))
                throw new ArgumentException("Invalid status");

            return orderDAL.GetOrdersByStatus(status);
        }

        public DataTable GetEndOfDayStatistics()
        {
            return orderDAL.GetEndOfDayStatistics();
        }
    }
}
