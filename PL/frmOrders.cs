using System;
using System.Data;
using System.Windows.Forms;
using BLL;

namespace PL
{
    public partial class frmOrders : Form
    {
        private OrderBLL orderBLL;

        public frmOrders()
        {
            InitializeComponent();
            orderBLL = new OrderBLL();
            LoadPendingOrders();
            LoadCompletedOrders();
        }

        private void LoadPendingOrders()
        {
            try
            {
                DataTable orders = orderBLL.GetOrdersByStatus("Pending");
                dgvPending.DataSource = orders;
                FormatDataGridView(dgvPending);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading pending orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCompletedOrders()
        {
            try
            {
                DataTable orders = orderBLL.GetOrdersByStatus("Completed");
                dgvCompleted.DataSource = orders;
                FormatDataGridView(dgvCompleted);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading completed orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView(DataGridView dgv)
        {
            // Format the DataGridView
            if (dgv.Columns.Count > 0)
            {
                dgv.Columns["OrderID"].HeaderText = "Order ID";
                dgv.Columns["CustomerName"].HeaderText = "Customer Name";
                dgv.Columns["Phone"].HeaderText = "Phone";
                dgv.Columns["BooksQty"].HeaderText = "Books Qty";
                dgv.Columns["OtherPurchasesAmount"].HeaderText = "Other Purchases";
                dgv.Columns["TotalBill"].HeaderText = "Total Bill";
                dgv.Columns["OrderDate"].HeaderText = "Order Date";
                dgv.Columns["Status"].HeaderText = "Status";
                dgv.Columns["PaymentMethod"].HeaderText = "Payment";

                // Format columns
                dgv.Columns["OtherPurchasesAmount"].DefaultCellStyle.Format = "F2";
                dgv.Columns["TotalBill"].DefaultCellStyle.Format = "F2";
                dgv.Columns["OrderDate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";

                // Auto-size columns
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPendingOrders();
            LoadCompletedOrders();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadPendingOrders();
                LoadCompletedOrders();
                return;
            }

            try
            {
                DataTable orders = orderBLL.SearchOrders(searchTerm);
                
                // Show in both tabs for search results
                dgvPending.DataSource = orders;
                dgvCompleted.DataSource = orders;
                
                FormatDataGridView(dgvPending);
                FormatDataGridView(dgvCompleted);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddReservation_Click(object sender, EventArgs e)
        {
            frmReservation reservationForm = new frmReservation();
            if (reservationForm.ShowDialog() == DialogResult.OK)
            {
                LoadPendingOrders();
                LoadCompletedOrders();
            }
            else
            {
                LoadPendingOrders();
                LoadCompletedOrders();
            }
        }

        private void contextMenuEdit_Click(object sender, EventArgs e)
        {
            DataGridView dgv = GetCurrentDataGridView();
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to edit.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderId = Convert.ToInt32(dgv.SelectedRows[0].Cells["OrderID"].Value);
            string status = dgv.SelectedRows[0].Cells["Status"].Value.ToString();

            // Check if order is completed
            if (status.Equals("Completed", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Completed orders cannot be edited.", "Edit Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable order = orderBLL.GetOrderById(orderId);

                if (order.Rows.Count > 0)
                {
                    frmEditOrder editForm = new frmEditOrder(orderId);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadPendingOrders();
                        LoadCompletedOrders();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void contextMenuDelete_Click(object sender, EventArgs e)
        {
            DataGridView dgv = GetCurrentDataGridView();
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderId = Convert.ToInt32(dgv.SelectedRows[0].Cells["OrderID"].Value);
            string customerName = dgv.SelectedRows[0].Cells["CustomerName"].Value.ToString();
            string status = dgv.SelectedRows[0].Cells["Status"].Value.ToString();

            // Check if order is completed
            if (status.Equals("Completed", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Completed orders cannot be deleted.", "Delete Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete order {orderId} for {customerName}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = orderBLL.DeleteOrder(orderId);

                    if (success)
                    {
                        MessageBox.Show("Order deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPendingOrders();
                        LoadCompletedOrders();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void contextMenuChangeStatus_Click(object sender, EventArgs e)
        {
            DataGridView dgv = GetCurrentDataGridView();
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to change status.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderId = Convert.ToInt32(dgv.SelectedRows[0].Cells["OrderID"].Value);
            string currentStatus = dgv.SelectedRows[0].Cells["Status"].Value.ToString();

            // Check if order is completed
            if (currentStatus.Equals("Completed", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Completed orders cannot have their status changed.", "Status Change Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmChangeStatus statusForm = new frmChangeStatus(orderId, currentStatus);
            if (statusForm.ShowDialog() == DialogResult.OK)
            {
                LoadPendingOrders();
                LoadCompletedOrders();
            }
        }

        private DataGridView GetCurrentDataGridView()
        {
            if (tabControl.SelectedTab == tabPending)
                return dgvPending;
            else
                return dgvCompleted;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Refresh the current tab when switching
            if (tabControl.SelectedTab == tabPending)
            {
                LoadPendingOrders();
            }
            else if (tabControl.SelectedTab == tabCompleted)
            {
                LoadCompletedOrders();
            }
        }
    }
}
