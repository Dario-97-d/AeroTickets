using AeroTickets.ClassLibrary;
using AeroTickets.ClassLibrary.Models;

namespace AeroTickets.WinForms.UserControls;

public partial class UC_Airplane : UserControl, IAT_UserControl
{
    readonly Form1 _f1;
    readonly List<Airplane> _airplanes;

    Airplane _airplane = null!;

    public string Action { get; set; } = null!;

    public UC_Airplane(Form1 f)
    {
        InitializeComponent();

        _f1 = f;
        _airplanes = f.Airplanes;
    }

    /// <summary>
    /// Shows UserControl UC_Airplane.
    /// </summary>
    /// <param name="action">Action for the UserControl. ("New", "Search", "Edit")</param>
    /// <returns>Empty.String if successful; otherwise, error string.</returns>
    public string ShowUC(string action)
    {
        object selectedItem = _f1.GetListViewSelectedItem()!;
        Action = action;
        btnSubmit.Text = action;

        if (selectedItem is null) { _airplane = null!; }
        else
        {
            if (selectedItem.GetType().Name == AT_Consts.Airplane)
            {
                _airplane = (Airplane)selectedItem;
            }
            else _airplane = null!;
        }

        if (Action == "Edit" && _airplane is null)
        {
            Form1.ShowMsgBoxError($"Could not get {AT_Consts.Airplane} to Edit.", Action);
            return "error";
        }

        SetControlsValues();

        Show();

        return "";
    }

    /// <summary>
    /// Sets Controls' values according to selected Airplane in Form1.lsvContent,
    /// if there is one selected. If not, set all values to blank.
    /// </summary>
    void SetControlsValues()
    {
        if (_airplane is not null)
        {
            txbManufacturer.Text = _airplane.Manufacturer;
            txbModel.Text = _airplane.Model;
            txbName.Text = _airplane.Name;
            nudSeats.Value = _airplane.Seats;
        }
        else
        {
            panel1.Controls.OfType<TextBox>().ToList().ForEach(txb => txb.ResetText());
            nudSeats.Value = 0;
        }
    }

    private void nudSeats_KeyPress(object sender, KeyPressEventArgs e)
    {
        // Keys.Back is always accepted
        if (e.KeyChar == (char)Keys.Back) return;

        // Besides Keys.Back, only Digits are accepted
        if (!char.IsDigit(e.KeyChar))
        {
            e.Handled = true;
            return;
        }

        // Only 3 digits are allowed
        if (nudSeats.Text.Length == 3)
        {
            e.Handled = true;
            return;
        }
    }

