using AeroTickets.ClassLibrary;
using AeroTickets.ClassLibrary.Models;

namespace AeroTickets.WinForms.UserControls;

public partial class UC_Flight : UserControl, IAT_UserControl
{
    readonly Form1 _f1;
    readonly List<Airplane> _airplanes;
    readonly List<Airport> _airports;
    readonly List<Flight> _flights;

    readonly string _displayMember = "DisplayMember";

    Flight _flight = null!;

    /// <summary>
    /// Controls whether ComboBoxes are set to open.
    /// This is needed to prevent ComboBoxes from opening on *certain CheckBoxes* CheckedChanged
    /// when showing the UC (this.ShowUC()).
    /// * CheckBoxes: chbSearchOrigin, chbSearchDest, chbSearchAirplane.
    /// </summary>
    bool _openComboBox = false;

    public string Action { get; set; } = null!;

    public UC_Flight(Form1 f)
    {
        InitializeComponent();

        _f1 = f;
        _airplanes = f.Airplanes;
        _airports = f.Airports;
        _flights = f.Flights;

        // ComboBoxes are loaded on this.VisibleChanged
    }

    /// <summary>
    /// Shows UserControl UC_Flight.
    /// </summary>
    /// <param name="action">Action for the UserControl. ("New", "Search", "Edit")</param>
    /// <returns>Empty.String if successful; otherwise, error string.</returns>
    public string ShowUC(string action)
    {
        object selectedItem = _f1.GetListViewSelectedItem();

        _openComboBox = false;

        Action = action;

        btnSubmit.Text = action;

        LoadComboBoxesAirports();
        LoadComboBoxAirplanes();

        // Try to get selected Flight in Form1.lsvContent

        if (selectedItem is null)
        {
            _flight = null!;
        }
        else
        {
            if (selectedItem.GetType().Name == AT_Consts.Flight)
            {
                _flight = (Flight)selectedItem;
            }
            // If there is a Ticket selected in Form1.lsvContent, get its Flight
            else if (selectedItem.GetType().Name == AT_Consts.Ticket)
            {
                Ticket ticket = (Ticket)selectedItem;
                try
                {
                    _flight = _flights.FirstOrDefault(f => f.ID == ticket.FlightID)!;
                }
                catch
                {
                    Form1.ShowMsgBoxError($"Could not find {AT_Consts.Ticket}'s {AT_Consts.Flight}.",
                        "UC_Flight.ShowUC()");
                    return "error";
                }
            }
            else
            {
                Form1.ShowMsgBoxError("Something's gone wrong at UC_Flight.ShowUC()", Action);
                return "error";
            }
        }

        if (Action == "Search")
        {
            panel1.Controls.OfType<CheckBox>().Where(chb => chb.Name[..9] == "chbSearch")
                .ToList().ForEach(chb => { chb.Visible = true; chb.Checked = false; });
            txbFlightNumber.Enabled = false;
            chbCustomFlightNumber.Enabled = false;
            dtpFlightDate.Enabled = false;
            dtpFlightHour.Enabled = false;
            nudSeats.Enabled = false;
            chbCustomSeats.Enabled = false;
        }
        else
        {
            panel1.Controls.OfType<CheckBox>().Where(chb => chb.Name[..9] == "chbSearch")
                .ToList().ForEach(chb => { chb.Checked = false; chb.Visible = false; });
            txbFlightNumber.Enabled = chbCustomFlightNumber.Checked;
            chbCustomFlightNumber.Enabled = true;
            dtpFlightDate.Enabled = true;
            dtpFlightHour.Enabled = true;
            nudSeats.Enabled = chbCustomSeats.Checked;
            chbCustomSeats.Enabled = true;
        }

        SetControlsValues();

        Show();

        _openComboBox = true;

        return "";
    }

