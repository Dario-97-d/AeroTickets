using AeroTickets.ClassLibrary;
using AeroTickets.ClassLibrary.Models;
using AeroTickets.WinForms.UserControls;
using System.Globalization;

namespace AeroTickets.WinForms;

public partial class Form1 : Form
{
    const int ANIM_TIME = 600;
    const int ANIM_STEPS = 20;
    const int ANIM_INTERVAL = ANIM_TIME / ANIM_STEPS;

    bool _lblCreditsIsCollapsed = true;
    bool _lblCreditsIsSliding = false;

    bool _searching = false;
    AT_Model _itemToSearch = null!;

    // Current item's class at stake (class) (Airplane, Airport, Customer, Flight, Ticket)
    string _itemClass = AT_Consts.Flight;

    readonly Color _enabledBackColor = Color.White;
    readonly Color _enabledMOverBackColor = Color.FromArgb(192, 192, 255);
    readonly Color _disabledBackColor = Color.FromArgb(224, 224, 224);


    public List<Airplane> Airplanes { get; set; }
    public List<Airport> Airports { get; set; }
    public List<Flight> Flights { get; set; }
    public List<Ticket> Tickets { get; set; }
    //public List<Customer> Customers { get; set; }

    readonly UC_Airplane _ucAirplane;
    readonly UC_Airport _ucAirport;
    //readonly UC_Customer _ucCustomer;
    readonly UC_Flight _ucFlight;
    readonly UC_Ticket _ucTicket;


    public Form1()
    {
        InitializeComponent();
        timerAboutCredits.Interval = ANIM_INTERVAL;

        pnlContent.Visible = false;
        pnlListView.Visible = false;
        btnCustomers.Visible = false;

        // Required before UserControls
        Airplanes = XFiles.LoadItems(AT_Consts.Airplane).Cast<Airplane>().ToList();
        Airports = XFiles.LoadItems(AT_Consts.Airport).Cast<Airport>().ToList();
        //Customers = XFiles.LoadItems(AT_Consts.Customer).Cast<Customer>().ToList();
        Flights = XFiles.LoadItems(AT_Consts.Flight).Cast<Flight>().ToList();
        Tickets = XFiles.LoadItems(AT_Consts.Ticket).Cast<Ticket>().ToList();

        // UserControls
        _ucAirplane = new(this);
        _ucAirport = new(this);
        //_ucCustomer = new(this);
        _ucFlight = new(this);
        _ucTicket = new(this);
    }

    // public Methods

    /// <summary>
    /// Sets the Form1 field (AT_Model) _itemToSearch equal to a given item and proceeds to Search.
    /// The given item's property values will be used to check for similarity.
    /// </summary>
    /// <param name="item">Item whose values will be used to check for similarities.</param>
    public void SearchItem(AT_Model item)
    {
        _searching = true;
        _itemToSearch = item;
        LoadListView();
        _searching = false;
    }

    /// <summary>
    /// Gets the current SelectedItem in ListView lsvContent.
    /// </summary>
    /// <returns>Object stored as a ListViewItem.Tag, if there is a SelectedItem.
    /// Returns null! either if it fails or there's no SelectedItem.</returns>
    public object GetListViewSelectedItem()
    {
        if (lsvContent.SelectedItems.Count == 1)
        {
            try { return lsvContent.SelectedItems[0].Tag; }
            catch { ShowMsgBoxError("Could not get ListView SelectedItem.", "Error"); }
        }

        return null!;
    }


    private void Form1_Load(object sender, EventArgs e)
    {
        UpdateLabelDate();
        timerClock.Start();

        SetUserControls();

        pnlContent.Visible = true;
    }

    private void Form1_Resize(object sender, EventArgs e)
    {
        // ResizeListViewColumns();
        LoadListView();

        // Locate Controls

        // Panel pnlSideButtons

        int start = 192; // pnlSideButtons' starting Top property

        if (Height < 832)
            pnlSideButtons.Top = start;
        else
            pnlSideButtons.Top = (pnlSideMenu.Height - pnlSideButtons.Top) / 2;

        // Label lblCredits
        lblCredits.Top = lblCredits.Parent.Height - (_lblCreditsIsCollapsed ? 0 : lblCredits.Height);

        // Panel pnlContent
        pnlContent.Height = pnlFooter.Top - pnlContent.Top - 64;
    }

    #region Load and Resize Methods

