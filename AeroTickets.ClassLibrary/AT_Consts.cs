using AeroTickets.ClassLibrary.Models;

namespace AeroTickets.ClassLibrary;

public static class AT_Consts
{
    // AT Custom Class' Names
    /// <summary>
    /// Class name: Airplane.
    /// </summary>
    public static string Airplane { get; } = typeof(Airplane).Name;
    /// <summary>
    /// Class name: Airport.
    /// </summary>
    public static string Airport { get; } = typeof(Airport).Name;
    /// <summary>
    /// Class name: Customer.
    /// </summary>
    public static string Customer { get; } = typeof(Customer).Name;
    /// <summary>
    /// Class name: Flight.
    /// </summary>
    public static string Flight { get; } = typeof(Flight).Name;
    /// <summary>
    /// Class name: Schedule.
    /// </summary>
    public static string Schedule { get; } = typeof(Schedule).Name;
    /// <summary>
    /// Class name: Ticket.
    /// </summary>
    public static string Ticket { get; } = typeof(Ticket).Name;

    /// <summary>
    /// List of custom Class Names.
    /// </summary>
    public static List<string> ATTypes = new()
    {
        Airplane, Airport, Customer, Flight, Ticket, Schedule
    };
}
