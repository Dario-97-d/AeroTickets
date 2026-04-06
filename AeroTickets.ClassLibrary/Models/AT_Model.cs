namespace AeroTickets.ClassLibrary.Models;

public abstract class AT_Model : IXFiles
{
    public abstract int ID { get; }
    public abstract string DisplayMember { get; }
    public abstract override string ToString();
    public abstract string XFilesString();

    public bool SearchResult(AT_Model item)
    {
        if (GetType() != item.GetType())
            return false;

        System.Reflection.PropertyInfo[] properties = GetType().GetProperties();

        for (int i = 0; i < properties.Length; i++)
        {
            if (properties[i].Name == "DisplayMember")
                continue;

            object valueThis = properties[i].GetValue(this)!;
            object valueGiven = properties[i].GetValue(item)!;

            if (valueThis.Equals(valueGiven))
                return true;
        }

        return false;
    }
}