    /// <summary>
    /// Updates the content of Label lblDate.
    /// </summary>
    void UpdateLabelDate()
    {
        CultureInfo culture = CultureInfo.InvariantCulture;
        string weekDayToday = culture.DateTimeFormat.GetAbbreviatedDayName(DateTime.Now.DayOfWeek);
        string day = DateTime.Now.ToString("dd");
        string month = culture.DateTimeFormat.GetAbbreviatedMonthName(DateTime.Now.Month);
        string year = DateTime.Now.ToString("yyyy");

        lblDate.Text = $"{weekDayToday}, {day} - {month} - {year}";
        lblDate.Top = pnlFooter.Top - lblDate.Height - 4;
        lblDate.Left = Width - lblDate.Width - 8;
    }

    /// <summary>
    /// Sets the UserControls' Dock to Fill, Adds them to the Panel pnlContent and hides them all.
    /// </summary>
    void SetUserControls()
    {
        _ucAirplane.Dock = DockStyle.Top;
        _ucAirport.Dock = DockStyle.Top;
        //_ucCustomer.Dock = DockStyle.Top;
        _ucFlight.Dock = DockStyle.Top;
        _ucTicket.Dock = DockStyle.Top;

        pnlContent.Controls.Add(_ucAirplane);
        pnlContent.Controls.Add(_ucAirport);
        //pnlContent.Controls.Add(_ucCustomer);
        pnlContent.Controls.Add(_ucFlight);
        pnlContent.Controls.Add(_ucTicket);

        HideAllUserControls();
    }

    /// <summary>
    /// Hides all UserControls.
    /// </summary>
    void HideAllUserControls()
    {
        pnlContent.Controls.OfType<UserControl>().ToList().ForEach(uc => { uc.Visible = false; });
    }

    /// <summary>
    /// Resizes columns in ListView lsvContent.
    /// </summary>
    void ResizeListViewColumns()
    {

    }

    #endregion

    #region Timers and SlideLabelCredits

    private void timerClock_Tick(object sender, EventArgs e)
    {
        string now = DateTime.Now.ToString("HH : mm : ss   ");
        lblTime.Text = now;
        if (now[..10] == "00 : 00 : 0") UpdateLabelDate();
    }

    private void timerAboutCredits_Tick(object sender, EventArgs e)
    {
        SlideLabelCredits();
    }

    /// <summary>
    /// Slides Label lblCredits on lblAbout_Click.
    /// </summary>
    void SlideLabelCredits()
    {
        int step = lblCredits.Height / ANIM_STEPS;

        if (_lblCreditsIsCollapsed)
        {
            lblCredits.Top -= step;

            if (lblCredits.Bottom <= pnlSideMenu.Height)
            {
                timerAboutCredits.Stop();
                _lblCreditsIsSliding = false;
                _lblCreditsIsCollapsed = false;
            }
        }
        else
        {
            lblCredits.Top += step;

            if (lblCredits.Top >= pnlSideMenu.Height)
            {
                timerAboutCredits.Stop();
                _lblCreditsIsSliding = false;
                _lblCreditsIsCollapsed = true;
            }
        }
    }

    #endregion

    #region Click Methods (except ListView)

    // Minimize
    private void btnMinimize_Click(object sender, EventArgs e)
    {
        WindowState = FormWindowState.Minimized;
    }
    // Close
    private void btnClose_Click(object sender, EventArgs e)
    {
        DialogResult dr = MessageBox.Show(
            "Are you sure you want to close the application?", "X",
            MessageBoxButtons.YesNo);

        if (dr == DialogResult.Yes) Close();
    }

    // Top-Center Buttons (New, Search, (indirectly) Edit)
    private void ButtonsToUC_Click(object sender, EventArgs e)
    {
        string action = ((Control)sender).Name[3..]; // (New, Search, Edit)
        IAT_UserControl ucAction = _itemClass switch
        {
            string s when s == AT_Consts.Airplane => _ucAirplane,
            string s when s == AT_Consts.Airport => _ucAirport,
            //string s when s == AT_Consts.Customer => _ucCustomer,
            string s when s == AT_Consts.Flight => _ucFlight,
            string s when s == AT_Consts.Ticket => _ucTicket,
            _ => null!
        };

        if (ucAction is null) return;

        HideAllUserControls();

        lblContent.Text = $"{action} {_itemClass}";
        lblContent.TextAlign = ContentAlignment.MiddleCenter;

        pnlListView.Visible = false;
        ucAction.ShowUC(action);
    }

