namespace Challenges;
using RealmOfDataStructures.ChalengeTree;
using RealmOfDataStructures.Hero;
using RealmOfDataStructures.Item;

public class LivingRealmChallenges : ChallengeTree
{
    public LivingRealmChallenges()
    {
        #region Challenge 1
        Challenge c1 = new(1, "You discovered A rock. What do you do?", ["Leave it.", "Pick it up.", "Kick it."]);
        c1.Funcs.Add(0, (hero) => Console.WriteLine("You left the Rock undisturbed"));
        c1.Funcs.Add(1, (hero) => { hero.PickUpItem(new Rock("Basic Rock", hero)); Console.WriteLine("You picked up the rock. Dispersing baby spiders."); });
        c1.Funcs.Add(2, (hero) => Console.WriteLine("You kicked the rock. Dispersing baby spiders."));
        Insert(c1);
        #endregion
        #region Challenge 2
        Challenge c2 = new(2, "There is a chest in the corner of the room. What do you do?", ["Leave it.", "Open it."]);
        c2.Funcs.Add(0, (hero) => Console.WriteLine("You can always check back"));
        c2.Funcs.Add(1, (hero) => { Console.WriteLine("You aquired a Potion of Healing!"); hero.PickUpItem(new PotionOfHealing("Potion of Healing", hero, 20)); });
        Insert(c2);
        #endregion
        #region Challenge 3
        #region Challenge 3.2
        Challenge c3_2 = new(3, "One of the bats you slayed is lying on the ground dead. It has something shiny!", ["Inspect", "Leave",]);
        c3_2.Funcs.Add(0, (hero) => { Console.WriteLine("You found a key!"); hero.PickUpItem(new Key("Serpent Key", hero, "GreenRoomChest")); });
        c3_2.Funcs.Add(1, (hero) => { Console.WriteLine("It's dead. It's not going anywhere"); });
        #endregion
        Challenge c3 = new(3, "You startled the bats, what do you do?", ["Attack!", "Run!",]);
        c3.Funcs.Add(0, (hero) => { if (hero.Equipped.FirstOrDefault(e => e.Type == RealmOfDataStructures.Equipment.Equipment_Type.Weapon) != null) { Console.WriteLine("DIE BATS, DIE!!"); Thread.Sleep(1200); Console.WriteLine("You unalived those bats!"); hero.Agility += 25; Console.WriteLine("You gained 25 Agility"); Insert(c3_2); } else { Console.WriteLine("You swat with your hands and sustain injury"); hero.Health -= 15; Console.WriteLine("You lost 15 health"); }; });
        c3.Funcs.Add(1, (hero) => { Console.WriteLine("You aquired a Potion of Healing!"); hero.PickUpItem(new PotionOfHealing("Potion of Healing", hero, 20)); });
        Insert(c3);
        #endregion
    }
}