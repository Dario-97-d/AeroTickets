namespace AeroTickets.ClassLibrary.Models;

public class Schedule : AT_Model
{
    List<(DayOfWeek, TimeOnly)> _scheds;

    public override int ID { get; }
    public override string DisplayMember { get { return $"property not implemented"; } }

    public string Name { get; }
    public int AirplaneID { get; }
    public int Seats { get; }
    public int OriginID { get ; }
    public int DestID { get ; }
    public List<(DayOfWeek, TimeOnly)> Scheds { get { return _scheds; } }

    public Schedule(int id, string name, int originID, int destID)
    {
        ID = id;
        Name = name;
        OriginID = originID;
        DestID = destID;
        _scheds = new List<(DayOfWeek, TimeOnly)>();
    }

    public Schedule(string[] fields)
    {
        ID = int.Parse(fields[0]);
        Name = fields[1];
        OriginID = int.Parse(fields[2]);
        DestID = int.Parse(fields[3]);
        _scheds = new List<(DayOfWeek, TimeOnly)> ();
    }

    public override string ToString()
    {
        return
            $"ID: {ID} -- Name:{Name} -- Plane ID: {AirplaneID} -- Seats: {Seats} -- " +
            $"Origin Airport ID: {OriginID} -- Destination Airport ID: {DestID} -- " +
            $"\nWeekday - hour:" +
            $"\n{_scheds}";
    }

    public override string XFilesString()
    {
        string scheds = "";
        foreach ((DayOfWeek, TimeOnly) sched in _scheds)
        {
            scheds += sched;
        }
        return $"{ID};{Name};{AirplaneID};{Seats};{OriginID};{DestID};{_scheds}";
    }
}
