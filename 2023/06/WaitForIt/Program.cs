using System.Text.RegularExpressions;
using WaitForIt;

var inputs = File.ReadAllLines("../../../Input.txt").ToList();

var times = GetNumbers(inputs[0]);
var distances = GetNumbers(inputs[1]);
var races = new List<Race>();

for (var i = 0; i < times.Length; i++)
{
    races.Add(new Race(times[i], distances[i]));
}

var winningRaces = races.Select(x => x.FindPossibleWinnings());
var multiply = winningRaces.Aggregate(1L, (result, count) => result * count);
Console.WriteLine("Part One: " + multiply);

var time = int.Parse(inputs[0].Replace(" ", "").Replace("Time:", ""));
var distance = long.Parse(inputs[1].Replace(" ", "").Replace("Distance:", ""));
var race = new Race(time, distance);
var winningRace = race.FindPossibleWinnings();
Console.WriteLine("Part Two: " + winningRace);

return;

static int[] GetNumbers(string input)
    => Regex.Matches(input, @"\d+")
    .Select(m => int.Parse(m.Value))
    .ToArray();