namespace AeroTickets.WinForms.UserControls
{
    partial class keepUC_Planes
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
            pnlNew = new Panel();
            nudSeats = new NumericUpDown();
            lblSeats = new Label();
            txbModel = new TextBox();
            lblModel = new Label();
            lblName = new Label();
            lblNewPlane = new Label();
            txbName = new TextBox();
            btnNew = new Button();
            lsvPlanes = new ListView();
            pnlNew.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSeats).BeginInit();
            SuspendLayout();
            // 
            // pnlNew
            // 
            pnlNew.BackColor = SystemColors.Control;
            pnlNew.BorderStyle = BorderStyle.FixedSingle;
            pnlNew.Controls.Add(nudSeats);
            pnlNew.Controls.Add(lblSeats);
            pnlNew.Controls.Add(txbModel);
            pnlNew.Controls.Add(lblModel);
            pnlNew.Controls.Add(lblName);
            pnlNew.Controls.Add(lblNewPlane);
            pnlNew.Controls.Add(txbName);
            pnlNew.Controls.Add(btnNew);
            pnlNew.Dock = DockStyle.Top;
            pnlNew.Location = new Point(0, 0);
            pnlNew.Margin = new Padding(4);
            pnlNew.Name = "pnlNew";
            pnlNew.Size = new Size(1248, 64);
            pnlNew.TabIndex = 0;
            // 
            // nudSeats
            // 
            nudSeats.Location = new Point(605, 14);
            nudSeats.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            nudSeats.Name = "nudSeats";
            nudSeats.Size = new Size(78, 39);
            nudSeats.TabIndex = 8;
            nudSeats.TextAlign = HorizontalAlignment.Center;
            nudSeats.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // lblSeats
            // 
            lblSeats.AutoSize = true;
            lblSeats.Location = new Point(520, 16);
            lblSeats.Name = "lblSeats";
            lblSeats.Size = new Size(79, 32);
            lblSeats.TabIndex = 7;
            lblSeats.Text = "Seats:";
            // 
            // txbModel
            // 
            txbModel.Location = new Point(362, 12);
            txbModel.Name = "txbModel";
            txbModel.Size = new Size(128, 39);
            txbModel.TabIndex = 6;
            // 
            // lblModel
            // 
            lblModel.AutoSize = true;
            lblModel.Location = new Point(264, 16);
            lblModel.Name = "lblModel";
            lblModel.Size = new Size(92, 32);
            lblModel.TabIndex = 5;
            lblModel.Text = "Model:";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(776, 16);
            lblName.Name = "lblName";
            lblName.Size = new Size(87, 32);
            lblName.TabIndex = 4;
            lblName.Text = "Name:";
            // 
            // lblNewPlane
            // 
            lblNewPlane.AutoSize = true;
            lblNewPlane.Dock = DockStyle.Left;
            lblNewPlane.ForeColor = Color.MediumBlue;
            lblNewPlane.Location = new Point(0, 0);
            lblNewPlane.MinimumSize = new Size(256, 64);
            lblNewPlane.Name = "lblNewPlane";
            lblNewPlane.Size = new Size(256, 64);
            lblNewPlane.TabIndex = 3;
            lblNewPlane.Text = "New plane";
            lblNewPlane.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txbName
            // 
            txbName.Location = new Point(869, 12);
            txbName.Name = "txbName";
            txbName.Size = new Size(150, 39);
            txbName.TabIndex = 2;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.MediumBlue;
            btnNew.FlatAppearance.BorderSize = 0;
            btnNew.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 192, 255);
            btnNew.FlatAppearance.MouseOverBackColor = Color.Blue;
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(1096, 10);
            btnNew.Margin = new Padding(4);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(88, 44);
            btnNew.TabIndex = 0;
            btnNew.Text = "Add";
            btnNew.UseVisualStyleBackColor = false;
            btnNew.Click += btnNew_Click;
            // 
            // lsvPlanes
            // 
            lsvPlanes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lsvPlanes.Location = new Point(64, 96);
            lsvPlanes.Name = "lsvPlanes";
            lsvPlanes.Size = new Size(1120, 252);
            lsvPlanes.TabIndex = 1;
            lsvPlanes.UseCompatibleStateImageBehavior = false;
            // 
            // UC_NewAirplane
            // 
            AutoScaleDimensions = new SizeF(14F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lsvPlanes);
            Controls.Add(pnlNew);
            Font = new Font("Segoe UI Variable Small Semibol", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.Black;
            Margin = new Padding(4);
            Name = "UC_NewAircraft";
            Size = new Size(1248, 380);
            pnlNew.ResumeLayout(false);
            pnlNew.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSeats).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlNew;
        private Button btnNew;
        private TextBox txbName;
        private NumericUpDown nudSeats;
        private Label lblSeats;
        private TextBox txbModel;
        private Label lblModel;
        private Label lblName;
        private Label lblNewPlane;
        private ListView lsvPlanes;
    }
}
