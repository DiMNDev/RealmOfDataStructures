namespace RealmOfDataStructures.Equipment;
public class Equipment
{
    public Equipment_Type Type { get; set; }
}

public enum Equipment_Type
{
    Weapon,
    Charm,
    Ring,
    Armor
}