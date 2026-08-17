using System;
using System.Data;
using System.Windows.Forms;
using BLL;

namespace PL
{
    public partial class frmEndOfDay : Form
    {
        private OrderBLL orderBLL;

        public frmEndOfDay()
        {
            InitializeComponent();
            orderBLL = new OrderBLL();
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            try
            {
                DataTable stats = orderBLL.GetEndOfDayStatistics();

                if (stats.Rows.Count > 0)
                {
                    DataRow row = stats.Rows[0];
                    
                    lblTotalCustomers.Text = row["TotalCustomers"].ToString();
                    lblTotalBooks.Text = row["TotalBooks"].ToString();
                    lblTotalMoney.Text = Convert.ToDecimal(row["TotalMoney"]).ToString("F2") + " JD";
                    lblTotalCash.Text = Convert.ToDecimal(row["TotalCash"]).ToString("F2") + " JD";
                    lblTotalVisa.Text = Convert.ToDecimal(row["TotalVisa"]).ToString("F2") + " JD";
                    lblTotalOrders.Text = row["TotalOrders"].ToString();
                }
                else
                {
                    lblTotalCustomers.Text = "0";
                    lblTotalBooks.Text = "0";
                    lblTotalMoney.Text = "0.00 JD";
                    lblTotalCash.Text = "0.00 JD";
                    lblTotalVisa.Text = "0.00 JD";
                    lblTotalOrders.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading statistics: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStatistics();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
