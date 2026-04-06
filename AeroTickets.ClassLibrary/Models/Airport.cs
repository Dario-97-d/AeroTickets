namespace AeroTickets.ClassLibrary.Models;

public class Airport : AT_Model
{
    public override int ID { get; }
    public override string DisplayMember { get { return $"{Code} ({City})"; } }

    public string Name { get; }
    public string Code { get; }
    public string City { get; }
    public string Country { get; }

    public Airport(int id, string name, string code, string city, string country)
    {
        ID = id;
        Name = name;
        Code = code;
        City = city;
        Country = country;
    }

    public Airport(string[] fields)
    {
        ID = int.TryParse(fields[0], out int result) ? result : 0;
        Name = fields[1];
        Code = fields[2];
        City = fields[3];
        Country = fields[4];
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} {ID}" +
            $"\nName: {Name}\nCode: {Code}\nCity: {City}, {Country}";
    }

    public override string XFilesString()
    {
        return $"{ID};{Name};{Code};{City};{Country}";
    }
}