    private void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Action == "Search")
            SearchAirplane();
        else SubmitAirplane();
    }

    /// <summary>
    /// Prepares a new object of type Airplane and calls Form1.SearchItem().
    /// For each value sought from the user, if the field's CheckBox is Checked,
    /// the new object will have the given value; otherwise, it will get a default value,
    /// so that it won't match any other Airplane's related value.
    /// </summary>
    void SearchAirplane()
    {
        int id = 0;
        string manuf = txbManufacturer.Text.Trim();
        string model = txbModel.Text.Trim();
        string name = txbName.Text.Trim();
        int seats = int.TryParse(nudSeats.Value.ToString(), out seats) ? seats : 0;

        try
        {
            _airplane = new(id, manuf, model, name, seats);
            _f1.SearchItem(_airplane);
        }
        catch
        {
            Form1.ShowMsgBoxError($"Could not create object of type {AT_Consts.Airplane}.",
                "UC_Airplane.SearchAirplane()");
        }
    }

    /// <summary>
    /// Gets and validates the values given by the user to submit Airplane,
    /// either as a New Airplane or as an Edited Airplane. Then, attempts to Save it.
    /// </summary>
    void SubmitAirplane()
    {
        int id;
        string manufacturer, model, name;
        int seats;
        string finalMsg;

        // Check Input

        id = GetAirplaneID();
        if (id == -1) return;

        manufacturer = CheckAirplaneManufacturer();
        if (manufacturer == "") return;

        model = CheckAirplaneModel();
        if (model == "") return;

        name = CheckAirplaneName();
        if (name == "") return;

        seats = GetSeats();
        if (seats == -1) return;

        // Confirm

        finalMsg = "Confirm Airplane:\n" +
            $"\nManufacturer: {manufacturer}" +
            $"\nModel: {model}" +
            $"\nName: {name}" +
            $"\nSeats: {seats}";

        if (Form1.ShowMsgBoxQuestionYN(finalMsg, Action) != DialogResult.Yes) return;

        // Conclude

        _airplane = new(id, manufacturer, model, name, seats);

        // Try to save _airplane
        if (!SaveAirplane()) return;

        // MessageBox Success!
        Form1.ShowMsgBoxInfo("The Airplane was registered.", Action);
    }

    /// <summary>
    /// Gets an ID an Airplane.
    /// </summary>
    /// <returns>If Creating Airplane, returns Max Airplane ID +1 (returns 1 if no Airplanes);
    /// if Editing Airplane, returns its current ID;
    /// if it fails, returns -1.</returns>
    int GetAirplaneID()
    {
        if (Action == "New")
        {
            if (_airplanes.Count > 0)
                return _airplanes.Max(a => a.ID) + 1;
            else return 1;
        }

        if (Action == "Edit" && _airplane is not null)
        {
            return _airplane.ID;
        }

        Form1.ShowMsgBoxError("error at GetAirplaneID().", "UC_Airplane.GetAirplaneID()");

        return -1;
    }

    /// <summary>
    /// Checks whether given string for Manufacturer is valid.
    /// </summary>
    /// <returns>Returns true if successful; otherwise, false.</returns>
    string CheckAirplaneManufacturer()
    {
        string manuf = txbManufacturer.Text = txbManufacturer.Text.Trim();

        if (manuf.Length == 0)
        {
            Form1.ShowMsgBoxWarning("A Manufacturer is required.", Action);
            return "";
        }

        // Allowed characters
        if (!manuf.All(c => char.IsLetterOrDigit(c) || " .-'".Contains(c)))
        {
            Form1.ShowMsgBoxWarning(
                "Manufacturer must contain only letters, numbers, space ( ), dot (.), hyphen (-) and apostrophe (').",
                Action);
            return "";
        }

        //// Minimum letters
        //if (manuf.Select(c => char.IsLetter(c)).ToList().Count < 3)
        //{
        //    Form1.ShowMsgBoxWarning("Manufacturer must contain at least 3 letters.", Action);
        //    return "";
        //}

        return manuf;
    }

    /// <summary>
    /// Checks whether given string for Model is valid.
    /// </summary>
    /// <returns>Returns true if successful; otherwise, false.</returns>
    string CheckAirplaneModel()
    {
        string model = txbModel.Text = txbModel.Text.Trim();

        if (model.Length == 0)
        {
            Form1.ShowMsgBoxWarning("A Model name is required.", Action);
            return "";
        }

        // Possible rules for Airplane Model names
        //if (!model.All(c => char.IsLetter(c) || " .-".Contains(c)))
        //    return "";

        return model;
    }

    /// <summary>
    /// Checks whether given string for Name is valid.
    /// </summary>
    /// <returns>Returns true if successful; otherwise, false.</returns>
    string CheckAirplaneName()
    {
        string name = txbName.Text = txbName.Text.Trim();

        if (name.Length == 0)
        {
            Form1.ShowMsgBoxWarning("A Name is required.", Action);
            return "";
        }

        // Allowed characters
        if (!name.All(c => char.IsLetter(c) || " .-'".Contains(c)))
        {
            Form1.ShowMsgBoxWarning(
                "Name must contain only letters, space ( ), dot (.), hyphen (-) and apostrophe (').",
                Action);
            return "";
        }

        //// Minimum letters
        //if (name.Select(c => char.IsLetter(c)).ToList().Count < 3)
        //{
        //    Form1.ShowMsgBoxWarning("The Airplane Name must contain at least 3 letters.", Action);
        //    return "";
        //}

        // Check there's already an Airplane with this name
        try
        {
            Airplane? airp = _airplanes.FirstOrDefault(a => a.Name == name);

            // If there's no Airplane with chosen name
            if (airp is null)
                return name;

            // If Editing and keeping the name
            try
            {
                if (airp is not null && Action == "Edit" && airp.ID == _airplane.ID)
                    return name;
            }
            catch
            {
                Form1.ShowMsgBoxError(
                    "error at try airp is not null && Action == \"Edit\" && ID == ID.",
                    "UC_Airplane.CheckAirplaneName()");
                return "";
            }

            // If there is already an Airplane with this name

            string msg = "There is already a Plane with this name.\nAssign another name.";
            Form1.ShowMsgBoxWarning(msg, Action);
            return "";
        }
        catch
        {
            Form1.ShowMsgBoxError("error at UC_NewAirplane.CheckAirplaneName()", Action);
            return "";
        }
    }

    /// <summary>
    /// Gets the number of Seats given by the user.
    /// </summary>
    /// <returns>The number of Seats.</returns>
    int GetSeats()
    {
        return (int)nudSeats.Value;
    }

    /// <summary>
    /// Attempts to Save Airplane to XFiles.
    /// </summary>
    /// <param name="_airplane">Airplane to be saved.</param>
    /// <returns>Returns true if successful; otherwise, false.</returns>
    bool SaveAirplane()
    {
        bool success = false;

        if (Action == "New")
        {
            int tries = 0;
            do
            {
                try { success = XFiles.SaveItem(_airplane); }
                catch { tries++; }
            } while (!success && tries < 100);

            if (success)
                _airplanes.Add(_airplane);
        }
        else if (Action == "Edit")
        {
            success = XFiles.EditItem(_airplane);

            if (success)
            {
                int index = _airplanes.FindIndex(a => a.ID == _airplane.ID);
                //_airplanes[index] = _airplane;
                _airplanes.RemoveAt(index);
                _airplanes.Add(_airplane);
            }
        }


        if (!success)
        {
            Form1.ShowMsgBoxError($"Could not edit {AT_Consts.Airplane}.", "UC_Airplane.SubmitAirlane()");
            return false;
        }

        return true;
    }

}
