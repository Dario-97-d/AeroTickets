namespace AeroTickets.WinForms.UserControls
{
    partial class UC_Airplane
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
            panel1 = new Panel();
            txbManufacturer = new TextBox();
            label4 = new Label();
            btnSubmit = new Button();
            nudSeats = new NumericUpDown();
            txbName = new TextBox();
            txbModel = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSeats).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.White;
            panel1.Controls.Add(txbManufacturer);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btnSubmit);
            panel1.Controls.Add(nudSeats);
            panel1.Controls.Add(txbName);
            panel1.Controls.Add(txbModel);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(140, 98);
            panel1.Name = "panel1";
            panel1.Size = new Size(640, 316);
            panel1.TabIndex = 0;
            // 
            // txbManufacturer
            // 
            txbManufacturer.Location = new Point(264, 13);
            txbManufacturer.Name = "txbManufacturer";
            txbManufacturer.Size = new Size(320, 39);
            txbManufacturer.TabIndex = 1;
            // 
            // label4
            // 
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(256, 64);
            label4.TabIndex = 0;
            label4.Text = "Manufacturer:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.MediumBlue;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(264, 256);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(128, 48);
            btnSubmit.TabIndex = 8;
            btnSubmit.Text = "Create";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // nudSeats
            // 
            nudSeats.Location = new Point(268, 206);
            nudSeats.Margin = new Padding(4);
            nudSeats.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            nudSeats.Name = "nudSeats";
            nudSeats.Size = new Size(78, 39);
            nudSeats.TabIndex = 7;
            nudSeats.TextAlign = HorizontalAlignment.Center;
            nudSeats.KeyPress += nudSeats_KeyPress;
            // 
            // txbName
            // 
            txbName.Location = new Point(264, 141);
            txbName.Name = "txbName";
            txbName.Size = new Size(320, 39);
            txbName.TabIndex = 5;
            // 
            // txbModel
            // 
            txbModel.Location = new Point(264, 77);
            txbModel.Name = "txbModel";
            txbModel.Size = new Size(320, 39);
            txbModel.TabIndex = 3;
            // 
            // label3
            // 
            label3.Location = new Point(0, 192);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(256, 64);
            label3.TabIndex = 6;
            label3.Text = "Seats:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Location = new Point(0, 128);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(256, 64);
            label2.TabIndex = 4;
            label2.Text = "Name:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.Location = new Point(0, 64);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(256, 64);
            label1.TabIndex = 2;
            label1.Text = "Model:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // UC_Airplane
            // 
            AutoScaleDimensions = new SizeF(14F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Font = new Font("Segoe UI Variable Small Semibol", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "UC_Airplane";
            Size = new Size(920, 512);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSeats).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private NumericUpDown nudSeats;
        private TextBox txbName;
        private TextBox txbModel;
        private Label label3;
        private Label label2;
        private Button btnSubmit;
        private TextBox txbManufacturer;
        private Label label4;
    }
}
