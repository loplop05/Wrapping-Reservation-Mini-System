using System;
using System.Data;
using System.Windows.Forms;
using BLL;

namespace PL
{
    public partial class frmReservation : Form
    {
        private CustomerBLL customerBLL;
        private OrderBLL orderBLL;
        private int currentCustomerId = -1;

        public frmReservation()
        {
            InitializeComponent();
            customerBLL = new CustomerBLL();
            orderBLL = new OrderBLL();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Please enter a phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable customer = customerBLL.GetCustomerByPhone(phone);

                if (customer.Rows.Count > 0)
                {
                    // Customer exists - allow multiple reservations
                    currentCustomerId = Convert.ToInt32(customer.Rows[0]["CustomerID"]);
                    txtName.Text = customer.Rows[0]["Name"].ToString();
                    txtName.ReadOnly = true;
                    MessageBox.Show("Customer found! Ready to add another reservation.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Customer doesn't exist
                    currentCustomerId = -1;
                    txtName.Text = "";
                    txtName.ReadOnly = false;
                    txtName.Focus();
                    MessageBox.Show("Customer not found. Please enter customer name to create a new customer.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching for customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nudBooksQty_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void txtOtherPurchases_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            try
            {
                int booksQty = Convert.ToInt32(nudBooksQty.Value);
                decimal otherPurchases = 0;

                if (decimal.TryParse(txtOtherPurchases.Text, out otherPurchases))
                {
                    decimal total = orderBLL.CalculateTotalBill(booksQty, otherPurchases);
                    lblTotalBillValue.Text = total.ToString("F2") + " JD";
                }
                else
                {
                    lblTotalBillValue.Text = "0.00 JD";
                }
            }
            catch
            {
                lblTotalBillValue.Text = "0.00 JD";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate phone
            string phone = txtPhone.Text.Trim();
            if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Please enter a phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            // Validate or create customer
            if (currentCustomerId == -1)
            {
                string name = txtName.Text.Trim();
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Please enter customer name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                    return;
                }

                try
                {
                    currentCustomerId = customerBLL.GetOrCreateCustomer(phone, name);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Validate books quantity
            int booksQty = Convert.ToInt32(nudBooksQty.Value);
            if (booksQty <= 0)
            {
                MessageBox.Show("Please enter a valid number of books.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudBooksQty.Focus();
                return;
            }

            // Validate other purchases
            decimal otherPurchases = 0;
            if (!decimal.TryParse(txtOtherPurchases.Text, out otherPurchases) || otherPurchases < 0)
            {
                MessageBox.Show("Please enter a valid amount for other purchases.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOtherPurchases.Focus();
                return;
            }

            try
            {
                const string paymentMethod = "Cash";
                bool success = orderBLL.CreateOrder(currentCustomerId, booksQty, otherPurchases, "Pending", paymentMethod);

                if (success)
                {
                    MessageBox.Show("Reservation saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to save reservation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving reservation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtPhone.Text = "";
            txtName.Text = "";
            txtName.ReadOnly = false;
            nudBooksQty.Value = 1;
            txtOtherPurchases.Text = "0";
            lblTotalBillValue.Text = "0.00 JD";
            currentCustomerId = -1; // Reset to allow new customer or same customer for new reservation
            txtPhone.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
