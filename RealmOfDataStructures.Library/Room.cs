namespace RealmOfDataStructures.Room;

public class Room
{
    public int ID { get; set; }
    public string RoomName { get; init; }
    public List<Room> AdjacentRooms { get; set; } = new();
    public string EnterMessage { get; set; }
    public Room(int id, string roomName, string msg)
    {
        ID = id;
        RoomName = roomName;
        EnterMessage = msg;
    }
    public void Enter()
    {
        Console.WriteLine(EnterMessage);
    }
}
