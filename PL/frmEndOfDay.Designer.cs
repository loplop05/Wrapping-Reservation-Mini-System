namespace PL
{
    partial class frmEndOfDay
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTotalCustomersLabel = new System.Windows.Forms.Label();
            this.lblTotalCustomers = new System.Windows.Forms.Label();
            this.lblTotalBooksLabel = new System.Windows.Forms.Label();
            this.lblTotalBooks = new System.Windows.Forms.Label();
            this.lblTotalMoneyLabel = new System.Windows.Forms.Label();
            this.lblTotalMoney = new System.Windows.Forms.Label();
            this.lblTotalCashLabel = new System.Windows.Forms.Label();
            this.lblTotalCash = new System.Windows.Forms.Label();
            this.lblTotalVisaLabel = new System.Windows.Forms.Label();
            this.lblTotalVisa = new System.Windows.Forms.Label();
            this.lblTotalOrdersLabel = new System.Windows.Forms.Label();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSavePdf = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(200, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(250, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "End of Day Report";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(250, 70);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(100, 29);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "2026-08-18";
            // 
            // lblTotalCustomersLabel
            // 
            this.lblTotalCustomersLabel.AutoSize = true;
            this.lblTotalCustomersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCustomersLabel.Location = new System.Drawing.Point(50, 130);
            this.lblTotalCustomersLabel.Name = "lblTotalCustomersLabel";
            this.lblTotalCustomersLabel.Size = new System.Drawing.Size(180, 31);
            this.lblTotalCustomersLabel.TabIndex = 2;
            this.lblTotalCustomersLabel.Text = "Total Customers:";
            // 
            // lblTotalCustomers
            // 
            this.lblTotalCustomers.AutoSize = true;
            this.lblTotalCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCustomers.Location = new System.Drawing.Point(400, 130);
            this.lblTotalCustomers.Name = "lblTotalCustomers";
            this.lblTotalCustomers.Size = new System.Drawing.Size(25, 31);
            this.lblTotalCustomers.TabIndex = 3;
            this.lblTotalCustomers.Text = "0";
            // 
            // lblTotalBooksLabel
            // 
            this.lblTotalBooksLabel.AutoSize = true;
            this.lblTotalBooksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBooksLabel.Location = new System.Drawing.Point(50, 180);
            this.lblTotalBooksLabel.Name = "lblTotalBooksLabel";
            this.lblTotalBooksLabel.Size = new System.Drawing.Size(140, 31);
            this.lblTotalBooksLabel.TabIndex = 4;
            this.lblTotalBooksLabel.Text = "Total Books:";
            // 
            // lblTotalBooks
            // 
            this.lblTotalBooks.AutoSize = true;
            this.lblTotalBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBooks.Location = new System.Drawing.Point(400, 180);
            this.lblTotalBooks.Name = "lblTotalBooks";
            this.lblTotalBooks.Size = new System.Drawing.Size(25, 31);
            this.lblTotalBooks.TabIndex = 5;
            this.lblTotalBooks.Text = "0";
            // 
            // lblTotalMoneyLabel
            // 
            this.lblTotalMoneyLabel.AutoSize = true;
            this.lblTotalMoneyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMoneyLabel.Location = new System.Drawing.Point(50, 230);
            this.lblTotalMoneyLabel.Name = "lblTotalMoneyLabel";
            this.lblTotalMoneyLabel.Size = new System.Drawing.Size(130, 31);
            this.lblTotalMoneyLabel.TabIndex = 6;
            this.lblTotalMoneyLabel.Text = "Total Money:";
            // 
            // lblTotalMoney
            // 
            this.lblTotalMoney.AutoSize = true;
            this.lblTotalMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMoney.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.lblTotalMoney.Location = new System.Drawing.Point(400, 230);
            this.lblTotalMoney.Name = "lblTotalMoney";
            this.lblTotalMoney.Size = new System.Drawing.Size(80, 31);
            this.lblTotalMoney.TabIndex = 7;
            this.lblTotalMoney.Text = "0.00 JD";
            // 
            // lblTotalCashLabel
            // 
            this.lblTotalCashLabel.AutoSize = true;
            this.lblTotalCashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCashLabel.Location = new System.Drawing.Point(50, 280);
            this.lblTotalCashLabel.Name = "lblTotalCashLabel";
            this.lblTotalCashLabel.Size = new System.Drawing.Size(90, 31);
            this.lblTotalCashLabel.TabIndex = 8;
            this.lblTotalCashLabel.Text = "Total Cash:";
            // 
            // lblTotalCash
            // 
            this.lblTotalCash.AutoSize = true;
            this.lblTotalCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCash.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblTotalCash.Location = new System.Drawing.Point(400, 280);
            this.lblTotalCash.Name = "lblTotalCash";
            this.lblTotalCash.Size = new System.Drawing.Size(80, 31);
            this.lblTotalCash.TabIndex = 9;
            this.lblTotalCash.Text = "0.00 JD";
            // 
            // lblTotalVisaLabel
            // 
            this.lblTotalVisaLabel.AutoSize = true;
            this.lblTotalVisaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVisaLabel.Location = new System.Drawing.Point(50, 330);
            this.lblTotalVisaLabel.Name = "lblTotalVisaLabel";
            this.lblTotalVisaLabel.Size = new System.Drawing.Size(100, 31);
            this.lblTotalVisaLabel.TabIndex = 10;
            this.lblTotalVisaLabel.Text = "Total Visa:";
            // 
            // lblTotalVisa
            // 
            this.lblTotalVisa.AutoSize = true;
            this.lblTotalVisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVisa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(39)))), ((int)(((byte)(176)))));
            this.lblTotalVisa.Location = new System.Drawing.Point(400, 330);
            this.lblTotalVisa.Name = "lblTotalVisa";
            this.lblTotalVisa.Size = new System.Drawing.Size(80, 31);
            this.lblTotalVisa.TabIndex = 11;
            this.lblTotalVisa.Text = "0.00 JD";
            // 
            // lblTotalOrdersLabel
            // 
            this.lblTotalOrdersLabel.AutoSize = true;
            this.lblTotalOrdersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalOrdersLabel.Location = new System.Drawing.Point(50, 380);
            this.lblTotalOrdersLabel.Name = "lblTotalOrdersLabel";
            this.lblTotalOrdersLabel.Size = new System.Drawing.Size(130, 31);
            this.lblTotalOrdersLabel.TabIndex = 12;
            this.lblTotalOrdersLabel.Text = "Total Orders:";
            // 
            // lblTotalOrders
            // 
            this.lblTotalOrders.AutoSize = true;
            this.lblTotalOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalOrders.Location = new System.Drawing.Point(400, 380);
            this.lblTotalOrders.Name = "lblTotalOrders";
            this.lblTotalOrders.Size = new System.Drawing.Size(25, 31);
            this.lblTotalOrders.TabIndex = 13;
            this.lblTotalOrders.Text = "0";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(50, 450);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(120, 45);
            this.btnPrint.TabIndex = 14;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSavePdf
            // 
            this.btnSavePdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(39)))), ((int)(((byte)(176)))));
            this.btnSavePdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePdf.ForeColor = System.Drawing.Color.White;
            this.btnSavePdf.Location = new System.Drawing.Point(200, 450);
            this.btnSavePdf.Name = "btnSavePdf";
            this.btnSavePdf.Size = new System.Drawing.Size(120, 45);
            this.btnSavePdf.TabIndex = 15;
            this.btnSavePdf.Text = "Save as File";
            this.btnSavePdf.UseVisualStyleBackColor = false;
            this.btnSavePdf.Click += new System.EventHandler(this.btnSaveAsPdf_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(350, 450);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 45);
            this.btnRefresh.TabIndex = 16;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(500, 450);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 45);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmEndOfDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 530);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSavePdf);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lblTotalOrders);
            this.Controls.Add(this.lblTotalOrdersLabel);
            this.Controls.Add(this.lblTotalVisa);
            this.Controls.Add(this.lblTotalVisaLabel);
            this.Controls.Add(this.lblTotalCash);
            this.Controls.Add(this.lblTotalCashLabel);
            this.Controls.Add(this.lblTotalMoney);
            this.Controls.Add(this.lblTotalMoneyLabel);
            this.Controls.Add(this.lblTotalBooks);
            this.Controls.Add(this.lblTotalBooksLabel);
            this.Controls.Add(this.lblTotalCustomers);
            this.Controls.Add(this.lblTotalCustomersLabel);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmEndOfDay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "End of Day Report";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTotalCustomersLabel;
        private System.Windows.Forms.Label lblTotalCustomers;
        private System.Windows.Forms.Label lblTotalBooksLabel;
        private System.Windows.Forms.Label lblTotalBooks;
        private System.Windows.Forms.Label lblTotalMoneyLabel;
        private System.Windows.Forms.Label lblTotalMoney;
        private System.Windows.Forms.Label lblTotalCashLabel;
        private System.Windows.Forms.Label lblTotalCash;
        private System.Windows.Forms.Label lblTotalVisaLabel;
        private System.Windows.Forms.Label lblTotalVisa;
        private System.Windows.Forms.Label lblTotalOrdersLabel;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSavePdf;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClose;
    }
}
