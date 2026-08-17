namespace PL
{
    partial class frmEditOrder
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
            this.lblBooksQty = new System.Windows.Forms.Label();
            this.nudBooksQty = new System.Windows.Forms.NumericUpDown();
            this.lblOtherPurchases = new System.Windows.Forms.Label();
            this.txtOtherPurchases = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblTotalBill = new System.Windows.Forms.Label();
            this.lblTotalBillValue = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudBooksQty)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBooksQty
            // 
            this.lblBooksQty.AutoSize = true;
            this.lblBooksQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBooksQty.Location = new System.Drawing.Point(50, 80);
            this.lblBooksQty.Name = "lblBooksQty";
            this.lblBooksQty.Size = new System.Drawing.Size(161, 24);
            this.lblBooksQty.TabIndex = 1;
            this.lblBooksQty.Text = "Number of Books:";
            // 
            // nudBooksQty
            // 
            this.nudBooksQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudBooksQty.Location = new System.Drawing.Point(291, 80);
            this.nudBooksQty.Name = "nudBooksQty";
            this.nudBooksQty.Size = new System.Drawing.Size(120, 28);
            this.nudBooksQty.TabIndex = 2;
            this.nudBooksQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBooksQty.ValueChanged += new System.EventHandler(this.nudBooksQty_ValueChanged);
            // 
            // lblOtherPurchases
            // 
            this.lblOtherPurchases.AutoSize = true;
            this.lblOtherPurchases.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOtherPurchases.Location = new System.Drawing.Point(50, 130);
            this.lblOtherPurchases.Name = "lblOtherPurchases";
            this.lblOtherPurchases.Size = new System.Drawing.Size(156, 24);
            this.lblOtherPurchases.TabIndex = 3;
            this.lblOtherPurchases.Text = "Other Purchases:";
            // 
            // txtOtherPurchases
            // 
            this.txtOtherPurchases.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtherPurchases.Location = new System.Drawing.Point(291, 130);
            this.txtOtherPurchases.Name = "txtOtherPurchases";
            this.txtOtherPurchases.Size = new System.Drawing.Size(120, 28);
            this.txtOtherPurchases.TabIndex = 4;
            this.txtOtherPurchases.TextChanged += new System.EventHandler(this.txtOtherPurchases_TextChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(50, 180);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(65, 24);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Status:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Pending",
            "Ready",
            "Completed",
            "Cancelled"});
            this.cmbStatus.Location = new System.Drawing.Point(273, 177);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 30);
            this.cmbStatus.TabIndex = 6;
            // 
            // lblTotalBill
            // 
            this.lblTotalBill.AutoSize = true;
            this.lblTotalBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBill.Location = new System.Drawing.Point(50, 230);
            this.lblTotalBill.Name = "lblTotalBill";
            this.lblTotalBill.Size = new System.Drawing.Size(96, 24);
            this.lblTotalBill.TabIndex = 7;
            this.lblTotalBill.Text = "Total Bill:";
            // 
            // lblTotalBillValue
            // 
            this.lblTotalBillValue.AutoSize = true;
            this.lblTotalBillValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBillValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblTotalBillValue.Location = new System.Drawing.Point(200, 227);
            this.lblTotalBillValue.Name = "lblTotalBillValue";
            this.lblTotalBillValue.Size = new System.Drawing.Size(100, 29);
            this.lblTotalBillValue.TabIndex = 8;
            this.lblTotalBillValue.Text = "0.00 JD";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(99, 332);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(153, 61);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(312, 332);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 63);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(150, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(147, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Edit Order";
            // 
            // frmEditOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(547, 422);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTotalBillValue);
            this.Controls.Add(this.lblTotalBill);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtOtherPurchases);
            this.Controls.Add(this.lblOtherPurchases);
            this.Controls.Add(this.nudBooksQty);
            this.Controls.Add(this.lblBooksQty);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmEditOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Order";
            ((System.ComponentModel.ISupportInitialize)(this.nudBooksQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblBooksQty;
        private System.Windows.Forms.NumericUpDown nudBooksQty;
        private System.Windows.Forms.Label lblOtherPurchases;
        private System.Windows.Forms.TextBox txtOtherPurchases;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblTotalBill;
        private System.Windows.Forms.Label lblTotalBillValue;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
