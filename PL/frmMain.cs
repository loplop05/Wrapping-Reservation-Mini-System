using System;
using System.Drawing;
using System.Windows.Forms;

namespace PL
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAddReservation_Click(object sender, EventArgs e)
        {
            frmReservation reservationForm = new frmReservation();
            reservationForm.ShowDialog();
        }

        private void btnCheckStatus_Click(object sender, EventArgs e)
        {
            frmOrders ordersForm = new frmOrders();
            ordersForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEndOfDay_Click(object sender, EventArgs e)
        {
            frmEndOfDay endOfDayForm = new frmEndOfDay();
            endOfDayForm.ShowDialog();
        }
    }
}
