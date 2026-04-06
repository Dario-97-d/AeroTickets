namespace AeroTickets.WinForms.UserControls;

public partial class UC_Customer : UserControl, IAT_UserControl
{
    readonly Form1 _f1;
    //readonly List<Customer> _customers;

    public string Action { get; set; } = null!;

    public UC_Customer(Form1 f)
    {
        InitializeComponent();

        _f1 = f;
        //_customers = f.Customers;
    }

    public string ShowUC(string action)
    {
        Action = action;

        Show();

        return "";
    }
}
