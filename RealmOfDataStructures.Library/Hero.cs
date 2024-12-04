namespace RealmOfDataStructures.Hero;
using Item;
using Room;
using Equipment;

public class Hero
{
    public string HeroName { get; set; }
    public int Health { get; set; } = 100;
    public int Strength { get; set; } = 10;
    public int Inteligence { get; set; } = 10;
    public int Agility { get; set; } = 10;
    public Item[] Pouch { get; set; } = new Item[5];
    public Equipment[] Equipped { get; set; } = new Equipment[5];
    public Room CurrentRoom { get; set; }

    public Hero()
    {
    }

    public string PickUpItem(Item newItem)
    {
        for (int i = 0; i < Pouch.Length; i++)
        {
            if (Pouch[i] == null)
            {
                Pouch[i] = newItem;
                break;
            }
        }
        return $"Inventory is full! Would you like to add {newItem} and drop {Pouch[0].ItemName}";
    }

    public void Resurrect()
    {
        Console.WriteLine("Welcome back to the land of the living");

    }

    public void LevelUp()
    {
    }

    public void CalculateTotals()
    {
    }
}
