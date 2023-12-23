namespace HauntedWasteland;

internal class WastelandMap
{
    private List<char> _instructions;
    private readonly IEnumerable<Node> _nodes;

    public WastelandMap(List<char> instructions, IEnumerable<Node> nodes)
    {
        _instructions = instructions;
        _nodes = nodes;
    }

    public int GetRequiredStepsToReach(string name)
    {
        var steps = 0;
        var nextElement = string.Empty;
        var firstTime = true;

        for (var i = 0; i < _instructions.Count; i++)
        {
            var instruction = _instructions[i];
            var node = i == 0 && firstTime
                ? _nodes.First(x => x.Starting == "AAA")
                : _nodes.First(x => x.Starting == nextElement);

            if (firstTime)
            {
                firstTime = false;
            }

            nextElement = instruction == 'L' ? node.Left : node.Right;
            steps++;

            if (nextElement == name)
            {
                return steps;
            }

            if (nextElement != name && i == _instructions.Count - 1)
            {
                i = -1;
            }
        }
        return -1;
    }

    public int GetRequiredStepsToNodesEndWith(string name)
    {
        var steps = 0;
        var nextElements = new List<string>();
        var firstTime = true;
        var nodes = new List<Node>();

        for (var i = 0; i < _instructions.Count; i++)
        {
            var instruction = _instructions[i];
            nodes = i == 0 && firstTime
                ? _nodes.Where(x => x.Starting.EndsWith("A")).ToList()
                : _nodes.Where(x => nextElements.Any(y => y == x.Starting)).ToList();

            firstTime = false;

            nextElements = instruction == 'L'
                ? nodes.Select(x => x.Left).ToList()
                : nodes.Select(x => x.Right).ToList();
            steps++;

            if (nextElements.All(x => x.EndsWith("Z")))
            {
                return steps;
            }

            if (!nextElements.All(x => x.EndsWith("Z")) && i == _instructions.Count - 1)
            {
                i = -1;
            }
        }

        return -1;
    }
}