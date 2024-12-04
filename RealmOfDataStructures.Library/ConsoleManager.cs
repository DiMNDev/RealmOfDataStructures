namespace RealmOfDataStructures.ConsoleManger;
using Hero;

public static class Util
{
    public static int width = Console.WindowWidth;
    public static void SetupHeader(string msg)
    {
        int width = Console.WindowWidth - 4;
        Console.WriteLine(new string('=', Console.WindowWidth));
        Console.Write($"||{new string(' ', width)}||");
        Console.WriteLine(new string('=', Console.WindowWidth));
        Console.SetCursorPosition(3, 1);
        Console.Write(msg);
    }
    public static void SetHeaderStats(Hero hero)
    {
        SetupHeader($"Hero:{hero.HeroName,12} || Health:{hero.Health,8} || Strength:{hero.Strength,8} || Intelligence:{hero.Inteligence,8} || Agility:{hero.Agility,8} ||");
        Console.SetCursorPosition(0, 3);
    }
    public static void ReloadStats(Hero hero)
    {
        (int _, int top) = Console.GetCursorPosition();
        Console.SetCursorPosition(0, 0);
        SetupHeader($"Hero:{hero.HeroName,12} || Health:{hero.Health,8} || Strength:{hero.Strength,8} || Intelligence:{hero.Inteligence,8} || Agility:{hero.Agility,8} ||");
        Console.SetCursorPosition(0, top);
    }
    public static void DisplayRoom(string roomName)
    {
        Console.SetCursorPosition(0, 3);
        Console.WriteLine($"||{new string(' ', width - 4)}||");
        Console.SetCursorPosition((width / 2) - roomName.Length, 3);
        Console.Write(roomName);
        Console.SetCursorPosition(0, 4);
        Console.WriteLine($"||{new string('=', width - 4)}||");
        Console.SetCursorPosition(0, 5);
    }
    public static void ClearRow(int row)
    {
        Console.SetCursorPosition(0, row);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, row);
    }
    public static void ClearMenu(int top)
    {
        (int cLeft, int cTop) = Console.GetCursorPosition();
        for (int i = cTop; i > top; i--)
        {
            ClearRow(i);
        }
    }
    public static void WaitForAnyKey()
    {
        Console.WriteLine("Press any key to continue..");
        Console.Read();
    }
}