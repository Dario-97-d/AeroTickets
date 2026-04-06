using AeroTickets.ClassLibrary.Models;

namespace AeroTickets.ClassLibrary;

public static class AT_Checks
{
    // Checks for XFiles

    /// <summary>
    /// Checks whether the fields given are suitable for creation of new object of the given type.
    /// </summary>
    /// <param name="type">Type of object as string.</param>
    /// <param name="fields">Fields used for new object.</param>
    /// <returns>Empty.String if successful; otherwise, error string.</returns>
    public static string CheckFields(string type, string[] fields)
    {
        switch (type)
        {
            case string s when s == AT_Consts.Airplane: return CheckFieldsAirplane(fields);
            case string s when s == AT_Consts.Airport: return CheckFieldsAirport(fields);
            //case string s when s == AT_Consts.Customer: return CheckFieldsCustomer(fields);
            case string s when s == AT_Consts.Flight: return CheckFieldsFlight(fields);
            case string s when s == AT_Consts.Ticket: return CheckFieldsTicket(fields);
        }

        // Success
        return "";
    }

    /// <summary>
    /// Checks whether the fields given are suitable for creation of new object of type Airplane.
    /// </summary>
    /// <param name="fields">Fields used for new Airplane</param>
    /// <returns>Empty.String if successful; otherwise, error string.</returns>
    public static string CheckFieldsAirplane(string[] fields)
    {
        string where = " in CheckFieldsAirplane(), AT_Checks.cs";
        
        if (fields.Length != XFiles.AirplaneFieldsCount)
            return "error fields.Length" + where;

        // ID
        if (!int.TryParse(fields[0], out _))
            return "error ID TryParse" + where;

        // Manufacturer
        if (string.IsNullOrEmpty(fields[1]) || !fields[1].All(c => char.IsLetter(c) || " .-".Contains(c)))
            return "error Manufacturer" + where;

        // Model
        if (string.IsNullOrEmpty(fields[2]) || !fields[2].All(c => char.IsLetterOrDigit(c) || " .-".Contains(c)))
            return "error Model" + where;

        // Name
        if (string.IsNullOrEmpty(fields[3]) || !fields[3].All(c => char.IsLetter(c) || " .-".Contains(c)))
            return "error Name" + where;

        // Seats
        if (!int.TryParse(fields[4], out _))
            return "error Seats TryParse" + where;

        // Success
        return "";
    }

    /// <summary>
    /// Checks whether the fields given are suitable for creation of new object of type Airport.
    /// </summary>
    /// <param name="fields">Fields used for new Airport.</param>
    /// <returns>Empty.String if successful; otherwise, error string.</returns>
    public static string CheckFieldsAirport(string[] fields)
    {
        if (fields.Length != XFiles.AirportFieldsCount) return "error fields.Length in AT_Checks.cs";

        // ID
        if (!int.TryParse(fields[0], out _)) return "error ID TryParse in AT_Checks.cs";

        // Name
        if (fields[1].Trim().Length == 0) return "error empty Name in AT_Checks.cs";

        // IATA code
        if (fields[2].Length != 3 || !fields[2].All(char.IsLetter)) return "error IATA code in AT_Checks.cs";

        // City
        if (fields[3].Length == 0) return "error City in AT_Checks.cs";

        // Country
        if (fields[4].Length == 0) return "error Country in AT_Checks.cs";

        return "";
    }

    /// <summary>
    /// Checks whether the fields given are suitable for creation of new object of type Flight.
    /// </summary>
    /// <param name="fields">Fields used for new Flight.</param>
    /// <returns>Empty.String if successful; otherwise, error message.</returns>
    public static string CheckFieldsFlight(string[] fields)
    {
        if (fields.Length != XFiles.FlightFieldsCount)
            return "error fields.Length in CheckFieldsFlight, AT_Checks.cs";

        // ID
        if (!int.TryParse(fields[0], out _))
            return "error ID TryParse in CheckFieldsFlight, AT_Checks.cs";

        // Flight Number
        if (fields[1][..2] != "AT")
            return "error Flight Number doesn't start with \"AT\" in CheckFieldsFlight, AT_Checks.cs";
        if (!int.TryParse(fields[1][2..], out int result) || result < 1 || result > 9999)
            return "error Flight Number out of bounds in CheckFieldsFlight, AT_Checks.cs";

        // DateHour
        if (!DateTime.TryParse(fields[2], out _))
            return "error dateHour in CheckFieldsFlight, AT_Checks.cs";

        // OriginID, DestID, AirplaneID, Seats
        if (fields[3..].Select(int.Parse).ToArray().Length != 4)
            return "error OriginID, DestID, AircraftID, Seats TryParse in CheckFieldsFlight, AT_Checks.cs";
        
        // Success
        return "";
    }

    /// <summary>
    /// Checks whether the fields given are suitable for creation of new object of type Ticket.
    /// </summary>
    /// <param name="fields">Fields used for new Ticket.</param>
    /// <returns>Empty.String if successful; otherwise, error string.</returns>
    public static string CheckFieldsTicket(string[] fields)
    {
        if (fields.Length != XFiles.TicketFieldsCount)
            return "error fields.Length in CheckFieldsTicket(), AT_Checks.cs";

        // ID
        if (!int.TryParse(fields[0], out _))
            return "error ID TryParse in CheckFieldsTicket(), AT_Checks.cs";

        // Reference
        if (fields[1].Contains(';'))
            return "error Reference in CheckFieldsTicket(), AT_Checks.cs";

        // FlightID
        if (!int.TryParse(fields[2], out _))
            return "error FlightID TryParse in CheckFieldsTicket(), AT_Checks.cs";

        // Seat
        if (!int.TryParse(fields[3], out _))
            return "error Seat TryParse in CheckFieldsTicket(), AT_Checks.cs";

        // CustomerID
        if (!int.TryParse(fields[4], out _))
            return "error CustomerID TryParse in CheckFieldsTicket(), AT_Checks.cs";

        // CustomerName
        if (fields[5].Contains(';'))
            return "error CustomerName Contains(';') in CheckFieldsTicket(), AT_Checks.cs";

        return "";
    }

}
