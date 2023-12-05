namespace IfYouGiveASeedAFertilizer;

internal class Seed
{
    public long Id { get; }
    public long Range { get; }
    public long Soil { get; set; }
    public long SoilRange { get; set; }
    public long Fertilizer { get; set; }
    public long Water { get; set; }
    public long Light { get; set; }
    public long Temperature { get; set; }
    public long Humidity { get; set; }
    public long Location { get; set; }

    public Seed(long id)
    {
        Id = id;
    }

    public Seed(long id, long range)
    {
        Id = id;
        Range = range;
    }

    public void SetValues(IEnumerable<string> seedToSoil,
        IEnumerable<string> soilToFertilizer,
        IEnumerable<string> fertilizerToWater,
        IEnumerable<string> waterToLight,
        IEnumerable<string> lightToTemperature,
        IEnumerable<string> temperatureToHumidity,
        IEnumerable<string> humidityToLocation)
    {
        Soil = GetValueFromMap(seedToSoil, Id);
        Fertilizer = GetValueFromMap(soilToFertilizer, Soil);
        Water = GetValueFromMap(fertilizerToWater, Fertilizer);
        Light = GetValueFromMap(waterToLight, Water);
        Temperature = GetValueFromMap(lightToTemperature, Light);
        Humidity = GetValueFromMap(temperatureToHumidity, Temperature);
        Location = GetValueFromMap(humidityToLocation, Humidity);
    }

    public void SetValuesWithRange(IEnumerable<string> seedToSoil,
        IEnumerable<string> soilToFertilizer,
        IEnumerable<string> fertilizerToWater,
        IEnumerable<string> waterToLight,
        IEnumerable<string> lightToTemperature,
        IEnumerable<string> temperatureToHumidity,
        IEnumerable<string> humidityToLocation)
    {

    }

    private static long GetValueFromMap(IEnumerable<string> map, long id)
    {
        foreach (var input in map)
        {
            var numbers = input.Split(" ").Select(long.Parse).ToArray();
            var sourceRange = numbers[1];
            var rangeLength = numbers[2];

            if (id >= sourceRange && id <= sourceRange + rangeLength - 1)
            {
                var destinationRange = numbers[0];
                return id + destinationRange - sourceRange;
            }
        }
        return id;
    }
}