using AeroTickets.ClassLibrary;
using AeroTickets.ClassLibrary.Models;

namespace AeroTickets.WinForms.UserControls;

public partial class UC_Ticket : UserControl, IAT_UserControl
{
    readonly Form1 _f1;
    readonly List<Airport> _airports;
    //readonly List<Customer> _customers;
    readonly List<Flight> _flights;
    readonly List<Ticket> _tickets;

    readonly string _displayMember = "DisplayMember";

    Ticket _ticket = null!;
    Flight _ticketFlight = null!;

    public string Action { get; set; } = null!;

    public UC_Ticket(Form1 f)
    {
        InitializeComponent();

        _f1 = f;
        _airports = f.Airports;
        //_customers = f.Customers;
        _flights = f.Flights;
        _tickets = f.Tickets;

        // Temporary
        cmbCustomer.Visible = false;
    }


    /// <summary>
    /// Shows UserControl UC_Ticket.
    /// </summary>
    /// <param name="action">Action for the UserControl. ("New", "Search", "Edit")</param>
    /// <returns>Empty.String.</returns>
    public string ShowUC(string action)
    {
        object selectedItem = _f1.GetListViewSelectedItem()!;

        Action = action;
        btnSubmit.Text = action;

        LoadComboBoxFlight();
        //LoadComboBoxCustomer();

        if (selectedItem is null)
        {
            _ticket = null!;
            _ticketFlight = null!;
        }
        else
        {
            if (selectedItem is Ticket)
            {
                _ticket = (Ticket)selectedItem;
                _ticketFlight = _flights.FirstOrDefault(f => f.ID == _ticket.FlightID)!;
            }
            else if (selectedItem is Flight)
            {
                _ticket = null!;
                _ticketFlight = (Flight)selectedItem;
            }
            else
            {
                Form1.ShowMsgBoxError("error at selectedItem is Ticket, UC_Ticket.ShowUC()", Action);
                return "error";
            }
        }

        if (Action == "Search")
        {
            //txbFrom.Enabled = true;
            //txbTo.Enabled = true;
            lblSeatCheck.Visible = false;
            lblSeatsAvailable.Visible = false;
        }
        else
        {
            //txbFrom.Enabled = false;
            //txbTo.Enabled = false;
            lblSeatCheck.Visible = true;
            lblSeatsAvailable.Visible = true;
        }

        if (Action == "Edit")
            cmbFlight.Enabled = false;
        else
            cmbFlight.Enabled = true;

        SetControlsValues();

        Show();

        return "";
    }

    void SetControlsValues()
    {
        cmbFlight.SelectedItem = _ticketFlight;

        if (_ticket is null)
        {
            nudSeat.Value = 0;
            //cmbCustomer.SelectedIndex = -1;
            txbCustomerName.ResetText();
        }
        else
        {
            nudSeat.Value = _ticket.Seat;
            //try cmbCustomer.SelectedIndex = _customers.FirstOrDefault(c => c.ID == _ticket.CustomerID);
            txbCustomerName.Text = _ticket.CustomerName;
        }
    }

    /// <summary>
    /// Updates the DataSources for ComboBox cmbFlight.
    /// </summary>
    void LoadComboBoxFlight()
    {
        cmbFlight.DataSource = null;
        cmbFlight.DisplayMember = _displayMember;
        cmbFlight.DataSource = _flights.OrderByDescending(f => f.DateHour).ToList();
        cmbFlight.SelectedIndex = -1;
        cmbFlight.Text = AT_Consts.Flight;
    }

    // Not implemented
    /// <summary>
    /// Updates the DataSources for ComboBox cmbCustomer.
    /// </summary>
    void LoadComboBoxCustomer()
    {
        //cmbCustomer.DataSource = null;
        //cmbCustomer.DisplayMember = _displayMember;
        //cmbCustomer.DataSource = _customers;
        //cmbCustomer.SelectedIndex = -1;
        //cmbCustomer.Text = "";
    }


