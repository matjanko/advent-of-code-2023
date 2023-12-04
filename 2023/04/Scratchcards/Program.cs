using Scratchcards;

var inputs = File.ReadAllLines("../../../Input.txt").ToList();
var cards = inputs.Select(x => new Card(x)).ToList();
var points = cards.Select(x => x.GetPoints());
var sum = points.Sum();

Console.WriteLine("Part One: " + sum);

var game = new Game(cards);
game.Play();
Console.WriteLine("Part Two: " + game.TotalScratchcards);