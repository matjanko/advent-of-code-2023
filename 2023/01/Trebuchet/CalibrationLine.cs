namespace Trebuchet;

internal class CalibrationLine
{
    public string Line { get; private set; }

    public CalibrationLine(string line)
    {
        Line = line;
    }

    public int GetCalibrationValue()
    {
        var firstDigit = Line.FirstOrDefault(char.IsDigit).ToString();
        var lastDigit = Line.LastOrDefault(char.IsDigit).ToString();
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
        for (var i = 0; i < Line.Length; i++)
        {
            if (char.IsDigit(Line[i]))
            {
                return Line[i].ToString();
            }

            if (i + 3 > Line.Length)
            {
                continue;
            }

            var value = Line.Substring(i, 3);
            switch (value)
            {
                case "one":
                    return "1";
                case "two":
                    return "2";
                case "six":
                    return "6";
            }

            if (i + 4 > Line.Length)
            {
                continue;
            }

            value = Line.Substring(i, 4);
            switch (value)
            {
                case "four":
                    return "4";
                case "five":
                    return "5";
                case "nine":
                    return "9";
            }

            if (i + 5 > Line.Length)
            {
                continue;
            }

            value = Line.Substring(i, 5);
            switch (value)
            {
                case "three":
                    return "3";
                case "seven":
                    return "7";
                case "eight":
                    return "8";
            }
        }
        return string.Empty;
    }

    private string LastDigit()
    {
        for (var i = Line.Length - 1; i >= 0; i--)
        {
            if (char.IsDigit(Line[i]))
            {
                return Line[i].ToString();
            }

            if (i - 3 < 0)
            {
                continue;
            }

            var value = Line.Substring(i - 2, 3);
            switch (value)
            {
                case "one":
                    return "1";
                case "two":
                    return "2";
                case "six":
                    return "6";
            }

            if (i - 4 < 0)
            {
                continue;
            }

            value = Line.Substring(i - 3, 4);
            switch (value)
            {
                case "four":
                    return "4";
                case "five":
                    return "5";
                case "nine":
                    return "9";
            }

            if (i - 5 < 0)
            {
                continue;
            }

            value = Line.Substring(i - 4, 5);
            switch (value)
            {
                case "three":
                    return "3";
                case "seven":
                    return "7";
                case "eight":
                    return "8";
            }
        }
        return string.Empty;
    }
    // public void ConvertSpelledDigits()
    // {
    //     for (var i = 0; i < Line.Length; i++)
    //     {
    //         if (i + 3 > Line.Length)
    //         {
    //             continue;
    //         }
    //
    //         var a = Line.Substring(i, 3);
    //         Line = a switch
    //         {
    //             "one" => Line.Replace("one", "1"),
    //             "two" => Line.Replace("two", "2"),
    //             "six" => Line.Replace("six", "6"),
    //             _ => Line
    //         };
    //
    //         if (i + 4 > Line.Length)
    //         {
    //             continue;
    //         }
    //
    //         var b = Line.Substring(i, 4);
    //         Line = b switch
    //         {
    //             "four" => Line.Replace("four", "4"),
    //             "five" => Line.Replace("five", "5"),
    //             "nine" => Line.Replace("nine", "9"),
    //             _ => Line
    //         };
    //
    //         if (i + 5 > Line.Length)
    //         {
    //             continue;
    //         }
    //
    //         var c = Line.Substring(i, 5);
    //         Line = c switch
    //         {
    //             "three" => Line.Replace("three", "3"),
    //             "seven" => Line.Replace("seven", "7"),
    //             "eight" => Line.Replace("eight", "8"),
    //             _ => Line
    //         };
    //     }
    // }
}