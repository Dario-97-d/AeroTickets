namespace AeroTickets.WinForms.UserControls
{
    partial class UC_Ticket
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            panel1 = new Panel();
            txbCustomerName = new TextBox();
            lblSeatsAvailable = new Label();
            txbTo = new TextBox();
            txbFrom = new TextBox();
            label4 = new Label();
            label5 = new Label();
            lblSeatCheck = new Label();
            nudSeat = new NumericUpDown();
            btnSubmit = new Button();
            cmbCustomer = new ComboBox();
            cmbFlight = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSeat).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(256, 64);
            label1.TabIndex = 0;
            label1.Text = "Flight:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top;
            panel1.Controls.Add(txbCustomerName);
            panel1.Controls.Add(lblSeatsAvailable);
            panel1.Controls.Add(txbTo);
            panel1.Controls.Add(txbFrom);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lblSeatCheck);
            panel1.Controls.Add(nudSeat);
            panel1.Controls.Add(btnSubmit);
            panel1.Controls.Add(cmbCustomer);
            panel1.Controls.Add(cmbFlight);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(40, 48);
            panel1.Name = "panel1";
            panel1.Size = new Size(640, 380);
            panel1.TabIndex = 0;
            // 
            // txbCustomerName
            // 
            txbCustomerName.Location = new Point(262, 270);
            txbCustomerName.Name = "txbCustomerName";
            txbCustomerName.Size = new Size(321, 39);
            txbCustomerName.TabIndex = 12;
            txbCustomerName.KeyPress += txbCustomerName_KeyPress;
            // 
            // lblSeatsAvailable
            // 
            lblSeatsAvailable.AutoSize = true;
            lblSeatsAvailable.Font = new Font("Segoe UI Variable Small Semibol", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblSeatsAvailable.Location = new Point(402, 212);
            lblSeatsAvailable.Name = "lblSeatsAvailable";
            lblSeatsAvailable.Size = new Size(138, 27);
            lblSeatsAvailable.TabIndex = 9;
            lblSeatsAvailable.Text = "000 available.";
            // 
            // txbTo
            // 
            txbTo.Enabled = false;
            txbTo.Location = new Point(263, 141);
            txbTo.Name = "txbTo";
            txbTo.Size = new Size(320, 39);
            txbTo.TabIndex = 5;
            // 
            // txbFrom
            // 
            txbFrom.Enabled = false;
            txbFrom.Location = new Point(262, 77);
            txbFrom.Name = "txbFrom";
            txbFrom.Size = new Size(320, 39);
            txbFrom.TabIndex = 3;
            // 
            // label4
            // 
            label4.Location = new Point(0, 64);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(256, 64);
            label4.TabIndex = 2;
            label4.Text = "From:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Location = new Point(0, 128);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(256, 64);
            label5.TabIndex = 4;
            label5.Text = "To:";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSeatCheck
            // 
            lblSeatCheck.BorderStyle = BorderStyle.FixedSingle;
            lblSeatCheck.ForeColor = Color.Silver;
            lblSeatCheck.Location = new Point(358, 205);
            lblSeatCheck.Name = "lblSeatCheck";
            lblSeatCheck.Size = new Size(38, 40);
            lblSeatCheck.TabIndex = 8;
            lblSeatCheck.Text = "O";
            lblSeatCheck.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // nudSeat
            // 
            nudSeat.Location = new Point(268, 206);
            nudSeat.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            nudSeat.Name = "nudSeat";
            nudSeat.Size = new Size(78, 39);
            nudSeat.TabIndex = 7;
            nudSeat.TextAlign = HorizontalAlignment.Center;
            nudSeat.ValueChanged += nudSeat_ValueChanged;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.MediumBlue;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(268, 320);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(128, 48);
            btnSubmit.TabIndex = 13;
            btnSubmit.Text = "Create";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // cmbCustomer
            // 
            cmbCustomer.FormattingEnabled = true;
            cmbCustomer.Location = new Point(262, 269);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(320, 40);
            cmbCustomer.TabIndex = 11;
            // 
            // cmbFlight
            // 
            cmbFlight.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFlight.FormattingEnabled = true;
            cmbFlight.Location = new Point(262, 13);
            cmbFlight.Name = "cmbFlight";
            cmbFlight.Size = new Size(320, 40);
            cmbFlight.TabIndex = 1;
            cmbFlight.SelectedIndexChanged += cmbFlight_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.Location = new Point(0, 256);
            label3.Name = "label3";
            label3.Size = new Size(256, 64);
            label3.TabIndex = 10;
            label3.Text = "Customer Name:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Location = new Point(0, 192);
            label2.Name = "label2";
            label2.Size = new Size(256, 64);
            label2.TabIndex = 6;
            label2.Text = "Seat:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // UC_Ticket
            // 
            AutoScaleDimensions = new SizeF(14F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel1);
            Font = new Font("Segoe UI Variable Small Semibol", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "UC_Ticket";
            Size = new Size(720, 476);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSeat).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label2;
        private ComboBox cmbCustomer;
        private ComboBox cmbFlight;
        private Label label3;
        private Button btnSubmit;
        private NumericUpDown nudSeat;
        private Label lblSeatCheck;
        private Label label4;
        private Label label5;
        private TextBox txbTo;
        private TextBox txbFrom;
        private Label lblSeatsAvailable;
        private TextBox txbCustomerName;
    }
}
