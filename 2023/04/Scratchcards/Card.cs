namespace Scratchcards;

internal class Card
{
    private readonly List<int> _winningNumbers;
    private readonly List<int> _cardNumbers;

    public Card(string input)
    {
        _cardNumbers = input.Split(": ")[1].Split(" | ")[0].Split(" ")
            .Where(x => x != string.Empty)
            .Select(int.Parse)
            .ToList();

        _winningNumbers = input.Split(": ")[1].Split(" | ")[1].Split(" ")
            .Where(x => x != string.Empty)
            .Select(int.Parse)
            .ToList();
    }

    public int GetPoints()
    {
        var matchingNumbers = _winningNumbers.Intersect(_cardNumbers).ToList();
        var points = matchingNumbers.Count > 0 ? 1 : 0;

        for (var i = 0; i < matchingNumbers.Count - 1; i++)
        {
            points *= 2;
        }

        return points;
    }

    public int GetMatchingNumbersQuantity() => _winningNumbers.Intersect(_cardNumbers).ToList().Count;
}