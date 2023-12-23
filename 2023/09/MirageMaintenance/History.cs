namespace MirageMaintenance;

internal class History
{
    private readonly string _value;

    public History(string value)
    {
        _value = value;
    }

    public int FindLastExtrapolatedValue()
    {
        var lists = GenerateLists();
        return lists.Select(x => x.Last()).Sum();
    }

    public int FindFirstExtrapolatedValue()
    {
        var lists = GenerateLists();
        lists.Reverse();

        for (var i = 0; i < lists.Count; i++)
        {
            if (lists[i].All(x => x == 0))
            {
                lists[0].Insert(0, 0);
                continue;
            }

            var first = lists[i].First();
            var down = lists[i - 1].First();
            lists[i].Insert(0, first - down);
        }

        return lists.Last().First();
    }

    private List<List<int>> GenerateLists()
    {
        var numbers = _value.Split(" ").Select(int.Parse).ToList();
        var lists = new List<List<int>>();
        lists.Add(numbers);

        for (var i = 0; i < lists.Count; i++)
        {
            var newList = ProcessNumbers(lists[i]);
            lists.Add(newList.ToList());

            if (lists.Last().All(x => x == 0))
            {
                return lists;
            }
        }

        return lists;
    }
    private static IEnumerable<int> ProcessNumbers(IReadOnlyList<int> numbers)
    {
        for (var i = 0; i < numbers.Count - 1; i++)
        {
            var firstValue = numbers[i];
            var secondValue = numbers[i + 1];
            var newValue = secondValue - firstValue;
            yield return newValue;
        }
    }
}