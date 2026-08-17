using System;
using System.Data;
using System.Windows.Forms;
using BLL;

namespace PL
{
    public partial class frmEditOrder : Form
    {
        private OrderBLL orderBLL;
        private int orderId;

        public frmEditOrder(int orderId)
        {
            InitializeComponent();
            orderBLL = new OrderBLL();
            this.orderId = orderId;
            LoadOrderData();
        }

        private void LoadOrderData()
        {
            try
            {
                DataTable order = orderBLL.GetOrderById(orderId);

                if (order.Rows.Count > 0)
                {
                    DataRow row = order.Rows[0];
                    nudBooksQty.Value = Convert.ToInt32(row["BooksQty"]);
                    txtOtherPurchases.Text = Convert.ToDecimal(row["OtherPurchasesAmount"]).ToString("F2");
                    cmbStatus.Text = row["Status"].ToString();
                    cmbPaymentMethod.Text = row["PaymentMethod"].ToString();
                    CalculateTotal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    lblTotalBill.Text = total.ToString("F2") + " JD";
                }
                else
                {
                    lblTotalBill.Text = "0.00 JD";
                }
            }
            catch
            {
                lblTotalBill.Text = "0.00 JD";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int booksQty = Convert.ToInt32(nudBooksQty.Value);
            decimal otherPurchases = 0;

            if (!decimal.TryParse(txtOtherPurchases.Text, out otherPurchases) || otherPurchases < 0)
            {
                MessageBox.Show("Please enter a valid amount for other purchases.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOtherPurchases.Focus();
                return;
            }

            string status = cmbStatus.Text;
            string paymentMethod = cmbPaymentMethod.Text;

            try
            {
                bool success = orderBLL.UpdateOrder(orderId, booksQty, otherPurchases, status, paymentMethod);

                if (success)
                {
                    MessageBox.Show("Order updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
