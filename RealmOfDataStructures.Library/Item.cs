namespace RealmOfDataStructures.Item;
using RealmOfDataStructures.Hero;


public abstract class Item
{
    public Item(string itemName, Hero owner)
    {
        ItemName = itemName;
        Owner = owner;
    }
    public Guid guid = Guid.NewGuid();
    public string ItemName { get; set; }
    public Hero Owner { get; set; }
    public virtual void Use(string? msg)
    {
        Console.WriteLine(msg);
        RemoveItem();
    }
    private void RemoveItem()
    {
        Item[] remainingItems = Owner.Pouch.Where(i => i == null || i.guid != guid).ToArray();
        for (int i = 0; i < remainingItems.Length; i++)
        {
            Owner.Pouch[i] = remainingItems[i];
        }
    }
}

public class PotionOfHealing : Item
{
    public int Strength { get; init; }
    public PotionOfHealing(string itemName, Hero owner, int strength) : base(itemName, owner)
    {
        Strength = strength;
    }
    public override void Use(string? msg)
    {
        Owner.Health += Strength;
        // Remove Item
        base.Use($"You used {ItemName} and gained {Strength} Health");
    }
}
public class PotionOfStrength : Item
{
    public int Strength { get; init; }
    public PotionOfStrength(string itemName, Hero owner, int strength) : base(itemName, owner)
    {
        Strength = strength;
    }
    public override void Use(string? msg)
    {
        Owner.Health += Strength;
        // Remove Item        
        base.Use($"You used {ItemName} and gained {Strength} strength");
    }
}

public class StoneOfResurrection : Item
{
    public StoneOfResurrection(Hero owner, string itemName = "Stone of Resurrection") : base(itemName, owner)
    {
    }
    public override void Use(string? msg)
    {
        Owner.Resurrect();
        // Remove Item        
        base.Use($"You used {ItemName} and have been Resurrected to the Realm of Living Data Structures");
    }
}

public class Rock : Item
{
    public Rock(string itemName, Hero owner) : base(itemName, owner)
    {
    }

}

public class Key : Item
{
    public String Unlocks { get; set; }
    public Key(string itemName, Hero owner, string unlocks) : base(itemName, owner)
    {
        Unlocks = unlocks;
    }
}