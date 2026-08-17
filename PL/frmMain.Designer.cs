namespace PL
{
    partial class frmMain
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
            this.btnAddReservation = new System.Windows.Forms.Button();
            this.btnCheckStatus = new System.Windows.Forms.Button();
            this.btnEndOfDay = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(150, 50);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(455, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Library Book Wrapping System";
            // 
            // btnAddReservation
            // 
            this.btnAddReservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAddReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddReservation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddReservation.ForeColor = System.Drawing.Color.White;
            this.btnAddReservation.Location = new System.Drawing.Point(200, 119);
            this.btnAddReservation.Name = "btnAddReservation";
            this.btnAddReservation.Size = new System.Drawing.Size(300, 91);
            this.btnAddReservation.TabIndex = 1;
            this.btnAddReservation.Text = "Add Reservation";
            this.btnAddReservation.UseVisualStyleBackColor = false;
            this.btnAddReservation.Click += new System.EventHandler(this.btnAddReservation_Click);
            // 
            // btnCheckStatus
            // 
            this.btnCheckStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.btnCheckStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckStatus.ForeColor = System.Drawing.Color.White;
            this.btnCheckStatus.Location = new System.Drawing.Point(200, 235);
            this.btnCheckStatus.Name = "btnCheckStatus";
            this.btnCheckStatus.Size = new System.Drawing.Size(300, 89);
            this.btnCheckStatus.TabIndex = 2;
            this.btnCheckStatus.Text = "Check Status";
            this.btnCheckStatus.UseVisualStyleBackColor = false;
            this.btnCheckStatus.Click += new System.EventHandler(this.btnCheckStatus_Click);
            // 
            // btnEndOfDay
            // 
            this.btnEndOfDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnEndOfDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEndOfDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEndOfDay.ForeColor = System.Drawing.Color.White;
            this.btnEndOfDay.Location = new System.Drawing.Point(200, 340);
            this.btnEndOfDay.Name = "btnEndOfDay";
            this.btnEndOfDay.Size = new System.Drawing.Size(300, 65);
            this.btnEndOfDay.TabIndex = 3;
            this.btnEndOfDay.Text = "End of Day Report";
            this.btnEndOfDay.UseVisualStyleBackColor = false;
            this.btnEndOfDay.Click += new System.EventHandler(this.btnEndOfDay_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(200, 420);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(300, 50);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnEndOfDay);
            this.Controls.Add(this.btnCheckStatus);
            this.Controls.Add(this.btnAddReservation);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library Book Wrapping System";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAddReservation;
        private System.Windows.Forms.Button btnCheckStatus;
        private System.Windows.Forms.Button btnEndOfDay;
        private System.Windows.Forms.Button btnExit;
    }
}
