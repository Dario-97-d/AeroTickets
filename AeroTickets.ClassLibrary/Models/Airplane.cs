namespace AeroTickets.ClassLibrary.Models;

public class Airplane : AT_Model
{
    public override int ID { get; }
    public override string DisplayMember { get { return $"{ID}: {Model}, {Seats} seats"; } }

    public string Manufacturer { get; }
    public string Model { get; }
    public string Name { get; }
    public int Seats { get; }

    public Airplane(int id, string manufacturer, string model, string name, int seats)
    {
        ID = id;
        Manufacturer = manufacturer;
        Model = model;
        Name = name;
        Seats = seats;
    }

    public Airplane(string[] fields)
    {
        ID = int.TryParse(fields[0], out int result) ? result : 0;
        Manufacturer = fields[1];
        Model = fields[2];
        Name = fields[3];
        Seats = int.TryParse(fields[4], out result) ? result : 0;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} {ID}" +
            $"\nManufacturer: {Manufacturer}\nModel: {Model}\nName: {Name}\nSeats: {Seats}";
    }

    public override string XFilesString()
    {
        return $"{ID};{Manufacturer};{Model};{Name};{Seats}";
    }
}
