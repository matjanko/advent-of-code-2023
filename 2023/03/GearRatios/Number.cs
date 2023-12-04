using System.Drawing;

namespace GearRatios;

public class Number
{
    public int Value { get; }
    public Point GearPoint { get; private set; }
    private List<Point> AroundPoints { get; init; }

    private readonly Point _last;

    public Number(int value, Point last, int x, int y)
    {
        Value = value;
        _last = last;
        AroundPoints = FindAroundPoints(x, y);
    }

    private List<Point> FindAroundPoints(int x, int y)
    {
        var points = new List<Point>();
        var x1 = _last.X - 1;
        var x2 = _last.X + 1;
        var y1 = _last.Y - Value.ToString().Length;
        var y2 = _last.Y + 1;

        if (y1 >= 0)
        {
            points.Add(_last with { Y = y1 });
        }

        if (y2 <= y - 1)
        {
            points.Add(_last with { Y = y2 });
        }

        if (x1 >= 0)
        {
            for (var i = Math.Max(0, y1); i <= Math.Min(y - 1, y2); i++)
            {
                points.Add(new Point(x1, i));
            }
        }

        if (x2 <= x - 1)
        {
            for (var i = Math.Max(0, y1); i <= Math.Min(y - 1, y2); i++)
            {
                points.Add(new Point(x2, i));
            }
        }

        return points;
    }

    public bool IsPartNumber(string[,] schematic)
    {
        return AroundPoints
            .Select(point => schematic[point.X, point.Y])
            .Any(s => s != "." && !char.IsDigit(char.Parse(s)));
    }

    public bool IsGearPartNumber(string[,] schematic)
    {
        foreach (var point in AroundPoints)
        {
            var s = schematic[point.X, point.Y];

            if (s == "*")
            {
                GearPoint = new Point(point.X, point.Y);
                return true;
            }
        }

        return false;
    }
}