namespace WaitForIt;

public class Race
{
    private long _time;
    private long _distance;

    public Race(long time, long distance)
    {
        _time = time;
        _distance = distance;
    }

    public long FindPossibleWinnings()
    {
        var result = 0L;

        for (var holdButtonTime = 1; holdButtonTime < _time; holdButtonTime++)
        {
            var remainingTime = _time - holdButtonTime;
            long boatSpeed = holdButtonTime;
            var newDistance = remainingTime * boatSpeed;

            if (newDistance > _distance)
            {
                result++;
            }
        }

        return result;
    }
}