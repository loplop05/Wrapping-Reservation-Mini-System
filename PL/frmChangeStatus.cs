using System;
using System.Windows.Forms;
using BLL;

namespace PL
{
    public partial class frmChangeStatus : Form
    {
        private OrderBLL orderBLL;
        private int orderId;

        public frmChangeStatus(int orderId, string currentStatus)
        {
            InitializeComponent();
            orderBLL = new OrderBLL();
            this.orderId = orderId;
            cmbStatus.Text = currentStatus;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newStatus = cmbStatus.Text;

            if (string.IsNullOrEmpty(newStatus))
            {
                MessageBox.Show("Please select a status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool success = orderBLL.UpdateOrderStatus(orderId, newStatus);

                if (success)
                {
                    MessageBox.Show("Status updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating status: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
