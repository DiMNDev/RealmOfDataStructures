namespace RealmOfDataStructures.Game;
public partial class Game
{
    [Serializable]
    private class LongNameException : Exception
    {
        public LongNameException()
        {
        }

        public LongNameException(string? message) : base(message)
        {
        }

        public LongNameException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
