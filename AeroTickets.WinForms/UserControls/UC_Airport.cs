using AeroTickets.ClassLibrary;
using AeroTickets.ClassLibrary.Models;
using System.Text.RegularExpressions;

namespace AeroTickets.WinForms.UserControls;

public partial class UC_Airport : UserControl, IAT_UserControl
{
    readonly Form1 _f1;
    readonly List<Airport> _airports;

    Airport _airport = null!;

    public string Action { get; set; } = null!;

    public UC_Airport(Form1 f)
    {
        InitializeComponent();

        _f1 = f;
        _airports = f.Airports;
    }


    /// <summary>
    /// Shows UserControl UC_Airport.
    /// </summary>
    /// <param name="action">Action for the UserControl. ("New", "Search", "Edit")</param>
    /// <returns>Empty.String.</returns>
    public string ShowUC(string action)
    {
        object selectedItem = _f1.GetListViewSelectedItem()!;

        Action = action;
        btnSubmit.Text = action;

        if (selectedItem is null)
            _airport = null!;
        else
        {
            if (selectedItem.GetType().Name == AT_Consts.Airport)
            {
                _airport = (Airport)selectedItem;
            }
        }

        if (Action == "Edit" && _airport is null)
        {
            Form1.ShowMsgBoxError($"Could not get {AT_Consts.Airport} to Edit.", "UC_Airport.ShowUC()");
            return "error";            
        }

        SetControlsValues();

        Show();

        return "";
    }

    /// <summary>
    /// Sets Controls' values according to selected Airport in Form1.lsvContent,
    /// if there is one selected. If not, set all values to blank.
    /// </summary>
    void SetControlsValues()
    {
        if (_airport is not null)
        {
            txbAirportName.Text = _airport.Name;
            txbCode.Text = _airport.Code;
            txbCity.Text = _airport.City;
            txbCountry.Text = _airport.Country;
        }
        else
        {
            panel1.Controls.OfType<TextBox>().ToList().ForEach(txb => txb.ResetText());
        }
    }


    // Events

