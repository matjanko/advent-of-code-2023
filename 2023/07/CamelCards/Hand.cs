namespace CamelCards;

internal class Hand
{
    public string Cards { get; }
    public int Bid { get; }
    public HandType Type { get; set; }

    public Hand(string cards, int bid)
    {
        Cards = cards;
        Bid = bid;
    }
}