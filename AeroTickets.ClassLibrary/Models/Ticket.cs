namespace AeroTickets.ClassLibrary.Models;

public class Ticket : AT_Model
{
    public override int ID { get; }
    public override string DisplayMember { get; } = "property not implemented";

    public string Reference { get; }
    public int FlightID { get; }
    public int Seat { get; set; }
    public int CustomerID { get; }
    public string CustomerName { get; set; }

    public Ticket(int id, string refr, int flightID, int seat, int customerID, string customerName)
    {
        ID = id;
        Reference = refr;
        FlightID = flightID;
        Seat = seat;
        CustomerID = customerID;
        CustomerName = customerName;
    }

    public Ticket(string[] fields)
    {
        if (AT_Checks.CheckFieldsTicket(fields) == "")
        {
            ID = int.Parse(fields[0]);
            Reference = fields[1];
            FlightID = int.Parse(fields[2]);
            Seat = int.Parse(fields[3]);
            CustomerID = int.Parse(fields[4]);
            CustomerName = fields[5];
        }
        else
        {
            ID = 0;
            Reference = "";
            FlightID = 0;
            Seat = 0;
            CustomerID = 0;
            CustomerName = "";
        }
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} {ID}" +
            $"\nRef: {Reference}\nFlightID: {FlightID}\nSeat: {Seat}" +
            $"\nCustomer: {CustomerID} - {CustomerName}";
    }

    public override string XFilesString()
    {
        return $"{ID};{Reference};{FlightID};{Seat};{CustomerID};{CustomerName}";
    }
}