    /// <summary>
    /// Sets Controls' values according to selected Flight in Form1.lsvContent,
    /// if there is one selected. If, instead, there's a Ticket selected,
    /// set Controls' values to those of its Flight.
    /// If none of the previous, set all values to blank.
    /// </summary>
    void SetControlsValues()
    {
        if (_flight is null)
        {
            chbCustomFlightNumber.Checked = false;
            cmbAirportOrigin.SelectedIndex = -1;
            cmbAirportOrigin.SelectedIndex = -1;
            cmbAirplane.SelectedIndex = -1;
            nudSeats.Value = 0;
            chbCustomSeats.Checked = false;
        }
        else
        {
            try
            {
                // Setting Controls' values according to Form1.lsvContent.SelectedItem

                chbCustomFlightNumber.Checked = true;
                txbFlightNumber.Text = _flight.Number[2..];
                dtpFlightDate.Value = _flight.DateHour.Date;
                dtpFlightHour.Value = DateTime.Parse(_flight.DateHour.TimeOfDay.ToString());
                cmbAirportOrigin.SelectedItem = _airports.FirstOrDefault(
                    a => a.ID == _flight.OriginID);
                cmbAirportDest.SelectedItem = _airports.FirstOrDefault(
                    a => a.ID == _flight.DestID);
                //cmbAirplane.SelectedItem = _airplanes.FirstOrDefault(
                //    a => a.ID == _flight.AirplaneID);
                nudSeats.Value = _flight.Seats;
                chbCustomSeats.Checked = _flight.Seats != (_airplanes.FirstOrDefault(
                    a => a.ID == _flight.AirplaneID)?.Seats ?? 0);
            }
            catch
            {
                Form1.ShowMsgBoxError(
                    $"Could not set {AT_Consts.Flight}'s values.",
                    $"UC_Flight.ShowUC()");
            }
        }
    }

    /// <summary>
    /// Updates the DataSources for both ComboBoxes related to Airports.
    /// </summary>
    void LoadComboBoxesAirports()
    {
        cmbAirportOrigin.DataSource = null;
        cmbAirportOrigin.DisplayMember = _displayMember;
        cmbAirportOrigin.DataSource = _airports;
        cmbAirportOrigin.SelectedIndex = -1;
        cmbAirportOrigin.Text = "Airport";

        cmbAirportDest.BindingContext = new BindingContext();

        cmbAirportDest.DataSource = null;
        cmbAirportDest.DisplayMember = _displayMember;
        cmbAirportDest.DataSource = _airports;
        cmbAirportDest.SelectedIndex = -1;
        cmbAirportDest.Text = "Airport";
    }

    /// <summary>
    /// Updates the DataSource of the ComboBox cmbAirplane.
    /// </summary>
    void LoadComboBoxAirplanes()
    {
        cmbAirplane.DataSource = null;
        cmbAirplane.DisplayMember = _displayMember;
        cmbAirplane.DataSource = _airplanes;
        cmbAirplane.SelectedIndex = -1;

        nudSeats.Value = 0;
    }

    // Event's Methods
    #region Events (except btnSubmit_Click) (includes ComboBoxes, CheckBoxes, KeyPress)

    // ComboBoxes

    private void ComboBoxesAirport_Leave(object sender, EventArgs e)
    {
        ComboBox? cmb = (ComboBox)sender;
        Airport? airp;

        if (cmb is null) return;

        if ((airp =
            _airports.FirstOrDefault(
                a => a.DisplayMember[..3].Equals(cmb.Text.ToUpper()))) != null)
        {
            cmb.Text = airp.DisplayMember;
        }
    }

