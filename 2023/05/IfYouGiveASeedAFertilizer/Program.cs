using IfYouGiveASeedAFertilizer;

var inputs = File.ReadAllLines("../../../Input.txt").ToList();

var almanac = new Almanac(inputs);
almanac.InitializeSeeds(inputs);
almanac.CalculateSeeds();
var lowestLocation = almanac.GetLowestLocation();
Console.WriteLine("Part One: " + lowestLocation);

var rereadingAlmanac = new RereadingAlmanac(inputs.ToArray());
lowestLocation = rereadingAlmanac.GetLowestLocation();
Console.WriteLine("Part Two: " + lowestLocation);