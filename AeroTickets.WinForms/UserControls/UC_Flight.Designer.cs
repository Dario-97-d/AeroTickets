namespace AeroTickets.WinForms.UserControls
{
    partial class UC_Flight
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
            cmbAirplane = new ComboBox();
            cmbAirportDest = new ComboBox();
            cmbAirportOrigin = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            chbCustomFlightNumber = new CheckBox();
            txbFlightNumber = new TextBox();
            label2 = new Label();
            btnSubmit = new Button();
            panel1 = new Panel();
            chbSearchOrigin = new CheckBox();
            chbSearchDest = new CheckBox();
            chbSearchNumber = new CheckBox();
            chbSearchSeats = new CheckBox();
            chbSearchAirplane = new CheckBox();
            chbSearchHour = new CheckBox();
            chbSearchDate = new CheckBox();
            dtpFlightHour = new DateTimePicker();
            dtpFlightDate = new DateTimePicker();
            nudSeats = new NumericUpDown();
            label7 = new Label();
            chbCustomSeats = new CheckBox();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSeats).BeginInit();
            SuspendLayout();
            // 
            // cmbAirplane
            // 
            cmbAirplane.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAirplane.Location = new Point(268, 333);
            cmbAirplane.Margin = new Padding(4);
            cmbAirplane.Name = "cmbAirplane";
            cmbAirplane.Size = new Size(320, 40);
            cmbAirplane.TabIndex = 17;
            cmbAirplane.SelectedIndexChanged += cmbAirplane_SelectedIndexChanged;
            // 
            // cmbAirportDest
            // 
            cmbAirportDest.FormattingEnabled = true;
            cmbAirportDest.Location = new Point(268, 269);
            cmbAirportDest.Margin = new Padding(4);
            cmbAirportDest.Name = "cmbAirportDest";
            cmbAirportDest.Size = new Size(320, 40);
            cmbAirportDest.TabIndex = 14;
            cmbAirportDest.Text = "Airport";
            cmbAirportDest.SelectedIndexChanged += ComboBoxesAirport_SelectedIndexChanged;
            cmbAirportDest.Leave += ComboBoxesAirport_Leave;
            // 
            // cmbAirportOrigin
            // 
            cmbAirportOrigin.FormattingEnabled = true;
            cmbAirportOrigin.Location = new Point(268, 205);
            cmbAirportOrigin.Margin = new Padding(4);
            cmbAirportOrigin.Name = "cmbAirportOrigin";
            cmbAirportOrigin.Size = new Size(320, 40);
            cmbAirportOrigin.TabIndex = 11;
            cmbAirportOrigin.Text = "Airport";
            cmbAirportOrigin.SelectedIndexChanged += ComboBoxesAirport_SelectedIndexChanged;
            cmbAirportOrigin.Leave += ComboBoxesAirport_Leave;
            // 
            // label6
            // 
            label6.Location = new Point(4, 320);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(256, 64);
            label6.TabIndex = 16;
            label6.Text = "Plane:";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Location = new Point(4, 256);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(256, 64);
            label5.TabIndex = 13;
            label5.Text = "To:";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Location = new Point(4, 192);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(256, 64);
            label4.TabIndex = 10;
            label4.Text = "From:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Location = new Point(4, 64);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(256, 64);
            label3.TabIndex = 4;
            label3.Text = "Flight date:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // chbCustomFlightNumber
            // 
            chbCustomFlightNumber.AutoSize = true;
            chbCustomFlightNumber.ForeColor = Color.Black;
            chbCustomFlightNumber.Location = new Point(366, 15);
            chbCustomFlightNumber.Margin = new Padding(4);
            chbCustomFlightNumber.Name = "chbCustomFlightNumber";
            chbCustomFlightNumber.Size = new Size(126, 36);
            chbCustomFlightNumber.TabIndex = 2;
            chbCustomFlightNumber.Text = "Custom";
            chbCustomFlightNumber.UseVisualStyleBackColor = true;
            chbCustomFlightNumber.CheckedChanged += chbCustomFlightNumber_CheckedChanged;
            // 
            // txbFlightNumber
            // 
            txbFlightNumber.Enabled = false;
            txbFlightNumber.Location = new Point(272, 13);
            txbFlightNumber.Margin = new Padding(4);
            txbFlightNumber.MaxLength = 4;
            txbFlightNumber.Name = "txbFlightNumber";
            txbFlightNumber.Size = new Size(78, 39);
            txbFlightNumber.TabIndex = 1;
            txbFlightNumber.Text = "Auto";
            txbFlightNumber.TextAlign = HorizontalAlignment.Center;
            txbFlightNumber.KeyPress += NumericPos_KeyPress;
            // 
            // label2
            // 
            label2.Location = new Point(4, 0);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(256, 64);
            label2.TabIndex = 0;
            label2.Text = "Flight number:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.MediumBlue;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(268, 448);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(128, 48);
            btnSubmit.TabIndex = 23;
            btnSubmit.Text = "Create";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(chbSearchOrigin);
            panel1.Controls.Add(chbSearchDest);
            panel1.Controls.Add(chbSearchNumber);
            panel1.Controls.Add(chbSearchSeats);
            panel1.Controls.Add(chbSearchAirplane);
            panel1.Controls.Add(chbSearchHour);
            panel1.Controls.Add(chbSearchDate);
            panel1.Controls.Add(dtpFlightHour);
            panel1.Controls.Add(dtpFlightDate);
            panel1.Controls.Add(nudSeats);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(chbCustomSeats);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnSubmit);
            panel1.Controls.Add(txbFlightNumber);
            panel1.Controls.Add(cmbAirplane);
            panel1.Controls.Add(chbCustomFlightNumber);
            panel1.Controls.Add(cmbAirportDest);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(cmbAirportOrigin);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label6);
            panel1.Location = new Point(140, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(640, 508);
            panel1.TabIndex = 0;
            // 
            // chbSearchOrigin
            // 
            chbSearchOrigin.AutoSize = true;
            chbSearchOrigin.Location = new Point(602, 215);
            chbSearchOrigin.Name = "chbSearchOrigin";
            chbSearchOrigin.Size = new Size(22, 21);
            chbSearchOrigin.TabIndex = 12;
            chbSearchOrigin.UseVisualStyleBackColor = true;
            chbSearchOrigin.CheckedChanged += CheckBoxesSearchRelatedToComboBoxes_CheckedChanged;
            // 
            // chbSearchDest
            // 
            chbSearchDest.AutoSize = true;
            chbSearchDest.Location = new Point(602, 279);
            chbSearchDest.Name = "chbSearchDest";
            chbSearchDest.Size = new Size(22, 21);
            chbSearchDest.TabIndex = 15;
            chbSearchDest.UseVisualStyleBackColor = true;
            chbSearchDest.CheckedChanged += CheckBoxesSearchRelatedToComboBoxes_CheckedChanged;
            // 
            // chbSearchNumber
            // 
            chbSearchNumber.AutoSize = true;
            chbSearchNumber.Location = new Point(602, 23);
            chbSearchNumber.Name = "chbSearchNumber";
            chbSearchNumber.Size = new Size(22, 21);
            chbSearchNumber.TabIndex = 3;
            chbSearchNumber.UseVisualStyleBackColor = true;
            chbSearchNumber.CheckedChanged += CheckBoxesSearchUnrelatedToComboBoxes_CheckedChanged;
            // 
            // chbSearchSeats
            // 
            chbSearchSeats.AutoSize = true;
            chbSearchSeats.Location = new Point(602, 407);
            chbSearchSeats.Name = "chbSearchSeats";
            chbSearchSeats.Size = new Size(22, 21);
            chbSearchSeats.TabIndex = 22;
            chbSearchSeats.UseVisualStyleBackColor = true;
            chbSearchSeats.CheckedChanged += CheckBoxesSearchUnrelatedToComboBoxes_CheckedChanged;
            // 
            // chbSearchAirplane
            // 
            chbSearchAirplane.AutoSize = true;
            chbSearchAirplane.Location = new Point(602, 343);
            chbSearchAirplane.Name = "chbSearchAirplane";
            chbSearchAirplane.Size = new Size(22, 21);
            chbSearchAirplane.TabIndex = 18;
            chbSearchAirplane.UseVisualStyleBackColor = true;
            chbSearchAirplane.CheckedChanged += CheckBoxesSearchRelatedToComboBoxes_CheckedChanged;
            // 
            // chbSearchHour
            // 
            chbSearchHour.AutoSize = true;
            chbSearchHour.Location = new Point(602, 151);
            chbSearchHour.Name = "chbSearchHour";
            chbSearchHour.Size = new Size(22, 21);
            chbSearchHour.TabIndex = 9;
            chbSearchHour.UseVisualStyleBackColor = true;
            chbSearchHour.CheckedChanged += CheckBoxesSearchUnrelatedToComboBoxes_CheckedChanged;
            // 
            // chbSearchDate
            // 
            chbSearchDate.AutoSize = true;
            chbSearchDate.Location = new Point(602, 87);
            chbSearchDate.Name = "chbSearchDate";
            chbSearchDate.Size = new Size(22, 21);
            chbSearchDate.TabIndex = 6;
            chbSearchDate.UseVisualStyleBackColor = true;
            chbSearchDate.CheckedChanged += CheckBoxesSearchUnrelatedToComboBoxes_CheckedChanged;
            // 
            // dtpFlightHour
            // 
            dtpFlightHour.CustomFormat = " HH : mm";
            dtpFlightHour.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpFlightHour.Format = DateTimePickerFormat.Custom;
            dtpFlightHour.Location = new Point(268, 142);
            dtpFlightHour.Name = "dtpFlightHour";
            dtpFlightHour.ShowUpDown = true;
            dtpFlightHour.Size = new Size(128, 35);
            dtpFlightHour.TabIndex = 8;
            // 
            // dtpFlightDate
            // 
            dtpFlightDate.CustomFormat = " dd-MM-yyyy";
            dtpFlightDate.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpFlightDate.Format = DateTimePickerFormat.Custom;
            dtpFlightDate.Location = new Point(268, 78);
            dtpFlightDate.MaxDate = new DateTime(2049, 12, 31, 0, 0, 0, 0);
            dtpFlightDate.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dtpFlightDate.Name = "dtpFlightDate";
            dtpFlightDate.Size = new Size(192, 35);
            dtpFlightDate.TabIndex = 5;
            // 
            // nudSeats
            // 
            nudSeats.Enabled = false;
            nudSeats.Location = new Point(272, 398);
            nudSeats.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            nudSeats.Name = "nudSeats";
            nudSeats.Size = new Size(78, 39);
            nudSeats.TabIndex = 20;
            nudSeats.TextAlign = HorizontalAlignment.Center;
            nudSeats.KeyPress += nudSeats_KeyPress;
            // 
            // label7
            // 
            label7.Location = new Point(4, 384);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(256, 64);
            label7.TabIndex = 19;
            label7.Text = "Seats:";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // chbCustomSeats
            // 
            chbCustomSeats.AutoSize = true;
            chbCustomSeats.ForeColor = Color.Black;
            chbCustomSeats.Location = new Point(366, 399);
            chbCustomSeats.Margin = new Padding(4);
            chbCustomSeats.Name = "chbCustomSeats";
            chbCustomSeats.Size = new Size(126, 36);
            chbCustomSeats.TabIndex = 21;
            chbCustomSeats.Text = "Custom";
            chbCustomSeats.UseVisualStyleBackColor = true;
            chbCustomSeats.CheckedChanged += chbCustomSeats_CheckedChanged;
            // 
            // label1
            // 
            label1.Location = new Point(4, 128);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(256, 64);
            label1.TabIndex = 7;
            label1.Text = "Flight at:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // UC_Flight
            // 
            AutoScaleDimensions = new SizeF(14F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel1);
            Font = new Font("Segoe UI Variable Small Semibol", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "UC_Flight";
            Size = new Size(920, 540);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSeats).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbAirplane;
        private ComboBox cmbAirportDest;
        private ComboBox cmbAirportOrigin;
        private ComboBox cmbDateMonth;
        private ComboBox cmbDateYear;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private CheckBox chbCustomFlightNumber;
        private TextBox txbFlightNumber;
        private Label label2;
        private Button btnSubmit;
        private Panel panel1;
        private Label label1;
        private ComboBox cmbMinute;
        private ComboBox cmbHour;
        public ComboBox cmbDateDay;
        private Label label7;
        private CheckBox chbCustomSeats;
        private NumericUpDown nudSeats;
        private DateTimePicker dtpFlightDate;
        private DateTimePicker dtpFlightHour;
        private CheckBox chbSearchAirplane;
        private CheckBox chbSearchHour;
        private CheckBox chbSearchDate;
        private CheckBox chbSearchSeats;
        private CheckBox checkBox1;
        private CheckBox chbSearchNumber;
        private CheckBox chbSearchOrigin;
        private CheckBox chbSearchDest;
    }
}
