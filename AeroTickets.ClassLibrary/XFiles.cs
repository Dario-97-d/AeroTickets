using AeroTickets.ClassLibrary.Models;

namespace AeroTickets.ClassLibrary;

public static class XFiles
{
    /// <summary>
    /// List of custom Class Names.
    /// </summary>
    static readonly List<string> _types = AT_Consts.ATTypes;

    static readonly string _pathAirplanes = @"XFiles_airplanes.txt";
    static readonly string _pathAirports = @"XFiles_airports.txt";
    static readonly string _pathCustomers = @"XFiles_customers.txt";
    static readonly string _pathFlights = @"XFiles_flights.txt";
    static readonly string _pathTickets = @"XFiles_tickets.txt";
    static readonly string _pathSchedules = @"XFiles_schedules.txt";


    static readonly string _headerFileWarning =
        "WARNING! DO NOT CHANGE THIS FILE UNLESS YOU UNDERSTAND WHAT YOU'RE DOING.\n";

    static readonly string _headerFileAirplanes = _headerFileWarning +
        "XFiles-Airplanes\r\nID-MANUFACTURER-MODEL-NAME-SEATS\n---";

    static readonly string _headerFileAirports = _headerFileWarning +
        "XFiles-Airports\r\nID-NAME-CODE-CITY-COUNTRY\n---";

    static readonly string _headerFileCustomers = _headerFileWarning +
        "XFiles-Customers\r\nID-NAME-COUNTRY-CITIZENID\n---";

    static readonly string _headerFileFlights = _headerFileWarning +
        "XFiles-Flights\r\nID-NUMBER-DATEHOUR-ORIGINID-DESTINATIONID-AIRPLANEID-SEATS\n---";

    static readonly string _headerFileTickets = _headerFileWarning +
        "XFiles-Tickets\r\nID-REFERENCE-FLIGHTID-SEAT-CUSTOMERID-CUSTOMERNAME\n---";

    static readonly string _headerFileSchedules = _headerFileWarning +
        "XFile-Schedules\r\nID-NAME-PLANEID-SCHEDS\n---";


    // Required fields count when checking for new object
    public static int AirplaneFieldsCount { get; } = 5;
    public static int AirportFieldsCount { get; } = 5;
    public static int CustomerFieldsCount { get; } = 7;
    public static int FlightFieldsCount { get; } = 7;
    public static int TicketFieldsCount { get; } = 6;
    public static int ScheduleFieldsCount { get; } = 7;


    /// <summary>
    /// Holds standard XFiles information for each custom Class:
    /// XFiles path, XFiles header, number of string[] fields required for new object.
    /// </summary>
    static readonly Dictionary<string, (string path, string header, int fieldsCount)> _typeInfo = new()
    {
        { _types[0], (_pathAirplanes, _headerFileAirplanes, AirplaneFieldsCount) },
        { _types[1], (_pathAirports, _headerFileAirports, AirportFieldsCount) },
        { _types[2], (_pathCustomers, _headerFileCustomers, CustomerFieldsCount) },
        { _types[3], (_pathFlights, _headerFileFlights, FlightFieldsCount)},
        { _types[4], (_pathTickets, _headerFileTickets, TicketFieldsCount) },
        { _types[5], (_pathSchedules, _headerFileSchedules, ScheduleFieldsCount) }
    };


    /// <summary>
    /// Loads a List of objects of a class derived from AT_Model.
    /// </summary>
    /// <param name="type">Type of items to be loaded.</param>
    /// <returns>List of objects of given type. Returns new() if not successful.</returns>
    public static List<AT_Model> LoadItems(string type)
    {
        List<AT_Model> list = new();
        string path;

        path = SortPath(type);

        if (File.Exists(path))
        {
            StreamReader sr;
            string[] fields;
            string? line;

            try
            {
                sr = File.OpenText(path);

                while ((line = sr.ReadLine()) != null)
                {
                    fields = line.Split(';').Select(f => f.Trim()).ToArray();

                    if (CheckFieldsItem(type, fields) != "") continue;

                    if (AddToList(list, type, fields) != "") return list;
                }
            }
            catch { return new List<AT_Model>(); }

            sr.Close();
        }

        return list;
    }

    /// <summary>
    /// Sorts path to XFiles file related to given type.
    /// </summary>
    /// <param name="type">Type related to XFiles file.</param>
    /// <returns>Path of file if sucessfully sorted; otherwise, returns Empty.String.</returns>
    static string SortPath(string type)
    {
        string path;
        try
        {
            path = _typeInfo[type].path;
        }
        catch { return ""; }

        return path;
    }

