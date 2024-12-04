namespace RealmOfDataStructures.Game;

using System;


public partial class Game
{
    [Serializable]
    private class StupidNameException : Exception
    {
        public StupidNameException()
        {
        }

        public StupidNameException(string? message) : base(message)
        {
        }

        public StupidNameException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
