using System.Drawing;

namespace GearRatios;

internal class Engine
{
    private readonly string[,] _engineSchematic;

    public List<Number> Numbers { get; }

    public Engine(IReadOnlyList<string> inputs)
    {
        _engineSchematic = InitEngineSchematic(inputs);
        Numbers = GetAllNumbers();
    }

    private static string[,] InitEngineSchematic(IReadOnlyList<string> inputs)
    {
        var result = new string[inputs.Count, inputs[0].Length];

        for (var i = 0; i < inputs.Count; i++)
        {
            var input = inputs[i];

            for (var j = 0; j < input.Length; j++)
            {
                result[i, j] = input[j].ToString();
            }
        }

        return result;
    }

    private List<Number> GetAllNumbers()
    {
        var numbers = new List<Number>();
        var number = string.Empty;
        var x = _engineSchematic.GetLength(0);
        var y = _engineSchematic.GetLength(1);

        for (var i = 0; i < x; i++)
        {
            for (var j = 0; j < y; j++)
            {
                var element = _engineSchematic[i, j];
                if (char.IsDigit(char.Parse(element)))
                {
                    number += element;
                    if (j == y - 1)
                    {
                        numbers.Add(new Number(
                            int.Parse(number), new Point(i, j), x, y));
                        number = string.Empty;
                    }
                }
                else if (number != string.Empty)
                {
                    numbers.Add(new Number(
                        int.Parse(number), new Point(i, j - 1), x, y));
                    
                    number = string.Empty;
                }
            }
        }


        return numbers;
    }

    public IEnumerable<Number> GetAllPartNumbers()
    {
        return Numbers.Where(x => x.IsPartNumber(_engineSchematic)).ToList();
    }

    public IEnumerable<Number> GetAllGearPartNumbers()
    {
        return Numbers.Where(x => x.IsGearPartNumber(_engineSchematic)).ToList();
    }
}