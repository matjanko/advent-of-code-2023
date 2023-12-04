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

        for (var i = 0; i < _engineSchematic.GetLength(0); i++)
        {
            for (var j = 0; j < _engineSchematic.GetLength(1); j++)
            {
                var element = _engineSchematic[i, j];
                if (char.IsDigit(char.Parse(element)))
                {
                    number += element;
                }
                else if (number != string.Empty)
                {
                    numbers.Add(new Number(int.Parse(number), new Point(i, j - 1)));
                    number = string.Empty;
                }
            }
        }


        return numbers;
    }
}