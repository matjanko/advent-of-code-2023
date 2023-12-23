namespace IfYouGiveASeedAFertilizer;

internal class SeedsRange
{
    public List<AlmanacMap> Seeds { get; }

    public List<AlmanacMap> Soil { get; private set; }
    public List<AlmanacMap> Fertilizer { get; private set; }
    public List<AlmanacMap> Water { get; private set; }
    public List<AlmanacMap> Light { get; private set; }
    public List<AlmanacMap> Temperature { get; private set; }
    public List<AlmanacMap> Humidity { get; private set; }
    public List<AlmanacMap> Location { get; private set; }

    public SeedsRange(List<AlmanacMap> seeds)
    {
        Seeds = seeds;
    }

    public void SetValues(IEnumerable<string> seedToSoil,
        IEnumerable<string> soilToFertilizer,
        IEnumerable<string> fertilizerToWater,
        IEnumerable<string> waterToLight,
        IEnumerable<string> lightToTemperature,
        IEnumerable<string> temperatureToHumidity,
        IEnumerable<string> humidityToLocation)
    {
        Soil = GetValueFromMap(seedToSoil.ToList(), Seeds);
        Fertilizer = GetValueFromMap(soilToFertilizer.ToList(), Soil);
        Water = GetValueFromMap(fertilizerToWater.ToList(), Fertilizer);
        Light = GetValueFromMap(waterToLight.ToList(), Water);
        Temperature = GetValueFromMap(lightToTemperature.ToList(), Light);
        Humidity = GetValueFromMap(temperatureToHumidity.ToList(), Temperature);
        Location = GetValueFromMap(humidityToLocation.ToList(), Humidity);
    }

    private static List<AlmanacMap> GetValueFromMap(List<string> mapInputs, List<AlmanacMap> almanacMaps)
    {
        var result = almanacMaps;

        foreach (var elMapRow in almanacMaps)
        {
            foreach (var input in mapInputs)
            {
                var numbers = input.Split(" ").Select(long.Parse).ToArray();
                var mapRow = new AlmanacMap(numbers[0], numbers[1], numbers[2]);

                var minEl = elMapRow.Min();
                var maxEl = elMapRow.Max();

                var minMap = mapRow.Min();
                var maxMap = mapRow.Max();
            }
        }
        return result;
    }
}