namespace HauntedWasteland;

internal class Node
{
    public string Starting { get; }
    public string Right { get; }
    public string Left { get; }

    public Node(string starting, string right, string left)
    {
        Starting = starting;
        Right = right;
        Left = left;
    }
}