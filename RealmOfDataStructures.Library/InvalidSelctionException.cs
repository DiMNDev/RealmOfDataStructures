namespace RealmOfDataStructures.Game;

using System;


public partial class Game
{
    [Serializable]
    private class InvalidSelctionException : Exception
    {
        public InvalidSelctionException()
        {
        }

        public InvalidSelctionException(string? message) : base(message)
        {
        }

        public InvalidSelctionException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
