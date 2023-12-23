using System.Text.RegularExpressions;

namespace IfYouGiveASeedAFertilizer;

internal class RereadingAlmanac : Almanac
{
    private List<SeedsRange> _seeds = new();
    private readonly string[] _inputs;

    public RereadingAlmanac(string[] inputs) : base(inputs)
    {
        _inputs = inputs;
        InitializeSeeds();
        CalculateSeeds();
    }

    private void InitializeSeeds()
    {
        var seeds = Regex.Matches(_inputs[0], @"\d+").Select(m => long.Parse(m.Value)).ToList();

        for (var i = 0; i < seeds.Count; i++)
        {
            if (i % 2 == 0)
            {
                _seeds.Add(new SeedsRange(new List<AlmanacMap> { new (seeds[i], seeds[i], seeds[i + 1]) }));
            }
        }
    }

    private new void CalculateSeeds()
    {
        _seeds.ForEach(x => x.SetValues(
            _seedToSoil,
            _soilToFertilizer,
            _fertilizerToWater,
            _waterToLight,
            _lightToTemperature,
            _temperatureToHumidity,
            _humidityToLocation));
    }

    public new long GetLowestLocation()
    {

        return 0L;
    }
}