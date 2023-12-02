using Trebuchet;

var inputs = File.ReadAllLines("../../../Input.txt").ToList();
var lines = inputs.Select(x => new CalibrationLine(x)).ToList();
var sum = lines.Select(x => x.GetCalibrationValue()).Sum();
Console.WriteLine("Part One: " + sum);

var sum2 = lines.Select(x => x.GetCorrectedCalibrationValue()).Sum();
Console.WriteLine("Part Two: " + sum2);