    private void cmbFlight_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbFlight.SelectedItem is null)
        {
            _ticketFlight = null!;
            txbFrom.ResetText();
            txbTo.ResetText();
            nudSeat.Value = 0;
            nudSeat.Enabled = false;
            lblSeatsAvailable.ResetText();
        }
        else
        {
            // Get selected Flight

            try { _ticketFlight = (Flight)cmbFlight.SelectedItem; }
            catch
            {
                _ticketFlight = null!;
                Form1.ShowMsgBoxError("error at UC_Ticket.cmbFlight_SelectedIndexChanged()", Action);
                return;
            }

            nudSeat.Enabled = true;

            // Origin and Destination Airports

            Airport airport = null!;

            airport = _airports.FirstOrDefault(a => a.ID == _ticketFlight.OriginID)!;
            if (airport is not null)
                txbFrom.Text = airport.DisplayMember;
            else txbFrom.ResetText();

            airport = _airports.FirstOrDefault(a => a.ID == _ticketFlight.DestID)!;
            if (airport is not null)
                txbTo.Text = airport.DisplayMember;
            else txbTo.ResetText();

            nudSeat.Maximum = _ticketFlight.Seats;

            UpdateLabelSeatsAvailable();
        }
    }

    private void nudSeat_ValueChanged(object sender, EventArgs e)
    {
        lblSeatsAvailable.Text = "380 seats available.";
        if (nudSeat.Value == 0 || cmbFlight.SelectedItem is null)
        {
            lblSeatCheck.ForeColor = Color.Silver;
            lblSeatCheck.Text = "O";
            return;
        }

        // Check chosen Seat is taken
        Ticket sameSeatTicket = _tickets.FirstOrDefault(t =>
            t.FlightID == _ticketFlight.ID && t.Seat == nudSeat.Value)!;

        // Seat is not taken
        if (sameSeatTicket == null)
        {
            lblSeatCheck.ForeColor = Color.Green;
            lblSeatCheck.Text = "I";
        }
        else
        {
            // If Seat is the Editing Ticket's Seat
            if (Action == "Edit" && _ticket != null && sameSeatTicket.ID == _ticket.ID)
            {
                lblSeatCheck.ForeColor = Color.Green;
                lblSeatCheck.Text = "I";
            }
            // Else
            else
            {
                lblSeatCheck.ForeColor = Color.DarkRed;
                lblSeatCheck.Text = "X";
            }
        }
    }

    private void txbCustomerName_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsLetter(e.KeyChar) && !" .-".Contains(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            e.Handled = true;
    }

    private void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Action == "Search")
            SearchTicket();
        else SubmitTicket();
    }

    /// <summary>
    /// Prepares a new object of type Ticket and calls Form1.SearchItem().
    /// For each value sought from the user, if the field's CheckBox is Checked,
    /// the new object will have the given value; otherwise, it will get a default value,
    /// so that it won't match any other Ticket's related value.
    /// </summary>
    void SearchTicket()
    {
        try
        {
            _ticket = new(
                0,
                "",
                ((Flight)cmbFlight.SelectedItem)?.ID ?? 0,
                (int)nudSeat.Value,
                -1,
                //cmbCustomer.Text
                txbCustomerName.Text
                );
        }
        catch
        {
            Form1.ShowMsgBoxError($"Could not create new object of Type {AT_Consts.Ticket}", Action);
            return;
        }

        _f1.SearchItem(_ticket);
    }

    /// <summary>
    /// Gets and validates the values given by the user to submit Ticket,
    /// either as a New Ticket or as an Edited Ticket. Then, attempts to Save it.
    /// </summary>
    void SubmitTicket()
    {
        int id;
        int selectedSeat;
        int customerID = 0; // Customer registry it not implemented
        int refrFlightTicket;
        string customerName;
        string reference;
        string msgCaption = $"{Action} {AT_Consts.Ticket}";

        id = GetTicketID();
        if (id == -1) return;

        selectedSeat = (int)nudSeat.Value;

        //customerName = cmbCustomer.Text.Trim();
        customerName = txbCustomerName.Text.Trim();

        // Check Seat

        // Seat is outside bounds?
        if (selectedSeat < 1 || selectedSeat > _ticketFlight.Seats)
        {
            Form1.ShowMsgBoxWarning("Seat number is out of the Flight's capacity.", msgCaption);
            return;
        }

        // Seat is taken?
        if (_tickets.Any(t => t.FlightID == _ticketFlight.ID && t.Seat == selectedSeat))
        {
            // If Editing Ticket and selecting the same seat as it was
            if (Action == "Edit" && _ticket is not null && selectedSeat == _ticket.Seat)
            { } // All good, keep going
            else
            {
                Form1.ShowMsgBoxWarning("This Seat is already taken.\nChoose another seat.", msgCaption);
                return;
            }
        }

        // Check Customer Name

        // Name is Empty?
        if (customerName == "")
        {
            Form1.ShowMsgBoxWarning("A Customer Name is required.", msgCaption);
            return;
        }

        // Name is valid?
        if (!customerName.All(c => char.IsLetter(c) || " .-".Contains(c)))
        {
            Form1.ShowMsgBoxWarning(
                "Customer Name is not valid." +
                "\nName must contain only letters, space, dot (.) and hyphen (-).",
                msgCaption);
            return;
        }

        if (Action == "Edit")
            reference = _ticket.Reference;
        else
        {
            refrFlightTicket = _tickets.Where(t => t.ID == _ticketFlight.ID).Count() + 1;
            reference = $"{_ticketFlight.DateHour:yyMMddHHmm}{_ticketFlight.Number}-{refrFlightTicket}";
        }

        try
        {
            _ticket = new Ticket(
            id,
            reference,
            _ticketFlight.ID,
            selectedSeat,
            customerID,
            customerName
            );
        }
        catch
        {
            Form1.ShowMsgBoxError($"error creating object of type {AT_Consts.Ticket}",
                "UC_Ticket.SubmitTicket()");
            return;
        }


        if (!SaveTicket()) return;

        UpdateLabelSeatsAvailable();

        Form1.ShowMsgBoxInfo("The Ticket was registered.", msgCaption);

        if (Action == "New")
        {
            lblSeatCheck.ForeColor = Color.DarkRed;
            lblSeatCheck.Text = "X";
        }
    }

    /// <summary>
    /// Gets an ID for a Ticket.
    /// </summary>
    /// <returns>If Creating Ticket, returns Max Ticket ID +1 (returns 1 if no Tickets);
    /// if Editing Ticket, returns its current ID;
    /// if it fails, returns -1;</returns>
    int GetTicketID()
    {
        if (Action == "New")
        {
            if (_tickets.Count > 0)
                return _tickets.Max(t => t.ID) + 1;
            else return 1;
        }

        if (Action == "Edit" && _ticket is not null)
        {
            return _ticket.ID;
        }

        Form1.ShowMsgBoxError("error at GetTicketID().", "UC_Ticket.GetTicketID()");
        return -1;
    }

    bool SaveTicket()
    {
        bool success = false;
        int tries = 0;

        if (Action == "New")
        {
            do
            {
                try { success = XFiles.SaveItem(_ticket); }
                catch { tries++; }
            } while (!success && tries < 100);

            if (success)
                _tickets.Add(_ticket);
        }
        else if (Action == "Edit")
        {
            success = XFiles.EditItem(_ticket);

            if (success)
            {
                int index = _tickets.FindIndex(t => t.ID == _ticket.ID);
                //_tickets[index] = _ticket;
                _tickets.RemoveAt(index);
                _tickets.Add(_ticket);
            }
        }


        if (!success)
        {
            Form1.ShowMsgBoxError($"Could not edit {AT_Consts.Ticket}.", "SubmitTicket(), UC_Ticket.cs");
            return false;
        }

        return true;
    }

    void UpdateLabelSeatsAvailable()
    {
        // Available Seats

        int availableSeats = _ticketFlight.Seats -
            _tickets.Count(t => t.FlightID == _ticketFlight.ID);

        lblSeatsAvailable.Text = $"{availableSeats} seats available.";
        lblSeatsAvailable.ForeColor = availableSeats switch
        {
            0 => Color.DarkRed,
            int i when i > 0 => Color.DarkGreen,
            _ => Color.Silver
        };
    }

}