    private void ComboBoxesAirport_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Action != "Search")
            return;

        if (sender == cmbAirportOrigin && cmbAirportOrigin.SelectedIndex != -1)
        {
            chbSearchOrigin.Checked = true;
            return;
        }

        if (sender == cmbAirportDest && cmbAirportDest.SelectedIndex != -1)
        {
            chbSearchDest.Checked = true;
            return;
        }
    }

    private void cmbAirplane_SelectedIndexChanged(object sender, EventArgs e)
    {
        int? seats = -1;

        if (Action == "Search" && cmbAirplane.SelectedItem is not null)
            chbSearchAirplane.Checked = true;
        else chbSearchAirplane.Checked = false;

        if (cmbAirplane.SelectedIndex == -1 || chbCustomSeats.Checked) return;

        try
        {
            seats = _airplanes.FirstOrDefault(a => a.DisplayMember.Contains(cmbAirplane.Text[..^1]))?.Seats ?? -1;
            if (seats != null && seats != -1)
            {
                nudSeats.Value = (int)seats;
                return;
            }
        }
        catch { }

        Form1.ShowMsgBoxError("error at cmbAirplane_SelectedIndexChanged().", "UC_Flight.cs");
        nudSeats.Value = 0;
    }

    // CheckBoxes

    private void chbCustomFlightNumber_CheckedChanged(object sender, EventArgs e)
    {
        if (!((CheckBox)sender).Checked)
        {
            txbFlightNumber.Text = "Auto";
        }
        else
        {
            txbFlightNumber.ResetText();
        }

        txbFlightNumber.Enabled = chbCustomFlightNumber.Checked;
    }

    private void chbCustomSeats_CheckedChanged(object sender, EventArgs e)
    {
        nudSeats.Enabled = chbCustomSeats.Checked;

        if (!chbCustomSeats.Checked && cmbAirplane.SelectedIndex != -1)
        {
            try
            {
                nudSeats.Value = GetAirplaneSeats();
                return;
            }
            catch { }
        }

        //if (nudSeats.Text.Length == 0)
        nudSeats.Value = 0;
    }

    private void CheckBoxesSearchUnrelatedToComboBoxes_CheckedChanged(object sender, EventArgs e)
    {
        if (sender == chbSearchNumber)
        {
            txbFlightNumber.Enabled = chbSearchNumber.Checked && chbCustomFlightNumber.Checked;
            chbCustomFlightNumber.Enabled = chbSearchNumber.Checked;
            chbCustomFlightNumber.ForeColor = chbCustomFlightNumber.Enabled ? Color.MediumBlue : Color.Black;
            return;
        }

        if (sender == chbSearchDate)
        {
            dtpFlightDate.Enabled = chbSearchDate.Checked;
            return;
        }

        if (sender == chbSearchHour)
        {
            dtpFlightHour.Enabled = chbSearchHour.Checked;
            return;
        }

        if (sender == chbSearchSeats)
        {
            chbCustomSeats.Enabled = chbSearchSeats.Checked;
            nudSeats.Enabled = chbSearchSeats.Checked && chbCustomSeats.Checked;
            chbCustomSeats.ForeColor = chbCustomSeats.Enabled ? Color.MediumBlue : Color.Black;
            return;
        }
    }

    private void CheckBoxesSearchRelatedToComboBoxes_CheckedChanged(object sender, EventArgs e)
    {
        // The goal of this Method is to deselect the selected Airport/Airplane in its ComboBox
        //
        // CheckBoxes: chbSearchOrigin, chbSearchDest, chbSearchAirplane
        // For any of these ^, act on the correspondent ComboBox:
        // - (cmbAirportOrigin, cmbAirportDest, cmbAirplane)

        string chbName = ((Control)sender).Name;

        if (chbName == chbSearchOrigin.Name)
        {
            if (chbSearchOrigin.Checked)
            {
                if (cmbAirportOrigin.SelectedIndex != -1)
                    return;
                else
                    cmbAirportOrigin.DroppedDown = _openComboBox;

                chbSearchOrigin.Checked = false;
            }

            cmbAirportOrigin.SelectedIndex = -1;

            return;
        }
        if (chbName == chbSearchDest.Name)
        {
            if (chbSearchDest.Checked)
            {
                if (cmbAirportDest.SelectedIndex != -1)
                    return;
                else
                    cmbAirportDest.DroppedDown = _openComboBox;

                chbSearchDest.Checked = false;
            }

            cmbAirportDest.SelectedIndex = -1;

            return;
        }
        if (chbName == chbSearchAirplane.Name)
        {
            if (chbSearchAirplane.Checked)
            {
                if (cmbAirplane.SelectedIndex != -1)
                    return;
                else
                    cmbAirplane.DroppedDown = _openComboBox;

                chbSearchAirplane.Checked = false;
            }

            // First Item gets selected and stays unless this is done a 2nd time
            cmbAirplane.SelectedIndex = -1;
            cmbAirplane.SelectedItem = null;

            nudSeats.Value = 0;
            chbCustomSeats.Checked = false;
            return;
        }
    }

    // KeyPress

    private void NumericPos_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            e.Handled = true;
    }

    private void nudSeats_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Back) return;

        if (!char.IsDigit(e.KeyChar))
        {
            e.Handled = true;
            return;
        }

        if (nudSeats.Text.Length == 3)
        {
            e.Handled = true;
            return;
        }
    }

    #endregion

    // Submit (New, Search, Edit)

    private void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Action == "Search")
            SearchFlight();
        else
            SubmitFlight();
    }

    // Search
    /// <summary>
    /// Prepares a new object of type Flight and calls Form1.SearchItem().
    /// For each value sought from the user, if the field's CheckBox is Checked,
    /// the new object will have the given value; otherwise, it will get a default value,
    /// so that it won't match any other Flight's related value.
    /// </summary>
    void SearchFlight()
    {
        string flightNumber = chbSearchNumber.Checked ? txbFlightNumber.Text : "";
        DateTime flightDate = chbSearchDate.Checked ? dtpFlightDate.Value.Date : new(0);
        TimeSpan flightHour = chbSearchHour.Checked ? dtpFlightHour.Value.TimeOfDay : TimeSpan.Zero;
        DateTime dateHour = flightDate + flightHour;
        int originID, destID;
        int airplaneID = 0;
        int seats = chbSearchSeats.Checked ? GetAirplaneSeats() : 0;


        (originID, destID) = GetAirportsIDs();

        if (chbSearchAirplane.Checked)
        {
            // Get ID of selected Airplane. If it fails -> airplaneID = 0
            airplaneID = _airplanes.FirstOrDefault(a => a == cmbAirplane.SelectedItem)?.ID ?? 0;
        }

        try
        {
            _flight = new(
            0,
            flightNumber,
            dateHour,
            originID,
            destID,
            airplaneID,
            seats
            );
        }
        catch
        {
            Form1.ShowMsgBoxError("error at UC_Flight.SearchFlight().", Action);
            return;
        }

        _f1.SearchItem(_flight);
    }

    // New and Edit
    /// <summary>
    /// Gets and validates the values given by the user to submit Flight,
    /// either as a New Flight or as an Edited Flight. Then, attempts to Save it.
    /// </summary>
    void SubmitFlight()
    {
        // New Flight or Edit Flight

        int id;
        string flightNumber;
        DateTime dateHour;
        int originID, destID, airplaneID, seats;
        string finalMsg;

        // Get ID
        id = GetFlightID();
        if (id == -1) return;

        // Check and sort FlightNumber

        flightNumber = GetFlightNumber();
        if (flightNumber == "") return;

        // Get Date/Hour of Flight

        dateHour = dtpFlightDate.Value.Date + dtpFlightHour.Value.TimeOfDay;

        // Check and assign Airports' IDs

        (originID, destID) = GetAirportsIDs();
        if (originID == -1 || destID == -1) return;

        // Check and get selected Aircraft's ID

        airplaneID = GetSelectedAirplaneID();
        if (airplaneID == -1) return;

        // Check and get Number of Seats

        seats = GetAirplaneSeats();
        if (seats < 0) return;


        // Confirm flight

        finalMsg = "Are you sure you want to register this Flight?\n" +
            "\nFlight number: " + flightNumber +
            "\nDate and Time: " + dateHour.ToString()[..^3] +
            "\nFrom: " + cmbAirportOrigin.Text +
            "\nTo: " + cmbAirportDest.Text +
            "\nAirplane: " + cmbAirplane.Text +
            "\nSeats: " + seats;

        if (Form1.ShowMsgBoxQuestionYN(finalMsg, Action) != DialogResult.Yes)
            return;

        try
        {
            _flight = new(
            id,
            flightNumber,
            dateHour,
            originID,
            destID,
            airplaneID,
            seats
            );
        }
        catch
        {
            Form1.ShowMsgBoxError($"error creating object of type {AT_Consts.Flight}.",
                "UC_Flight.SubmitFlight()");
            return;
        }


        if (!SaveFlight(_flight)) return;

        Form1.ShowMsgBoxInfo("The Flight was registered.", Action);
    }


    // Auxiliary Methods

    /// <summary>
    /// Gets an ID for a Flight.
    /// </summary>
    /// <returns>If Creating Flight, returns Max Flight ID +1 (returns 1 if no Flights);
    /// if Editing Flight, returns its current ID;
    /// if it fails, returns -1;</returns>
    int GetFlightID()
    {
        if (Action == "New")
        {
            if (_flights.Count > 0)
                return _flights.Max(f => f.ID) + 1;
            else return 1;
        }

        if (Action == "Edit" && _flight is not null)
            return _flight.ID;

        Form1.ShowMsgBoxError("error at GetFlightID().", "UC_Flight.GetFlightID()");

        return -1;
    }

    /// <summary>
    /// Gets a string like "AT____" where "____" is a whole number between 1 and 9999,
    /// either Automatically or Custom chosen by the user.
    /// </summary>
    /// <returns>Flight number as string if successful; otherwise, Empty.String.</returns>
    string GetFlightNumber()
    {
        string failMsg;

        // If Flight number is set to Auto

        if (txbFlightNumber.Text == "Auto")
        {
            // Try to assign a number 1 through 9999
            for (int i = 1; i < 10000; i++)
            {
                if (_flights.All(f => f.Number[2..] != i.ToString()))
                {
                    return $"AT{i}";
                }
            }

            // If it gets here, no number has been assigned
            failMsg = "\nCould not find an available Flight number.";
            return "";
        }

        // If Flight number is not set to Auto

        if (int.TryParse(txbFlightNumber.Text, out int result) && result > 0 && result < 10000)
            return "AT" + result;

        failMsg = "\nThe number must be 1 to 4 digits, minimum 1 and maximum 9999.";

        Form1.ShowMsgBoxWarning(failMsg, Action);

        // Failed
        return "";
    }

    /// <summary>
    /// Gets the IDs of the Airports selected in ComboBoxes cmbAirportOrigin and cmbAirportDest.
    /// </summary>
    /// <returns>Returns the selected Airports' IDs.
    /// When any of the Airports is not found:
    /// if Searching Flight, return 0 for each Airport not found;
    /// if Creating or Editing Flight, return -1.</returns>
    (int, int) GetAirportsIDs()
    {
        int idO = 0, idD = 0;
        string failMsg = "The Flight was not registered.\n";

        // Check given Origin Action is registered
        try
        {
            if (Action != "Search" || chbSearchOrigin.Checked)
                idO = _airports.FirstOrDefault(
                    a =>
                    a.DisplayMember.Equals(cmbAirportOrigin.Text, StringComparison.OrdinalIgnoreCase)
                    ||
                    a.Code.Equals(cmbAirportOrigin.Text, StringComparison.OrdinalIgnoreCase)
                    )?.ID ?? -1;
        }
        catch { idO = -1; }
        failMsg += idO == -1 ? "\nInvalid origin airport." : "";

        // Check given Destination Action is registered
        try
        {
            if (Action != "Search" || chbSearchDest.Checked)
                idD = _airports.FirstOrDefault(
                    a =>
                    a.DisplayMember.Equals(cmbAirportDest.Text, StringComparison.OrdinalIgnoreCase)
                    ||
                    a.Code.Equals(cmbAirportDest.Text, StringComparison.OrdinalIgnoreCase)
                    )?.ID ?? -1;
        }
        catch { idD = -1; }
        failMsg += idD == -1 ? "\nInvalid destination airport." : "";

        // Check Airports were not found
        if (idO == -1 || idD == -1)
        {
            // If Creating or Editing, SubmitFlight() fails
            if (Action == "Search")
                return ((idO == -1 ? 0 : idO), (idD == -1 ? 0 : idO));
            Form1.ShowMsgBoxWarning(failMsg, Action);

            return (idO, idD);
        }

        // If Origin and Destination Airports are the same
        if (idO == idD && Action != "Search")
        {
            Form1.ShowMsgBoxWarning(
                "The Flight must have different Origin and Destination Airports.", Action);
            return (-1, -1);
        }

        return (idO, idD);
    }

    /// <summary>
    /// Gets the ID of the Airplane selected in ComboBox cmbAirplane.
    /// </summary>
    /// <returns>Returns the selected Airplane's ID, if selected.
    /// Returns 0 if Searching and CheckBox chbSearchAirplane is not Checked.
    /// Returns -1 if not Searching and no Airplane is selected.</returns>
    int GetSelectedAirplaneID()
    {
        int id;

        if (Action == "Search" && !chbSearchAirplane.Checked)
            return 0;
        else
        {
            try { id = ((Airplane)cmbAirplane.SelectedItem)?.ID ?? -1; }
            catch { id = -1; }
        }

        if (id == -1)
        {
            MessageBox.Show("Could not get the selected Airplane.", Action,
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        return id;
    }

    /// <summary>
    /// Gets the number of Seats,
    /// either from the selected Airplane or from Custom choice in NumericUpDown nudCustomSeats.
    /// </summary>
    /// <returns>Returns either the selected Airplane's number of Seats or the Custom number of Seats.
    /// Returns 0 if Searching, and CheckBox chbSearchAirplane is not Checked or selected Airplane is not found.
    /// Returns -1 if not Searching and Airplane is not found.</returns>
    int GetAirplaneSeats()
    {
        if (Action == "Search" && !chbSearchAirplane.Checked)
            return 0;

        if (chbCustomSeats.Checked)
            return (int)nudSeats.Value;

        try
        {
            return _airplanes.First(
                a => a.DisplayMember == cmbAirplane.Text
                ).Seats;
        }
        catch
        {
            MessageBox.Show("Could not find the Plane's number of Seats." +
            "\nIf you want to set a custom number of seats, Check the box.",
            Action, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return Action == "Search" ? 0 : -1;
        }
    }

    /// <summary>
    /// Attempts to Save the Flight in XFiles, when Creating or Editing Flight.
    /// </summary>
    /// <param name="flight">Flight to be saved in XFiles.</param>
    /// <returns>Returns true if successful; otherwise, false.</returns>
    bool SaveFlight(Flight flight)
    {
        bool success = false;
        int tries = 0;

        if (Action == "New")
        {
            do
            {
                try { success = XFiles.SaveItem(flight); }
                catch { tries++; }
            } while (!success && tries < 100);

            if (success)
                _flights.Add(_flight);
        }
        else if (Action == "Edit")
        {
            success = XFiles.EditItem(flight);

            if (success)
            {
                int index = _flights.FindIndex(f => f.ID == flight.ID);
                //_flights[index] = flight;
                _flights.RemoveAt(index);
                _flights.Add(flight);
            }
        }


        if (!success)
        {
            Form1.ShowMsgBoxError("It was not possible to register the Flight.", Action);
            return false;
        }

        return true;
    }

}
