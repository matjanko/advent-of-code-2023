namespace CamelCards;

internal class Game
{
    public static readonly char[] GameCards = { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };
    public static readonly char[] JokerGameCards = {'J', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'Q', 'K', 'A' };

    private readonly List<Hand> _hands;
    public readonly List<Hand> SortedHands = new();

    public Game(List<Hand> hands)
    {
        _hands = hands;
    }

    public void FindHandsType(bool isJoker)
    {
        foreach (var hand in _hands)
        {
            hand.Type = GetHandType(hand.Cards, isJoker);
        }
    }

    public void SortHandsByStrength(bool isJoker)
    {
        var handsGroup = _hands
            .GroupBy(x => x.Type)
            .OrderBy(x => (int)x.Key)
            .ToList();

        foreach (var hands in handsGroup)
        {
            if (hands.Count() == 1)
            {
                SortedHands.Add(hands.ElementAt(0));
            }
            else
            {
                var list = hands.ToList();
                list.Sort(new CardsComparer(isJoker));
                SortedHands.AddRange(list);
            }
        }
    }

    private HandType GetHandType(string cards, bool isJoker)
    {
        var c = isJoker ? PrepareCards(cards) : cards;
        return GetDefaultHandType(c);
    }

    private static string PrepareCards(string cards)
    {
        if (cards.All(x => x == 'J'))
        {
            return cards;
        }

        var jokers = cards.Count(c => c == 'J');

        if (jokers == 0 || cards.All(x => x == 'J'))
        {
            return cards;
        }

        var cardsWithoutJokers = cards.Replace("J", "");
        var groupedCards = cardsWithoutJokers.GroupBy(c => c).OrderByDescending(x => x.Count()).ToList();

        if (groupedCards.All(x => x.Count() == 1))
        {
            return cards.Replace("J", cardsWithoutJokers[0].ToString());
        }

        var c = groupedCards.First().Key;
        return cards.Replace('J', c);
    }

    private static HandType GetDefaultHandType(string cards)
    {
        var groupedCards = cards.GroupBy(x => x).ToList();

        if (cards.All(x => x == cards[0]))
        {
            return HandType.FiveOfAKind;
        }

        if (groupedCards.Any(x => x.Count() == 4) && groupedCards.Count(x => x.Count() == 1) == 1)
        {
            return HandType.FourOfAKind;
        }

        if (groupedCards.Any(x => x.Count() == 3) && groupedCards.Count(x => x.Count() == 2) == 1)
        {
            return HandType.FullHouse;
        }

        if (groupedCards.Any(x => x.Count() == 3) && groupedCards.Count(x => x.Count() == 1) == 2)
        {
            return HandType.ThreeOfAKind;
        }

        if (groupedCards.Count(x => x.Count() == 2) == 2 && groupedCards.Count(x => x.Count() == 1) == 1)
        {
            return HandType.TwoPair;
        }

        if (groupedCards.Count(x => x.Count() == 2) == 1 && groupedCards.Count(x => x.Count() == 1) == 3)
        {
            return HandType.OnePair;
        }

        return HandType.HighCard;
    }
}