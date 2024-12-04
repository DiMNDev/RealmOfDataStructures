namespace RealmOfDataStructures.Game;

using Challenges;
using RealmOfDataStructures.ChalengeTree;
using RealmOfDataStructures.ConsoleManger;
using RealmOfDataStructures.Dungeon;
using RealmOfDataStructures.Hero;
using Room;


public partial class Game
{
    public Hero hero { get; set; }
    public Dungeon RealmOfLiving { get; set; }
    public Dungeon RealmOfDead { get; set; }
    public Dungeon CurrentRealm { get; set; }
    public Room CurrentRoom { get; set; }
    public LivingRealmChallenges Challenges { get; set; } = new();

    public Game()
    {
        RealmOfLiving = new LivingRealm("Realm of Living Data Structures");
        RealmOfLiving.AddRooms();
        RealmOfDead = new DeadRealm("Realm of Dead Data Structures");
    }
    public string GetHeroName()
    {
        try
        {
            string HeroName = Console.ReadLine()!;
            if (HeroName == "") throw new StupidNameException();
            if (HeroName.Count() > 12) throw new LongNameException();

            hero = new() { HeroName = HeroName };
        }
        catch (System.Exception)
        {
            GetHeroName();
        }
        return hero.HeroName;
    }
    public void Setup()
    {
        Util.SetupHeader("Hello Traveler, What is your name: ");
        GetHeroName();
        Console.Clear();
        Util.SetHeaderStats(hero);
    }
    public void StartAdventure()
    {
        CurrentRealm = RealmOfLiving;
        CurrentRoom = CurrentRealm.DungeonMap.FirstOrDefault(r => r.Key == 1).Value;
        DisplayOptions();
    }
    public void DisplayOptions()
    {
        (int left, int top) = Console.GetCursorPosition();
        Challenge challenge = Challenges.Search(CurrentRoom.ID);
        Util.DisplayRoom(CurrentRoom.RoomName);
        Console.WriteLine(CurrentRoom.EnterMessage);
        if (challenge != null && !challenge.Skip)
        {
            DisplayChallenge(challenge);
            Util.ClearMenu(top);
            challenge.Skip = true;
            DisplayOptions();
        }
        else
        {
            DisplayStandardOptions(top);
        }
    }

    private void DisplayChallenge(Challenge challenge)
    {
        if (challenge.Resolved)
        {
            return;
        }
        Console.WriteLine($"{challenge.Description}");
        int Counter = 1;
        foreach (var option in challenge.Options)
        {
            Console.WriteLine($"{Counter++}. {option}");
        }
        try
        {
            int input = int.Parse(Console.ReadLine()) - 1;
            Action<Hero> func = challenge.Funcs.FirstOrDefault(f => f.Key == input).Value;
            func(hero);
            if (challenge.Resolved)
            {
                Challenges.Delete(CurrentRoom.ID);
            }
            Util.WaitForAnyKey();
        }
        catch (Exception)
        {
            DisplayOptions();
        }
    }
    private void DisplayStandardOptions(int top)
    {
        Console.WriteLine("What you you like to do?");
        Console.WriteLine("1. Move");
        Console.WriteLine("2. Use");
        Console.WriteLine("3. Attack");
        Console.WriteLine("4. Run");
        try
        {
            int input = int.Parse(Console.ReadLine()) - 1;

            Options option = input switch
            {
                0 => Options.move,
                1 => Options.use,
                2 => Options.attack,
                3 => Options.run,
                _ => throw new InvalidSelctionException()
            };
            switch (option)
            {
                case Options.move:
                    Move(top);
                    break;
                case Options.use:
                    Use(top);
                    Util.WaitForAnyKey();
                    Util.ClearMenu(top);
                    DisplayOptions();
                    break;
                case Options.attack:
                    Console.WriteLine("Attack");
                    break;
                case Options.run:
                    Console.WriteLine("run");
                    break;
                default:
                    throw new InvalidSelctionException();
            }
        }
        catch (System.Exception)
        {
            Console.WriteLine("Try Again");
            Util.ClearMenu(top);
            DisplayOptions();
        }
    }
    private void Move(int top)
    {
        Util.ClearMenu(top);
        int Counter = 1;
        Console.WriteLine("What room would you like to explore?");
        foreach (var room in CurrentRoom.AdjacentRooms)
        {
            Console.WriteLine($"{Counter++}. {room.RoomName}");
        }
        int input = int.Parse(Console.ReadLine());
        if (input > 0 && input <= CurrentRoom.AdjacentRooms.Count)
        {
            Challenge challenge = Challenges.Search(CurrentRoom.ID);
            challenge.Skip = false;
            CurrentRoom = CurrentRoom.AdjacentRooms[input - 1];
            Util.ClearMenu(--top);
            DisplayOptions();
        }
        else { throw new InvalidSelctionException(); }
    }

    private void Use(int top)
    {
        Util.ClearMenu(top);
        int Counter = 1;
        Console.WriteLine("--Pouch--");
        foreach (var item in hero.Pouch)
        {
            Console.WriteLine($"{Counter++}. {item?.ItemName ?? "None"}");
        }
        Console.WriteLine("Make a selection -or- Press any key to return to main menu..");

        int input = int.Parse(Console.ReadLine()!);
        if (input > 0 && input <= hero.Pouch.Length)
        {
            hero.Pouch[input - 1].Use("All Gone");
            Util.ReloadStats(hero);
        }
        else
        {
            Util.ClearMenu(top);
        }

    }

    public void PickRoom()
    {
        Console.WriteLine();
    }
}

public enum Options
{
    move,
    use,
    attack,
    run,
}