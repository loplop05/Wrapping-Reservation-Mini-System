namespace PL
{
    partial class frmReservation
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
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblBooksQty = new System.Windows.Forms.Label();
            this.nudBooksQty = new System.Windows.Forms.NumericUpDown();
            this.lblOtherPurchases = new System.Windows.Forms.Label();
            this.txtOtherPurchases = new System.Windows.Forms.TextBox();
            this.lblTotalBill = new System.Windows.Forms.Label();
            this.lblTotalBillValue = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudBooksQty)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(199, 38);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(376, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Book Wrapping Reservation";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(139, 99);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(145, 24);
            this.lblPhone.TabIndex = 1;
            this.lblPhone.Text = "Phone Number:";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtPhone.Location = new System.Drawing.Point(313, 90);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 36);
            this.txtPhone.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(519, 90);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 36);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(139, 149);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(152, 24);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Customer Name:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.txtName.Location = new System.Drawing.Point(301, 138);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(236, 40);
            this.txtName.TabIndex = 5;
            // 
            // lblBooksQty
            // 
            this.lblBooksQty.AutoSize = true;
            this.lblBooksQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBooksQty.Location = new System.Drawing.Point(139, 199);
            this.lblBooksQty.Name = "lblBooksQty";
            this.lblBooksQty.Size = new System.Drawing.Size(161, 24);
            this.lblBooksQty.TabIndex = 6;
            this.lblBooksQty.Text = "Number of Books:";
            // 
            // nudBooksQty
            // 
            this.nudBooksQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudBooksQty.Location = new System.Drawing.Point(313, 192);
            this.nudBooksQty.Name = "nudBooksQty";
            this.nudBooksQty.Size = new System.Drawing.Size(120, 34);
            this.nudBooksQty.TabIndex = 7;
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
            this.lblOtherPurchases.Location = new System.Drawing.Point(139, 249);
            this.lblOtherPurchases.Name = "lblOtherPurchases";
            this.lblOtherPurchases.Size = new System.Drawing.Size(156, 24);
            this.lblOtherPurchases.TabIndex = 8;
            this.lblOtherPurchases.Text = "Other Purchases:";
            // 
            // txtOtherPurchases
            // 
            this.txtOtherPurchases.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtherPurchases.Location = new System.Drawing.Point(313, 249);
            this.txtOtherPurchases.Name = "txtOtherPurchases";
            this.txtOtherPurchases.Size = new System.Drawing.Size(120, 38);
            this.txtOtherPurchases.TabIndex = 9;
            this.txtOtherPurchases.Text = "0";
            this.txtOtherPurchases.TextChanged += new System.EventHandler(this.txtOtherPurchases_TextChanged);
            // 
            // lblTotalBill
            // 
            this.lblTotalBill.AutoSize = true;
            this.lblTotalBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBill.Location = new System.Drawing.Point(139, 370);
            this.lblTotalBill.Name = "lblTotalBill";
            this.lblTotalBill.Size = new System.Drawing.Size(150, 38);
            this.lblTotalBill.TabIndex = 10;
            this.lblTotalBill.Text = "Total Bill:";
            // 
            // lblTotalBillValue
            // 
            this.lblTotalBillValue.AutoSize = true;
            this.lblTotalBillValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBillValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblTotalBillValue.Location = new System.Drawing.Point(343, 370);
            this.lblTotalBillValue.Name = "lblTotalBillValue";
            this.lblTotalBillValue.Size = new System.Drawing.Size(130, 38);
            this.lblTotalBillValue.TabIndex = 11;
            this.lblTotalBillValue.Text = "0.00 JD";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(146, 443);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 42);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save Reservation";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(333, 443);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 42);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(491, 443);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 42);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(780, 549);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTotalBillValue);
            this.Controls.Add(this.lblTotalBill);
            this.Controls.Add(this.txtOtherPurchases);
            this.Controls.Add(this.lblOtherPurchases);
            this.Controls.Add(this.nudBooksQty);
            this.Controls.Add(this.lblBooksQty);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmReservation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Reservation";
            ((System.ComponentModel.ISupportInitialize)(this.nudBooksQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblBooksQty;
        private System.Windows.Forms.NumericUpDown nudBooksQty;
        private System.Windows.Forms.Label lblOtherPurchases;
        private System.Windows.Forms.TextBox txtOtherPurchases;
        private System.Windows.Forms.Label lblTotalBill;
        private System.Windows.Forms.Label lblTotalBillValue;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
    }
}
