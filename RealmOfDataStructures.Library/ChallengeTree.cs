namespace RealmOfDataStructures.ChalengeTree;
using RealmOfDataStructures.Hero;


public class Challenge
{
    public int RoomIndex { get; set; }
    public string Description { get; set; }
    public List<string> Options { get; set; }

    public Dictionary<int, Action<Hero>> Funcs { get; set; } = new();

    public Challenge(int roomIndex, string description, List<string> options)
    {
        RoomIndex = roomIndex;
        Description = description;
        Options = options;
    }

    public override string ToString()
    {
        return $"Room {RoomIndex}: {Description}";
    }
}

public class ChallengeNode
{
    public Challenge Challenge { get; set; }
    public ChallengeNode Left { get; set; }
    public ChallengeNode Right { get; set; }

    public ChallengeNode(Challenge challenge)
    {
        Challenge = challenge;
    }
}

public class ChallengeTree
{
    private ChallengeNode root;

    public ChallengeTree() { }

    #region  Insert in Tree
    public void Insert(Challenge challenge)
    {
        root = Insert(root, challenge);
    }
    private ChallengeNode Insert(ChallengeNode node, Challenge challenge)
    {
        if (node == null)
            return new ChallengeNode(challenge);

        if (challenge.RoomIndex < node.Challenge.RoomIndex)
            node.Left = Insert(node.Left, challenge);
        else if (challenge.RoomIndex > node.Challenge.RoomIndex)
            node.Right = Insert(node.Right, challenge);

        return Balance(node);
    }
    #endregion
    #region Search in Tree
    public Challenge Search(int roomIndex)
    {
        var node = Search(root, roomIndex);
        return node?.Challenge;
    }

    private ChallengeNode Search(ChallengeNode node, int roomIndex)
    {
        if (node == null || node.Challenge.RoomIndex == roomIndex)
            return node;

        if (roomIndex < node.Challenge.RoomIndex)
            return Search(node.Left, roomIndex);
        else
            return Search(node.Right, roomIndex);
    }
    #endregion
    #region  Delete from Tree
    public void Delete(int roomIndex)
    {
        root = Delete(root, roomIndex);
    }

    private ChallengeNode Delete(ChallengeNode node, int roomIndex)
    {
        if (node == null)
            return null;

        if (roomIndex < node.Challenge.RoomIndex)
            node.Left = Delete(node.Left, roomIndex);
        else if (roomIndex > node.Challenge.RoomIndex)
            node.Right = Delete(node.Right, roomIndex);
        else
        {
            if (node.Left == null)
                return node.Right;
            else if (node.Right == null)
                return node.Left;

            ChallengeNode minNode = GetMinNode(node.Right);
            node.Challenge = minNode.Challenge;
            node.Right = Delete(node.Right, minNode.Challenge.RoomIndex);
        }

        return Balance(node);
    }

    private ChallengeNode GetMinNode(ChallengeNode node)
    {
        while (node.Left != null)
            node = node.Left;
        return node;
    }
    #endregion
    #region Balance the Tree
    private ChallengeNode Balance(ChallengeNode node)
    {
        int balanceFactor = GetHeight(node.Left) - GetHeight(node.Right);

        if (balanceFactor > 1)
        {
            if (GetHeight(node.Left.Left) >= GetHeight(node.Left.Right))
                node = RotateRight(node);
            else
            {
                node.Left = RotateLeft(node.Left);
                node = RotateRight(node);
            }
        }
        else if (balanceFactor < -1)
        {
            if (GetHeight(node.Right.Right) >= GetHeight(node.Right.Left))
                node = RotateLeft(node);
            else
            {
                node.Right = RotateRight(node.Right);
                node = RotateLeft(node);
            }
        }

        return node;
    }

    private int GetHeight(ChallengeNode node)
    {
        if (node == null)
            return 0;
        return Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;
    }

    private ChallengeNode RotateRight(ChallengeNode y)
    {
        ChallengeNode x = y.Left;
        ChallengeNode T = x.Right;

        x.Right = y;
        y.Left = T;

        return x;
    }

    private ChallengeNode RotateLeft(ChallengeNode x)
    {
        ChallengeNode y = x.Right;
        ChallengeNode T = y.Left;

        y.Left = x;
        x.Right = T;

        return y;
    }
    #endregion

    // Display the tree (in-order traversal) -- DEBUG ONLY
    public void Display()
    {
        Display(root);
    }

    private void Display(ChallengeNode node)
    {
        if (node == null)
            return;

        Display(node.Left);
        Console.WriteLine(node.Challenge);
        Display(node.Right);
    }
}
