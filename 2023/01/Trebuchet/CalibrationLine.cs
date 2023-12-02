namespace Trebuchet;

internal class CalibrationLine
{
    private readonly string _line;

    public CalibrationLine(string line)
    {
        _line = line;
    }

    public int GetCalibrationValue()
    {
        var firstDigit = _line.FirstOrDefault(char.IsDigit).ToString();
        var lastDigit = _line.LastOrDefault(char.IsDigit).ToString();
        return int.Parse(firstDigit + lastDigit);
    }

    public int GetCorrectedCalibrationValue()
    {
        var firstDigit = FirstDigit();
        var lastDigit = LastDigit();
        return int.Parse(firstDigit + lastDigit);
    }

    private string FirstDigit()
    {
        for (var i = 0; i < _line.Length; i++)
        {
            if (char.IsDigit(_line[i])) { return _line[i].ToString(); }
            if (i + 3 > _line.Length) { continue; }

            var value = _line.Substring(i, 3);
            switch (value)
            {
                case "one": return "1";
                case "two": return "2";
                case "six": return "6";
            }

            if (i + 4 > _line.Length) { continue; }

            value = _line.Substring(i, 4);
            switch (value)
            {
                case "four": return "4";
                case "five": return "5";
                case "nine": return "9";
            }

            if (i + 5 > _line.Length) { continue; }

            value = _line.Substring(i, 5);
            switch (value)
            {
                case "three": return "3";
                case "seven": return "7";
                case "eight": return "8";
            }
        }
        return string.Empty;
    }

    private string LastDigit()
    {
        for (var i = _line.Length - 1; i >= 0; i--)
        {
            if (char.IsDigit(_line[i])) { return _line[i].ToString(); }

            if (i - 3 < 0) { continue; }

            var value = _line.Substring(i - 2, 3);
            switch (value)
            {
                case "one": return "1";
                case "two": return "2";
                case "six": return "6";
            }

            if (i - 4 < 0) { continue; }

            value = _line.Substring(i - 3, 4);
            switch (value)
            {
                case "four": return "4";
                case "five": return "5";
                case "nine": return "9";
            }

            if (i - 5 < 0) { continue; }

            value = _line.Substring(i - 4, 5);
            switch (value)
            {
                case "three": return "3";
                case "seven": return "7";
                case "eight": return "8";
            }
        }
        return string.Empty;
    }
}