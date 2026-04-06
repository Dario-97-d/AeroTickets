namespace AeroTickets.WinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnClose = new Button();
            pnlFooter = new Panel();
            lblAbout = new Label();
            lblTime = new Label();
            btnMinimize = new Button();
            lblDate = new Label();
            pnlSideMenu = new Panel();
            pnlSideButtons = new Panel();
            btnAirplanes = new Button();
            btnAirports = new Button();
            btnCustomers = new Button();
            btnTickets = new Button();
            btnFlights = new Button();
            lblAeroTickets = new Label();
            lblCredits = new Label();
            timerAboutCredits = new System.Windows.Forms.Timer(components);
            timerClock = new System.Windows.Forms.Timer(components);
            btnNew = new Button();
            pnlContent = new Panel();
            pnlListView = new Panel();
            btnDelete = new Button();
            lsvContent = new ListView();
            btnEdit = new Button();
            lblContent = new Label();
            btnSearch = new Button();
            pnlFooter.SuspendLayout();
            pnlSideMenu.SuspendLayout();
            pnlSideButtons.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlListView.SuspendLayout();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.FlatAppearance.BorderSize = 2;
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point);
            btnClose.Location = new Point(1324, 11);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(64, 64);
            btnClose.TabIndex = 1;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pnlFooter
            // 
            pnlFooter.AccessibleRole = AccessibleRole.StatusBar;
            pnlFooter.BackColor = Color.Gray;
            pnlFooter.Controls.Add(lblAbout);
            pnlFooter.Controls.Add(lblTime);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.ForeColor = Color.White;
            pnlFooter.Location = new Point(0, 704);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(1400, 64);
            pnlFooter.TabIndex = 3;
            pnlFooter.MouseDoubleClick += pnlFooter_MouseDoubleClick;
            // 
            // lblAbout
            // 
            lblAbout.Dock = DockStyle.Left;
            lblAbout.Location = new Point(0, 0);
            lblAbout.MinimumSize = new Size(0, 64);
            lblAbout.Name = "lblAbout";
            lblAbout.Size = new Size(256, 64);
            lblAbout.TabIndex = 1;
            lblAbout.Text = "About";
            lblAbout.TextAlign = ContentAlignment.MiddleCenter;
            lblAbout.Click += lblAbout_Click;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Dock = DockStyle.Right;
            lblTime.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTime.Location = new Point(1232, 0);
            lblTime.MinimumSize = new Size(0, 64);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(168, 64);
            lblTime.TabIndex = 0;
            lblTime.Text = "00h 00m 00s  ";
            lblTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimize.FlatAppearance.BorderSize = 2;
            btnMinimize.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 192, 255);
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point);
            btnMinimize.Location = new Point(1254, 11);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(64, 64);
            btnMinimize.TabIndex = 0;
            btnMinimize.Text = "_";
            btnMinimize.UseVisualStyleBackColor = true;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDate.Location = new Point(1172, 673);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(221, 28);
            lblDate.TabIndex = 2;
            lblDate.Text = "Wed, 12-Apr-2022";
            lblDate.Click += lblDate_Click;
            // 
            // pnlSideMenu
            // 
            pnlSideMenu.BackColor = Color.MediumBlue;
            pnlSideMenu.Controls.Add(pnlSideButtons);
            pnlSideMenu.Controls.Add(lblAeroTickets);
            pnlSideMenu.Controls.Add(lblCredits);
            pnlSideMenu.Dock = DockStyle.Left;
            pnlSideMenu.ForeColor = Color.White;
            pnlSideMenu.Location = new Point(0, 0);
            pnlSideMenu.Name = "pnlSideMenu";
            pnlSideMenu.Size = new Size(256, 704);
            pnlSideMenu.TabIndex = 4;
            // 
            // pnlSideButtons
            // 
            pnlSideButtons.AutoScroll = true;
            pnlSideButtons.Controls.Add(btnAirplanes);
            pnlSideButtons.Controls.Add(btnAirports);
            pnlSideButtons.Controls.Add(btnCustomers);
            pnlSideButtons.Controls.Add(btnTickets);
            pnlSideButtons.Controls.Add(btnFlights);
            pnlSideButtons.Location = new Point(0, 192);
            pnlSideButtons.Name = "pnlSideButtons";
            pnlSideButtons.Size = new Size(256, 320);
            pnlSideButtons.TabIndex = 2;
            // 
            // btnAirplanes
            // 
            btnAirplanes.FlatAppearance.BorderSize = 0;
            btnAirplanes.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 192);
            btnAirplanes.FlatAppearance.MouseOverBackColor = Color.Blue;
            btnAirplanes.FlatStyle = FlatStyle.Flat;
            btnAirplanes.Location = new Point(0, 192);
            btnAirplanes.Name = "btnAirplanes";
            btnAirplanes.Size = new Size(256, 64);
            btnAirplanes.TabIndex = 3;
            btnAirplanes.Text = "Airplanes";
            btnAirplanes.UseVisualStyleBackColor = true;
            btnAirplanes.Click += SideButtons_Click;
            // 
            // btnAirports
            // 
            btnAirports.FlatAppearance.BorderSize = 0;
            btnAirports.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 192);
            btnAirports.FlatAppearance.MouseOverBackColor = Color.Blue;
            btnAirports.FlatStyle = FlatStyle.Flat;
            btnAirports.Location = new Point(0, 128);
            btnAirports.Name = "btnAirports";
            btnAirports.Size = new Size(256, 64);
            btnAirports.TabIndex = 2;
            btnAirports.Text = "Airports";
            btnAirports.UseVisualStyleBackColor = true;
            btnAirports.Click += SideButtons_Click;
            // 
            // btnCustomers
            // 
            btnCustomers.FlatAppearance.BorderSize = 0;
            btnCustomers.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 192);
            btnCustomers.FlatAppearance.MouseOverBackColor = Color.Blue;
            btnCustomers.FlatStyle = FlatStyle.Flat;
            btnCustomers.Location = new Point(0, 256);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(256, 64);
            btnCustomers.TabIndex = 4;
            btnCustomers.Text = "Customers";
            btnCustomers.UseVisualStyleBackColor = true;
            btnCustomers.Click += SideButtons_Click;
            // 
            // btnTickets
            // 
            btnTickets.FlatAppearance.BorderSize = 0;
            btnTickets.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 0, 192);
            btnTickets.FlatAppearance.MouseOverBackColor = Color.Blue;
            btnTickets.FlatStyle = FlatStyle.Flat;
            btnTickets.Location = new Point(0, 64);
            btnTickets.Name = "btnTickets";
            btnTickets.Size = new Size(256, 64);
            btnTickets.TabIndex = 1;
            btnTickets.Text = "Tickets";
            btnTickets.UseVisualStyleBackColor = true;
            btnTickets.Click += SideButtons_Click;
            // 
            // btnFlights
            // 
            btnFlights.FlatAppearance.BorderSize = 0;
            btnFlights.FlatAppearance.MouseDownBackColor = Color.DarkBlue;
            btnFlights.FlatAppearance.MouseOverBackColor = Color.Blue;
            btnFlights.FlatStyle = FlatStyle.Flat;
            btnFlights.Location = new Point(0, 0);
            btnFlights.Name = "btnFlights";
            btnFlights.Size = new Size(256, 64);
            btnFlights.TabIndex = 0;
            btnFlights.Text = "Flights";
            btnFlights.UseVisualStyleBackColor = true;
            btnFlights.Click += SideButtons_Click;
            // 
            // lblAeroTickets
            // 
            lblAeroTickets.AutoSize = true;
            lblAeroTickets.Font = new Font("Segoe UI Variable Small Semibol", 24F, FontStyle.Regular, GraphicsUnit.Point);
            lblAeroTickets.Location = new Point(0, 32);
            lblAeroTickets.MinimumSize = new Size(256, 0);
            lblAeroTickets.Name = "lblAeroTickets";
            lblAeroTickets.Size = new Size(256, 128);
            lblAeroTickets.TabIndex = 0;
            lblAeroTickets.Text = "Aero\r\nTickets";
            lblAeroTickets.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCredits
            // 
            lblCredits.BackColor = Color.DarkGray;
            lblCredits.Location = new Point(0, 564);
            lblCredits.MinimumSize = new Size(256, 0);
            lblCredits.Name = "lblCredits";
            lblCredits.Size = new Size(256, 140);
            lblCredits.TabIndex = 1;
            lblCredits.Text = "  AeroTickets\r\n  v1.0.0\r\n  04/2023\r\n  by Dário Dias";
            lblCredits.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // timerAboutCredits
            // 
            timerAboutCredits.Tick += timerAboutCredits_Tick;
            // 
            // timerClock
            // 
            timerClock.Interval = 1000;
            timerClock.Tick += timerClock_Tick;
            // 
            // btnNew
            // 
            btnNew.BackColor = Color.MediumBlue;
            btnNew.FlatAppearance.MouseDownBackColor = Color.DarkBlue;
            btnNew.FlatAppearance.MouseOverBackColor = Color.Blue;
            btnNew.FlatStyle = FlatStyle.Flat;
            btnNew.ForeColor = Color.White;
            btnNew.Location = new Point(320, 74);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(192, 64);
            btnNew.TabIndex = 5;
            btnNew.Text = "New Flight";
            btnNew.UseVisualStyleBackColor = false;
            btnNew.Click += ButtonsToUC_Click;
            // 
            // pnlContent
            // 
            pnlContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlContent.AutoScroll = true;
            pnlContent.Controls.Add(pnlListView);
            pnlContent.Location = new Point(320, 256);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(920, 384);
            pnlContent.TabIndex = 8;
            // 
            // pnlListView
            // 
            pnlListView.Controls.Add(btnDelete);
            pnlListView.Controls.Add(lsvContent);
            pnlListView.Controls.Add(btnEdit);
            pnlListView.Dock = DockStyle.Fill;
            pnlListView.Location = new Point(0, 0);
            pnlListView.Name = "pnlListView";
            pnlListView.Size = new Size(920, 384);
            pnlListView.TabIndex = 0;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.FlatAppearance.BorderSize = 4;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(776, 118);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(128, 48);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += EditAndDeleteButtons_Click;
            // 
            // lsvContent
            // 
            lsvContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lsvContent.BackColor = Color.LightBlue;
            lsvContent.Font = new Font("Lucida Console", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lsvContent.ForeColor = Color.MediumBlue;
            lsvContent.FullRowSelect = true;
            lsvContent.GridLines = true;
            lsvContent.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lsvContent.Location = new Point(0, 0);
            lsvContent.MultiSelect = false;
            lsvContent.Name = "lsvContent";
            lsvContent.Size = new Size(760, 384);
            lsvContent.TabIndex = 0;
            lsvContent.UseCompatibleStateImageBehavior = false;
            lsvContent.View = View.Details;
            lsvContent.SelectedIndexChanged += lsvContent_SelectedIndexChanged;
            lsvContent.DoubleClick += lsvContent_DoubleClick;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.FlatAppearance.BorderSize = 4;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Location = new Point(776, 64);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(128, 48);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += EditAndDeleteButtons_Click;
            // 
            // lblContent
            // 
            lblContent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblContent.Font = new Font("Segoe UI Variable Small Semibol", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblContent.Location = new Point(320, 188);
            lblContent.MinimumSize = new Size(0, 64);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(920, 64);
            lblContent.TabIndex = 7;
            lblContent.Text = "Flights";
            lblContent.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.MediumBlue;
            btnSearch.FlatAppearance.MouseDownBackColor = Color.DarkBlue;
            btnSearch.FlatAppearance.MouseOverBackColor = Color.Blue;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(544, 74);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(192, 64);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += ButtonsToUC_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            ClientSize = new Size(1400, 768);
            ControlBox = false;
            Controls.Add(btnSearch);
            Controls.Add(lblContent);
            Controls.Add(btnNew);
            Controls.Add(pnlContent);
            Controls.Add(pnlSideMenu);
            Controls.Add(lblDate);
            Controls.Add(btnMinimize);
            Controls.Add(pnlFooter);
            Controls.Add(btnClose);
            Font = new Font("Segoe UI Variable Small Semibol", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.MediumBlue;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(720, 768);
            Name = "Form1";
            StartPosition = FormStartPosition.Manual;
            Text = "AeroTickets";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            Resize += Form1_Resize;
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            pnlSideMenu.ResumeLayout(false);
            pnlSideMenu.PerformLayout();
            pnlSideButtons.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlListView.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClose;
        private Panel pnlFooter;
        private Label lblTime;
        private Button btnMinimize;
        private Label lblDate;
        private Label lblAbout;
        private Panel pnlSideMenu;
        private Label lblCredits;
        private System.Windows.Forms.Timer timerAboutCredits;
        private System.Windows.Forms.Timer timerClock;
        private Label lblAeroTickets;
        private Panel pnlSideButtons;
        private Button btnFlights;
        private Button btnAirplanes;
        private Button btnAirports;
        private Button btnCustomers;
        private Button btnTickets;
        private Button btnNew;
        private Panel pnlContent;
        private ListView lsvContent;
        private Label lblContent;
        private Panel pnlListView;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnSearch;
    }
}