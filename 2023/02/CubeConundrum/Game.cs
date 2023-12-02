namespace CubeConundrum;

public class Game
{
    public int GameId { get; }

    private readonly Dictionary<string, int> _cubes = new()
    {
        { "red", 0 },
        { "green", 0 },
        { "blue", 0 }
    };

    public Game(string record)
    {
        var gameTag = record.Split(":")[0];
        GameId = int.Parse(gameTag.Replace("Game ", ""));

        var rounds = record.Split(": ")[1].Replace(",", "").Split("; ");
        PlayGame(rounds);
    }

    private void PlayGame(IEnumerable<string> rounds)
    {
        foreach (var round in rounds)
        {
            var cubes = round.Split(" ");
            for (var i = 0; i < cubes.Length; i++)
            {
                if (char.IsDigit(cubes[i][0])) { continue; }
                var count = int.Parse(cubes[i - 1]);
                var color = cubes[i];
                _cubes[color] = Math.Max(count, _cubes[color]);
            }
        }
    }

    public bool IsPossibleGame() => _cubes["red"] <= 12 && _cubes["green"] <= 13 && _cubes["blue"] <= 14;
    public int PowerCubes() => _cubes.Values.Aggregate(1, (result, count) => result * count);
}