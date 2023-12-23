using HauntedWasteland;

var inputs = File.ReadAllLines("../../../Input.txt");
var instructions = inputs[0].ToList();
var nodes = GetNodes(inputs);

var wastelandMap = new WastelandMap(instructions, nodes);
//var requiredSteps = wastelandMap.GetRequiredStepsToReach("ZZZ");
//Console.WriteLine("Part One: " + requiredSteps);

var requiredSteps = wastelandMap.GetRequiredStepsToNodesEndWith("Z");
Console.WriteLine("Part Two: " + requiredSteps);
return;

IEnumerable<Node> GetNodes(IReadOnlyList<string> inputs)
{
    for (var i = 0; i < inputs.Count; i++)
    {
        if (i < 2) { continue; }

        var input = inputs[i].Split(" = ");
        var starting = input[0];
        var elements = input[1].Replace("(", "").Replace(")", "").Replace(" ", "").Split(",");
        yield return new Node(starting, elements[1], elements[0]);
    }
}