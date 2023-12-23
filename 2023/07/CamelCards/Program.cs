using CamelCards;

var inputs = File.ReadAllLines("../../../Input.txt").ToList();

var hands = inputs.Select(input => input.Split(" ")).Select(input => new Hand(input[0], int.Parse(input[1]))).ToList();
var game = new Game(hands);
game.FindHandsType(isJoker: false);
game.SortHandsByStrength(isJoker: false);
var totalWinnings = game.SortedHands.Select((hand, index) => (index + 1) * hand.Bid).Sum();
Console.WriteLine("Part One: " + totalWinnings);


var game2 = new Game(hands);
game2.FindHandsType(isJoker: true);
game2.SortHandsByStrength(isJoker: true);
var totalWinnings2 = game2.SortedHands.Select((hand, index) => (index + 1) * hand.Bid).Sum();
Console.WriteLine("Part Two: " + totalWinnings2);