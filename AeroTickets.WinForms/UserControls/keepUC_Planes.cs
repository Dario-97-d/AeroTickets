using AeroTickets.ClassLibrary;
using AeroTickets.ClassLibrary.Models;

namespace AeroTickets.WinForms.UserControls;

public partial class keepUC_Planes : UserControl
{
    public List<Airplane> _planes = new();

    public keepUC_Planes()
    {
        InitializeComponent();

        StartListView();
    }

    public void StartListView()
    {
        lsvPlanes.View = View.Details;

        lsvPlanes.Columns.Clear();
        lsvPlanes.Columns.Add("Name", ColumnNameWidth());
        lsvPlanes.Columns.Add("Model", 128);
        lsvPlanes.Columns.Add("Seats", 96);

        UpdateListView();
    }

    int ColumnNameWidth()
    {
        return lsvPlanes.Width - 224;
    }

    void UpdateListView()
    {
        string[] lvi = new string[3];

        lsvPlanes.Items.Clear();

        if (_planes == null) return;

        foreach (Airplane p in _planes)
        {
            try
            {
                lvi[0] = p.Name;
                lvi[1] = p.Model;
                lvi[2] = p.Seats.ToString();
            }
            catch { continue; }

            lsvPlanes.Items.Add(new ListViewItem(lvi));
        }
    }

    private void btnNew_Click(object sender, EventArgs e)
    {
        //Airplane newPlane;
        //int id = _planes.Count + 1;
        //string model = txbModel.Text.Trim();
        //string name = txbName.Text.Trim();
        //int seats = (int)nudSeats.Value;

        //if (!CheckNewPlane(model, name)) return;

        //newPlane = new Airplane(id, name, model, seats);

        //_planes.Add(newPlane);
        //XFiles.SaveItem(newPlane);

        //UpdateListView();

        //txbName.ResetText();
    }

    bool CheckNewPlane(string model, string name)
    {
        if (model.Length == 0)
        {
            MessageBox.Show("A model name is necessary.");
            return false;
        }

        if (name.Length == 0)
        {
            MessageBox.Show("A name is necessary.");
            return false;
        }

        return true;
    }
}
