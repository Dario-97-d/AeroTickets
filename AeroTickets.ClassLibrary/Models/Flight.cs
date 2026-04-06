namespace AeroTickets.ClassLibrary.Models;

public class Flight : AT_Model
{
    public override int ID { get; }
    public override string DisplayMember { get { return $"{Number} - {DateHour:g}"; } }

    public string Number { get; }
    public DateTime DateHour { get; }
    public DateTime FlightDate { get { return DateHour.Date; } }
    public TimeSpan FlightHour { get { return DateHour.TimeOfDay; } }
    public int OriginID { get ; }
    public int DestID { get ; }
    public int AirplaneID { get; }
    public int Seats { get ; }

    public Flight(int id, string number, DateTime dateHour, int originID, int destID, int airpID, int seats)
    {
        ID = id;
        Number = number;
        DateHour = dateHour;
        OriginID = originID;
        DestID = destID;
        AirplaneID = airpID;
        Seats = seats;
    }

    public Flight(string[] fields)
    {
        if (AT_Checks.CheckFieldsFlight(fields) == "")
        {
            ID = int.Parse(fields[0]);
            Number = fields[1];
            DateHour = DateTime.Parse(fields[2]);
            OriginID = int.Parse(fields[3]);
            DestID = int.Parse(fields[4]);
            AirplaneID = int.Parse(fields[5]);
            Seats = int.Parse(fields[6]);
        }
        else
        {
            ID = 0; Number = "0"; DateHour = new DateTime(0);
            OriginID = 0; DestID = 0; AirplaneID = 0; Seats = 0;
        }
    }

    /// <summary>
    /// Checks whether Flight given has any similarity with [this].
    /// </summary>
    /// <param name="flight">Flight to compare.</param>
    /// <returns>Returns true if any of the properties is equal in both Flights; otherwise, false.</returns>
    public bool SearchResult(Flight flight)
    {
        // Check whether Flight given has any similarity with this.
        if (
            Number == flight.Number ||
            DateHour.Date == flight.DateHour.Date ||
            DateHour.TimeOfDay == flight.DateHour.TimeOfDay ||
            OriginID == flight.OriginID ||
            DestID == flight.DestID ||
            Seats == flight.Seats
            )
            return true;
        
        return false;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} {ID}" +
            $"\n{Number} - {DateHour:g}" +
            $"\nFrom (Airport ID): {OriginID}\nTo (Airport ID): {DestID}" +
            $"\nAirplane ID: {AirplaneID}\n{Seats} seats";
    }

    public override string XFilesString()
    {
        return $"{ID};{Number};{DateHour:g};{OriginID};{DestID};{AirplaneID};{Seats}";
    }

}
