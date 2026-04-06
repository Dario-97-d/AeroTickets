namespace AeroTickets.ClassLibrary.Models;

public class Customer : AT_Model
{
    string _country;
    int _citizenNumber;
    string _email;
    string _phone;

    public override int ID { get; }
    public override string DisplayMember { get { return $"property not implemented"; } }

    public string Name { get; }
    public string Type { get; }

    public Customer(int id, string name, string type, string country, int citizenID, string email, string phone)
    {
        ID = id;
        Name = name;
        Type = type;
        _country = country;
        _citizenNumber = citizenID;
        _email = email;
        _phone = phone;
    }

    public Customer(string[] fields)
    {
        ID = int.Parse(fields[0]);
        Name = fields[1];
        Type = fields[2];
        _country = fields[3];
        _citizenNumber = int.Parse(fields[4]);
        _email = fields[5];
        _phone = fields[6];
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} {ID}" +
            $"\nName: {Name}\nType: {Type}" +
            $"Country: {_country}, Citizen number: {_citizenNumber}" +
            $"\nE-mail: {_email}\nPhone number: {_phone}";
    }

    public override string XFilesString()
    {
        return $"{ID};{Name};{Type};{_country};{_citizenNumber};{_email};{_phone}";
    }
}
