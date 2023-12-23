namespace CamelCards;

internal class CardsComparer : IComparer<Hand>
{
    private readonly bool _isJoker;
    public CardsComparer(bool isJoker)
    {
        _isJoker = isJoker;
    }

    public int Compare(Hand? x, Hand? y)
    {
        var gameCards = _isJoker ? Game.JokerGameCards.ToList() : Game.GameCards.ToList();

        if (x is null || y is null)
        {
            throw new Exception();
        }

        var cards1 = x.Cards;
        var cards2 = y.Cards;

        for (var i = 0; i < cards1.Length; i++)
        {
            var n1 = gameCards.IndexOf(cards1[i]) + 1;
            var n2 = gameCards.IndexOf(cards2[i]) + 1;

            if (n1 != n2)
            {
                return n1 > n2 ? 1 : -1;
            }
        }

        return 0;
    }
}