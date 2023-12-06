using IfYouGiveASeedAFertilizer;

var inputs = File.ReadAllLines("../../../Input.txt").ToList();
var almanac = new Almanac(inputs);
almanac.InitializeSeeds(inputs);
almanac.CalculateSeeds();
var lowestLocation = almanac.GetLowestLocation();

Console.WriteLine("Part One: " + lowestLocation);

almanac = new Almanac(inputs);
almanac.InitializeSeedsWithRange(inputs);
lowestLocation = 0;

Console.WriteLine("Part Two: " + lowestLocation);