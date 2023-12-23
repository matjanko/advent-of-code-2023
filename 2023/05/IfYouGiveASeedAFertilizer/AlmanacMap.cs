namespace IfYouGiveASeedAFertilizer;

internal class AlmanacMap
{
    public long DestinationRange { get; }
    public long SourceRange { get; }
    public long RangeLength { get; }

    public AlmanacMap(long destinationRange, long sourceRange, long rangeLength)
    {
        DestinationRange = destinationRange;
        SourceRange = sourceRange;
        RangeLength = rangeLength;
    }

    public long Min() => SourceRange;
    public long Max() => SourceRange + RangeLength - 1;
}