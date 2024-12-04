namespace RealmOfDataStructures.Dungeon;
using RealmOfDataStructures.ChalengeTree;
using RealmOfDataStructures.Room;


public abstract class Dungeon
{
    public string DungeonTitle { get; init; }
    internal Dictionary<int, Room> DungeonMap { get; set; } = new();
    private ChallengeTree Challenges { get; init; } = new();

    // Draw a map to illustrate the graph (room connections)
    public Dungeon(string title)
    {
        DungeonTitle = title;
    }

    public virtual void AddRooms() { }
}

public class LivingRealm : Dungeon
{
    public LivingRealm(string title) : base(title) { }
    public override void AddRooms()
    {
        Room DragonsLair = new(9, "Dragons Lair", "You have entered the Dragons Lair! Good Luck!");
        Room room1 = new(1, "The Beginning", "A wooden sign says: 'Welcome to the Realm of Data Structures'");
        Room room2 = new(2, "Strange Box", "");
        Room room3 = new(3, "Amber Room", "A true hero doesn't show their strength, they exersize it.");
        Room room4 = new(4, "Key of Doom", "You found a key, do you pick it up?");
        Room room5 = new(5, "Banish All Hope", "A large door blocks your path?");
        Room room6 = new(6, "Poisonous Encounter", "A serpent blocks your path.");
        Room room7 = new(7, "start", "A serpent blocks your path.");
        room1.AdjacentRooms.AddRange([room2, room3, room4, room5]);
        room2.AdjacentRooms.AddRange([room1]);
        room3.AdjacentRooms.AddRange([room1, room6]);
        room4.AdjacentRooms.AddRange([room1, room6]);
        room5.AdjacentRooms.AddRange([room1, DragonsLair]);
        room6.AdjacentRooms.AddRange([room3, room4, room7]);
        DungeonMap.Add(room1.ID, room1);
        DungeonMap.Add(room2.ID, room2);
        DungeonMap.Add(room3.ID, room3);
        DungeonMap.Add(room4.ID, room4);
        DungeonMap.Add(room5.ID, room5);
        DungeonMap.Add(room6.ID, room6);
    }
}
public class DeadRealm : Dungeon
{
    public DeadRealm(string title) : base(title)
    {

    }
}