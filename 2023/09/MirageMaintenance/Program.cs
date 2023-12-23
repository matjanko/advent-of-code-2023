using MirageMaintenance;

var inputs = File.ReadAllLines("../../../Input.txt").ToList();
var histories = inputs.Select(x => new History(x)).ToList();
var lastValues = histories.Select(x => x.FindLastExtrapolatedValue()).ToList();
var result = lastValues.Sum();
Console.WriteLine("Part One: " + result);

var firstValues = histories.Select(x => x.FindFirstExtrapolatedValue()).ToList();
result = firstValues.Sum();
Console.WriteLine("Part Two: " + result);