using CubeConundrum;

var inputs = File.ReadAllLines("../../../Input.txt").ToList();
var games = inputs.Select(x => new Game(x)).ToList();

var possibleGames = games.Where(x => x.IsPossibleGame());
var idsSum = possibleGames.Select(x => x.GameId).Sum();
Console.WriteLine("Part One: " + idsSum);

var powersSum = games.Select(x => x.PowerCubes()).Sum();
Console.WriteLine("Part Two: " + powersSum);