using GearRatios;

var inputs = File.ReadAllLines("../../../Input.txt");

var engine = new Engine(inputs);
var partNumbers = engine.GetAllPartNumbers();
var sum = partNumbers.Select(x => x.Value).Sum();
Console.WriteLine("Part One: " + sum);

var gearPartNumbers = engine.GetAllGearPartNumbers();
var groupedPartNumbers = gearPartNumbers.GroupBy(x => x.GearPoint).Where(x => x.Count() == 2);
var gearRatios = groupedPartNumbers.Select(x => x.ElementAt(0).Value * x.ElementAt(1).Value);
var sum2 = gearRatios.Sum();
Console.WriteLine("Part Two: " + sum2);