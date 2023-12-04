using System.Drawing;

namespace GearRatios;

public class Number
{
    public int Value { get; }
    public List<Point> AroundPoints { get; init; }

    private readonly Point? _last;

    public Number(int value, Point last)
    {
        Value = value;
        _last = last;
        AroundPoints = FindAroundPoints();
    }

    private List<Point> FindAroundPoints()
    {
        var points = new List<Point>();

        return points;
    }
}