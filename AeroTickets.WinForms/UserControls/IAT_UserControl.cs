namespace AeroTickets.WinForms.UserControls;

public interface IAT_UserControl
{
    public string Action { get; set; }

    public string ShowUC(string action);
}
