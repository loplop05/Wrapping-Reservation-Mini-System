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
            LoadOrders();
        }

        private void LoadOrders()
        {
            try
            {
                DataTable orders = orderBLL.GetAllOrders();
                dgvOrders.DataSource = orders;

                // Format the DataGridView
                dgvOrders.Columns["OrderID"].HeaderText = "Order ID";
                dgvOrders.Columns["CustomerName"].HeaderText = "Customer Name";
                dgvOrders.Columns["Phone"].HeaderText = "Phone";
                dgvOrders.Columns["BooksQty"].HeaderText = "Books Qty";
                dgvOrders.Columns["OtherPurchasesAmount"].HeaderText = "Other Purchases";
                dgvOrders.Columns["TotalBill"].HeaderText = "Total Bill";
                dgvOrders.Columns["OrderDate"].HeaderText = "Order Date";
                dgvOrders.Columns["Status"].HeaderText = "Status";

                // Format columns
                dgvOrders.Columns["OtherPurchasesAmount"].DefaultCellStyle.Format = "F2";
                dgvOrders.Columns["TotalBill"].DefaultCellStyle.Format = "F2";
                dgvOrders.Columns["OrderDate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";

                // Auto-size columns
                dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadOrders();
                return;
            }

            try
            {
                DataTable orders = orderBLL.SearchOrders(searchTerm);
                dgvOrders.DataSource = orders;

                // Apply same formatting
                dgvOrders.Columns["OtherPurchasesAmount"].DefaultCellStyle.Format = "F2";
                dgvOrders.Columns["TotalBill"].DefaultCellStyle.Format = "F2";
                dgvOrders.Columns["OrderDate"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
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
                LoadOrders();
            }
            else
            {
                LoadOrders();
            }
        }

        private void btnEditOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to edit.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderID"].Value);

            try
            {
                DataTable order = orderBLL.GetOrderById(orderId);

                if (order.Rows.Count > 0)
                {
                    frmEditOrder editForm = new frmEditOrder(orderId);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadOrders();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading order: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderID"].Value);
            string customerName = dgvOrders.SelectedRows[0].Cells["CustomerName"].Value.ToString();

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
                        LoadOrders();
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

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to change status.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderID"].Value);
            string currentStatus = dgvOrders.SelectedRows[0].Cells["Status"].Value.ToString();

            frmChangeStatus statusForm = new frmChangeStatus(orderId, currentStatus);
            if (statusForm.ShowDialog() == DialogResult.OK)
            {
                LoadOrders();
            }
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
    }
}
