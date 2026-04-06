namespace AeroTickets.WinForms.UserControls
{
    partial class UC_Airport
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
            btnSubmit = new Button();
            txbCity = new TextBox();
            txbCountry = new TextBox();
            txbCode = new TextBox();
            txbAirportName = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnSubmit);
            panel1.Controls.Add(txbCity);
            panel1.Controls.Add(txbCountry);
            panel1.Controls.Add(txbCode);
            panel1.Controls.Add(txbAirportName);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(140, 66);
            panel1.Name = "panel1";
            panel1.Size = new Size(640, 320);
            panel1.TabIndex = 0;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.MediumBlue;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(204, 260);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(128, 48);
            btnSubmit.TabIndex = 8;
            btnSubmit.Text = "Create";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // txbCity
            // 
            txbCity.Location = new Point(268, 141);
            txbCity.Margin = new Padding(4);
            txbCity.Name = "txbCity";
            txbCity.Size = new Size(320, 39);
            txbCity.TabIndex = 5;
            txbCity.KeyPress += TextBoxesCityCountry_KeyPress;
            // 
            // txbCountry
            // 
            txbCountry.Location = new Point(268, 205);
            txbCountry.Margin = new Padding(4);
            txbCountry.Name = "txbCountry";
            txbCountry.Size = new Size(320, 39);
            txbCountry.TabIndex = 7;
            txbCountry.KeyPress += TextBoxesCityCountry_KeyPress;
            // 
            // txbCode
            // 
            txbCode.Location = new Point(268, 77);
            txbCode.Margin = new Padding(4);
            txbCode.Name = "txbCode";
            txbCode.Size = new Size(96, 39);
            txbCode.TabIndex = 3;
            txbCode.KeyPress += txbCode_KeyPress;
            // 
            // txbAirportName
            // 
            txbAirportName.Location = new Point(268, 13);
            txbAirportName.Margin = new Padding(4);
            txbAirportName.Name = "txbAirportName";
            txbAirportName.Size = new Size(320, 39);
            txbAirportName.TabIndex = 1;
            txbAirportName.KeyPress += txbAirportName_KeyPress;
            // 
            // label4
            // 
            label4.Location = new Point(4, 128);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(256, 64);
            label4.TabIndex = 4;
            label4.Text = "City:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Location = new Point(4, 192);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(256, 64);
            label3.TabIndex = 6;
            label3.Text = "Country:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.Location = new Point(4, 64);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(256, 64);
            label1.TabIndex = 2;
            label1.Text = "IATA code:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Location = new Point(4, 0);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(256, 64);
            label2.TabIndex = 0;
            label2.Text = "Airport name:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // UC_Airport
            // 
            AutoScaleDimensions = new SizeF(14F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Font = new Font("Segoe UI Variable Small Semibol", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "UC_Airport";
            Size = new Size(920, 448);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label4;
        private Label label3;
        private Label label1;
        private Label label2;
        private TextBox txbAirportName;
        private TextBox txbCity;
        private TextBox txbCountry;
        private TextBox txbCode;
        private Button btnSubmit;
    }
}