    /// <summary>
    /// Checks whether fields[] is valid for new object of given type.
    /// </summary>
    /// <param name="type">Type of object as string</param>
    /// <param name="fields">Fields used for new object</param>
    /// <returns>Empty.String if Check was successful; else, returns error string.</returns>
    static string CheckFieldsItem(string type, string[] fields)
    {
        if (fields.Length < _typeInfo[type].fieldsCount)
            return "error fields.Length in XFiles.cs";

        return AT_Checks.CheckFields(type, fields);
    }

    /// <summary>
    /// Calls the constructor for an object of the type given,
    /// with fields[] as argument for the object's values,
    /// and Adds it to the given List.
    /// </summary>
    /// <param name="list">List for the new object to be Added to.</param>
    /// <param name="type">Type of object as string.</param>
    /// <param name="fields">Arguments for new object.</param>
    /// <returns>Empty.String if sucessful; otherwise, returns error string.</returns>
    static string AddToList(List<AT_Model> list, string type, string[] fields)
    {
        try
        {
            switch (type)
            {
                case string s when s == AT_Consts.Airplane: list.Add(new Airplane(fields)); return "";
                case string s when s == AT_Consts.Airport: list.Add(new Airport(fields)); return "";
                case string s when s == AT_Consts.Customer: list.Add(new Customer(fields)); return "";
                case string s when s == AT_Consts.Flight: list.Add(new Flight(fields)); return "";
                case string s when s == AT_Consts.Ticket: list.Add(new Ticket(fields)); return "";
                case string s when s == AT_Consts.Schedule: list.Add(new Schedule(fields)); return "";
            }
        }
        catch { return "error catch in AddToList(), XFiles.cs"; }

        return "error type not found in AddToList(), XFiles.cs";
    }

    /// <summary>
    /// Saves the item given to a file, according to the item's type.
    /// </summary>
    /// <param name="item">Item to be saved in file.</param>
    /// <returns>Returns true if successful; otherwise, false.</returns>
    public static bool SaveItem(AT_Model item)
    {
        StreamWriter sw;
        string type = item.GetType().Name;
        string path = _typeInfo[type].path;

        if (path == "") return false;

        if (!File.Exists(path))
        {
            if (!CreateFileItems(type, path)) return false;
        }

        sw = new(path, true);

        sw.WriteLine(item.XFilesString());
        sw.Close();

        return true;
    }

    /// <summary>
    /// Creates XFiles file on path given, according to the type of object to be saved.
    /// </summary>
    /// <param name="type">Type of object as string.</param>
    /// <param name="path">Path for the creation of the file.</param>
    /// <returns>Returns true if successful; otherwise, false.</returns>
    static bool CreateFileItems(string type, string path)
    {
        try
        {
            StreamWriter sw = File.CreateText(path);
            sw.WriteLine(_typeInfo[type].header);
            sw.Close();
        }
        catch { return false; }

        return true;
    }

    /// <summary>
    /// Deletes from XFiles all records where ID == item.ID.
    /// </summary>
    /// <param name="item">Item to be deleted.</param>
    /// <returns>Returns true if successful; otherwise, false.</returns>
    public static bool DeleteItem(AT_Model item)
    {
        string path = _typeInfo[item.GetType().Name].path;

        try
        {
            if (File.Exists(path))
            {
                string tempFile = Path.GetTempFileName();

                File.WriteAllLines(tempFile, File.ReadLines(path).Where(
                    line => !(line.Contains(';') && int.TryParse(line[..line.IndexOf(';')], out int result) && result == item.ID)
                    ));

                File.Delete(path);
                File.Move(tempFile, path);

                //File.WriteAllLines(path, File.ReadLines(path).Where(
                //    line => int.TryParse(line[..line.IndexOf(';')], out int result) && result != item.ID
                //    ));
            }
        }
        catch { return false; }

        return true;
    }

    /// <summary>
    /// Deletes Item's current record on ID match and Saves Item Item's current info.
    /// </summary>
    /// <param name="item">Item to be edited.</param>
    /// <returns>Returns true if succesful; otherwise, false.</returns>
    public static bool EditItem(AT_Model item)
    {
        try
        {
            if (DeleteItem(item))
                return SaveItem(item);
        }
        catch { }

        return false;
    }

}