    // Right-Side Buttons (Edit, Cancel)
    private void EditAndDeleteButtons_Click(object sender, EventArgs e)
    {
        // Check Button is enabled -> if not, return
        if (((Control)sender).BackColor == _disabledBackColor || lsvContent.SelectedIndices.Count != 1)
        {
            return;
        }

        // If Button is Edit
        if (sender == btnEdit)
        {
            // On Edit, the UserControl gets the ListView SelectedItem through Form1.GetListViewSelectedItem()

            ButtonsToUC_Click(sender, e);
            return;
        }

        // If Button is Delete
        if (sender == btnDelete)
        {
            DeleteSelectedItem();
        }
    }

    // Left Side Menu Buttons
    private void SideButtons_Click(object sender, EventArgs e)
    {
        _itemClass = ((Control)sender).Text[..^1];

        LoadListView();
    }

    // Bottom-Right of Form1
    private void lblDate_Click(object sender, EventArgs e)
    {
        UpdateLabelDate();
    }

    // Bottom-Left of Form1
    private void lblAbout_Click(object sender, EventArgs e)
    {
        if (_lblCreditsIsSliding) return;

        SlideLabelCredits();
        _lblCreditsIsSliding = true;
        timerAboutCredits.Start();
    }

    // Footer MouseDoubleClick() -> Minimize
    private void pnlFooter_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        WindowState = FormWindowState.Minimized;
    }

    #endregion

    #region ListView (includes DoubleClick and SelectedIndexChanged)

    // One ListView to show them All

    /// <summary>
    /// Sets Form1's Controls according to current chosen item class and shows items in ListView lsvContent.
    /// </summary>
    void LoadListView()
    {
        DisableButtonsEditAndDelete();

        HideAllUserControls();

        btnNew.Text = $"New {_itemClass}";
        lblContent.Text = $"{_itemClass}s";
        lblContent.TextAlign = ContentAlignment.MiddleLeft;

        switch (_itemClass)
        {
            case string s when s == AT_Consts.Airplane: LoadListViewAirplanes(); break;
            case string s when s == AT_Consts.Airport: LoadListViewAirports(); break;
            //case string s when s == AT_Consts.Customer: LoadListViewCustomers(); break;
            case string s when s == AT_Consts.Flight: LoadListViewFlights(); break;
            case string s when s == AT_Consts.Ticket: LoadListViewTickets(); break;
            //case string s when s == typeof(Schedule).Name: LoadListViewSchedules(); break;
            default:
                ShowMsgBoxError(
                    $"Could not load items of type {_itemClass}.", $"ListView {_itemClass}s");
                break;
        }

        int results = lsvContent.Items.Count;
        lblContent.Text += $" ({results} result{(results == 1 ? "" : 's')})";

        pnlListView.Visible = true;
    }

    /// <summary>
    /// Loads ListView lsvContent so as to display Airplanes.
    /// </summary>
    void LoadListViewAirplanes()
    {
        lsvContent.Clear();

        int colID = 256;
        int colName = 320;
        int colManuf = 256;
        int colModel = 256;
        int colSeats = 96;

        int restum = lsvContent.Width - 4 - (colID + colName + colManuf + colModel + colSeats);

        lsvContent.Columns.Add("ID", colID);
        lsvContent.Columns.Add("Name", colName + restum);
        lsvContent.Columns.Add("Manufacturer", colManuf);
        lsvContent.Columns.Add("Model", colModel);
        lsvContent.Columns.Add("Seats", colSeats, HorizontalAlignment.Right);

        try
        {
            if (Airplanes.Count < 1) return;

            ListViewItem lvItem;
            string[] lvi = new string[lsvContent.Columns.Count];

            foreach (Airplane a in Airplanes)
            {
                if (_searching)
                {
                    if (!a.SearchResult(_itemToSearch))
                        continue;
                }

                lvi[0] = a.ID.ToString();
                lvi[1] = a.Name;
                lvi[2] = a.Manufacturer;
                lvi[3] = a.Model;
                lvi[4] = a.Seats.ToString();

                lvItem = new ListViewItem(lvi);
                lvItem.Tag = a;

                lsvContent.Items.Add(lvItem);
            }
        }
        catch { ShowMsgBoxWarning("Can't show the items.", AT_Consts.Airplane); }
    }

    /// <summary>
    /// Loads ListView lsvContent so as to display Airports.
    /// </summary>
    void LoadListViewAirports()
    {
        lsvContent.Clear();

        int colName = (lsvContent.Width - 4) / 2;
        int colCode = 96;
        int colCityCountry = (colName - colCode) / 2;

        int restum = lsvContent.Width - 4 - (colName + colCode + 2 * colCityCountry);

        lsvContent.Columns.Add("Name", colName);
        lsvContent.Columns.Add("Code", colCode + restum);
        lsvContent.Columns.Add("City", colCityCountry);
        lsvContent.Columns.Add("Country", colCityCountry);

        try
        {
            if (Airports.Count < 1) return;

            ListViewItem lvItem;
            string[] lvi = new string[lsvContent.Columns.Count];

            foreach (Airport a in Airports)
            {
                if (_searching)
                {
                    if (!a.SearchResult(_itemToSearch))
                        continue;
                }

                lvi[0] = a.Name;
                lvi[1] = a.Code;
                lvi[2] = a.City;
                lvi[3] = a.Country;

                lvItem = new ListViewItem(lvi);
                lvItem.Tag = a;

                lsvContent.Items.Add(lvItem);
            }
        }
        catch { ShowMsgBoxWarning("Can't show the items.", typeof(Airport).Name); }
    }

    /// <summary>
    /// Loads ListView lsvContent so as to display registered Customers.
    /// </summary>
    void LoadListViewCustomers()
    {
        lsvContent.Clear();

        int colWidth = (lsvContent.Width - 4) / 3;
        lsvContent.Columns.Add("ID", colWidth);
        lsvContent.Columns.Add("Name", colWidth);
        lsvContent.Columns.Add("Type", colWidth);

        try
        {
            //if (Customers.Count < 1) return;

            //ListViewItem lvItem;
            //string[] lvi = new string[lsvContent.Columns.Count];

            //foreach (Customer c in Customers)
            //{
            //    lvi[0] = c.ID.ToString();
            //    lvi[1] = c.Name;
            //    lvi[2] = c.Type;

            //    lvItem = new ListViewItem(lvi);
            //    lvItem.Tag = c;

            //    lsvContent.Items.Add(lvItem);
            //}
        }
        catch { ShowMsgBoxWarning("Can't show the items.", AT_Consts.Customer); }
    }

    /// <summary>
    /// Loads ListView lsvContent so as to display registered Flights.
    /// </summary>
    void LoadListViewFlights()
    {
        lsvContent.Clear();

        int colNumber = 128;
        int colDay = 160;
        int colHour = 96;
        int colFromTo = 256;
        int colAirplane = 160;
        int colSeats = 96;

        int restum = lsvContent.Width - 4 -
            (colNumber + colDay + colHour + 2 * colFromTo + colAirplane + 2 * colSeats);

        lsvContent.Columns.Add("Number", colNumber);
        lsvContent.Columns.Add("Day", colDay, HorizontalAlignment.Center);
        lsvContent.Columns.Add("Hour", colHour, HorizontalAlignment.Center);
        lsvContent.Columns.Add("From", colFromTo);
        lsvContent.Columns.Add("To", colFromTo);
        lsvContent.Columns.Add("Airplane", colAirplane + restum);
        lsvContent.Columns.Add("Seats ", colSeats, HorizontalAlignment.Right);
        lsvContent.Columns.Add("Avail.", colSeats, HorizontalAlignment.Right);

        try
        {
            if (Flights.Count < 1) return;

            ListViewItem lvItem;
            string[] lvi = new string[lsvContent.Columns.Count];

            foreach (Flight f in Flights)
            {
                if (_searching)
                {
                    if (!f.SearchResult(_itemToSearch))
                        continue;
                }

                lvi[0] = f.Number;
                lvi[1] = f.DateHour.ToString("dd-MM-yyyy");
                lvi[2] = f.DateHour.ToString("HH:mm");
                lvi[3] = Airports.FirstOrDefault(a => a.ID == f.OriginID)?.DisplayMember ?? "not found";
                lvi[4] = Airports.FirstOrDefault(a => a.ID == f.DestID)?.DisplayMember ?? "not found";
                lvi[5] = Airplanes.FirstOrDefault(a => a.ID == f.AirplaneID)?.Model ?? "not found";
                lvi[6] = f.Seats.ToString();
                lvi[7] = (f.Seats - Tickets.Count(t => t.FlightID == f.ID)).ToString();

                lvItem = new ListViewItem(lvi);
                lvItem.Tag = f;

                lsvContent.Items.Add(lvItem);
            }
        }
        catch { ShowMsgBoxWarning("Can't show the items.", AT_Consts.Flight); }
    }

    /// <summary>
    /// Loads ListView lsvContent so as to display registered Tickets.
    /// </summary>
    void LoadListViewTickets()
    {
        lsvContent.Clear();

        int colReference = 320;
        int colFlight = 128;
        int colFromTo = 256;
        int colSched = 256;

        int restum = lsvContent.Width - 4 - (colReference + colFlight + 2 * colFromTo + colSched);

        lsvContent.Columns.Add("Reference", colReference);
        lsvContent.Columns.Add("Flight", colFlight);
        lsvContent.Columns.Add("From", colFromTo + (restum / 2));
        lsvContent.Columns.Add("To", colFromTo + (restum / 2));
        lsvContent.Columns.Add("Sched", colSched, HorizontalAlignment.Center);

        try
        {
            if (Tickets.Count < 1) return;

            ListViewItem lvItem;
            string[] lvi = new string[lsvContent.Columns.Count];

            foreach (Ticket t in Tickets)
            {
                if (_searching)
                {
                    if (!t.SearchResult(_itemToSearch))
                        continue;
                }

                lvi[0] = t.Reference;
                lvi[1] = Flights.FirstOrDefault(f => f.ID == t.FlightID)?.Number ?? "not found";
                lvi[2] = Airports.FirstOrDefault(a => a.ID == Flights.FirstOrDefault(f => f.ID == t.FlightID)?.OriginID)?.DisplayMember ?? "not found";
                lvi[3] = Airports.FirstOrDefault(a => a.ID == Flights.FirstOrDefault(f => f.ID == t.FlightID)?.DestID)?.DisplayMember ?? "not found";
                lvi[4] = Flights.FirstOrDefault(f => f.ID == t.FlightID)?.DateHour.ToString("dd-MM-yyyy HH:mm") ?? "not found";

                lvItem = new ListViewItem(lvi);
                lvItem.Tag = t;

                lsvContent.Items.Add(lvItem);
            }
        }
        catch { ShowMsgBoxWarning("Can't show the items.", AT_Consts.Ticket); }
    }

    /// <summary>
    /// Loads ListView lsvContent so as to display registered Schedules.
    /// </summary>
    void LoadListViewSchedules()
    {
        lsvContent.Clear();

        MessageBox.Show("Not implemented.");

        //if (Tickets.Count < 1) return;

        //try
        //{
        //    string[] lvi = new string[lsvContent.Columns.Count];

        //    foreach (Schedule s in Schedules)
        //    {
        //        lvi[0] = s.Name;
        //        lvi[1] = Airplanes[s.AirplaneID].Name;
        //        lvi[2] = s.Seats.ToString();
        //        lvi[3] = Airports[s.OriginID].ToString() ?? "";
        //        lvi[4] = Airports[s.DestID].ToString() ?? "";
        //        lvi[5] = s.Scheds.Count.ToString();

        //        lsvContent.Items.Add(new ListViewItem(lvi));
        //    }
        //}
        //catch { ShowMsgBoxWarning("Can't show the items.", AT_Consts.Schedule); }
    }

    private void lsvContent_DoubleClick(object sender, EventArgs e)
    {
        if (lblContent.Text[..6] == AT_Consts.Flight)
        {
            if (lsvContent.SelectedIndices.Count != 1)
            {
                ShowMsgBoxWarning("A Flight selection is required.", "lsvContent_DoubleClick()");
                return;
            }

            if (_ucTicket.ShowUC("New") == "")
            {
                lblContent.Text = $"New {AT_Consts.Ticket}";
                lblContent.TextAlign = ContentAlignment.MiddleCenter;
                btnNew.Text = $"New {AT_Consts.Ticket}";

                pnlListView.Visible = false;
                _itemClass = AT_Consts.Ticket;
            }
        }
    }

    private void lsvContent_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lsvContent.SelectedIndices.Count == 1)
        {
            EnableButtonsEditAndDelete();
        }
        else
        {
            DisableButtonsEditAndDelete();
        }
    }

    #endregion

    // Other Methods

    /// <summary>
    /// Sets aspect of Buttons Edit and Delete to enabled through BackColors (including MouseOver and MouseDown).
    /// </summary>
    void EnableButtonsEditAndDelete()
    {
        List<Button> buttons = new List<Button>() { btnEdit, btnDelete };
        foreach (Button btn in buttons)
        {
            btn.BackColor = _enabledBackColor;
            btn.ForeColor = Color.MediumBlue;
            btn.FlatAppearance.MouseDownBackColor = Color.Empty;
            btn.FlatAppearance.MouseOverBackColor = _enabledMOverBackColor;
            btn.Cursor = Cursors.Hand;
            btn.TabStop = true;
        }
    }

    /// <summary>
    /// Sets aspect of Buttons Edit and Delete to disabled through BackColors (including MouseOver and MouseDown).
    /// </summary>
    void DisableButtonsEditAndDelete()
    {
        List<Button> buttons = new List<Button>() { btnEdit, btnDelete };
        foreach (Button btn in buttons)
        {
            btn.BackColor = _disabledBackColor;
            btn.ForeColor = Color.FromArgb(64, 64, 64);
            btn.FlatAppearance.MouseDownBackColor = _disabledBackColor;
            btn.FlatAppearance.MouseOverBackColor = _disabledBackColor;
            btn.Cursor = Cursors.Default;
            btn.TabStop = false;
        }
    }

    /// <summary>
    /// Deletes SelectedItem in ListView lsvContent.
    /// </summary>
    void DeleteSelectedItem()
    {
        try
        {
            AT_Model? itemDelete = (AT_Model)lsvContent.SelectedItems[0].Tag;

            DialogResult dr = ShowMsgBoxQuestionYN(
                $"Are you sure you want to delete this {_itemClass}?\n" +
                $"\n{itemDelete}", btnDelete.Text);

            if (dr == DialogResult.Yes)
            {
                if (XFiles.DeleteItem(itemDelete))
                {
                    RemoveItemFromList(itemDelete);
                    LoadListView();
                }
            }

            return; // Success
        }
        catch { }

        // If it gets here, it's not been successful
        ShowMsgBoxError($"Could not delete {_itemClass}.", "Delete");
    }

    /// <summary>
    /// Removes given item from its Form1 List.
    /// </summary>
    /// <param name="item">Item to be removed from List.</param>
    void RemoveItemFromList(AT_Model item)
    {
        try
        {
            // on switch-case:
            // - Remove item from its List
            // - Start ListView
            // - return; // Success

            switch (item.GetType().Name)
            {
                case string s when s == AT_Consts.Airplane:
                    Airplanes.Remove((Airplane)item);
                    LoadListViewAirplanes();
                    return; // Success

                case string s when s == AT_Consts.Airport:
                    Airports.Remove((Airport)item);
                    LoadListViewAirports();
                    return; // Success

                //case string s when s == AT_Consts.Customer:
                //    Customers.Remove((Customer)item);
                //    LoadListViewCustomers();
                //    return; // Success

                case string s when s == AT_Consts.Flight:
                    Flights.Remove((Flight)item);
                    LoadListViewFlights();
                    return; // Success

                case string s when s == AT_Consts.Ticket:
                    Tickets.Remove((Ticket)item);
                    LoadListViewTickets();
                    return; // Success
            }
        }
        catch { }

        // If it gets here, it wasn't successful
        ShowMsgBoxError($"Could not remove {_itemClass} from List.", "RemoveItemFromList()");
    }

    #region MessageBoxes

    /// <summary>
    /// Shows a MessageBox with the text and caption given, OK button and Info icon.
    /// </summary>
    /// <param name="msg">Text for MessageBox.</param>
    /// <param name="caption">Caption for MessageBox.</param>
    public static void ShowMsgBoxInfo(string msg, string caption)
    {
        MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    /// <summary>
    /// Shows a MessageBox with the text and caption given, OK button and Warning icon.
    /// </summary>
    /// <param name="msg">Text for MessageBox.</param>
    /// <param name="caption">Caption for MessageBox.</param>
    public static void ShowMsgBoxWarning(string msg, string caption)
    {
        MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

    /// <summary>
    /// Shows a MessageBox with the text and caption given, OK button and Error icon.
    /// </summary>
    /// <param name="msg">Text for MessageBox.</param>
    /// <param name="caption">Caption for MessageBox.</param>
    public static void ShowMsgBoxError(string msg, string caption)
    {
        MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    /// <summary>
    /// Shows a MessageBox with the text and caption given, YesNo buttons and Question icon.
    /// </summary>
    /// <param name="msg">Text for MessageBox.</param>
    /// <param name="caption">Caption for MessageBox.</param>
    /// <returns>Answer given.</returns>
    public static DialogResult ShowMsgBoxQuestionYN(string msg, string caption)
    {
        return MessageBox.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    }

    #endregion

}