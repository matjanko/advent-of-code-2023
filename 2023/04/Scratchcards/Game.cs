namespace Scratchcards;

internal class Game
{
    private readonly List<Card> _scratchcards;
    private Dictionary<int, int> _scratchcardsMultiplier = new();

    public int TotalScratchcards { get; private set; }

    public Game(List<Card> scratchcards)
    {
        _scratchcards = scratchcards;

        for (var i = 0; i < _scratchcards.Count; i++)
        {
            _scratchcardsMultiplier.Add(i + 1, 1);
        }
    }

    public void Play()
    {
        for (var i = 0; i < _scratchcards.Count; i++)
        {
            var matchingNumbersQuantity = _scratchcards.ElementAt(i).GetMatchingNumbersQuantity();
            var multiplier = _scratchcardsMultiplier[i + 1];

            for (var j = i + 1; j <= matchingNumbersQuantity + i; j++)
            {
                _scratchcardsMultiplier[j + 1] += multiplier;
            }

        }

        TotalScratchcards = _scratchcardsMultiplier.Values.Sum();
    }
}