    private void txbAirportName_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Back)
            return;

        if (!char.IsLetterOrDigit(e.KeyChar) && !" .-'".Contains(e.KeyChar))
            e.Handled = true;
    }

    private void txbCode_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Back)
            return;

        if (!char.IsLetter(e.KeyChar))
            e.Handled = true;

        if (txbCode.Text.Length >= 3 && txbCode.SelectionLength < 1)
            e.Handled = true;
    }

    private void TextBoxesCityCountry_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsLetter(e.KeyChar) && !" .-".Contains(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            e.Handled = true;
    }

    private void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Action == "Search")
        {
            SearchAirport();
        }
        else
        {
            SubmitAirport();

            // Clear all TextBoxes
            Controls.OfType<TextBox>().ToList().ForEach(txb => txb.Clear());
        }
    }


    // Auxiliary Methods

    /// <summary>
    /// Prepares a new object of type Airport and calls Form1.SearchItem().
    /// For each value sought from the user, if the field's CheckBox is Checked,
    /// the new object will have the given value; otherwise, it will get a default value,
    /// so that it won't match any other Airport's related value.
    /// </summary>
    void SearchAirport()
    {
        try
        {
            _airport = new(
                0,
                txbAirportName.Text,
                txbCode.Text.ToUpper(),
                txbCity.Text,
                txbCountry.Text
                );
        }
        catch
        {
            Form1.ShowMsgBoxError($"Could not create new object of Type {AT_Consts.Airport}", Action);
            return;
        }

        _f1.SearchItem(_airport);
    }

    /// <summary>
    /// Gets and validates the values given by the user to submit Airport,
    /// either as a New Airport or as an Edited Airport. Then, attempts to Save it.
    /// </summary>
    void SubmitAirport()
    {
        int id = GetAirportID();
        string name = txbAirportName.Text.Trim();
        string code = txbCode.Text.Trim().ToUpper();
        string city = txbCity.Text.Trim();
        string country = txbCountry.Text.Trim();

        if (id == -1) return;

        if (!CheckUserInput(name, code, city, country)) return;

        _airport = new Airport(id, name, code, city, country);

        if (CheckAirportCodeIsRegistered()) return;

        if (!SaveAirport()) return;

        Form1.ShowMsgBoxInfo("The airport was registered.", $"{Action} {AT_Consts.Airport}");
    }

    /// <summary>
    /// Gets an ID for an Airport.
    /// </summary>
    /// <returns>If Creating Airport, returns Max Airport ID +1 (returns 1 if no Airports);
    /// if Editing Airport, returns its current ID;
    /// if it fails, returns -1;</returns>
    int GetAirportID()
    {
        if (Action == "New")
        {
            if (_airports.Count > 0)
                return _airports.Max(a => a.ID) + 1;
            else return 1;
        }
        
        if (Action == "Edit" && _airport is not null)
            return _airport.ID;

        Form1.ShowMsgBoxError("error at GetAirportID().", "UC_Airport.GetAirportID()");

        return -1;
    }

    /// <summary>
    /// Checks whether user input is valid for creating object of type Airport.
    /// </summary>
    /// <param name="name">Name for the Airport.</param>
    /// <param name="code">IATA code for the Airport.</param>
    /// <param name="city">City the Airport serves.</param>
    /// <param name="country">Country of the Airport.</param>
    /// <returns>Returns true if successful; otherwise, false.</returns>
    bool CheckUserInput(string name, string code, string city, string country)
    {
        if (name.Length == 0)
        {
            Form1.ShowMsgBoxWarning("The airport name is required.", Action);
            return false;
        }

        if (code.Length != 3 || !Regex.IsMatch(code, @"^[A-Z]+$"))
        {
            Form1.ShowMsgBoxWarning("The code must have 3 letters.", Action);
            return false;
        }

        if (city.Length == 0)
        {
            Form1.ShowMsgBoxWarning("The city is required.", Action);
            return false;
        }

        if (!city.All(c => char.IsLetter(c) || " .-".Contains(c)))
        {
            Form1.ShowMsgBoxWarning(
                "The city name must contain only letters, space, dot (.) and hyphen (-).", Action);
            return false;
        }

        if (country.Length == 0)
        {
            Form1.ShowMsgBoxWarning("The country is required.", Action);
            return false;
        }

        if (!country.All(c => char.IsLetter(c)))
        {
            Form1.ShowMsgBoxWarning("The country must contain letters only.", Action);
            return false;
        }

        return true;
    }

    /// <summary>
    /// Checks whether given Airport's Code is already registered.
    /// </summary>
    /// <returns>Returns true if Airport's Code is registered; otherwise, false.</returns>
    bool CheckAirportCodeIsRegistered()
    {
        try
        {
            if (_airports.Any(a => a.Code == _airport.Code && a.ID != _airport.ID))
            {
                string msg = "The Airport was not registered." +
                        "\nAn Airport with this IATA code already exists.";

                Form1.ShowMsgBoxWarning(msg, Action);
                return true;
            }
        }
        catch
        {
            Form1.ShowMsgBoxError($"There was a problem checking this {AT_Consts.Airplane}.", Action);
        }

        return false;
    }

    /// <summary>
    /// Attempts to Save Airport to XFiles and then Add it to its List in Form1.
    /// </summary>
    /// <returns>Returns true if successful; otherwise, false.</returns>
    bool SaveAirport()
    {
        bool success = false;

        if (Action == "New")
        {
            int tries = 0;
            do
            {
                try { success = XFiles.SaveItem(_airport); }
                catch { tries++; }
            } while (!success && tries < 100);

            if (success)
                _airports.Add(_airport);
        }
        else if (Action == "Edit")
        {
            success = XFiles.EditItem(_airport);

            if (success)
            {
                int index = _airports.FindIndex(a => a.ID == _airport.ID);
                //_airports[index] = _airport;
                if(index != -1)
                {
                    _airports.RemoveAt(index);
                    _airports.Add(_airport);
                }
                else
                {
                    Form1.ShowMsgBoxError($"error at _airports.RemoveAt(index).", "UC_Airport.SubmitAirport()");
                    return false;
                }
            }
        }


        if (!success)
        {
            Form1.ShowMsgBoxError($"Could not edit {AT_Consts.Airport}.", "UC_Airport.SubmitAirport()");
            return false;
        }

        return true;
    }

}
