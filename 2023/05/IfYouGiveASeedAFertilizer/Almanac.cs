namespace IfYouGiveASeedAFertilizer;

internal class Almanac
{
    private List<Seed> _seeds = new();

    public List<string> _seedToSoil = new();
    public List<string> _soilToFertilizer = new();
    public List<string> _fertilizerToWater = new();
    public List<string> _waterToLight = new();
    public List<string> _lightToTemperature = new();
    public List<string> _temperatureToHumidity = new();
    public List<string> _humidityToLocation = new();


    public Almanac(IEnumerable<string> inputs)
    {
        InitializeMap(inputs);
    }

    public long GetLowestLocation()
        => _seeds.Select(x => x.Location).Min();

    public void InitializeSeeds(IEnumerable<string> inputs)
    {
        foreach (var input in inputs)
        {
            if (!input.StartsWith("seeds:")) continue;
            _seeds = input.Replace("seeds: ", "").Split(" ")
                .Select(x => new Seed(long.Parse(x)))
                .ToList();
            break;
        }
    }

    private void InitializeMap(IEnumerable<string> inputs)
    {
        MapType? type = null;

        foreach (var input in inputs)
        {
            if (input == string.Empty)
            {
                type = null;
                continue;
            }

            if (input != string.Empty && !char.IsDigit(input[0]))
            {
                type = GetMapType(input);
                continue;
            }

            var map = GetMap(type);
            map?.Add(input);
        }
    }

    private static MapType? GetMapType(string input)
    {
        return input switch
        {
            "seed-to-soil map:" => MapType.SeedToSoil,
            "soil-to-fertilizer map:" => MapType.SoilToFertilizer,
            "fertilizer-to-water map:" => MapType.FertilizerToWater,
            "water-to-light map:" => MapType.WaterToLight,
            "light-to-temperature map:" => MapType.LightToTemperature,
            "temperature-to-humidity map:" => MapType.TemperatureToHumidity,
            "humidity-to-location map:" => MapType.HumidityToLocation,
            _ => null
        };
    }

    private List<string>? GetMap(MapType? type)
    {
        if (type == null)
        {
            return null;
        }

        return type switch
        {
            MapType.SeedToSoil => _seedToSoil,
            MapType.SoilToFertilizer => _soilToFertilizer,
            MapType.FertilizerToWater => _fertilizerToWater,
            MapType.WaterToLight => _waterToLight,
            MapType.LightToTemperature => _lightToTemperature,
            MapType.TemperatureToHumidity => _temperatureToHumidity,
            MapType.HumidityToLocation => _humidityToLocation,
            null => null,
            _ => null
        };
    }

    public void CalculateSeeds()
    {
        _seeds.ForEach(seed =>
        {
            seed.SetValues(_seedToSoil,
                _soilToFertilizer,
                _fertilizerToWater,
                _waterToLight,
                _lightToTemperature,
                _temperatureToHumidity,
                _humidityToLocation);
        });
    }
}