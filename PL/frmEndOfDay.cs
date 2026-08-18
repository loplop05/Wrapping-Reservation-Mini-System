using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
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

                if (stats != null && stats.Rows.Count > 0)
                {
                    DataRow row = stats.Rows[0];
                    
                    // Handle potential NULL values safely
                    lblTotalCustomers.Text = row["TotalCustomers"] != DBNull.Value ? row["TotalCustomers"].ToString() : "0";
                    lblTotalBooks.Text = row["TotalBooks"] != DBNull.Value ? row["TotalBooks"].ToString() : "0";
                    
                    decimal totalMoney = row["TotalMoney"] != DBNull.Value ? Convert.ToDecimal(row["TotalMoney"]) : 0m;
                    lblTotalMoney.Text = totalMoney.ToString("F2") + " JD";
                    
                    decimal totalCash = row["TotalCash"] != DBNull.Value ? Convert.ToDecimal(row["TotalCash"]) : 0m;
                    lblTotalCash.Text = totalCash.ToString("F2") + " JD";
                    
                    decimal totalVisa = row["TotalVisa"] != DBNull.Value ? Convert.ToDecimal(row["TotalVisa"]) : 0m;
                    lblTotalVisa.Text = totalVisa.ToString("F2") + " JD";
                    
                    lblTotalOrders.Text = row["TotalOrders"] != DBNull.Value ? row["TotalOrders"].ToString() : "0";
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
                MessageBox.Show("Error loading statistics: " + ex.Message + "\n\nRun Database.sql for a new database or FixDatabaseColumns.sql to upgrade an existing database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // Set default values on error
                lblTotalCustomers.Text = "0";
                lblTotalBooks.Text = "0";
                lblTotalMoney.Text = "0.00 JD";
                lblTotalCash.Text = "0.00 JD";
                lblTotalVisa.Text = "0.00 JD";
                lblTotalOrders.Text = "0";
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDoc;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font titleFont = new Font("Arial", 18, FontStyle.Bold);
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font normalFont = new Font("Arial", 11);
            Font labelFont = new Font("Arial", 11, FontStyle.Bold);

            float yPos = 50;
            float leftMargin = 50;
            float lineHeight = 30;

            // Title
            graphics.DrawString("End of Day Report", titleFont, Brushes.Black, leftMargin, yPos);
            yPos += lineHeight * 1.5f;

            // Date
            graphics.DrawString($"Date: {DateTime.Now.ToString("yyyy-MM-dd")}", normalFont, Brushes.Black, leftMargin, yPos);
            yPos += lineHeight * 1.5f;

            // Separator line
            graphics.DrawLine(Pens.Black, leftMargin, yPos, 600, yPos);
            yPos += lineHeight;

            // Statistics
            graphics.DrawString("Total Customers:", labelFont, Brushes.Black, leftMargin, yPos);
            graphics.DrawString(lblTotalCustomers.Text, normalFont, Brushes.Black, leftMargin + 200, yPos);
            yPos += lineHeight;

            graphics.DrawString("Total Books:", labelFont, Brushes.Black, leftMargin, yPos);
            graphics.DrawString(lblTotalBooks.Text, normalFont, Brushes.Black, leftMargin + 200, yPos);
            yPos += lineHeight;

            graphics.DrawString("Total Money:", labelFont, Brushes.Black, leftMargin, yPos);
            graphics.DrawString(lblTotalMoney.Text, normalFont, Brushes.Black, leftMargin + 200, yPos);
            yPos += lineHeight;

            graphics.DrawString("Total Cash:", labelFont, Brushes.Black, leftMargin, yPos);
            graphics.DrawString(lblTotalCash.Text, normalFont, Brushes.Black, leftMargin + 200, yPos);
            yPos += lineHeight;

            graphics.DrawString("Total Visa:", labelFont, Brushes.Black, leftMargin, yPos);
            graphics.DrawString(lblTotalVisa.Text, normalFont, Brushes.Black, leftMargin + 200, yPos);
            yPos += lineHeight;

            graphics.DrawString("Total Orders:", labelFont, Brushes.Black, leftMargin, yPos);
            graphics.DrawString(lblTotalOrders.Text, normalFont, Brushes.Black, leftMargin + 200, yPos);
            yPos += lineHeight * 1.5f;

            // Footer
            graphics.DrawLine(Pens.Black, leftMargin, yPos, 600, yPos);
            yPos += lineHeight;
            graphics.DrawString("Library Book Wrapping System", normalFont, Brushes.Gray, leftMargin, yPos);
        }

        private void btnSaveAsPdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.FileName = $"EndOfDayReport_{DateTime.Now.ToString("yyyyMMdd")}.txt";
            saveFileDialog.Title = "Save Report";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        writer.WriteLine("=".PadRight(50, '='));
                        writer.WriteLine("End of Day Report");
                        writer.WriteLine("=".PadRight(50, '='));
                        writer.WriteLine();
                        writer.WriteLine($"Date: {DateTime.Now.ToString("yyyy-MM-dd")}");
                        writer.WriteLine();
                        writer.WriteLine("-".PadRight(50, '-'));
                        writer.WriteLine("Statistics:");
                        writer.WriteLine("-".PadRight(50, '-'));
                        writer.WriteLine($"Total Customers: {lblTotalCustomers.Text}");
                        writer.WriteLine($"Total Books: {lblTotalBooks.Text}");
                        writer.WriteLine($"Total Money: {lblTotalMoney.Text}");
                        writer.WriteLine($"Total Cash: {lblTotalCash.Text}");
                        writer.WriteLine($"Total Visa: {lblTotalVisa.Text}");
                        writer.WriteLine($"Total Orders: {lblTotalOrders.Text}");
                        writer.WriteLine();
                        writer.WriteLine("-".PadRight(50, '-'));
                        writer.WriteLine("Library Book Wrapping System");
                        writer.WriteLine("-".PadRight(50, '-'));
                    }

                    MessageBox.Show("Report saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
